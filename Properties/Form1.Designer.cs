namespace Cooperativa_Agricola
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabProdutores = new System.Windows.Forms.TabPage();
            this.tabPropriedades = new System.Windows.Forms.TabPage();
            this.tabTalhoes = new System.Windows.Forms.TabPage();
            this.tabCargas = new System.Windows.Forms.TabPage();
            this.tabAnalises = new System.Windows.Forms.TabPage();
            this.tabPagamentos = new System.Windows.Forms.TabPage();
            this.tabConsultas = new System.Windows.Forms.TabPage();

            // Controles da aba Produtores
            this.lblProdNome = new System.Windows.Forms.Label();
            this.txtProdNome = new System.Windows.Forms.TextBox();
            this.lblProdCpfCnpj = new System.Windows.Forms.Label();
            this.txtProdCpfCnpj = new System.Windows.Forms.TextBox();
            this.lblProdEmail = new System.Windows.Forms.Label();
            this.txtProdEmail = new System.Windows.Forms.TextBox();
            this.lblProdData = new System.Windows.Forms.Label();
            this.dtpProdDataAssoc = new System.Windows.Forms.DateTimePicker();
            this.lblProdTel = new System.Windows.Forms.Label();
            this.txtProdTelefone = new System.Windows.Forms.TextBox();
            this.btnProdNovo = new System.Windows.Forms.Button();
            this.btnProdSalvar = new System.Windows.Forms.Button();
            this.btnProdExcluir = new System.Windows.Forms.Button();
            this.lblProdBusca = new System.Windows.Forms.Label();
            this.txtProdBusca = new System.Windows.Forms.TextBox();
            this.btnProdBuscar = new System.Windows.Forms.Button();
            this.dgvProdutores = new System.Windows.Forms.DataGridView();
            this.lblProdTotal = new System.Windows.Forms.Label();

            // Controles da aba Propriedades
            this.lblPropProdutor = new System.Windows.Forms.Label();
            this.cmbPropProdutor = new System.Windows.Forms.ComboBox();
            this.lblPropNome = new System.Windows.Forms.Label();
            this.txtPropNome = new System.Windows.Forms.TextBox();
            this.lblPropArea = new System.Windows.Forms.Label();
            this.txtPropArea = new System.Windows.Forms.TextBox();
            this.lblPropMunicipio = new System.Windows.Forms.Label();
            this.txtPropMunicipio = new System.Windows.Forms.TextBox();
            this.lblPropUf = new System.Windows.Forms.Label();
            this.txtPropUf = new System.Windows.Forms.TextBox();
            this.lblPropEstrada = new System.Windows.Forms.Label();
            this.txtPropEstrada = new System.Windows.Forms.TextBox();
            this.lblPropTipo = new System.Windows.Forms.Label();
            this.cmbPropTipo = new System.Windows.Forms.ComboBox();
            this.lblPropDoc = new System.Windows.Forms.Label();
            this.txtPropDoc = new System.Windows.Forms.TextBox();
            this.lblPropArrend = new System.Windows.Forms.Label();
            this.cmbPropArrendatario = new System.Windows.Forms.ComboBox();
            this.lblPropIni = new System.Windows.Forms.Label();
            this.dtpPropIni = new System.Windows.Forms.DateTimePicker();
            this.lblPropFim = new System.Windows.Forms.Label();
            this.dtpPropFim = new System.Windows.Forms.DateTimePicker();
            this.btnPropNovo = new System.Windows.Forms.Button();
            this.btnPropSalvar = new System.Windows.Forms.Button();
            this.btnPropExcluir = new System.Windows.Forms.Button();
            this.dgvPropriedades = new System.Windows.Forms.DataGridView();

            // Controles da aba Talhoes
            this.lblTalProp = new System.Windows.Forms.Label();
            this.cmbTalProp = new System.Windows.Forms.ComboBox();
            this.lblTalNumero = new System.Windows.Forms.Label();
            this.txtTalNumero = new System.Windows.Forms.TextBox();
            this.lblTalArea = new System.Windows.Forms.Label();
            this.txtTalArea = new System.Windows.Forms.TextBox();
            this.lblTalSolo = new System.Windows.Forms.Label();
            this.txtTalSolo = new System.Windows.Forms.TextBox();
            this.btnTalNovo = new System.Windows.Forms.Button();
            this.btnTalSalvar = new System.Windows.Forms.Button();
            this.btnTalExcluir = new System.Windows.Forms.Button();
            this.dgvTalhoes = new System.Windows.Forms.DataGridView();

            // Controles da aba Cargas e Pesagem
            this.lblCargaTicket = new System.Windows.Forms.Label();
            this.txtCargaTicket = new System.Windows.Forms.TextBox();
            this.lblCargaData = new System.Windows.Forms.Label();
            this.dtpCargaData = new System.Windows.Forms.DateTimePicker();
            this.lblCargaSafraTalhao = new System.Windows.Forms.Label();
            this.cmbCargaSafraTalhao = new System.Windows.Forms.ComboBox();
            this.lblCargaCaminhao = new System.Windows.Forms.Label();
            this.cmbCargaCaminhao = new System.Windows.Forms.ComboBox();
            this.lblCargaMotorista = new System.Windows.Forms.Label();
            this.cmbCargaMotorista = new System.Windows.Forms.ComboBox();
            this.lblCargaPreco = new System.Windows.Forms.Label();
            this.cmbCargaPrecoRef = new System.Windows.Forms.ComboBox();
            this.lblCargaPag = new System.Windows.Forms.Label();
            this.cmbCargaPagamento = new System.Windows.Forms.ComboBox();
            this.lblPesBruto = new System.Windows.Forms.Label();
            this.txtPesBruto = new System.Windows.Forms.TextBox();
            this.lblPesTara = new System.Windows.Forms.Label();
            this.txtPesTara = new System.Windows.Forms.TextBox();
            this.lblPesBalanca = new System.Windows.Forms.Label();
            this.txtPesBalanca = new System.Windows.Forms.TextBox();
            this.btnCargaNovo = new System.Windows.Forms.Button();
            this.btnCargaSalvar = new System.Windows.Forms.Button();
            this.btnCargaExcluir = new System.Windows.Forms.Button();
            this.dgvCargas = new System.Windows.Forms.DataGridView();

            // Controles da aba Amostras e Analises
            this.lblAnaCarga = new System.Windows.Forms.Label();
            this.cmbAnaCarga = new System.Windows.Forms.ComboBox();
            this.lblAnaEtiqueta = new System.Windows.Forms.Label();
            this.txtAnaEtiqueta = new System.Windows.Forms.TextBox();
            this.lblAnaPeso = new System.Windows.Forms.Label();
            this.txtAnaPesoAmostra = new System.Windows.Forms.TextBox();
            this.lblAnaColetor = new System.Windows.Forms.Label();
            this.txtAnaColetor = new System.Windows.Forms.TextBox();
            this.chkRegistrarAnalise = new System.Windows.Forms.CheckBox();
            this.lblAnaBrix = new System.Windows.Forms.Label();
            this.txtAnaBrix = new System.Windows.Forms.TextBox();
            this.lblAnaPol = new System.Windows.Forms.Label();
            this.txtAnaPol = new System.Windows.Forms.TextBox();
            this.lblAnaImpureza = new System.Windows.Forms.Label();
            this.txtAnaImpureza = new System.Windows.Forms.TextBox();
            this.lblAnaAtr = new System.Windows.Forms.Label();
            this.txtAnaAtr = new System.Windows.Forms.TextBox();
            this.lblAnaTecnico = new System.Windows.Forms.Label();
            this.txtAnaTecnico = new System.Windows.Forms.TextBox();
            this.btnAnaNovo = new System.Windows.Forms.Button();
            this.btnAnaSalvar = new System.Windows.Forms.Button();
            this.btnAnaExcluir = new System.Windows.Forms.Button();
            this.dgvAnalises = new System.Windows.Forms.DataGridView();

            // Controles da aba Pagamentos
            this.lblPagProdutor = new System.Windows.Forms.Label();
            this.cmbPagProdutor = new System.Windows.Forms.ComboBox();
            this.lblPagInicio = new System.Windows.Forms.Label();
            this.dtpPagInicio = new System.Windows.Forms.DateTimePicker();
            this.lblPagFim = new System.Windows.Forms.Label();
            this.dtpPagFim = new System.Windows.Forms.DateTimePicker();
            this.lblPagStatus = new System.Windows.Forms.Label();
            this.cmbPagStatus = new System.Windows.Forms.ComboBox();
            this.lblPagData = new System.Windows.Forms.Label();
            this.dtpPagData = new System.Windows.Forms.DateTimePicker();
            this.btnPagNovo = new System.Windows.Forms.Button();
            this.btnPagSalvar = new System.Windows.Forms.Button();
            this.btnPagExcluir = new System.Windows.Forms.Button();
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();

            // Controles da aba Consultas (E6)
            this.lblConsultaSel = new System.Windows.Forms.Label();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            this.btnExecutarConsulta = new System.Windows.Forms.Button();
            this.txtSqlConsulta = new System.Windows.Forms.TextBox();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.lblConsultaTotal = new System.Windows.Forms.Label();

            this.tabPrincipal.SuspendLayout();
            this.tabProdutores.SuspendLayout();
            this.tabPropriedades.SuspendLayout();
            this.tabTalhoes.SuspendLayout();
            this.tabCargas.SuspendLayout();
            this.tabAnalises.SuspendLayout();
            this.tabPagamentos.SuspendLayout();
            this.tabConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropriedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalhoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();

            // tabPrincipal
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1020, 620);
            this.tabPrincipal.Controls.Add(this.tabProdutores);
            this.tabPrincipal.Controls.Add(this.tabPropriedades);
            this.tabPrincipal.Controls.Add(this.tabTalhoes);
            this.tabPrincipal.Controls.Add(this.tabCargas);
            this.tabPrincipal.Controls.Add(this.tabAnalises);
            this.tabPrincipal.Controls.Add(this.tabPagamentos);
            this.tabPrincipal.Controls.Add(this.tabConsultas);

            // ================= ABA 1: PRODUTORES =================
            this.tabProdutores.Name = "tabProdutores";
            this.tabProdutores.Text = "Produtores";
            this.tabProdutores.Padding = new System.Windows.Forms.Padding(8);

            this.lblProdNome.Text = "Nome:";
            this.lblProdNome.Location = new System.Drawing.Point(16, 18);
            this.lblProdNome.AutoSize = true;
            this.txtProdNome.Location = new System.Drawing.Point(16, 36);
            this.txtProdNome.Size = new System.Drawing.Size(260, 22);

            this.lblProdCpfCnpj.Text = "CPF / CNPJ:";
            this.lblProdCpfCnpj.Location = new System.Drawing.Point(290, 18);
            this.lblProdCpfCnpj.AutoSize = true;
            this.txtProdCpfCnpj.Location = new System.Drawing.Point(290, 36);
            this.txtProdCpfCnpj.Size = new System.Drawing.Size(160, 22);

            this.lblProdEmail.Text = "E-mail:";
            this.lblProdEmail.Location = new System.Drawing.Point(464, 18);
            this.lblProdEmail.AutoSize = true;
            this.txtProdEmail.Location = new System.Drawing.Point(464, 36);
            this.txtProdEmail.Size = new System.Drawing.Size(210, 22);

            this.lblProdData.Text = "Data Associacao:";
            this.lblProdData.Location = new System.Drawing.Point(688, 18);
            this.lblProdData.AutoSize = true;
            this.dtpProdDataAssoc.Location = new System.Drawing.Point(688, 36);
            this.dtpProdDataAssoc.Size = new System.Drawing.Size(130, 22);
            this.dtpProdDataAssoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblProdTel.Text = "Telefone:";
            this.lblProdTel.Location = new System.Drawing.Point(832, 18);
            this.lblProdTel.AutoSize = true;
            this.txtProdTelefone.Location = new System.Drawing.Point(832, 36);
            this.txtProdTelefone.Size = new System.Drawing.Size(150, 22);

            this.btnProdNovo.Text = "Novo";
            this.btnProdNovo.Location = new System.Drawing.Point(16, 72);
            this.btnProdNovo.Size = new System.Drawing.Size(85, 28);
            this.btnProdNovo.Click += new System.EventHandler(this.btnProdNovo_Click);

            this.btnProdSalvar.Text = "Salvar";
            this.btnProdSalvar.Location = new System.Drawing.Point(110, 72);
            this.btnProdSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnProdSalvar.Click += new System.EventHandler(this.btnProdSalvar_Click);

            this.btnProdExcluir.Text = "Excluir";
            this.btnProdExcluir.Location = new System.Drawing.Point(204, 72);
            this.btnProdExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnProdExcluir.Click += new System.EventHandler(this.btnProdExcluir_Click);

            this.lblProdBusca.Text = "Buscar por nome:";
            this.lblProdBusca.Location = new System.Drawing.Point(464, 78);
            this.lblProdBusca.AutoSize = true;
            this.txtProdBusca.Location = new System.Drawing.Point(568, 74);
            this.txtProdBusca.Size = new System.Drawing.Size(220, 22);
            this.btnProdBuscar.Text = "Buscar";
            this.btnProdBuscar.Location = new System.Drawing.Point(796, 72);
            this.btnProdBuscar.Size = new System.Drawing.Size(85, 28);
            this.btnProdBuscar.Click += new System.EventHandler(this.btnProdBuscar_Click);

            this.dgvProdutores.Location = new System.Drawing.Point(16, 114);
            this.dgvProdutores.Size = new System.Drawing.Size(976, 430);
            this.dgvProdutores.ReadOnly = true;
            this.dgvProdutores.AllowUserToAddRows = false;
            this.dgvProdutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutores_CellClick);

            this.lblProdTotal.Text = "Total de produtores: 0";
            this.lblProdTotal.Location = new System.Drawing.Point(16, 554);
            this.lblProdTotal.AutoSize = true;

            this.tabProdutores.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProdNome, this.txtProdNome, this.lblProdCpfCnpj, this.txtProdCpfCnpj,
                this.lblProdEmail, this.txtProdEmail, this.lblProdData, this.dtpProdDataAssoc,
                this.lblProdTel, this.txtProdTelefone, this.btnProdNovo, this.btnProdSalvar,
                this.btnProdExcluir, this.lblProdBusca, this.txtProdBusca, this.btnProdBuscar,
                this.dgvProdutores, this.lblProdTotal
            });

            // ================= ABA 2: PROPRIEDADES =================
            this.tabPropriedades.Name = "tabPropriedades";
            this.tabPropriedades.Text = "Propriedades";
            this.tabPropriedades.Padding = new System.Windows.Forms.Padding(8);

            this.lblPropProdutor.Text = "Produtor Proprietario:";
            this.lblPropProdutor.Location = new System.Drawing.Point(16, 14);
            this.lblPropProdutor.AutoSize = true;
            this.cmbPropProdutor.Location = new System.Drawing.Point(16, 32);
            this.cmbPropProdutor.Size = new System.Drawing.Size(220, 22);
            this.cmbPropProdutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPropNome.Text = "Nome da Propriedade:";
            this.lblPropNome.Location = new System.Drawing.Point(248, 14);
            this.lblPropNome.AutoSize = true;
            this.txtPropNome.Location = new System.Drawing.Point(248, 32);
            this.txtPropNome.Size = new System.Drawing.Size(210, 22);

            this.lblPropArea.Text = "Area Total (ha):";
            this.lblPropArea.Location = new System.Drawing.Point(470, 14);
            this.lblPropArea.AutoSize = true;
            this.txtPropArea.Location = new System.Drawing.Point(470, 32);
            this.txtPropArea.Size = new System.Drawing.Size(95, 22);

            this.lblPropMunicipio.Text = "Municipio:";
            this.lblPropMunicipio.Location = new System.Drawing.Point(578, 14);
            this.lblPropMunicipio.AutoSize = true;
            this.txtPropMunicipio.Location = new System.Drawing.Point(578, 32);
            this.txtPropMunicipio.Size = new System.Drawing.Size(145, 22);

            this.lblPropUf.Text = "UF:";
            this.lblPropUf.Location = new System.Drawing.Point(735, 14);
            this.lblPropUf.AutoSize = true;
            this.txtPropUf.Location = new System.Drawing.Point(735, 32);
            this.txtPropUf.Size = new System.Drawing.Size(40, 22);
            this.txtPropUf.MaxLength = 2;

            this.lblPropEstrada.Text = "Estrada de Acesso:";
            this.lblPropEstrada.Location = new System.Drawing.Point(786, 14);
            this.lblPropEstrada.AutoSize = true;
            this.txtPropEstrada.Location = new System.Drawing.Point(786, 32);
            this.txtPropEstrada.Size = new System.Drawing.Size(206, 22);

            this.lblPropTipo.Text = "Tipo Posse:";
            this.lblPropTipo.Location = new System.Drawing.Point(16, 66);
            this.lblPropTipo.AutoSize = true;
            this.cmbPropTipo.Location = new System.Drawing.Point(16, 84);
            this.cmbPropTipo.Size = new System.Drawing.Size(120, 22);
            this.cmbPropTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropTipo.Items.AddRange(new object[] { "PROPRIA", "ARRENDADA" });
            this.cmbPropTipo.SelectedIndexChanged += new System.EventHandler(this.cmbPropTipo_SelectedIndexChanged);

            this.lblPropDoc.Text = "Matricula / Contrato:";
            this.lblPropDoc.Location = new System.Drawing.Point(148, 66);
            this.lblPropDoc.AutoSize = true;
            this.txtPropDoc.Location = new System.Drawing.Point(148, 84);
            this.txtPropDoc.Size = new System.Drawing.Size(160, 22);

            this.lblPropArrend.Text = "Arrendatario (Recebedor):";
            this.lblPropArrend.Location = new System.Drawing.Point(320, 66);
            this.lblPropArrend.AutoSize = true;
            this.cmbPropArrendatario.Location = new System.Drawing.Point(320, 84);
            this.cmbPropArrendatario.Size = new System.Drawing.Size(220, 22);
            this.cmbPropArrendatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPropIni.Text = "Inicio Contrato:";
            this.lblPropIni.Location = new System.Drawing.Point(552, 66);
            this.lblPropIni.AutoSize = true;
            this.dtpPropIni.Location = new System.Drawing.Point(552, 84);
            this.dtpPropIni.Size = new System.Drawing.Size(115, 22);
            this.dtpPropIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblPropFim.Text = "Fim Contrato:";
            this.lblPropFim.Location = new System.Drawing.Point(678, 66);
            this.lblPropFim.AutoSize = true;
            this.dtpPropFim.Location = new System.Drawing.Point(678, 84);
            this.dtpPropFim.Size = new System.Drawing.Size(115, 22);
            this.dtpPropFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnPropNovo.Text = "Novo";
            this.btnPropNovo.Location = new System.Drawing.Point(16, 118);
            this.btnPropNovo.Size = new System.Drawing.Size(85, 28);
            this.btnPropNovo.Click += new System.EventHandler(this.btnPropNovo_Click);

            this.btnPropSalvar.Text = "Salvar";
            this.btnPropSalvar.Location = new System.Drawing.Point(110, 118);
            this.btnPropSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnPropSalvar.Click += new System.EventHandler(this.btnPropSalvar_Click);

            this.btnPropExcluir.Text = "Excluir";
            this.btnPropExcluir.Location = new System.Drawing.Point(204, 118);
            this.btnPropExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnPropExcluir.Click += new System.EventHandler(this.btnPropExcluir_Click);

            this.dgvPropriedades.Location = new System.Drawing.Point(16, 156);
            this.dgvPropriedades.Size = new System.Drawing.Size(976, 410);
            this.dgvPropriedades.ReadOnly = true;
            this.dgvPropriedades.AllowUserToAddRows = false;
            this.dgvPropriedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropriedades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPropriedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPropriedades_CellClick);

            this.tabPropriedades.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPropProdutor, this.cmbPropProdutor, this.lblPropNome, this.txtPropNome,
                this.lblPropArea, this.txtPropArea, this.lblPropMunicipio, this.txtPropMunicipio,
                this.lblPropUf, this.txtPropUf, this.lblPropEstrada, this.txtPropEstrada,
                this.lblPropTipo, this.cmbPropTipo, this.lblPropDoc, this.txtPropDoc,
                this.lblPropArrend, this.cmbPropArrendatario, this.lblPropIni, this.dtpPropIni,
                this.lblPropFim, this.dtpPropFim, this.btnPropNovo, this.btnPropSalvar,
                this.btnPropExcluir, this.dgvPropriedades
            });

            // ================= ABA 3: TALHOES (ENTIDADE FRACA) =================
            this.tabTalhoes.Name = "tabTalhoes";
            this.tabTalhoes.Text = "Talhoes";
            this.tabTalhoes.Padding = new System.Windows.Forms.Padding(8);

            this.lblTalProp.Text = "Propriedade:";
            this.lblTalProp.Location = new System.Drawing.Point(16, 18);
            this.lblTalProp.AutoSize = true;
            this.cmbTalProp.Location = new System.Drawing.Point(16, 36);
            this.cmbTalProp.Size = new System.Drawing.Size(260, 22);
            this.cmbTalProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblTalNumero.Text = "Numero Talhao:";
            this.lblTalNumero.Location = new System.Drawing.Point(290, 18);
            this.lblTalNumero.AutoSize = true;
            this.txtTalNumero.Location = new System.Drawing.Point(290, 36);
            this.txtTalNumero.Size = new System.Drawing.Size(110, 22);

            this.lblTalArea.Text = "Area (ha):";
            this.lblTalArea.Location = new System.Drawing.Point(416, 18);
            this.lblTalArea.AutoSize = true;
            this.txtTalArea.Location = new System.Drawing.Point(416, 36);
            this.txtTalArea.Size = new System.Drawing.Size(110, 22);

            this.lblTalSolo.Text = "Tipo de Solo:";
            this.lblTalSolo.Location = new System.Drawing.Point(542, 18);
            this.lblTalSolo.AutoSize = true;
            this.txtTalSolo.Location = new System.Drawing.Point(542, 36);
            this.txtTalSolo.Size = new System.Drawing.Size(220, 22);

            this.btnTalNovo.Text = "Novo";
            this.btnTalNovo.Location = new System.Drawing.Point(16, 72);
            this.btnTalNovo.Size = new System.Drawing.Size(85, 28);
            this.btnTalNovo.Click += new System.EventHandler(this.btnTalNovo_Click);

            this.btnTalSalvar.Text = "Salvar";
            this.btnTalSalvar.Location = new System.Drawing.Point(110, 72);
            this.btnTalSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnTalSalvar.Click += new System.EventHandler(this.btnTalSalvar_Click);

            this.btnTalExcluir.Text = "Excluir";
            this.btnTalExcluir.Location = new System.Drawing.Point(204, 72);
            this.btnTalExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnTalExcluir.Click += new System.EventHandler(this.btnTalExcluir_Click);

            this.dgvTalhoes.Location = new System.Drawing.Point(16, 114);
            this.dgvTalhoes.Size = new System.Drawing.Size(976, 452);
            this.dgvTalhoes.ReadOnly = true;
            this.dgvTalhoes.AllowUserToAddRows = false;
            this.dgvTalhoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTalhoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTalhoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTalhoes_CellClick);

            this.tabTalhoes.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTalProp, this.cmbTalProp, this.lblTalNumero, this.txtTalNumero,
                this.lblTalArea, this.txtTalArea, this.lblTalSolo, this.txtTalSolo,
                this.btnTalNovo, this.btnTalSalvar, this.btnTalExcluir, this.dgvTalhoes
            });

            // ================= ABA 4: CARGAS E PESAGEM =================
            this.tabCargas.Name = "tabCargas";
            this.tabCargas.Text = "Cargas e Pesagem";
            this.tabCargas.Padding = new System.Windows.Forms.Padding(8);

            this.lblCargaTicket.Text = "Ticket:";
            this.lblCargaTicket.Location = new System.Drawing.Point(16, 14);
            this.lblCargaTicket.AutoSize = true;
            this.txtCargaTicket.Location = new System.Drawing.Point(16, 32);
            this.txtCargaTicket.Size = new System.Drawing.Size(120, 22);

            this.lblCargaData.Text = "Data Entrada:";
            this.lblCargaData.Location = new System.Drawing.Point(148, 14);
            this.lblCargaData.AutoSize = true;
            this.dtpCargaData.Location = new System.Drawing.Point(148, 32);
            this.dtpCargaData.Size = new System.Drawing.Size(140, 22);
            this.dtpCargaData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCargaData.CustomFormat = "dd/MM/yyyy HH:mm";

            this.lblCargaSafraTalhao.Text = "Safra / Propriedade / Talhao:";
            this.lblCargaSafraTalhao.Location = new System.Drawing.Point(300, 14);
            this.lblCargaSafraTalhao.AutoSize = true;
            this.cmbCargaSafraTalhao.Location = new System.Drawing.Point(300, 32);
            this.cmbCargaSafraTalhao.Size = new System.Drawing.Size(270, 22);
            this.cmbCargaSafraTalhao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCargaCaminhao.Text = "Caminhao:";
            this.lblCargaCaminhao.Location = new System.Drawing.Point(582, 14);
            this.lblCargaCaminhao.AutoSize = true;
            this.cmbCargaCaminhao.Location = new System.Drawing.Point(582, 32);
            this.cmbCargaCaminhao.Size = new System.Drawing.Size(195, 22);
            this.cmbCargaCaminhao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCargaMotorista.Text = "Motorista:";
            this.lblCargaMotorista.Location = new System.Drawing.Point(789, 14);
            this.lblCargaMotorista.AutoSize = true;
            this.cmbCargaMotorista.Location = new System.Drawing.Point(789, 32);
            this.cmbCargaMotorista.Size = new System.Drawing.Size(203, 22);
            this.cmbCargaMotorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCargaPreco.Text = "Preco Quinzena:";
            this.lblCargaPreco.Location = new System.Drawing.Point(16, 66);
            this.lblCargaPreco.AutoSize = true;
            this.cmbCargaPrecoRef.Location = new System.Drawing.Point(16, 84);
            this.cmbCargaPrecoRef.Size = new System.Drawing.Size(230, 22);
            this.cmbCargaPrecoRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCargaPag.Text = "Pagamento (opcional):";
            this.lblCargaPag.Location = new System.Drawing.Point(258, 66);
            this.lblCargaPag.AutoSize = true;
            this.cmbCargaPagamento.Location = new System.Drawing.Point(258, 84);
            this.cmbCargaPagamento.Size = new System.Drawing.Size(250, 22);
            this.cmbCargaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPesBruto.Text = "Peso Bruto (kg):";
            this.lblPesBruto.Location = new System.Drawing.Point(520, 66);
            this.lblPesBruto.AutoSize = true;
            this.txtPesBruto.Location = new System.Drawing.Point(520, 84);
            this.txtPesBruto.Size = new System.Drawing.Size(110, 22);

            this.lblPesTara.Text = "Peso Tara (kg):";
            this.lblPesTara.Location = new System.Drawing.Point(642, 66);
            this.lblPesTara.AutoSize = true;
            this.txtPesTara.Location = new System.Drawing.Point(642, 84);
            this.txtPesTara.Size = new System.Drawing.Size(110, 22);

            this.lblPesBalanca.Text = "Balanca:";
            this.lblPesBalanca.Location = new System.Drawing.Point(764, 66);
            this.lblPesBalanca.AutoSize = true;
            this.txtPesBalanca.Location = new System.Drawing.Point(764, 84);
            this.txtPesBalanca.Size = new System.Drawing.Size(120, 22);

            this.btnCargaNovo.Text = "Novo";
            this.btnCargaNovo.Location = new System.Drawing.Point(16, 118);
            this.btnCargaNovo.Size = new System.Drawing.Size(85, 28);
            this.btnCargaNovo.Click += new System.EventHandler(this.btnCargaNovo_Click);

            this.btnCargaSalvar.Text = "Salvar";
            this.btnCargaSalvar.Location = new System.Drawing.Point(110, 118);
            this.btnCargaSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnCargaSalvar.Click += new System.EventHandler(this.btnCargaSalvar_Click);

            this.btnCargaExcluir.Text = "Excluir";
            this.btnCargaExcluir.Location = new System.Drawing.Point(204, 118);
            this.btnCargaExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnCargaExcluir.Click += new System.EventHandler(this.btnCargaExcluir_Click);

            this.dgvCargas.Location = new System.Drawing.Point(16, 156);
            this.dgvCargas.Size = new System.Drawing.Size(976, 410);
            this.dgvCargas.ReadOnly = true;
            this.dgvCargas.AllowUserToAddRows = false;
            this.dgvCargas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCargas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargas_CellClick);

            this.tabCargas.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCargaTicket, this.txtCargaTicket, this.lblCargaData, this.dtpCargaData,
                this.lblCargaSafraTalhao, this.cmbCargaSafraTalhao, this.lblCargaCaminhao, this.cmbCargaCaminhao,
                this.lblCargaMotorista, this.cmbCargaMotorista, this.lblCargaPreco, this.cmbCargaPrecoRef,
                this.lblCargaPag, this.cmbCargaPagamento, this.lblPesBruto, this.txtPesBruto,
                this.lblPesTara, this.txtPesTara, this.lblPesBalanca, this.txtPesBalanca,
                this.btnCargaNovo, this.btnCargaSalvar, this.btnCargaExcluir, this.dgvCargas
            });

            // ================= ABA 5: AMOSTRAS E ANALISES =================
            this.tabAnalises.Name = "tabAnalises";
            this.tabAnalises.Text = "Amostras e Analises";
            this.tabAnalises.Padding = new System.Windows.Forms.Padding(8);

            this.lblAnaCarga.Text = "Carga (Ticket):";
            this.lblAnaCarga.Location = new System.Drawing.Point(16, 14);
            this.lblAnaCarga.AutoSize = true;
            this.cmbAnaCarga.Location = new System.Drawing.Point(16, 32);
            this.cmbAnaCarga.Size = new System.Drawing.Size(210, 22);
            this.cmbAnaCarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblAnaEtiqueta.Text = "Etiqueta Amostra:";
            this.lblAnaEtiqueta.Location = new System.Drawing.Point(238, 14);
            this.lblAnaEtiqueta.AutoSize = true;
            this.txtAnaEtiqueta.Location = new System.Drawing.Point(238, 32);
            this.txtAnaEtiqueta.Size = new System.Drawing.Size(140, 22);

            this.lblAnaPeso.Text = "Peso Amostra (kg):";
            this.lblAnaPeso.Location = new System.Drawing.Point(390, 14);
            this.lblAnaPeso.AutoSize = true;
            this.txtAnaPesoAmostra.Location = new System.Drawing.Point(390, 32);
            this.txtAnaPesoAmostra.Size = new System.Drawing.Size(110, 22);

            this.lblAnaColetor.Text = "Coletor:";
            this.lblAnaColetor.Location = new System.Drawing.Point(512, 14);
            this.lblAnaColetor.AutoSize = true;
            this.txtAnaColetor.Location = new System.Drawing.Point(512, 32);
            this.txtAnaColetor.Size = new System.Drawing.Size(180, 22);

            this.chkRegistrarAnalise.Text = "Registrar/Atualizar Analise";
            this.chkRegistrarAnalise.Location = new System.Drawing.Point(16, 68);
            this.chkRegistrarAnalise.AutoSize = true;
            this.chkRegistrarAnalise.CheckedChanged += new System.EventHandler(this.chkRegistrarAnalise_CheckedChanged);

            this.lblAnaBrix.Text = "Brix:";
            this.lblAnaBrix.Location = new System.Drawing.Point(210, 66);
            this.lblAnaBrix.AutoSize = true;
            this.txtAnaBrix.Location = new System.Drawing.Point(210, 84);
            this.txtAnaBrix.Size = new System.Drawing.Size(80, 22);

            this.lblAnaPol.Text = "Pol:";
            this.lblAnaPol.Location = new System.Drawing.Point(302, 66);
            this.lblAnaPol.AutoSize = true;
            this.txtAnaPol.Location = new System.Drawing.Point(302, 84);
            this.txtAnaPol.Size = new System.Drawing.Size(80, 22);

            this.lblAnaImpureza.Text = "Impureza (%):";
            this.lblAnaImpureza.Location = new System.Drawing.Point(394, 66);
            this.lblAnaImpureza.AutoSize = true;
            this.txtAnaImpureza.Location = new System.Drawing.Point(394, 84);
            this.txtAnaImpureza.Size = new System.Drawing.Size(90, 22);

            this.lblAnaAtr.Text = "ATR (kg/t):";
            this.lblAnaAtr.Location = new System.Drawing.Point(496, 66);
            this.lblAnaAtr.AutoSize = true;
            this.txtAnaAtr.Location = new System.Drawing.Point(496, 84);
            this.txtAnaAtr.Size = new System.Drawing.Size(90, 22);

            this.lblAnaTecnico.Text = "Tecnico Laboratorio:";
            this.lblAnaTecnico.Location = new System.Drawing.Point(598, 66);
            this.lblAnaTecnico.AutoSize = true;
            this.txtAnaTecnico.Location = new System.Drawing.Point(598, 84);
            this.txtAnaTecnico.Size = new System.Drawing.Size(200, 22);

            this.btnAnaNovo.Text = "Novo";
            this.btnAnaNovo.Location = new System.Drawing.Point(16, 118);
            this.btnAnaNovo.Size = new System.Drawing.Size(85, 28);
            this.btnAnaNovo.Click += new System.EventHandler(this.btnAnaNovo_Click);

            this.btnAnaSalvar.Text = "Salvar";
            this.btnAnaSalvar.Location = new System.Drawing.Point(110, 118);
            this.btnAnaSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnAnaSalvar.Click += new System.EventHandler(this.btnAnaSalvar_Click);

            this.btnAnaExcluir.Text = "Excluir";
            this.btnAnaExcluir.Location = new System.Drawing.Point(204, 118);
            this.btnAnaExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnAnaExcluir.Click += new System.EventHandler(this.btnAnaExcluir_Click);

            this.dgvAnalises.Location = new System.Drawing.Point(16, 156);
            this.dgvAnalises.Size = new System.Drawing.Size(976, 410);
            this.dgvAnalises.ReadOnly = true;
            this.dgvAnalises.AllowUserToAddRows = false;
            this.dgvAnalises.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalises.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalises.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnalises_CellClick);

            this.tabAnalises.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAnaCarga, this.cmbAnaCarga, this.lblAnaEtiqueta, this.txtAnaEtiqueta,
                this.lblAnaPeso, this.txtAnaPesoAmostra, this.lblAnaColetor, this.txtAnaColetor,
                this.chkRegistrarAnalise, this.lblAnaBrix, this.txtAnaBrix, this.lblAnaPol, this.txtAnaPol,
                this.lblAnaImpureza, this.txtAnaImpureza, this.lblAnaAtr, this.txtAnaAtr,
                this.lblAnaTecnico, this.txtAnaTecnico, this.btnAnaNovo, this.btnAnaSalvar,
                this.btnAnaExcluir, this.dgvAnalises
            });

            // ================= ABA 6: PAGAMENTOS =================
            this.tabPagamentos.Name = "tabPagamentos";
            this.tabPagamentos.Text = "Pagamentos";
            this.tabPagamentos.Padding = new System.Windows.Forms.Padding(8);

            this.lblPagProdutor.Text = "Produtor Beneficiario:";
            this.lblPagProdutor.Location = new System.Drawing.Point(16, 18);
            this.lblPagProdutor.AutoSize = true;
            this.cmbPagProdutor.Location = new System.Drawing.Point(16, 36);
            this.cmbPagProdutor.Size = new System.Drawing.Size(250, 22);
            this.cmbPagProdutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPagInicio.Text = "Inicio Periodo:";
            this.lblPagInicio.Location = new System.Drawing.Point(280, 18);
            this.lblPagInicio.AutoSize = true;
            this.dtpPagInicio.Location = new System.Drawing.Point(280, 36);
            this.dtpPagInicio.Size = new System.Drawing.Size(120, 22);
            this.dtpPagInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblPagFim.Text = "Fim Periodo:";
            this.lblPagFim.Location = new System.Drawing.Point(414, 18);
            this.lblPagFim.AutoSize = true;
            this.dtpPagFim.Location = new System.Drawing.Point(414, 36);
            this.dtpPagFim.Size = new System.Drawing.Size(120, 22);
            this.dtpPagFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblPagStatus.Text = "Status:";
            this.lblPagStatus.Location = new System.Drawing.Point(548, 18);
            this.lblPagStatus.AutoSize = true;
            this.cmbPagStatus.Location = new System.Drawing.Point(548, 36);
            this.cmbPagStatus.Size = new System.Drawing.Size(120, 22);
            this.cmbPagStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPagStatus.Items.AddRange(new object[] { "PENDENTE", "PAGO" });
            this.cmbPagStatus.SelectedIndexChanged += new System.EventHandler(this.cmbPagStatus_SelectedIndexChanged);

            this.lblPagData.Text = "Data Pagamento:";
            this.lblPagData.Location = new System.Drawing.Point(682, 18);
            this.lblPagData.AutoSize = true;
            this.dtpPagData.Location = new System.Drawing.Point(682, 36);
            this.dtpPagData.Size = new System.Drawing.Size(120, 22);
            this.dtpPagData.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnPagNovo.Text = "Novo";
            this.btnPagNovo.Location = new System.Drawing.Point(16, 72);
            this.btnPagNovo.Size = new System.Drawing.Size(85, 28);
            this.btnPagNovo.Click += new System.EventHandler(this.btnPagNovo_Click);

            this.btnPagSalvar.Text = "Salvar";
            this.btnPagSalvar.Location = new System.Drawing.Point(110, 72);
            this.btnPagSalvar.Size = new System.Drawing.Size(85, 28);
            this.btnPagSalvar.Click += new System.EventHandler(this.btnPagSalvar_Click);

            this.btnPagExcluir.Text = "Excluir";
            this.btnPagExcluir.Location = new System.Drawing.Point(204, 72);
            this.btnPagExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnPagExcluir.Click += new System.EventHandler(this.btnPagExcluir_Click);

            this.dgvPagamentos.Location = new System.Drawing.Point(16, 114);
            this.dgvPagamentos.Size = new System.Drawing.Size(976, 452);
            this.dgvPagamentos.ReadOnly = true;
            this.dgvPagamentos.AllowUserToAddRows = false;
            this.dgvPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagamentos_CellClick);

            this.tabPagamentos.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPagProdutor, this.cmbPagProdutor, this.lblPagInicio, this.dtpPagInicio,
                this.lblPagFim, this.dtpPagFim, this.lblPagStatus, this.cmbPagStatus,
                this.lblPagData, this.dtpPagData, this.btnPagNovo, this.btnPagSalvar,
                this.btnPagExcluir, this.dgvPagamentos
            });

            // ================= ABA 7: CONSULTAS SQL (E6) =================
            this.tabConsultas.Name = "tabConsultas";
            this.tabConsultas.Text = "Consultas (E6)";
            this.tabConsultas.Padding = new System.Windows.Forms.Padding(8);

            this.lblConsultaSel.Text = "Selecione a consulta SQL (E6):";
            this.lblConsultaSel.Location = new System.Drawing.Point(16, 14);
            this.lblConsultaSel.AutoSize = true;

            this.cmbConsulta.Location = new System.Drawing.Point(16, 34);
            this.cmbConsulta.Size = new System.Drawing.Size(810, 22);
            this.cmbConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnExecutarConsulta.Text = "Executar Consulta";
            this.btnExecutarConsulta.Location = new System.Drawing.Point(840, 32);
            this.btnExecutarConsulta.Size = new System.Drawing.Size(150, 26);
            this.btnExecutarConsulta.Click += new System.EventHandler(this.btnExecutarConsulta_Click);

            this.txtSqlConsulta.Location = new System.Drawing.Point(16, 68);
            this.txtSqlConsulta.Size = new System.Drawing.Size(974, 110);
            this.txtSqlConsulta.Multiline = true;
            this.txtSqlConsulta.ReadOnly = true;
            this.txtSqlConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSqlConsulta.Font = new System.Drawing.Font("Consolas", 9F);

            this.dgvConsultas.Location = new System.Drawing.Point(16, 190);
            this.dgvConsultas.Size = new System.Drawing.Size(974, 355);
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.lblConsultaTotal.Text = "Registros retornados: 0";
            this.lblConsultaTotal.Location = new System.Drawing.Point(16, 554);
            this.lblConsultaTotal.AutoSize = true;

            this.tabConsultas.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblConsultaSel, this.cmbConsulta, this.btnExecutarConsulta,
                this.txtSqlConsulta, this.dgvConsultas, this.lblConsultaTotal
            });

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cooperativa Agricola - Sistema CRUD";

            this.tabPrincipal.ResumeLayout(false);
            this.tabProdutores.ResumeLayout(false);
            this.tabProdutores.PerformLayout();
            this.tabPropriedades.ResumeLayout(false);
            this.tabPropriedades.PerformLayout();
            this.tabTalhoes.ResumeLayout(false);
            this.tabTalhoes.PerformLayout();
            this.tabCargas.ResumeLayout(false);
            this.tabCargas.PerformLayout();
            this.tabAnalises.ResumeLayout(false);
            this.tabAnalises.PerformLayout();
            this.tabPagamentos.ResumeLayout(false);
            this.tabPagamentos.PerformLayout();
            this.tabConsultas.ResumeLayout(false);
            this.tabConsultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropriedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalhoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabProdutores;
        private System.Windows.Forms.TabPage tabPropriedades;
        private System.Windows.Forms.TabPage tabTalhoes;
        private System.Windows.Forms.TabPage tabCargas;
        private System.Windows.Forms.TabPage tabAnalises;
        private System.Windows.Forms.TabPage tabPagamentos;
        private System.Windows.Forms.TabPage tabConsultas;

        private System.Windows.Forms.Label lblProdNome;
        private System.Windows.Forms.TextBox txtProdNome;
        private System.Windows.Forms.Label lblProdCpfCnpj;
        private System.Windows.Forms.TextBox txtProdCpfCnpj;
        private System.Windows.Forms.Label lblProdEmail;
        private System.Windows.Forms.TextBox txtProdEmail;
        private System.Windows.Forms.Label lblProdData;
        private System.Windows.Forms.DateTimePicker dtpProdDataAssoc;
        private System.Windows.Forms.Label lblProdTel;
        private System.Windows.Forms.TextBox txtProdTelefone;
        private System.Windows.Forms.Button btnProdNovo;
        private System.Windows.Forms.Button btnProdSalvar;
        private System.Windows.Forms.Button btnProdExcluir;
        private System.Windows.Forms.Label lblProdBusca;
        private System.Windows.Forms.TextBox txtProdBusca;
        private System.Windows.Forms.Button btnProdBuscar;
        private System.Windows.Forms.DataGridView dgvProdutores;
        private System.Windows.Forms.Label lblProdTotal;

        private System.Windows.Forms.Label lblPropProdutor;
        private System.Windows.Forms.ComboBox cmbPropProdutor;
        private System.Windows.Forms.Label lblPropNome;
        private System.Windows.Forms.TextBox txtPropNome;
        private System.Windows.Forms.Label lblPropArea;
        private System.Windows.Forms.TextBox txtPropArea;
        private System.Windows.Forms.Label lblPropMunicipio;
        private System.Windows.Forms.TextBox txtPropMunicipio;
        private System.Windows.Forms.Label lblPropUf;
        private System.Windows.Forms.TextBox txtPropUf;
        private System.Windows.Forms.Label lblPropEstrada;
        private System.Windows.Forms.TextBox txtPropEstrada;
        private System.Windows.Forms.Label lblPropTipo;
        private System.Windows.Forms.ComboBox cmbPropTipo;
        private System.Windows.Forms.Label lblPropDoc;
        private System.Windows.Forms.TextBox txtPropDoc;
        private System.Windows.Forms.Label lblPropArrend;
        private System.Windows.Forms.ComboBox cmbPropArrendatario;
        private System.Windows.Forms.Label lblPropIni;
        private System.Windows.Forms.DateTimePicker dtpPropIni;
        private System.Windows.Forms.Label lblPropFim;
        private System.Windows.Forms.DateTimePicker dtpPropFim;
        private System.Windows.Forms.Button btnPropNovo;
        private System.Windows.Forms.Button btnPropSalvar;
        private System.Windows.Forms.Button btnPropExcluir;
        private System.Windows.Forms.DataGridView dgvPropriedades;

        private System.Windows.Forms.Label lblTalProp;
        private System.Windows.Forms.ComboBox cmbTalProp;
        private System.Windows.Forms.Label lblTalNumero;
        private System.Windows.Forms.TextBox txtTalNumero;
        private System.Windows.Forms.Label lblTalArea;
        private System.Windows.Forms.TextBox txtTalArea;
        private System.Windows.Forms.Label lblTalSolo;
        private System.Windows.Forms.TextBox txtTalSolo;
        private System.Windows.Forms.Button btnTalNovo;
        private System.Windows.Forms.Button btnTalSalvar;
        private System.Windows.Forms.Button btnTalExcluir;
        private System.Windows.Forms.DataGridView dgvTalhoes;

        private System.Windows.Forms.Label lblCargaTicket;
        private System.Windows.Forms.TextBox txtCargaTicket;
        private System.Windows.Forms.Label lblCargaData;
        private System.Windows.Forms.DateTimePicker dtpCargaData;
        private System.Windows.Forms.Label lblCargaSafraTalhao;
        private System.Windows.Forms.ComboBox cmbCargaSafraTalhao;
        private System.Windows.Forms.Label lblCargaCaminhao;
        private System.Windows.Forms.ComboBox cmbCargaCaminhao;
        private System.Windows.Forms.Label lblCargaMotorista;
        private System.Windows.Forms.ComboBox cmbCargaMotorista;
        private System.Windows.Forms.Label lblCargaPreco;
        private System.Windows.Forms.ComboBox cmbCargaPrecoRef;
        private System.Windows.Forms.Label lblCargaPag;
        private System.Windows.Forms.ComboBox cmbCargaPagamento;
        private System.Windows.Forms.Label lblPesBruto;
        private System.Windows.Forms.TextBox txtPesBruto;
        private System.Windows.Forms.Label lblPesTara;
        private System.Windows.Forms.TextBox txtPesTara;
        private System.Windows.Forms.Label lblPesBalanca;
        private System.Windows.Forms.TextBox txtPesBalanca;
        private System.Windows.Forms.Button btnCargaNovo;
        private System.Windows.Forms.Button btnCargaSalvar;
        private System.Windows.Forms.Button btnCargaExcluir;
        private System.Windows.Forms.DataGridView dgvCargas;

        private System.Windows.Forms.Label lblAnaCarga;
        private System.Windows.Forms.ComboBox cmbAnaCarga;
        private System.Windows.Forms.Label lblAnaEtiqueta;
        private System.Windows.Forms.TextBox txtAnaEtiqueta;
        private System.Windows.Forms.Label lblAnaPeso;
        private System.Windows.Forms.TextBox txtAnaPesoAmostra;
        private System.Windows.Forms.Label lblAnaColetor;
        private System.Windows.Forms.TextBox txtAnaColetor;
        private System.Windows.Forms.CheckBox chkRegistrarAnalise;
        private System.Windows.Forms.Label lblAnaBrix;
        private System.Windows.Forms.TextBox txtAnaBrix;
        private System.Windows.Forms.Label lblAnaPol;
        private System.Windows.Forms.TextBox txtAnaPol;
        private System.Windows.Forms.Label lblAnaImpureza;
        private System.Windows.Forms.TextBox txtAnaImpureza;
        private System.Windows.Forms.Label lblAnaAtr;
        private System.Windows.Forms.TextBox txtAnaAtr;
        private System.Windows.Forms.Label lblAnaTecnico;
        private System.Windows.Forms.TextBox txtAnaTecnico;
        private System.Windows.Forms.Button btnAnaNovo;
        private System.Windows.Forms.Button btnAnaSalvar;
        private System.Windows.Forms.Button btnAnaExcluir;
        private System.Windows.Forms.DataGridView dgvAnalises;

        private System.Windows.Forms.Label lblPagProdutor;
        private System.Windows.Forms.ComboBox cmbPagProdutor;
        private System.Windows.Forms.Label lblPagInicio;
        private System.Windows.Forms.DateTimePicker dtpPagInicio;
        private System.Windows.Forms.Label lblPagFim;
        private System.Windows.Forms.DateTimePicker dtpPagFim;
        private System.Windows.Forms.Label lblPagStatus;
        private System.Windows.Forms.ComboBox cmbPagStatus;
        private System.Windows.Forms.Label lblPagData;
        private System.Windows.Forms.DateTimePicker dtpPagData;
        private System.Windows.Forms.Button btnPagNovo;
        private System.Windows.Forms.Button btnPagSalvar;
        private System.Windows.Forms.Button btnPagExcluir;
        private System.Windows.Forms.DataGridView dgvPagamentos;

        private System.Windows.Forms.Label lblConsultaSel;
        private System.Windows.Forms.ComboBox cmbConsulta;
        private System.Windows.Forms.Button btnExecutarConsulta;
        private System.Windows.Forms.TextBox txtSqlConsulta;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Label lblConsultaTotal;
    }
}
