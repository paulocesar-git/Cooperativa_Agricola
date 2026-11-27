-- Script DDL - Cooperativa Agricola (Entrega E4)
-- Cria o banco de dados e todas as tabelas com chaves e restricoes do E1

DROP DATABASE IF EXISTS cooperativa_agricola;

CREATE DATABASE cooperativa_agricola
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_general_ci;

USE cooperativa_agricola;

-- RN01: Produtores associados da cooperativa
CREATE TABLE produtor (
    id_produtor INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf_cnpj VARCHAR(18) NOT NULL UNIQUE,
    email VARCHAR(100),
    data_associacao DATE NOT NULL
) ENGINE=InnoDB;

-- RN02: Telefones do produtor (atributo multivalorado mapeado em tabela propria)
CREATE TABLE produtor_telefone (
    id_produtor INT NOT NULL,
    telefone VARCHAR(20) NOT NULL,
    PRIMARY KEY (id_produtor, telefone),
    CONSTRAINT fk_tel_produtor
        FOREIGN KEY (id_produtor) REFERENCES produtor(id_produtor)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- RN03: Propriedades rurais (endereco composto mapeado em colunas)
CREATE TABLE propriedade (
    id_propriedade INT AUTO_INCREMENT PRIMARY KEY,
    id_produtor_proprietario INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    area_total_ha DECIMAL(10,2) NOT NULL,
    municipio VARCHAR(80) NOT NULL,
    uf CHAR(2) NOT NULL,
    estrada_acesso VARCHAR(120) NOT NULL,
    tipo_posse VARCHAR(10) NOT NULL,
    CONSTRAINT fk_prop_proprietario
        FOREIGN KEY (id_produtor_proprietario) REFERENCES produtor(id_produtor)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_prop_area CHECK (area_total_ha > 0),
    CONSTRAINT chk_prop_tipo CHECK (tipo_posse IN ('PROPRIA', 'ARRENDADA'))
) ENGINE=InnoDB;

-- RN04: Subclasse da especializacao total e exclusiva - Propriedade Propria
CREATE TABLE propriedade_propria (
    id_propriedade INT PRIMARY KEY,
    matricula_imovel VARCHAR(40) NOT NULL UNIQUE,
    CONSTRAINT fk_prop_propria
        FOREIGN KEY (id_propriedade) REFERENCES propriedade(id_propriedade)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- RN04 e RN05: Subclasse da especializacao - Propriedade Arrendada
CREATE TABLE propriedade_arrendada (
    id_propriedade INT PRIMARY KEY,
    num_contrato VARCHAR(40) NOT NULL UNIQUE,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL,
    id_produtor_arrendatario INT NOT NULL,
    CONSTRAINT fk_prop_arrendada
        FOREIGN KEY (id_propriedade) REFERENCES propriedade(id_propriedade)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_prop_arrendatario
        FOREIGN KEY (id_produtor_arrendatario) REFERENCES produtor(id_produtor)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_arrend_datas CHECK (data_fim >= data_inicio)
) ENGINE=InnoDB;

-- RN06: Talhao como entidade fraca de Propriedade (chave primaria composta)
CREATE TABLE talhao (
    id_propriedade INT NOT NULL,
    numero_talhao INT NOT NULL,
    area_ha DECIMAL(10,2) NOT NULL,
    tipo_solo VARCHAR(50) NOT NULL,
    PRIMARY KEY (id_propriedade, numero_talhao),
    CONSTRAINT fk_talhao_propriedade
        FOREIGN KEY (id_propriedade) REFERENCES propriedade(id_propriedade)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_talhao_num CHECK (numero_talhao > 0),
    CONSTRAINT chk_talhao_area CHECK (area_ha > 0)
) ENGINE=InnoDB;

-- RN07: Safras agricolas
CREATE TABLE safra (
    id_safra INT AUTO_INCREMENT PRIMARY KEY,
    codigo_safra VARCHAR(15) NOT NULL UNIQUE,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL,
    ativa TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_safra_datas CHECK (data_fim >= data_inicio),
    CONSTRAINT chk_safra_ativa CHECK (ativa IN (0, 1))
) ENGINE=InnoDB;

-- RN08: Entidade associativa entre Talhao e Safra (N:N com atributos proprios)
CREATE TABLE safra_talhao (
    id_safra_talhao INT AUTO_INCREMENT PRIMARY KEY,
    id_propriedade INT NOT NULL,
    numero_talhao INT NOT NULL,
    id_safra INT NOT NULL,
    variedade_cana VARCHAR(50) NOT NULL,
    estagio_corte INT NOT NULL,
    CONSTRAINT uq_safra_talhao UNIQUE (id_propriedade, numero_talhao, id_safra),
    CONSTRAINT fk_st_talhao
        FOREIGN KEY (id_propriedade, numero_talhao) REFERENCES talhao(id_propriedade, numero_talhao)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_st_safra
        FOREIGN KEY (id_safra) REFERENCES safra(id_safra)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_st_corte CHECK (estagio_corte > 0)
) ENGINE=InnoDB;

-- RN09: Transportadoras terceirizadas
CREATE TABLE transportadora (
    id_transportadora INT AUTO_INCREMENT PRIMARY KEY,
    razao_social VARCHAR(100) NOT NULL,
    cnpj VARCHAR(18) NOT NULL UNIQUE,
    telefone VARCHAR(20) NOT NULL
) ENGINE=InnoDB;

-- RN09: Caminhoes pertencentes as transportadoras
CREATE TABLE caminhao (
    id_caminhao INT AUTO_INCREMENT PRIMARY KEY,
    id_transportadora INT NOT NULL,
    placa VARCHAR(10) NOT NULL UNIQUE,
    modelo VARCHAR(60) NOT NULL,
    tara_padrao_kg DECIMAL(10,2) NOT NULL,
    CONSTRAINT fk_cam_transportadora
        FOREIGN KEY (id_transportadora) REFERENCES transportadora(id_transportadora)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_cam_tara CHECK (tara_padrao_kg > 0)
) ENGINE=InnoDB;

-- RN09: Motoristas vinculados as transportadoras
CREATE TABLE motorista (
    id_motorista INT AUTO_INCREMENT PRIMARY KEY,
    id_transportadora INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    cnh VARCHAR(20) NOT NULL UNIQUE,
    CONSTRAINT fk_mot_transportadora
        FOREIGN KEY (id_transportadora) REFERENCES transportadora(id_transportadora)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- RN10: Preco de referencia da quinzena (historico preservado por safra)
CREATE TABLE preco_referencia (
    id_preco_ref INT AUTO_INCREMENT PRIMARY KEY,
    id_safra INT NOT NULL,
    quinzena_inicio DATE NOT NULL,
    quinzena_fim DATE NOT NULL,
    valor_kg_atr DECIMAL(10,4) NOT NULL,
    CONSTRAINT uq_preco_safra_quinzena UNIQUE (id_safra, quinzena_inicio),
    CONSTRAINT fk_preco_safra
        FOREIGN KEY (id_safra) REFERENCES safra(id_safra)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_preco_datas CHECK (quinzena_fim >= quinzena_inicio),
    CONSTRAINT chk_preco_valor CHECK (valor_kg_atr > 0)
) ENGINE=InnoDB;

-- RN05 e RN15: Pagamentos consolidados por periodo ao produtor beneficiario
CREATE TABLE pagamento (
    id_pagamento INT AUTO_INCREMENT PRIMARY KEY,
    id_produtor INT NOT NULL,
    data_inicio_periodo DATE NOT NULL,
    data_fim_periodo DATE NOT NULL,
    status VARCHAR(15) NOT NULL DEFAULT 'PENDENTE',
    data_pagamento DATE NULL,
    CONSTRAINT fk_pag_produtor
        FOREIGN KEY (id_produtor) REFERENCES produtor(id_produtor)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT chk_pag_periodo CHECK (data_fim_periodo >= data_inicio_periodo),
    CONSTRAINT chk_pag_status CHECK (status IN ('PENDENTE', 'PAGO')),
    CONSTRAINT chk_pag_data_status CHECK (
        (status = 'PAGO' AND data_pagamento IS NOT NULL) OR
        (status = 'PENDENTE' AND data_pagamento IS NULL)
    )
) ENGINE=InnoDB;

-- RN11: Cargas de cana recebidas na cooperativa
CREATE TABLE carga (
    id_carga INT AUTO_INCREMENT PRIMARY KEY,
    numero_ticket VARCHAR(20) NOT NULL UNIQUE,
    data_entrada DATETIME NOT NULL,
    id_safra_talhao INT NOT NULL,
    id_caminhao INT NOT NULL,
    id_motorista INT NOT NULL,
    id_preco_ref INT NOT NULL,
    id_pagamento INT NULL,
    CONSTRAINT fk_carga_safra_talhao
        FOREIGN KEY (id_safra_talhao) REFERENCES safra_talhao(id_safra_talhao)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_carga_caminhao
        FOREIGN KEY (id_caminhao) REFERENCES caminhao(id_caminhao)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_carga_motorista
        FOREIGN KEY (id_motorista) REFERENCES motorista(id_motorista)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_carga_preco
        FOREIGN KEY (id_preco_ref) REFERENCES preco_referencia(id_preco_ref)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_carga_pagamento
        FOREIGN KEY (id_pagamento) REFERENCES pagamento(id_pagamento)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB;

-- RN12: Pesagem na balanca (1:1 obrigatorio com Carga; peso liquido e derivado)
CREATE TABLE pesagem (
    id_carga INT PRIMARY KEY,
    data_hora_entrada DATETIME NOT NULL,
    data_hora_saida DATETIME NOT NULL,
    peso_bruto_kg DECIMAL(10,2) NOT NULL,
    peso_tara_kg DECIMAL(10,2) NOT NULL,
    balanca VARCHAR(30) NOT NULL,
    CONSTRAINT fk_pesagem_carga
        FOREIGN KEY (id_carga) REFERENCES carga(id_carga)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_pes_bruto CHECK (peso_bruto_kg > 0),
    CONSTRAINT chk_pes_tara CHECK (peso_tara_kg > 0),
    CONSTRAINT chk_pes_liquido CHECK (peso_bruto_kg > peso_tara_kg),
    CONSTRAINT chk_pes_horario CHECK (data_hora_saida >= data_hora_entrada)
) ENGINE=InnoDB;

-- RN13: Amostra coletada da carga (1:1 opcional com Carga)
CREATE TABLE amostra (
    id_amostra INT AUTO_INCREMENT PRIMARY KEY,
    id_carga INT NOT NULL UNIQUE,
    codigo_etiqueta VARCHAR(30) NOT NULL UNIQUE,
    data_hora_coleta DATETIME NOT NULL,
    peso_amostra_kg DECIMAL(6,2) NOT NULL,
    coletor VARCHAR(80) NOT NULL,
    CONSTRAINT fk_amostra_carga
        FOREIGN KEY (id_carga) REFERENCES carga(id_carga)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_amostra_peso CHECK (peso_amostra_kg > 0)
) ENGINE=InnoDB;

-- RN14: Analise laboratorial da amostra (1:1 opcional com Amostra)
CREATE TABLE analise (
    id_analise INT AUTO_INCREMENT PRIMARY KEY,
    id_amostra INT NOT NULL UNIQUE,
    data_hora_analise DATETIME NOT NULL,
    brix DECIMAL(5,2) NOT NULL,
    pol DECIMAL(5,2) NOT NULL,
    impureza_pct DECIMAL(5,2) NOT NULL,
    atr_kg_ton DECIMAL(6,2) NOT NULL,
    tecnico_lab VARCHAR(80) NOT NULL,
    CONSTRAINT fk_analise_amostra
        FOREIGN KEY (id_amostra) REFERENCES amostra(id_amostra)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_analise_brix CHECK (brix > 0),
    CONSTRAINT chk_analise_pol CHECK (pol > 0),
    CONSTRAINT chk_analise_impureza CHECK (impureza_pct >= 0 AND impureza_pct <= 100),
    CONSTRAINT chk_analise_atr CHECK (atr_kg_ton > 0)
) ENGINE=InnoDB;
