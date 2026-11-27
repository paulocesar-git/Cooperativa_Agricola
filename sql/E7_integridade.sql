-- Demonstracao de Integridade - Cooperativa Agricola (Entrega E7)
-- Tres comandos que devem falhar: integridade referencial, de chave e de dominio

USE cooperativa_agricola;

-- Teste 1: Violacao de integridade referencial (FOREIGN KEY)
-- Tenta inserir uma carga apontando para um id_safra_talhao inexistente (999)
INSERT INTO carga (numero_ticket, data_entrada, id_safra_talhao, id_caminhao, id_motorista, id_preco_ref, id_pagamento)
VALUES ('TK-ERRO-FK', '2026-09-28 10:00:00', 999, 1, 1, 12, NULL);

-- Teste 2: Violacao de integridade de chave (PRIMARY KEY composta)
-- Tenta duplicar o talhao numero 1 dentro da propriedade 1 (entidade fraca)
INSERT INTO talhao (id_propriedade, numero_talhao, area_ha, tipo_solo)
VALUES (1, 1, 30.00, 'Latossolo Vermelho');

-- Teste 3: Violacao de integridade de dominio (CHECK)
-- Tenta registrar analise com impureza acima de 100% (150.00), violando chk_analise_impureza
INSERT INTO analise (id_amostra, data_hora_analise, brix, pol, impureza_pct, atr_kg_ton, tecnico_lab)
VALUES (16, '2026-09-03 11:00:00', 19.50, 16.50, 150.00, 140.00, 'Dra. Beatriz Campos');
