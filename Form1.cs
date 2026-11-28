using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Cooperativa_Agricola
{
    public partial class Form1 : Form
    {
        // Controlam o registro selecionado em cada aba (0 indica novo registro)
        private int idProdutorSel = 0;
        private int idPropriedadeSel = 0;
        private int idTalhaoPropSel = 0;
        private int numTalhaoSel = 0;
        private int idCargaSel = 0;
        private int idAmostraSel = 0;
        private int idPagamentoSel = 0;

        // Lista com as 10 consultas SQL exigidas na entrega E6
        private List<KeyValuePair<string, string>> consultasE6 = new List<KeyValuePair<string, string>>();

        public Form1()
        {
            InitializeComponent();
            ConfigurarConsultasE6();
            cmbPropTipo.SelectedIndex = 0;
            cmbPagStatus.SelectedIndex = 0;
            AtualizarCamposPropriedade();
            AtualizarCamposAnalise();
            AtualizarCamposPagamento();

            try
            {
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco MariaDB/XAMPP: " + ex.Message,
                    "Erro de Conexao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Atualiza todas as listas e grids da tela
        private void CarregarTudo()
        {
            CarregarCombos();
            CarregarProdutores();
            CarregarPropriedades();
            CarregarTalhoes();
            CarregarCargas();
            CarregarAnalises();
            CarregarPagamentos();
        }

        // Preenche os ComboBoxes usados nas chaves estrangeiras
        private void CarregarCombos()
        {
            DataTable dtProd = Banco.Consultar("SELECT id_produtor, nome FROM produtor ORDER BY nome");
            PreencherCombo(cmbPropProdutor, dtProd.Copy(), "nome", "id_produtor");
            PreencherCombo(cmbPropArrendatario, dtProd.Copy(), "nome", "id_produtor");
            PreencherCombo(cmbPagProdutor, dtProd.Copy(), "nome", "id_produtor");

            DataTable dtProp = Banco.Consultar("SELECT id_propriedade, nome FROM propriedade ORDER BY nome");
            PreencherCombo(cmbTalProp, dtProp, "nome", "id_propriedade");

            DataTable dtSt = Banco.Consultar(
                "SELECT st.id_safra_talhao, CONCAT(s.codigo_safra, ' - ', p.nome, ' (Talhao ', st.numero_talhao, ')') AS descricao " +
                "FROM safra_talhao st " +
                "INNER JOIN safra s ON s.id_safra = st.id_safra " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "ORDER BY s.codigo_safra DESC, p.nome, st.numero_talhao");
            PreencherCombo(cmbCargaSafraTalhao, dtSt, "descricao", "id_safra_talhao");

            DataTable dtCam = Banco.Consultar(
                "SELECT id_caminhao, CONCAT(placa, ' - ', modelo) AS descricao FROM caminhao ORDER BY placa");
            PreencherCombo(cmbCargaCaminhao, dtCam, "descricao", "id_caminhao");

            DataTable dtMot = Banco.Consultar("SELECT id_motorista, nome FROM motorista ORDER BY nome");
            PreencherCombo(cmbCargaMotorista, dtMot, "nome", "id_motorista");

            DataTable dtPreco = Banco.Consultar(
                "SELECT id_preco_ref, CONCAT(DATE_FORMAT(quinzena_inicio, '%d/%m/%Y'), ' a ', DATE_FORMAT(quinzena_fim, '%d/%m/%Y'), ' (R$ ', valor_kg_atr, ')') AS descricao " +
                "FROM preco_referencia ORDER BY quinzena_inicio DESC");
            PreencherCombo(cmbCargaPrecoRef, dtPreco, "descricao", "id_preco_ref");

            // Adiciona opcao nula para carga ainda nao vinculada a pagamento
            DataTable dtPag = Banco.Consultar(
                "SELECT pag.id_pagamento, CONCAT('#', pag.id_pagamento, ' - ', prod.nome, ' (', pag.status, ')') AS descricao " +
                "FROM pagamento pag INNER JOIN produtor prod ON prod.id_produtor = pag.id_produtor " +
                "ORDER BY pag.id_pagamento DESC");
            DataRow linhaNula = dtPag.NewRow();
            linhaNula["id_pagamento"] = 0;
            linhaNula["descricao"] = "(Sem pagamento)";
            dtPag.Rows.InsertAt(linhaNula, 0);
            PreencherCombo(cmbCargaPagamento, dtPag, "descricao", "id_pagamento");

            DataTable dtCargas = Banco.Consultar("SELECT id_carga, numero_ticket FROM carga ORDER BY id_carga DESC");
            PreencherCombo(cmbAnaCarga, dtCargas, "numero_ticket", "id_carga");
        }

        private void PreencherCombo(ComboBox combo, DataTable dados, string display, string value)
        {
            combo.DataSource = dados;
            combo.DisplayMember = display;
            combo.ValueMember = value;
        }

        // Converte texto numerico aceitando virgula ou ponto
        private bool TentarDecimal(string texto, out decimal valor)
        {
            string limpo = texto.Trim().Replace(',', '.');
            return decimal.TryParse(limpo, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }

        // -------------------- ABA 1: PRODUTORES --------------------

        private void CarregarProdutores(string filtro = "")
        {
            string sql =
                "SELECT p.id_produtor, p.nome, p.cpf_cnpj, p.email, p.data_associacao, " +
                "COALESCE(MIN(pt.telefone), '') AS telefone " +
                "FROM produtor p " +
                "LEFT JOIN produtor_telefone pt ON pt.id_produtor = p.id_produtor " +
                "WHERE p.nome LIKE @Busca " +
                "GROUP BY p.id_produtor, p.nome, p.cpf_cnpj, p.email, p.data_associacao " +
                "ORDER BY p.nome";

            dgvProdutores.DataSource = Banco.Consultar(sql, new Dictionary<string, object> {
                { "@Busca", "%" + filtro.Trim() + "%" }
            });
            lblProdTotal.Text = "Total de produtores: " + dgvProdutores.Rows.Count;
        }

        private void LimparProdutor()
        {
            idProdutorSel = 0;
            txtProdNome.Clear();
            txtProdCpfCnpj.Clear();
            txtProdEmail.Clear();
            txtProdTelefone.Clear();
            dtpProdDataAssoc.Value = DateTime.Today;
            txtProdNome.Focus();
        }

        private void btnProdNovo_Click(object sender, EventArgs e)
        {
            LimparProdutor();
        }

        private void btnProdSalvar_Click(object sender, EventArgs e)
        {
            if (txtProdNome.Text.Trim() == "" || txtProdCpfCnpj.Text.Trim() == "")
            {
                MessageBox.Show("Informe o nome e o CPF/CNPJ do produtor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idProdutorSel == 0)
                {
                    int novoId = Banco.ExecutarEObterId(
                        "INSERT INTO produtor (nome, cpf_cnpj, email, data_associacao) VALUES (@Nome, @Cpf, @Email, @Data)",
                        new Dictionary<string, object> {
                            { "@Nome", txtProdNome.Text.Trim() },
                            { "@Cpf", txtProdCpfCnpj.Text.Trim() },
                            { "@Email", txtProdEmail.Text.Trim() == "" ? null : txtProdEmail.Text.Trim() },
                            { "@Data", dtpProdDataAssoc.Value.ToString("yyyy-MM-dd") }
                        });

                    if (txtProdTelefone.Text.Trim() != "")
                    {
                        Banco.ExecutarComando(
                            "INSERT INTO produtor_telefone (id_produtor, telefone) VALUES (@Id, @Tel)",
                            new Dictionary<string, object> {
                                { "@Id", novoId },
                                { "@Tel", txtProdTelefone.Text.Trim() }
                            });
                    }
                    MessageBox.Show("Produtor cadastrado com sucesso!");
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE produtor SET nome = @Nome, cpf_cnpj = @Cpf, email = @Email, data_associacao = @Data WHERE id_produtor = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idProdutorSel },
                            { "@Nome", txtProdNome.Text.Trim() },
                            { "@Cpf", txtProdCpfCnpj.Text.Trim() },
                            { "@Email", txtProdEmail.Text.Trim() == "" ? null : txtProdEmail.Text.Trim() },
                            { "@Data", dtpProdDataAssoc.Value.ToString("yyyy-MM-dd") }
                        });

                    if (txtProdTelefone.Text.Trim() != "")
                    {
                        Banco.ExecutarComando(
                            "INSERT IGNORE INTO produtor_telefone (id_produtor, telefone) VALUES (@Id, @Tel)",
                            new Dictionary<string, object> {
                                { "@Id", idProdutorSel },
                                { "@Tel", txtProdTelefone.Text.Trim() }
                            });
                    }
                    MessageBox.Show("Produtor atualizado com sucesso!");
                }

                LimparProdutor();
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produtor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvProdutores.Rows[e.RowIndex];
            idProdutorSel = Convert.ToInt32(linha.Cells["id_produtor"].Value);
            txtProdNome.Text = linha.Cells["nome"].Value?.ToString();
            txtProdCpfCnpj.Text = linha.Cells["cpf_cnpj"].Value?.ToString();
            txtProdEmail.Text = linha.Cells["email"].Value?.ToString();
            txtProdTelefone.Text = linha.Cells["telefone"].Value?.ToString();
            dtpProdDataAssoc.Value = Convert.ToDateTime(linha.Cells["data_associacao"].Value);
        }

        private void btnProdExcluir_Click(object sender, EventArgs e)
        {
            if (idProdutorSel == 0)
            {
                MessageBox.Show("Selecione um produtor na tabela para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao do produtor \"" + txtProdNome.Text + "\"?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM produtor WHERE id_produtor = @Id",
                        new Dictionary<string, object> { { "@Id", idProdutorSel } });
                    MessageBox.Show("Produtor excluido!");
                    LimparProdutor();
                    CarregarTudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProdBuscar_Click(object sender, EventArgs e)
        {
            CarregarProdutores(txtProdBusca.Text);
        }

        // -------------------- ABA 2: PROPRIEDADES --------------------

        private void AtualizarCamposPropriedade()
        {
            bool arrendada = cmbPropTipo.SelectedItem != null && cmbPropTipo.SelectedItem.ToString() == "ARRENDADA";
            lblPropDoc.Text = arrendada ? "Numero Contrato:" : "Matricula Imovel:";
            cmbPropArrendatario.Enabled = arrendada;
            dtpPropIni.Enabled = arrendada;
            dtpPropFim.Enabled = arrendada;
        }

        private void cmbPropTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCamposPropriedade();
        }

        private void CarregarPropriedades()
        {
            string sql =
                "SELECT p.id_propriedade, p.id_produtor_proprietario, dono.nome AS proprietario, p.nome, " +
                "p.area_total_ha, p.municipio, p.uf, p.estrada_acesso, p.tipo_posse, " +
                "COALESCE(pp.matricula_imovel, pa.num_contrato) AS documento, " +
                "pa.id_produtor_arrendatario, arrend.nome AS arrendatario, pa.data_inicio, pa.data_fim " +
                "FROM propriedade p " +
                "INNER JOIN produtor dono ON dono.id_produtor = p.id_produtor_proprietario " +
                "LEFT JOIN propriedade_propria pp ON pp.id_propriedade = p.id_propriedade " +
                "LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade " +
                "LEFT JOIN produtor arrend ON arrend.id_produtor = pa.id_produtor_arrendatario " +
                "ORDER BY p.nome";

            dgvPropriedades.DataSource = Banco.Consultar(sql);
            if (dgvPropriedades.Columns.Contains("id_produtor_proprietario"))
                dgvPropriedades.Columns["id_produtor_proprietario"].Visible = false;
            if (dgvPropriedades.Columns.Contains("id_produtor_arrendatario"))
                dgvPropriedades.Columns["id_produtor_arrendatario"].Visible = false;
        }

        private void LimparPropriedade()
        {
            idPropriedadeSel = 0;
            txtPropNome.Clear();
            txtPropArea.Clear();
            txtPropMunicipio.Clear();
            txtPropUf.Text = "SP";
            txtPropEstrada.Clear();
            txtPropDoc.Clear();
            cmbPropTipo.SelectedIndex = 0;
            dtpPropIni.Value = DateTime.Today;
            dtpPropFim.Value = DateTime.Today.AddYears(2);
        }

        private void btnPropNovo_Click(object sender, EventArgs e)
        {
            LimparPropriedade();
        }

        private void btnPropSalvar_Click(object sender, EventArgs e)
        {
            decimal area;
            if (txtPropNome.Text.Trim() == "" || !TentarDecimal(txtPropArea.Text, out area) || txtPropDoc.Text.Trim() == "")
            {
                MessageBox.Show("Preencha nome, area valida e matricula/contrato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbPropTipo.SelectedItem.ToString();
            int idDono = Convert.ToInt32(cmbPropProdutor.SelectedValue);

            try
            {
                int idProp = idPropriedadeSel;
                if (idPropriedadeSel == 0)
                {
                    idProp = Banco.ExecutarEObterId(
                        "INSERT INTO propriedade (id_produtor_proprietario, nome, area_total_ha, municipio, uf, estrada_acesso, tipo_posse) " +
                        "VALUES (@Dono, @Nome, @Area, @Mun, @Uf, @Est, @Tipo)",
                        new Dictionary<string, object> {
                            { "@Dono", idDono },
                            { "@Nome", txtPropNome.Text.Trim() },
                            { "@Area", area },
                            { "@Mun", txtPropMunicipio.Text.Trim() },
                            { "@Uf", txtPropUf.Text.Trim().ToUpper() },
                            { "@Est", txtPropEstrada.Text.Trim() },
                            { "@Tipo", tipo }
                        });
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE propriedade SET id_produtor_proprietario = @Dono, nome = @Nome, area_total_ha = @Area, " +
                        "municipio = @Mun, uf = @Uf, estrada_acesso = @Est, tipo_posse = @Tipo WHERE id_propriedade = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idPropriedadeSel },
                            { "@Dono", idDono },
                            { "@Nome", txtPropNome.Text.Trim() },
                            { "@Area", area },
                            { "@Mun", txtPropMunicipio.Text.Trim() },
                            { "@Uf", txtPropUf.Text.Trim().ToUpper() },
                            { "@Est", txtPropEstrada.Text.Trim() },
                            { "@Tipo", tipo }
                        });

                    // Remove registro antigo da subclasse para manter especializacao exclusiva
                    Banco.ExecutarComando("DELETE FROM propriedade_propria WHERE id_propriedade = @Id",
                        new Dictionary<string, object> { { "@Id", idProp } });
                    Banco.ExecutarComando("DELETE FROM propriedade_arrendada WHERE id_propriedade = @Id",
                        new Dictionary<string, object> { { "@Id", idProp } });
                }

                if (tipo == "PROPRIA")
                {
                    Banco.ExecutarComando(
                        "INSERT INTO propriedade_propria (id_propriedade, matricula_imovel) VALUES (@Id, @Mat)",
                        new Dictionary<string, object> {
                            { "@Id", idProp },
                            { "@Mat", txtPropDoc.Text.Trim() }
                        });
                }
                else
                {
                    Banco.ExecutarComando(
                        "INSERT INTO propriedade_arrendada (id_propriedade, num_contrato, data_inicio, data_fim, id_produtor_arrendatario) " +
                        "VALUES (@Id, @Ctr, @Ini, @Fim, @Arr)",
                        new Dictionary<string, object> {
                            { "@Id", idProp },
                            { "@Ctr", txtPropDoc.Text.Trim() },
                            { "@Ini", dtpPropIni.Value.ToString("yyyy-MM-dd") },
                            { "@Fim", dtpPropFim.Value.ToString("yyyy-MM-dd") },
                            { "@Arr", Convert.ToInt32(cmbPropArrendatario.SelectedValue) }
                        });
                }

                MessageBox.Show("Propriedade salva com sucesso!");
                LimparPropriedade();
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar propriedade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPropriedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvPropriedades.Rows[e.RowIndex];
            idPropriedadeSel = Convert.ToInt32(linha.Cells["id_propriedade"].Value);
            cmbPropProdutor.SelectedValue = Convert.ToInt32(linha.Cells["id_produtor_proprietario"].Value);
            txtPropNome.Text = linha.Cells["nome"].Value?.ToString();
            txtPropArea.Text = linha.Cells["area_total_ha"].Value?.ToString();
            txtPropMunicipio.Text = linha.Cells["municipio"].Value?.ToString();
            txtPropUf.Text = linha.Cells["uf"].Value?.ToString();
            txtPropEstrada.Text = linha.Cells["estrada_acesso"].Value?.ToString();
            cmbPropTipo.SelectedItem = linha.Cells["tipo_posse"].Value?.ToString();
            txtPropDoc.Text = linha.Cells["documento"].Value?.ToString();

            if (linha.Cells["id_produtor_arrendatario"].Value != DBNull.Value)
            {
                cmbPropArrendatario.SelectedValue = Convert.ToInt32(linha.Cells["id_produtor_arrendatario"].Value);
                dtpPropIni.Value = Convert.ToDateTime(linha.Cells["data_inicio"].Value);
                dtpPropFim.Value = Convert.ToDateTime(linha.Cells["data_fim"].Value);
            }
        }

        private void btnPropExcluir_Click(object sender, EventArgs e)
        {
            if (idPropriedadeSel == 0)
            {
                MessageBox.Show("Selecione uma propriedade para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao da propriedade \"" + txtPropNome.Text + "\"?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM propriedade WHERE id_propriedade = @Id",
                        new Dictionary<string, object> { { "@Id", idPropriedadeSel } });
                    MessageBox.Show("Propriedade excluida!");
                    LimparPropriedade();
                    CarregarTudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------- ABA 3: TALHOES (ENTIDADE FRACA) --------------------

        private void CarregarTalhoes()
        {
            string sql =
                "SELECT t.id_propriedade, p.nome AS propriedade, t.numero_talhao, t.area_ha, t.tipo_solo " +
                "FROM talhao t INNER JOIN propriedade p ON p.id_propriedade = t.id_propriedade " +
                "ORDER BY p.nome, t.numero_talhao";
            dgvTalhoes.DataSource = Banco.Consultar(sql);
        }

        private void LimparTalhao()
        {
            idTalhaoPropSel = 0;
            numTalhaoSel = 0;
            cmbTalProp.Enabled = true;
            txtTalNumero.Enabled = true;
            txtTalNumero.Clear();
            txtTalArea.Clear();
            txtTalSolo.Clear();
        }

        private void btnTalNovo_Click(object sender, EventArgs e)
        {
            LimparTalhao();
        }

        private void btnTalSalvar_Click(object sender, EventArgs e)
        {
            int num;
            decimal area;
            if (!int.TryParse(txtTalNumero.Text.Trim(), out num) || !TentarDecimal(txtTalArea.Text, out area) || txtTalSolo.Text.Trim() == "")
            {
                MessageBox.Show("Informe numero inteiro, area valida e tipo de solo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProp = Convert.ToInt32(cmbTalProp.SelectedValue);
                if (idTalhaoPropSel == 0)
                {
                    Banco.ExecutarComando(
                        "INSERT INTO talhao (id_propriedade, numero_talhao, area_ha, tipo_solo) VALUES (@Prop, @Num, @Area, @Solo)",
                        new Dictionary<string, object> {
                            { "@Prop", idProp },
                            { "@Num", num },
                            { "@Area", area },
                            { "@Solo", txtTalSolo.Text.Trim() }
                        });
                    MessageBox.Show("Talhao cadastrado com sucesso!");
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE talhao SET area_ha = @Area, tipo_solo = @Solo WHERE id_propriedade = @Prop AND numero_talhao = @Num",
                        new Dictionary<string, object> {
                            { "@Prop", idTalhaoPropSel },
                            { "@Num", numTalhaoSel },
                            { "@Area", area },
                            { "@Solo", txtTalSolo.Text.Trim() }
                        });
                    MessageBox.Show("Talhao atualizado com sucesso!");
                }

                LimparTalhao();
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar talhao: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTalhoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvTalhoes.Rows[e.RowIndex];
            idTalhaoPropSel = Convert.ToInt32(linha.Cells["id_propriedade"].Value);
            numTalhaoSel = Convert.ToInt32(linha.Cells["numero_talhao"].Value);
            cmbTalProp.SelectedValue = idTalhaoPropSel;
            txtTalNumero.Text = numTalhaoSel.ToString();
            txtTalArea.Text = linha.Cells["area_ha"].Value?.ToString();
            txtTalSolo.Text = linha.Cells["tipo_solo"].Value?.ToString();
            // Bloqueia chave primaria composta durante edicao
            cmbTalProp.Enabled = false;
            txtTalNumero.Enabled = false;
        }

        private void btnTalExcluir_Click(object sender, EventArgs e)
        {
            if (idTalhaoPropSel == 0)
            {
                MessageBox.Show("Selecione um talhao para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao do talhao " + numTalhaoSel + "?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM talhao WHERE id_propriedade = @Prop AND numero_talhao = @Num",
                        new Dictionary<string, object> {
                            { "@Prop", idTalhaoPropSel },
                            { "@Num", numTalhaoSel }
                        });
                    MessageBox.Show("Talhao excluido!");
                    LimparTalhao();
                    CarregarTudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------- ABA 4: CARGAS E PESAGEM --------------------

        private void CarregarCargas()
        {
            string sql =
                "SELECT c.id_carga, c.numero_ticket, c.data_entrada, p.nome AS propriedade, st.numero_talhao, " +
                "s.codigo_safra AS safra, cam.placa, m.nome AS motorista, " +
                "pes.peso_bruto_kg, pes.peso_tara_kg, (pes.peso_bruto_kg - pes.peso_tara_kg) AS peso_liquido_kg, " +
                "pes.balanca, pr.valor_kg_atr, c.id_safra_talhao, c.id_caminhao, c.id_motorista, c.id_preco_ref, c.id_pagamento " +
                "FROM carga c " +
                "INNER JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN safra s ON s.id_safra = st.id_safra " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "INNER JOIN caminhao cam ON cam.id_caminhao = c.id_caminhao " +
                "INNER JOIN motorista m ON m.id_motorista = c.id_motorista " +
                "INNER JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref " +
                "ORDER BY c.data_entrada DESC";

            dgvCargas.DataSource = Banco.Consultar(sql);
            string[] ocultar = { "id_safra_talhao", "id_caminhao", "id_motorista", "id_preco_ref" };
            foreach (string col in ocultar)
            {
                if (dgvCargas.Columns.Contains(col)) dgvCargas.Columns[col].Visible = false;
            }
        }

        private void LimparCarga()
        {
            idCargaSel = 0;
            txtCargaTicket.Clear();
            dtpCargaData.Value = DateTime.Now;
            txtPesBruto.Clear();
            txtPesTara.Clear();
            txtPesBalanca.Text = "Balanca 01";
            if (cmbCargaPagamento.Items.Count > 0) cmbCargaPagamento.SelectedIndex = 0;
        }

        private void btnCargaNovo_Click(object sender, EventArgs e)
        {
            LimparCarga();
        }

        private void btnCargaSalvar_Click(object sender, EventArgs e)
        {
            decimal bruto, tara;
            if (txtCargaTicket.Text.Trim() == "" || !TentarDecimal(txtPesBruto.Text, out bruto) || !TentarDecimal(txtPesTara.Text, out tara))
            {
                MessageBox.Show("Informe ticket, peso bruto e peso tara validos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPagVal = Convert.ToInt32(cmbCargaPagamento.SelectedValue);
            object idPagParam = (idPagVal == 0) ? (object)DBNull.Value : idPagVal;
            string dtEntrada = dtpCargaData.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string dtSaida = dtpCargaData.Value.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                if (idCargaSel == 0)
                {
                    int novoId = Banco.ExecutarEObterId(
                        "INSERT INTO carga (numero_ticket, data_entrada, id_safra_talhao, id_caminhao, id_motorista, id_preco_ref, id_pagamento) " +
                        "VALUES (@Ticket, @Data, @St, @Cam, @Mot, @Preco, @Pag)",
                        new Dictionary<string, object> {
                            { "@Ticket", txtCargaTicket.Text.Trim() },
                            { "@Data", dtEntrada },
                            { "@St", Convert.ToInt32(cmbCargaSafraTalhao.SelectedValue) },
                            { "@Cam", Convert.ToInt32(cmbCargaCaminhao.SelectedValue) },
                            { "@Mot", Convert.ToInt32(cmbCargaMotorista.SelectedValue) },
                            { "@Preco", Convert.ToInt32(cmbCargaPrecoRef.SelectedValue) },
                            { "@Pag", idPagParam }
                        });

                    Banco.ExecutarComando(
                        "INSERT INTO pesagem (id_carga, data_hora_entrada, data_hora_saida, peso_bruto_kg, peso_tara_kg, balanca) " +
                        "VALUES (@Id, @Ent, @Sai, @Bruto, @Tara, @Bal)",
                        new Dictionary<string, object> {
                            { "@Id", novoId },
                            { "@Ent", dtEntrada },
                            { "@Sai", dtSaida },
                            { "@Bruto", bruto },
                            { "@Tara", tara },
                            { "@Bal", txtPesBalanca.Text.Trim() == "" ? "Balanca 01" : txtPesBalanca.Text.Trim() }
                        });
                    MessageBox.Show("Carga e pesagem registradas com sucesso!");
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE carga SET numero_ticket = @Ticket, data_entrada = @Data, id_safra_talhao = @St, " +
                        "id_caminhao = @Cam, id_motorista = @Mot, id_preco_ref = @Preco, id_pagamento = @Pag WHERE id_carga = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idCargaSel },
                            { "@Ticket", txtCargaTicket.Text.Trim() },
                            { "@Data", dtEntrada },
                            { "@St", Convert.ToInt32(cmbCargaSafraTalhao.SelectedValue) },
                            { "@Cam", Convert.ToInt32(cmbCargaCaminhao.SelectedValue) },
                            { "@Mot", Convert.ToInt32(cmbCargaMotorista.SelectedValue) },
                            { "@Preco", Convert.ToInt32(cmbCargaPrecoRef.SelectedValue) },
                            { "@Pag", idPagParam }
                        });

                    Banco.ExecutarComando(
                        "UPDATE pesagem SET peso_bruto_kg = @Bruto, peso_tara_kg = @Tara, balanca = @Bal WHERE id_carga = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idCargaSel },
                            { "@Bruto", bruto },
                            { "@Tara", tara },
                            { "@Bal", txtPesBalanca.Text.Trim() == "" ? "Balanca 01" : txtPesBalanca.Text.Trim() }
                        });
                    MessageBox.Show("Carga e pesagem atualizadas com sucesso!");
                }

                LimparCarga();
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar carga/pesagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCargas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvCargas.Rows[e.RowIndex];
            idCargaSel = Convert.ToInt32(linha.Cells["id_carga"].Value);
            txtCargaTicket.Text = linha.Cells["numero_ticket"].Value?.ToString();
            dtpCargaData.Value = Convert.ToDateTime(linha.Cells["data_entrada"].Value);
            cmbCargaSafraTalhao.SelectedValue = Convert.ToInt32(linha.Cells["id_safra_talhao"].Value);
            cmbCargaCaminhao.SelectedValue = Convert.ToInt32(linha.Cells["id_caminhao"].Value);
            cmbCargaMotorista.SelectedValue = Convert.ToInt32(linha.Cells["id_motorista"].Value);
            cmbCargaPrecoRef.SelectedValue = Convert.ToInt32(linha.Cells["id_preco_ref"].Value);
            cmbCargaPagamento.SelectedValue = linha.Cells["id_pagamento"].Value == DBNull.Value ? 0 : Convert.ToInt32(linha.Cells["id_pagamento"].Value);
            txtPesBruto.Text = linha.Cells["peso_bruto_kg"].Value?.ToString();
            txtPesTara.Text = linha.Cells["peso_tara_kg"].Value?.ToString();
            txtPesBalanca.Text = linha.Cells["balanca"].Value?.ToString();
        }

        private void btnCargaExcluir_Click(object sender, EventArgs e)
        {
            if (idCargaSel == 0)
            {
                MessageBox.Show("Selecione uma carga para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao da carga \"" + txtCargaTicket.Text + "\"?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM carga WHERE id_carga = @Id",
                        new Dictionary<string, object> { { "@Id", idCargaSel } });
                    MessageBox.Show("Carga excluida!");
                    LimparCarga();
                    CarregarTudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------- ABA 5: AMOSTRAS E ANALISES --------------------

        private void AtualizarCamposAnalise()
        {
            bool ativa = chkRegistrarAnalise.Checked;
            txtAnaBrix.Enabled = ativa;
            txtAnaPol.Enabled = ativa;
            txtAnaImpureza.Enabled = ativa;
            txtAnaAtr.Enabled = ativa;
            txtAnaTecnico.Enabled = ativa;
        }

        private void chkRegistrarAnalise_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarCamposAnalise();
        }

        private void CarregarAnalises()
        {
            string sql =
                "SELECT am.id_amostra, am.id_carga, c.numero_ticket, am.codigo_etiqueta, am.peso_amostra_kg, am.coletor, " +
                "an.id_analise, an.brix, an.pol, an.impureza_pct, an.atr_kg_ton, an.tecnico_lab " +
                "FROM amostra am " +
                "INNER JOIN carga c ON c.id_carga = am.id_carga " +
                "LEFT JOIN analise an ON an.id_amostra = am.id_amostra " +
                "ORDER BY am.id_amostra DESC";
            dgvAnalises.DataSource = Banco.Consultar(sql);
            if (dgvAnalises.Columns.Contains("id_carga")) dgvAnalises.Columns["id_carga"].Visible = false;
        }

        private void LimparAnalise()
        {
            idAmostraSel = 0;
            cmbAnaCarga.Enabled = true;
            txtAnaEtiqueta.Clear();
            txtAnaPesoAmostra.Clear();
            txtAnaColetor.Clear();
            chkRegistrarAnalise.Checked = false;
            txtAnaBrix.Clear();
            txtAnaPol.Clear();
            txtAnaImpureza.Clear();
            txtAnaAtr.Clear();
            txtAnaTecnico.Clear();
        }

        private void btnAnaNovo_Click(object sender, EventArgs e)
        {
            LimparAnalise();
        }

        private void btnAnaSalvar_Click(object sender, EventArgs e)
        {
            decimal pesoAm;
            if (txtAnaEtiqueta.Text.Trim() == "" || !TentarDecimal(txtAnaPesoAmostra.Text, out pesoAm) || txtAnaColetor.Text.Trim() == "")
            {
                MessageBox.Show("Preencha etiqueta, peso da amostra e coletor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idAm = idAmostraSel;
                if (idAmostraSel == 0)
                {
                    idAm = Banco.ExecutarEObterId(
                        "INSERT INTO amostra (id_carga, codigo_etiqueta, data_hora_coleta, peso_amostra_kg, coletor) " +
                        "VALUES (@Carga, @Etiq, NOW(), @Peso, @Col)",
                        new Dictionary<string, object> {
                            { "@Carga", Convert.ToInt32(cmbAnaCarga.SelectedValue) },
                            { "@Etiq", txtAnaEtiqueta.Text.Trim() },
                            { "@Peso", pesoAm },
                            { "@Col", txtAnaColetor.Text.Trim() }
                        });
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE amostra SET codigo_etiqueta = @Etiq, peso_amostra_kg = @Peso, coletor = @Col WHERE id_amostra = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idAmostraSel },
                            { "@Etiq", txtAnaEtiqueta.Text.Trim() },
                            { "@Peso", pesoAm },
                            { "@Col", txtAnaColetor.Text.Trim() }
                        });
                }

                // Se marcada a opcao de analise, insere ou atualiza o resultado laboratorial
                if (chkRegistrarAnalise.Checked)
                {
                    decimal brix, pol, imp, atr;
                    if (!TentarDecimal(txtAnaBrix.Text, out brix) || !TentarDecimal(txtAnaPol.Text, out pol) ||
                        !TentarDecimal(txtAnaImpureza.Text, out imp) || !TentarDecimal(txtAnaAtr.Text, out atr) ||
                        txtAnaTecnico.Text.Trim() == "")
                    {
                        MessageBox.Show("Preencha Brix, Pol, Impureza, ATR e Tecnico corretamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataTable existe = Banco.Consultar("SELECT id_analise FROM analise WHERE id_amostra = @Am",
                        new Dictionary<string, object> { { "@Am", idAm } });

                    if (existe.Rows.Count == 0)
                    {
                        Banco.ExecutarComando(
                            "INSERT INTO analise (id_amostra, data_hora_analise, brix, pol, impureza_pct, atr_kg_ton, tecnico_lab) " +
                            "VALUES (@Am, NOW(), @Brix, @Pol, @Imp, @Atr, @Tec)",
                            new Dictionary<string, object> {
                                { "@Am", idAm }, { "@Brix", brix }, { "@Pol", pol },
                                { "@Imp", imp }, { "@Atr", atr }, { "@Tec", txtAnaTecnico.Text.Trim() }
                            });
                    }
                    else
                    {
                        Banco.ExecutarComando(
                            "UPDATE analise SET brix = @Brix, pol = @Pol, impureza_pct = @Imp, atr_kg_ton = @Atr, tecnico_lab = @Tec WHERE id_amostra = @Am",
                            new Dictionary<string, object> {
                                { "@Am", idAm }, { "@Brix", brix }, { "@Pol", pol },
                                { "@Imp", imp }, { "@Atr", atr }, { "@Tec", txtAnaTecnico.Text.Trim() }
                            });
                    }
                }

                MessageBox.Show("Amostra/Analise salva com sucesso!");
                LimparAnalise();
                CarregarAnalises();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar amostra/analise: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAnalises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvAnalises.Rows[e.RowIndex];
            idAmostraSel = Convert.ToInt32(linha.Cells["id_amostra"].Value);
            cmbAnaCarga.SelectedValue = Convert.ToInt32(linha.Cells["id_carga"].Value);
            cmbAnaCarga.Enabled = false;
            txtAnaEtiqueta.Text = linha.Cells["codigo_etiqueta"].Value?.ToString();
            txtAnaPesoAmostra.Text = linha.Cells["peso_amostra_kg"].Value?.ToString();
            txtAnaColetor.Text = linha.Cells["coletor"].Value?.ToString();

            bool temAnalise = linha.Cells["id_analise"].Value != DBNull.Value;
            chkRegistrarAnalise.Checked = temAnalise;
            txtAnaBrix.Text = temAnalise ? linha.Cells["brix"].Value?.ToString() : "";
            txtAnaPol.Text = temAnalise ? linha.Cells["pol"].Value?.ToString() : "";
            txtAnaImpureza.Text = temAnalise ? linha.Cells["impureza_pct"].Value?.ToString() : "";
            txtAnaAtr.Text = temAnalise ? linha.Cells["atr_kg_ton"].Value?.ToString() : "";
            txtAnaTecnico.Text = temAnalise ? linha.Cells["tecnico_lab"].Value?.ToString() : "";
        }

        private void btnAnaExcluir_Click(object sender, EventArgs e)
        {
            if (idAmostraSel == 0)
            {
                MessageBox.Show("Selecione uma amostra para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao da amostra \"" + txtAnaEtiqueta.Text + "\" (e sua analise, se houver)?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM amostra WHERE id_amostra = @Id",
                        new Dictionary<string, object> { { "@Id", idAmostraSel } });
                    MessageBox.Show("Amostra excluida!");
                    LimparAnalise();
                    CarregarAnalises();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------- ABA 6: PAGAMENTOS --------------------

        private void AtualizarCamposPagamento()
        {
            bool pago = cmbPagStatus.SelectedItem != null && cmbPagStatus.SelectedItem.ToString() == "PAGO";
            dtpPagData.Enabled = pago;
        }

        private void cmbPagStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCamposPagamento();
        }

        private void CarregarPagamentos()
        {
            string sql =
                "SELECT pag.id_pagamento, pag.id_produtor, prod.nome AS beneficiario, pag.data_inicio_periodo, " +
                "pag.data_fim_periodo, pag.status, pag.data_pagamento, COUNT(c.id_carga) AS qtd_cargas, " +
                "ROUND(COALESCE(SUM(((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000) * COALESCE(an.atr_kg_ton, 140.00) * pr.valor_kg_atr), 0), 2) AS total_calculado_rs " +
                "FROM pagamento pag " +
                "INNER JOIN produtor prod ON prod.id_produtor = pag.id_produtor " +
                "LEFT JOIN carga c ON c.id_pagamento = pag.id_pagamento " +
                "LEFT JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "LEFT JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref " +
                "LEFT JOIN amostra am ON am.id_carga = c.id_carga " +
                "LEFT JOIN analise an ON an.id_amostra = am.id_amostra " +
                "GROUP BY pag.id_pagamento, pag.id_produtor, prod.nome, pag.data_inicio_periodo, pag.data_fim_periodo, pag.status, pag.data_pagamento " +
                "ORDER BY pag.id_pagamento DESC";

            dgvPagamentos.DataSource = Banco.Consultar(sql);
            if (dgvPagamentos.Columns.Contains("id_produtor")) dgvPagamentos.Columns["id_produtor"].Visible = false;
        }

        private void LimparPagamento()
        {
            idPagamentoSel = 0;
            dtpPagInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpPagFim.Value = DateTime.Today;
            cmbPagStatus.SelectedItem = "PENDENTE";
            dtpPagData.Value = DateTime.Today;
        }

        private void btnPagNovo_Click(object sender, EventArgs e)
        {
            LimparPagamento();
        }

        private void btnPagSalvar_Click(object sender, EventArgs e)
        {
            string status = cmbPagStatus.SelectedItem.ToString();
            object dataPag = status == "PAGO" ? (object)dtpPagData.Value.ToString("yyyy-MM-dd") : DBNull.Value;

            try
            {
                if (idPagamentoSel == 0)
                {
                    Banco.ExecutarComando(
                        "INSERT INTO pagamento (id_produtor, data_inicio_periodo, data_fim_periodo, status, data_pagamento) " +
                        "VALUES (@Prod, @Ini, @Fim, @Status, @DataPag)",
                        new Dictionary<string, object> {
                            { "@Prod", Convert.ToInt32(cmbPagProdutor.SelectedValue) },
                            { "@Ini", dtpPagInicio.Value.ToString("yyyy-MM-dd") },
                            { "@Fim", dtpPagFim.Value.ToString("yyyy-MM-dd") },
                            { "@Status", status },
                            { "@DataPag", dataPag }
                        });
                    MessageBox.Show("Pagamento cadastrado com sucesso!");
                }
                else
                {
                    Banco.ExecutarComando(
                        "UPDATE pagamento SET id_produtor = @Prod, data_inicio_periodo = @Ini, data_fim_periodo = @Fim, " +
                        "status = @Status, data_pagamento = @DataPag WHERE id_pagamento = @Id",
                        new Dictionary<string, object> {
                            { "@Id", idPagamentoSel },
                            { "@Prod", Convert.ToInt32(cmbPagProdutor.SelectedValue) },
                            { "@Ini", dtpPagInicio.Value.ToString("yyyy-MM-dd") },
                            { "@Fim", dtpPagFim.Value.ToString("yyyy-MM-dd") },
                            { "@Status", status },
                            { "@DataPag", dataPag }
                        });
                    MessageBox.Show("Pagamento atualizado com sucesso!");
                }

                LimparPagamento();
                CarregarTudo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dgvPagamentos.Rows[e.RowIndex];
            idPagamentoSel = Convert.ToInt32(linha.Cells["id_pagamento"].Value);
            cmbPagProdutor.SelectedValue = Convert.ToInt32(linha.Cells["id_produtor"].Value);
            dtpPagInicio.Value = Convert.ToDateTime(linha.Cells["data_inicio_periodo"].Value);
            dtpPagFim.Value = Convert.ToDateTime(linha.Cells["data_fim_periodo"].Value);
            cmbPagStatus.SelectedItem = linha.Cells["status"].Value?.ToString();
            if (linha.Cells["data_pagamento"].Value != DBNull.Value)
                dtpPagData.Value = Convert.ToDateTime(linha.Cells["data_pagamento"].Value);
        }

        private void btnPagExcluir_Click(object sender, EventArgs e)
        {
            if (idPagamentoSel == 0)
            {
                MessageBox.Show("Selecione um pagamento para excluir.");
                return;
            }

            DialogResult resp = MessageBox.Show("Confirma a exclusao do pagamento #" + idPagamentoSel + "?",
                "Confirmacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    Banco.ExecutarComando("DELETE FROM pagamento WHERE id_pagamento = @Id",
                        new Dictionary<string, object> { { "@Id", idPagamentoSel } });
                    MessageBox.Show("Pagamento excluido!");
                    LimparPagamento();
                    CarregarTudo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------- ABA 7: CONSULTAS SQL (E6) --------------------

        private void ConfigurarConsultasE6()
        {
            consultasE6.Add(new KeyValuePair<string, string>(
                "1. [Enunciado] Qual a qualidade media medida por produtor na safra?",
                "SELECT s.codigo_safra AS safra, prod.nome AS produtor, COUNT(an.id_analise) AS cargas_analisadas, " +
                "ROUND(AVG(an.atr_kg_ton), 2) AS media_atr, ROUND(AVG(an.brix), 2) AS media_brix, " +
                "ROUND(AVG(an.pol), 2) AS media_pol, ROUND(AVG(an.impureza_pct), 2) AS media_impureza_pct " +
                "FROM analise an " +
                "INNER JOIN amostra am ON am.id_amostra = an.id_amostra " +
                "INNER JOIN carga c ON c.id_carga = am.id_carga " +
                "INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN safra s ON s.id_safra = st.id_safra " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade " +
                "INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario) " +
                "GROUP BY s.codigo_safra, prod.id_produtor, prod.nome ORDER BY s.codigo_safra DESC, media_atr DESC;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "2. [Enunciado] Quais cargas entraram sem analise de qualidade?",
                "SELECT c.numero_ticket, c.data_entrada, s.codigo_safra AS safra, p.nome AS propriedade, st.numero_talhao, " +
                "CASE WHEN am.id_amostra IS NULL THEN 'Sem amostra' ELSE 'Amostra aguardando analise' END AS situacao " +
                "FROM carga c " +
                "INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN safra s ON s.id_safra = st.id_safra " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "LEFT JOIN amostra am ON am.id_carga = c.id_carga " +
                "LEFT JOIN analise an ON an.id_amostra = am.id_amostra " +
                "WHERE an.id_analise IS NULL ORDER BY c.data_entrada;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "3. [Enunciado] Quantas toneladas vieram de cada propriedade e de cada talhao?",
                "SELECT p.nome AS propriedade, t.numero_talhao, COUNT(c.id_carga) AS qtd_cargas, " +
                "ROUND(COALESCE(SUM(pes.peso_bruto_kg - pes.peso_tara_kg), 0) / 1000, 2) AS total_toneladas " +
                "FROM talhao t INNER JOIN propriedade p ON p.id_propriedade = t.id_propriedade " +
                "LEFT JOIN safra_talhao st ON st.id_propriedade = t.id_propriedade AND st.numero_talhao = t.numero_talhao " +
                "LEFT JOIN carga c ON c.id_safra_talhao = st.id_safra_talhao " +
                "LEFT JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "GROUP BY p.id_propriedade, p.nome, t.numero_talhao ORDER BY total_toneladas DESC, p.nome, t.numero_talhao;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "4. [Enunciado] Quais produtores tem pagamento pendente no periodo (ago-set/2026)?",
                "SELECT pag.id_pagamento, prod.nome AS produtor_beneficiario, pag.data_inicio_periodo, pag.data_fim_periodo, pag.status, " +
                "COUNT(c.id_carga) AS qtd_cargas, ROUND(COALESCE(SUM((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000), 0), 2) AS toneladas_totais, " +
                "ROUND(COALESCE(SUM(((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000) * COALESCE(an.atr_kg_ton, 140.00) * pr.valor_kg_atr), 0), 2) AS valor_estimado_rs " +
                "FROM pagamento pag INNER JOIN produtor prod ON prod.id_produtor = pag.id_produtor " +
                "LEFT JOIN carga c ON c.id_pagamento = pag.id_pagamento " +
                "LEFT JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "LEFT JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref " +
                "LEFT JOIN amostra am ON am.id_carga = c.id_carga " +
                "LEFT JOIN analise an ON an.id_amostra = am.id_amostra " +
                "WHERE pag.status = 'PENDENTE' AND pag.data_inicio_periodo >= '2026-08-01' AND pag.data_fim_periodo <= '2026-09-30' " +
                "GROUP BY pag.id_pagamento, prod.nome, pag.data_inicio_periodo, pag.data_fim_periodo, pag.status ORDER BY pag.data_inicio_periodo, prod.nome;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "5. [Enunciado] Qual transportadora movimentou mais volume no mes (agosto/2026)?",
                "SELECT tr.razao_social AS transportadora, COUNT(c.id_carga) AS qtd_cargas, " +
                "ROUND(SUM(pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas_movimentadas " +
                "FROM carga c INNER JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "INNER JOIN caminhao cam ON cam.id_caminhao = c.id_caminhao " +
                "INNER JOIN transportadora tr ON tr.id_transportadora = cam.id_transportadora " +
                "WHERE c.data_entrada >= '2026-08-01 00:00:00' AND c.data_entrada < '2026-09-01 00:00:00' " +
                "GROUP BY tr.id_transportadora, tr.razao_social ORDER BY toneladas_movimentadas DESC;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "6. [Grupo] Calculo rastreavel do valor de cada carga analisada com preco da quinzena",
                "SELECT c.numero_ticket, DATE(c.data_entrada) AS data_entrada, prod.nome AS produtor_beneficiario, " +
                "ROUND((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas, an.atr_kg_ton, pr.quinzena_inicio, pr.valor_kg_atr, " +
                "ROUND(((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000) * an.atr_kg_ton * pr.valor_kg_atr, 2) AS valor_calculado_rs " +
                "FROM carga c INNER JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "INNER JOIN amostra am ON am.id_carga = c.id_carga " +
                "INNER JOIN analise an ON an.id_amostra = am.id_amostra " +
                "INNER JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref " +
                "INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade " +
                "INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario) " +
                "ORDER BY c.data_entrada;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "7. [Grupo] Propriedades arrendadas, dono da terra e arrendatario beneficiario",
                "SELECT p.nome AS propriedade, p.municipio, pa.num_contrato, pa.data_inicio, pa.data_fim, " +
                "dono.nome AS proprietario_terra, arrend.nome AS arrendatario_beneficiario " +
                "FROM propriedade p INNER JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade " +
                "INNER JOIN produtor dono ON dono.id_produtor = p.id_produtor_proprietario " +
                "INNER JOIN produtor arrend ON arrend.id_produtor = pa.id_produtor_arrendatario ORDER BY p.nome;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "8. [Grupo] Produtores associados que ainda nao possuem nenhuma carga entregue",
                "SELECT prod.id_produtor, prod.nome, prod.cpf_cnpj, prod.data_associacao FROM produtor prod " +
                "LEFT JOIN (SELECT DISTINCT COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario) AS id_produtor " +
                "FROM carga c INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade) entregas " +
                "ON entregas.id_produtor = prod.id_produtor WHERE entregas.id_produtor IS NULL ORDER BY prod.nome;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "9. [Grupo] Volume entregue e media de ATR por variedade de cana na safra 2026/2027",
                "SELECT st.variedade_cana, COUNT(c.id_carga) AS qtd_cargas, " +
                "ROUND(SUM(pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS total_toneladas, " +
                "ROUND(AVG(an.atr_kg_ton), 2) AS media_atr " +
                "FROM safra_talhao st INNER JOIN safra s ON s.id_safra = st.id_safra " +
                "INNER JOIN carga c ON c.id_safra_talhao = st.id_safra_talhao " +
                "INNER JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "LEFT JOIN amostra am ON am.id_carga = c.id_carga " +
                "LEFT JOIN analise an ON an.id_amostra = am.id_amostra " +
                "WHERE s.codigo_safra = '2026/2027' GROUP BY st.variedade_cana ORDER BY total_toneladas DESC;"));

            consultasE6.Add(new KeyValuePair<string, string>(
                "10. [Grupo] Cargas recebidas ainda nao vinculadas a nenhum pagamento",
                "SELECT c.numero_ticket, c.data_entrada, p.nome AS propriedade, st.numero_talhao, " +
                "prod.nome AS produtor_beneficiario, ROUND((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas " +
                "FROM carga c INNER JOIN pesagem pes ON pes.id_carga = c.id_carga " +
                "INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao " +
                "INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade " +
                "LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade " +
                "INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario) " +
                "WHERE c.id_pagamento IS NULL ORDER BY c.data_entrada;"));

            cmbConsulta.Items.Clear();
            foreach (var item in consultasE6)
                cmbConsulta.Items.Add(item.Key);
            cmbConsulta.SelectedIndex = 0;
        }

        private void btnExecutarConsulta_Click(object sender, EventArgs e)
        {
            if (cmbConsulta.SelectedIndex < 0) return;

            try
            {
                string sql = consultasE6[cmbConsulta.SelectedIndex].Value;
                txtSqlConsulta.Text = sql;
                DataTable resultado = Banco.Consultar(sql);
                dgvConsultas.DataSource = resultado;
                lblConsultaTotal.Text = "Registros retornados: " + resultado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
