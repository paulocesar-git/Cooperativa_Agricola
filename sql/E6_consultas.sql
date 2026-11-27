-- Consultas SQL - Cooperativa Agricola (Entrega E6)
-- Contem as 5 perguntas do enunciado e 5 perguntas propostas pelo grupo

USE cooperativa_agricola;

-- Consulta 01 (Enunciado): Qual a qualidade media medida por produtor na safra?
SELECT
    s.codigo_safra AS safra,
    prod.nome AS produtor,
    COUNT(an.id_analise) AS cargas_analisadas,
    ROUND(AVG(an.atr_kg_ton), 2) AS media_atr,
    ROUND(AVG(an.brix), 2) AS media_brix,
    ROUND(AVG(an.pol), 2) AS media_pol,
    ROUND(AVG(an.impureza_pct), 2) AS media_impureza_pct
FROM analise an
INNER JOIN amostra am ON am.id_amostra = an.id_amostra
INNER JOIN carga c ON c.id_carga = am.id_carga
INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao
INNER JOIN safra s ON s.id_safra = st.id_safra
INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade
LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade
INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario)
GROUP BY s.codigo_safra, prod.id_produtor, prod.nome
ORDER BY s.codigo_safra DESC, media_atr DESC;

-- Consulta 02 (Enunciado): Quais cargas entraram sem analise de qualidade?
SELECT
    c.numero_ticket,
    c.data_entrada,
    s.codigo_safra AS safra,
    p.nome AS propriedade,
    st.numero_talhao,
    CASE
        WHEN am.id_amostra IS NULL THEN 'Sem amostra'
        ELSE 'Amostra aguardando analise'
    END AS situacao
FROM carga c
INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao
INNER JOIN safra s ON s.id_safra = st.id_safra
INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade
LEFT JOIN amostra am ON am.id_carga = c.id_carga
LEFT JOIN analise an ON an.id_amostra = am.id_amostra
WHERE an.id_analise IS NULL
ORDER BY c.data_entrada;

-- Consulta 03 (Enunciado): Quantas toneladas vieram de cada propriedade e de cada talhao?
SELECT
    p.nome AS propriedade,
    t.numero_talhao,
    COUNT(c.id_carga) AS qtd_cargas,
    ROUND(COALESCE(SUM(pes.peso_bruto_kg - pes.peso_tara_kg), 0) / 1000, 2) AS total_toneladas
FROM talhao t
INNER JOIN propriedade p ON p.id_propriedade = t.id_propriedade
LEFT JOIN safra_talhao st ON st.id_propriedade = t.id_propriedade AND st.numero_talhao = t.numero_talhao
LEFT JOIN carga c ON c.id_safra_talhao = st.id_safra_talhao
LEFT JOIN pesagem pes ON pes.id_carga = c.id_carga
GROUP BY p.id_propriedade, p.nome, t.numero_talhao
ORDER BY total_toneladas DESC, p.nome, t.numero_talhao;

-- Consulta 04 (Enunciado): Quais produtores tem pagamento pendente no periodo?
SELECT
    pag.id_pagamento,
    prod.nome AS produtor_beneficiario,
    pag.data_inicio_periodo,
    pag.data_fim_periodo,
    pag.status,
    COUNT(c.id_carga) AS qtd_cargas,
    ROUND(COALESCE(SUM((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000), 0), 2) AS toneladas_totais,
    ROUND(COALESCE(SUM(((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000) * COALESCE(an.atr_kg_ton, 140.00) * pr.valor_kg_atr), 0), 2) AS valor_estimado_rs
FROM pagamento pag
INNER JOIN produtor prod ON prod.id_produtor = pag.id_produtor
LEFT JOIN carga c ON c.id_pagamento = pag.id_pagamento
LEFT JOIN pesagem pes ON pes.id_carga = c.id_carga
LEFT JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref
LEFT JOIN amostra am ON am.id_carga = c.id_carga
LEFT JOIN analise an ON an.id_amostra = am.id_amostra
WHERE pag.status = 'PENDENTE'
  AND pag.data_inicio_periodo >= '2026-08-01'
  AND pag.data_fim_periodo <= '2026-09-30'
GROUP BY pag.id_pagamento, prod.nome, pag.data_inicio_periodo, pag.data_fim_periodo, pag.status
ORDER BY pag.data_inicio_periodo, prod.nome;

-- Consulta 05 (Enunciado): Qual transportadora movimentou mais volume no mes (agosto/2026)?
SELECT
    tr.razao_social AS transportadora,
    COUNT(c.id_carga) AS qtd_cargas,
    ROUND(SUM(pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas_movimentadas
FROM carga c
INNER JOIN pesagem pes ON pes.id_carga = c.id_carga
INNER JOIN caminhao cam ON cam.id_caminhao = c.id_caminhao
INNER JOIN transportadora tr ON tr.id_transportadora = cam.id_transportadora
WHERE c.data_entrada >= '2026-08-01 00:00:00'
  AND c.data_entrada < '2026-09-01 00:00:00'
GROUP BY tr.id_transportadora, tr.razao_social
ORDER BY toneladas_movimentadas DESC;

-- Consulta 06 (Grupo): Qual o calculo rastreavel do valor de cada carga analisada com o preco da quinzena?
SELECT
    c.numero_ticket,
    DATE(c.data_entrada) AS data_entrada,
    prod.nome AS produtor_beneficiario,
    ROUND((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas,
    an.atr_kg_ton,
    pr.quinzena_inicio,
    pr.valor_kg_atr,
    ROUND(((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000) * an.atr_kg_ton * pr.valor_kg_atr, 2) AS valor_calculado_rs
FROM carga c
INNER JOIN pesagem pes ON pes.id_carga = c.id_carga
INNER JOIN amostra am ON am.id_carga = c.id_carga
INNER JOIN analise an ON an.id_amostra = am.id_amostra
INNER JOIN preco_referencia pr ON pr.id_preco_ref = c.id_preco_ref
INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao
INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade
LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade
INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario)
ORDER BY c.data_entrada;

-- Consulta 07 (Grupo): Quais propriedades sao arrendadas, quem e o dono da terra e quem recebe o pagamento?
SELECT
    p.nome AS propriedade,
    p.municipio,
    pa.num_contrato,
    pa.data_inicio,
    pa.data_fim,
    dono.nome AS proprietario_terra,
    arrend.nome AS arrendatario_beneficiario
FROM propriedade p
INNER JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade
INNER JOIN produtor dono ON dono.id_produtor = p.id_produtor_proprietario
INNER JOIN produtor arrend ON arrend.id_produtor = pa.id_produtor_arrendatario
ORDER BY p.nome;

-- Consulta 08 (Grupo): Quais produtores associados ainda nao possuem nenhuma carga entregue?
SELECT
    prod.id_produtor,
    prod.nome,
    prod.cpf_cnpj,
    prod.data_associacao
FROM produtor prod
LEFT JOIN (
    SELECT DISTINCT COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario) AS id_produtor
    FROM carga c
    INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao
    INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade
    LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade
) entregas ON entregas.id_produtor = prod.id_produtor
WHERE entregas.id_produtor IS NULL
ORDER BY prod.nome;

-- Consulta 09 (Grupo): Qual o volume entregue e a media de ATR por variedade de cana na safra 2026/2027?
SELECT
    st.variedade_cana,
    COUNT(c.id_carga) AS qtd_cargas,
    ROUND(SUM(pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS total_toneladas,
    ROUND(AVG(an.atr_kg_ton), 2) AS media_atr
FROM safra_talhao st
INNER JOIN safra s ON s.id_safra = st.id_safra
INNER JOIN carga c ON c.id_safra_talhao = st.id_safra_talhao
INNER JOIN pesagem pes ON pes.id_carga = c.id_carga
LEFT JOIN amostra am ON am.id_carga = c.id_carga
LEFT JOIN analise an ON an.id_amostra = am.id_amostra
WHERE s.codigo_safra = '2026/2027'
GROUP BY st.variedade_cana
ORDER BY total_toneladas DESC;

-- Consulta 10 (Grupo): Quais cargas recebidas ainda nao foram vinculadas a nenhum pagamento?
SELECT
    c.numero_ticket,
    c.data_entrada,
    p.nome AS propriedade,
    st.numero_talhao,
    prod.nome AS produtor_beneficiario,
    ROUND((pes.peso_bruto_kg - pes.peso_tara_kg) / 1000, 2) AS toneladas
FROM carga c
INNER JOIN pesagem pes ON pes.id_carga = c.id_carga
INNER JOIN safra_talhao st ON st.id_safra_talhao = c.id_safra_talhao
INNER JOIN propriedade p ON p.id_propriedade = st.id_propriedade
LEFT JOIN propriedade_arrendada pa ON pa.id_propriedade = p.id_propriedade
INNER JOIN produtor prod ON prod.id_produtor = COALESCE(pa.id_produtor_arrendatario, p.id_produtor_proprietario)
WHERE c.id_pagamento IS NULL
ORDER BY c.data_entrada;
