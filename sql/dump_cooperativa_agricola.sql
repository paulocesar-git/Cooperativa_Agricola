/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19  Distrib 10.11.16-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: cooperativa_agricola
-- ------------------------------------------------------
-- Server version	10.11.16-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `cooperativa_agricola`
--

/*!40000 DROP DATABASE IF EXISTS `cooperativa_agricola`*/;

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `cooperativa_agricola` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `cooperativa_agricola`;

--
-- Table structure for table `amostra`
--

DROP TABLE IF EXISTS `amostra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `amostra` (
  `id_amostra` int(11) NOT NULL AUTO_INCREMENT,
  `id_carga` int(11) NOT NULL,
  `codigo_etiqueta` varchar(30) NOT NULL,
  `data_hora_coleta` datetime NOT NULL,
  `peso_amostra_kg` decimal(6,2) NOT NULL,
  `coletor` varchar(80) NOT NULL,
  PRIMARY KEY (`id_amostra`),
  UNIQUE KEY `id_carga` (`id_carga`),
  UNIQUE KEY `codigo_etiqueta` (`codigo_etiqueta`),
  CONSTRAINT `fk_amostra_carga` FOREIGN KEY (`id_carga`) REFERENCES `carga` (`id_carga`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `chk_amostra_peso` CHECK (`peso_amostra_kg` > 0)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `amostra`
--

LOCK TABLES `amostra` WRITE;
/*!40000 ALTER TABLE `amostra` DISABLE KEYS */;
INSERT INTO `amostra` VALUES
(1,1,'AM-2025-001','2025-07-05 08:25:00',12.50,'Joao Pedro'),
(2,2,'AM-2025-002','2025-07-18 09:40:00',11.80,'Joao Pedro'),
(3,3,'AM-2025-003','2025-07-20 10:20:00',13.00,'Carla Souza'),
(4,4,'AM-2025-004','2025-08-04 08:00:00',12.20,'Joao Pedro'),
(5,5,'AM-2025-005','2025-08-19 14:30:00',12.90,'Carla Souza'),
(6,6,'AM-2025-006','2025-08-22 11:10:00',11.50,'Rafael Lima'),
(7,8,'AM-2026-001','2026-07-03 08:10:00',12.40,'Joao Pedro'),
(8,9,'AM-2026-002','2026-07-12 09:25:00',12.10,'Carla Souza'),
(9,10,'AM-2026-003','2026-07-21 10:40:00',13.20,'Rafael Lima'),
(10,11,'AM-2026-004','2026-07-25 13:20:00',12.00,'Joao Pedro'),
(11,12,'AM-2026-005','2026-08-02 08:00:00',12.60,'Carla Souza'),
(12,14,'AM-2026-006','2026-08-08 10:15:00',11.90,'Rafael Lima'),
(13,15,'AM-2026-007','2026-08-10 11:35:00',12.80,'Joao Pedro'),
(14,16,'AM-2026-008','2026-08-14 14:25:00',12.30,'Carla Souza'),
(15,17,'AM-2026-009','2026-08-18 09:15:00',12.70,'Rafael Lima'),
(16,20,'AM-2026-010','2026-09-03 08:30:00',13.10,'Joao Pedro'),
(17,21,'AM-2026-011','2026-09-07 10:55:00',12.00,'Carla Souza'),
(18,23,'AM-2026-012','2026-09-18 10:00:00',11.70,'Rafael Lima');
/*!40000 ALTER TABLE `amostra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `analise`
--

DROP TABLE IF EXISTS `analise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `analise` (
  `id_analise` int(11) NOT NULL AUTO_INCREMENT,
  `id_amostra` int(11) NOT NULL,
  `data_hora_analise` datetime NOT NULL,
  `brix` decimal(5,2) NOT NULL,
  `pol` decimal(5,2) NOT NULL,
  `impureza_pct` decimal(5,2) NOT NULL,
  `atr_kg_ton` decimal(6,2) NOT NULL,
  `tecnico_lab` varchar(80) NOT NULL,
  PRIMARY KEY (`id_analise`),
  UNIQUE KEY `id_amostra` (`id_amostra`),
  CONSTRAINT `fk_analise_amostra` FOREIGN KEY (`id_amostra`) REFERENCES `amostra` (`id_amostra`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `chk_analise_brix` CHECK (`brix` > 0),
  CONSTRAINT `chk_analise_pol` CHECK (`pol` > 0),
  CONSTRAINT `chk_analise_impureza` CHECK (`impureza_pct` >= 0 and `impureza_pct` <= 100),
  CONSTRAINT `chk_analise_atr` CHECK (`atr_kg_ton` > 0)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `analise`
--

LOCK TABLES `analise` WRITE;
/*!40000 ALTER TABLE `analise` DISABLE KEYS */;
INSERT INTO `analise` VALUES
(1,1,'2025-07-05 11:00:00',19.20,16.40,1.80,138.50,'Dra. Beatriz Campos'),
(2,2,'2025-07-18 12:15:00',19.80,16.95,1.50,142.30,'Dra. Beatriz Campos'),
(3,3,'2025-07-20 13:00:00',18.60,15.80,2.10,134.20,'Tec. Henrique Prado'),
(4,4,'2025-08-04 11:30:00',20.10,17.30,1.40,146.80,'Dra. Beatriz Campos'),
(5,5,'2025-08-19 16:40:00',20.40,17.60,1.20,149.10,'Tec. Henrique Prado'),
(6,6,'2025-08-22 14:00:00',19.50,16.70,1.70,140.60,'Dra. Beatriz Campos'),
(7,7,'2026-07-03 11:15:00',19.60,16.80,1.60,141.50,'Dra. Beatriz Campos'),
(8,8,'2026-07-12 12:00:00',20.00,17.10,1.50,144.20,'Tec. Henrique Prado'),
(9,9,'2026-07-21 13:30:00',18.90,16.10,2.00,136.40,'Dra. Beatriz Campos'),
(10,10,'2026-07-25 16:00:00',19.70,16.85,1.65,142.00,'Tec. Henrique Prado'),
(11,11,'2026-08-02 11:45:00',20.60,17.80,1.10,151.40,'Dra. Beatriz Campos'),
(12,12,'2026-08-08 13:15:00',19.10,16.25,1.90,137.90,'Tec. Henrique Prado'),
(13,13,'2026-08-10 14:30:00',20.80,18.00,1.05,153.20,'Dra. Beatriz Campos'),
(14,14,'2026-08-14 16:45:00',19.90,17.05,1.45,143.80,'Tec. Henrique Prado'),
(15,15,'2026-08-18 12:30:00',20.20,17.40,1.30,147.60,'Dra. Beatriz Campos');
/*!40000 ALTER TABLE `analise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caminhao`
--

DROP TABLE IF EXISTS `caminhao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `caminhao` (
  `id_caminhao` int(11) NOT NULL AUTO_INCREMENT,
  `id_transportadora` int(11) NOT NULL,
  `placa` varchar(10) NOT NULL,
  `modelo` varchar(60) NOT NULL,
  `tara_padrao_kg` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_caminhao`),
  UNIQUE KEY `placa` (`placa`),
  KEY `fk_cam_transportadora` (`id_transportadora`),
  CONSTRAINT `fk_cam_transportadora` FOREIGN KEY (`id_transportadora`) REFERENCES `transportadora` (`id_transportadora`) ON UPDATE CASCADE,
  CONSTRAINT `chk_cam_tara` CHECK (`tara_padrao_kg` > 0)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caminhao`
--

LOCK TABLES `caminhao` WRITE;
/*!40000 ALTER TABLE `caminhao` DISABLE KEYS */;
INSERT INTO `caminhao` VALUES
(1,1,'ABC1D23','Volvo FH 540 Rodotrem',24500.00),
(2,1,'BCD2E34','Scania R500 Bitrem',21800.00),
(3,2,'CDE3F45','Mercedes Axor 3344',23000.00),
(4,2,'DEF4G56','Volvo FMX 500',22500.00),
(5,3,'EFG5H67','Scania G450 Canavieiro',21000.00),
(6,4,'FGH6I78','DAF XF 530',23800.00),
(7,5,'GHI7J89','Mercedes Actros 2651',22000.00),
(8,6,'HIJ8K90','Volvo FH 460',21500.00),
(9,7,'IJK9L01','Iveco Hi-Way 480',21200.00),
(10,8,'JKL0M12','Scania R540 Rodotrem',24800.00),
(11,9,'KLM1N23','Mercedes Axor 3344',22900.00),
(12,10,'LMN2O34','Volvo FH 540',24000.00);
/*!40000 ALTER TABLE `caminhao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carga`
--

DROP TABLE IF EXISTS `carga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `carga` (
  `id_carga` int(11) NOT NULL AUTO_INCREMENT,
  `numero_ticket` varchar(20) NOT NULL,
  `data_entrada` datetime NOT NULL,
  `id_safra_talhao` int(11) NOT NULL,
  `id_caminhao` int(11) NOT NULL,
  `id_motorista` int(11) NOT NULL,
  `id_preco_ref` int(11) NOT NULL,
  `id_pagamento` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_carga`),
  UNIQUE KEY `numero_ticket` (`numero_ticket`),
  KEY `fk_carga_safra_talhao` (`id_safra_talhao`),
  KEY `fk_carga_caminhao` (`id_caminhao`),
  KEY `fk_carga_motorista` (`id_motorista`),
  KEY `fk_carga_preco` (`id_preco_ref`),
  KEY `fk_carga_pagamento` (`id_pagamento`),
  CONSTRAINT `fk_carga_caminhao` FOREIGN KEY (`id_caminhao`) REFERENCES `caminhao` (`id_caminhao`) ON UPDATE CASCADE,
  CONSTRAINT `fk_carga_motorista` FOREIGN KEY (`id_motorista`) REFERENCES `motorista` (`id_motorista`) ON UPDATE CASCADE,
  CONSTRAINT `fk_carga_pagamento` FOREIGN KEY (`id_pagamento`) REFERENCES `pagamento` (`id_pagamento`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_carga_preco` FOREIGN KEY (`id_preco_ref`) REFERENCES `preco_referencia` (`id_preco_ref`) ON UPDATE CASCADE,
  CONSTRAINT `fk_carga_safra_talhao` FOREIGN KEY (`id_safra_talhao`) REFERENCES `safra_talhao` (`id_safra_talhao`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carga`
--

LOCK TABLES `carga` WRITE;
/*!40000 ALTER TABLE `carga` DISABLE KEYS */;
INSERT INTO `carga` VALUES
(1,'TK-2025-0001','2025-07-05 08:15:00',1,1,1,1,1),
(2,'TK-2025-0002','2025-07-18 09:30:00',2,2,2,2,1),
(3,'TK-2025-0003','2025-07-20 10:10:00',7,3,3,2,2),
(4,'TK-2025-0004','2025-08-04 07:45:00',10,1,1,3,3),
(5,'TK-2025-0005','2025-08-19 14:20:00',11,4,4,4,3),
(6,'TK-2025-0006','2025-08-22 11:00:00',4,5,5,4,4),
(7,'TK-2025-0007','2025-08-25 15:40:00',6,2,2,4,4),
(8,'TK-2026-0001','2026-07-03 08:00:00',13,1,1,7,5),
(9,'TK-2026-0002','2026-07-12 09:15:00',14,2,2,7,5),
(10,'TK-2026-0003','2026-07-21 10:30:00',18,3,3,8,6),
(11,'TK-2026-0004','2026-07-25 13:10:00',21,6,6,8,7),
(12,'TK-2026-0005','2026-08-02 07:50:00',13,1,1,9,8),
(13,'TK-2026-0006','2026-08-06 08:40:00',15,2,2,9,8),
(14,'TK-2026-0007','2026-08-08 10:00:00',19,3,3,9,9),
(15,'TK-2026-0008','2026-08-10 11:25:00',20,1,2,9,10),
(16,'TK-2026-0009','2026-08-14 14:15:00',16,4,4,9,11),
(17,'TK-2026-0010','2026-08-18 09:05:00',17,1,1,10,11),
(18,'TK-2026-0011','2026-08-21 15:30:00',20,5,5,10,10),
(19,'TK-2026-0012','2026-08-26 16:00:00',19,7,7,10,9),
(20,'TK-2026-0013','2026-09-03 08:20:00',24,8,8,11,12),
(21,'TK-2026-0014','2026-09-07 10:45:00',24,9,9,11,12),
(22,'TK-2026-0015','2026-09-12 13:30:00',22,10,10,11,NULL),
(23,'TK-2026-0016','2026-09-18 09:50:00',23,11,11,12,NULL),
(24,'TK-2026-0017','2026-09-22 14:10:00',13,1,1,12,NULL),
(25,'TK-2026-0018','2026-09-25 16:20:00',18,3,4,12,NULL);
/*!40000 ALTER TABLE `carga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motorista`
--

DROP TABLE IF EXISTS `motorista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `motorista` (
  `id_motorista` int(11) NOT NULL AUTO_INCREMENT,
  `id_transportadora` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `cnh` varchar(20) NOT NULL,
  PRIMARY KEY (`id_motorista`),
  UNIQUE KEY `cpf` (`cpf`),
  UNIQUE KEY `cnh` (`cnh`),
  KEY `fk_mot_transportadora` (`id_transportadora`),
  CONSTRAINT `fk_mot_transportadora` FOREIGN KEY (`id_transportadora`) REFERENCES `transportadora` (`id_transportadora`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motorista`
--

LOCK TABLES `motorista` WRITE;
/*!40000 ALTER TABLE `motorista` DISABLE KEYS */;
INSERT INTO `motorista` VALUES
(1,1,'Carlos Eduardo Ribeiro','111.222.333-01','CNH-100001'),
(2,1,'Sergio Luiz Barbosa','111.222.333-02','CNH-100002'),
(3,2,'Anderson Gomes Vieira','111.222.333-03','CNH-100003'),
(4,2,'Renato Cesar Moraes','111.222.333-04','CNH-100004'),
(5,3,'Gilberto Teixeira Dias','111.222.333-05','CNH-100005'),
(6,4,'Fabio Augusto Cardoso','111.222.333-06','CNH-100006'),
(7,5,'Marcelo Henrique Pinto','111.222.333-07','CNH-100007'),
(8,6,'Rodrigo Batista Nunes','111.222.333-08','CNH-100008'),
(9,7,'Valdir Jose Santana','111.222.333-09','CNH-100009'),
(10,8,'Cleber Antonio Ramos','111.222.333-10','CNH-100010'),
(11,9,'Everton Paulo Correia','111.222.333-11','CNH-100011'),
(12,10,'Thiago Fernando Duarte','111.222.333-12','CNH-100012');
/*!40000 ALTER TABLE `motorista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamento` (
  `id_pagamento` int(11) NOT NULL AUTO_INCREMENT,
  `id_produtor` int(11) NOT NULL,
  `data_inicio_periodo` date NOT NULL,
  `data_fim_periodo` date NOT NULL,
  `status` varchar(15) NOT NULL DEFAULT 'PENDENTE',
  `data_pagamento` date DEFAULT NULL,
  PRIMARY KEY (`id_pagamento`),
  KEY `fk_pag_produtor` (`id_produtor`),
  CONSTRAINT `fk_pag_produtor` FOREIGN KEY (`id_produtor`) REFERENCES `produtor` (`id_produtor`) ON UPDATE CASCADE,
  CONSTRAINT `chk_pag_periodo` CHECK (`data_fim_periodo` >= `data_inicio_periodo`),
  CONSTRAINT `chk_pag_status` CHECK (`status` in ('PENDENTE','PAGO')),
  CONSTRAINT `chk_pag_data_status` CHECK (`status` = 'PAGO' and `data_pagamento` is not null or `status` = 'PENDENTE' and `data_pagamento` is null)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamento`
--

LOCK TABLES `pagamento` WRITE;
/*!40000 ALTER TABLE `pagamento` DISABLE KEYS */;
INSERT INTO `pagamento` VALUES
(1,1,'2025-07-01','2025-07-31','PAGO','2025-08-05'),
(2,2,'2025-07-01','2025-07-31','PAGO','2025-08-05'),
(3,4,'2025-08-01','2025-08-31','PAGO','2025-09-05'),
(4,5,'2025-08-01','2025-08-31','PAGO','2025-09-05'),
(5,1,'2026-07-01','2026-07-31','PAGO','2026-08-05'),
(6,2,'2026-07-01','2026-07-31','PAGO','2026-08-05'),
(7,6,'2026-07-01','2026-07-31','PAGO','2026-08-05'),
(8,1,'2026-08-01','2026-08-31','PENDENTE',NULL),
(9,3,'2026-08-01','2026-08-31','PENDENTE',NULL),
(10,4,'2026-08-01','2026-08-31','PENDENTE',NULL),
(11,5,'2026-08-01','2026-08-31','PENDENTE',NULL),
(12,7,'2026-09-01','2026-09-30','PENDENTE',NULL);
/*!40000 ALTER TABLE `pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pesagem`
--

DROP TABLE IF EXISTS `pesagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `pesagem` (
  `id_carga` int(11) NOT NULL,
  `data_hora_entrada` datetime NOT NULL,
  `data_hora_saida` datetime NOT NULL,
  `peso_bruto_kg` decimal(10,2) NOT NULL,
  `peso_tara_kg` decimal(10,2) NOT NULL,
  `balanca` varchar(30) NOT NULL,
  PRIMARY KEY (`id_carga`),
  CONSTRAINT `fk_pesagem_carga` FOREIGN KEY (`id_carga`) REFERENCES `carga` (`id_carga`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `chk_pes_bruto` CHECK (`peso_bruto_kg` > 0),
  CONSTRAINT `chk_pes_tara` CHECK (`peso_tara_kg` > 0),
  CONSTRAINT `chk_pes_liquido` CHECK (`peso_bruto_kg` > `peso_tara_kg`),
  CONSTRAINT `chk_pes_horario` CHECK (`data_hora_saida` >= `data_hora_entrada`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pesagem`
--

LOCK TABLES `pesagem` WRITE;
/*!40000 ALTER TABLE `pesagem` DISABLE KEYS */;
INSERT INTO `pesagem` VALUES
(1,'2025-07-05 08:15:00','2025-07-05 08:50:00',72500.00,24500.00,'Balanca 01'),
(2,'2025-07-18 09:30:00','2025-07-18 10:05:00',61800.00,21800.00,'Balanca 01'),
(3,'2025-07-20 10:10:00','2025-07-20 10:40:00',65000.00,23000.00,'Balanca 02'),
(4,'2025-08-04 07:45:00','2025-08-04 08:25:00',74500.00,24500.00,'Balanca 01'),
(5,'2025-08-19 14:20:00','2025-08-19 14:55:00',64500.00,22500.00,'Balanca 02'),
(6,'2025-08-22 11:00:00','2025-08-22 11:35:00',59000.00,21000.00,'Balanca 01'),
(7,'2025-08-25 15:40:00','2025-08-25 16:10:00',62800.00,21800.00,'Balanca 02'),
(8,'2026-07-03 08:00:00','2026-07-03 08:35:00',73500.00,24500.00,'Balanca 01'),
(9,'2026-07-12 09:15:00','2026-07-12 09:50:00',63800.00,21800.00,'Balanca 01'),
(10,'2026-07-21 10:30:00','2026-07-21 11:05:00',66000.00,23000.00,'Balanca 02'),
(11,'2026-07-25 13:10:00','2026-07-25 13:45:00',68800.00,23800.00,'Balanca 01'),
(12,'2026-08-02 07:50:00','2026-08-02 08:30:00',75500.00,24500.00,'Balanca 01'),
(13,'2026-08-06 08:40:00','2026-08-06 09:15:00',64800.00,21800.00,'Balanca 02'),
(14,'2026-08-08 10:00:00','2026-08-08 10:35:00',63000.00,23000.00,'Balanca 01'),
(15,'2026-08-10 11:25:00','2026-08-10 12:00:00',74500.00,24500.00,'Balanca 01'),
(16,'2026-08-14 14:15:00','2026-08-14 14:50:00',64500.00,22500.00,'Balanca 02'),
(17,'2026-08-18 09:05:00','2026-08-18 09:40:00',71500.00,24500.00,'Balanca 01'),
(18,'2026-08-21 15:30:00','2026-08-21 16:05:00',60000.00,21000.00,'Balanca 02'),
(19,'2026-08-26 16:00:00','2026-08-26 16:30:00',61000.00,22000.00,'Balanca 01'),
(20,'2026-09-03 08:20:00','2026-09-03 08:55:00',65500.00,21500.00,'Balanca 01'),
(21,'2026-09-07 10:45:00','2026-09-07 11:20:00',64200.00,21200.00,'Balanca 02'),
(22,'2026-09-12 13:30:00','2026-09-12 14:05:00',72800.00,24800.00,'Balanca 01'),
(23,'2026-09-18 09:50:00','2026-09-18 10:25:00',62900.00,22900.00,'Balanca 02'),
(24,'2026-09-22 14:10:00','2026-09-22 14:45:00',73500.00,24500.00,'Balanca 01'),
(25,'2026-09-25 16:20:00','2026-09-25 16:55:00',67000.00,23000.00,'Balanca 02');
/*!40000 ALTER TABLE `pesagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preco_referencia`
--

DROP TABLE IF EXISTS `preco_referencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `preco_referencia` (
  `id_preco_ref` int(11) NOT NULL AUTO_INCREMENT,
  `id_safra` int(11) NOT NULL,
  `quinzena_inicio` date NOT NULL,
  `quinzena_fim` date NOT NULL,
  `valor_kg_atr` decimal(10,4) NOT NULL,
  PRIMARY KEY (`id_preco_ref`),
  UNIQUE KEY `uq_preco_safra_quinzena` (`id_safra`,`quinzena_inicio`),
  CONSTRAINT `fk_preco_safra` FOREIGN KEY (`id_safra`) REFERENCES `safra` (`id_safra`) ON UPDATE CASCADE,
  CONSTRAINT `chk_preco_datas` CHECK (`quinzena_fim` >= `quinzena_inicio`),
  CONSTRAINT `chk_preco_valor` CHECK (`valor_kg_atr` > 0)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preco_referencia`
--

LOCK TABLES `preco_referencia` WRITE;
/*!40000 ALTER TABLE `preco_referencia` DISABLE KEYS */;
INSERT INTO `preco_referencia` VALUES
(1,9,'2025-07-01','2025-07-15',1.1250),
(2,9,'2025-07-16','2025-07-31',1.1400),
(3,9,'2025-08-01','2025-08-15',1.1580),
(4,9,'2025-08-16','2025-08-31',1.1720),
(5,9,'2025-09-01','2025-09-15',1.1650),
(6,9,'2025-09-16','2025-09-30',1.1800),
(7,10,'2026-07-01','2026-07-15',1.2100),
(8,10,'2026-07-16','2026-07-31',1.2250),
(9,10,'2026-08-01','2026-08-15',1.2400),
(10,10,'2026-08-16','2026-08-31',1.2550),
(11,10,'2026-09-01','2026-09-15',1.2680),
(12,10,'2026-09-16','2026-09-30',1.2800);
/*!40000 ALTER TABLE `preco_referencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produtor`
--

DROP TABLE IF EXISTS `produtor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `produtor` (
  `id_produtor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `cpf_cnpj` varchar(18) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `data_associacao` date NOT NULL,
  PRIMARY KEY (`id_produtor`),
  UNIQUE KEY `cpf_cnpj` (`cpf_cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produtor`
--

LOCK TABLES `produtor` WRITE;
/*!40000 ALTER TABLE `produtor` DISABLE KEYS */;
INSERT INTO `produtor` VALUES
(1,'Jose Carlos Oliveira','123.456.789-01','jose.oliveira@email.com','2018-03-15'),
(2,'Maria Aparecida Santos','234.567.890-12','maria.santos@email.com','2019-05-20'),
(3,'Antonio Ferreira Lima','345.678.901-23','antonio.lima@email.com','2017-11-10'),
(4,'Agropecuaria Boa Vista Ltda','12.345.678/0001-90','contato@boavista.com.br','2016-02-01'),
(5,'Paulo Henrique Costa','456.789.012-34','paulo.costa@email.com','2020-08-12'),
(6,'Luciana Mendes Rocha','567.890.123-45','luciana.rocha@email.com','2021-01-25'),
(7,'Fazenda Santa Rita S/A','23.456.789/0001-01','adm@santarita.com.br','2015-09-05'),
(8,'Roberto Alves Pereira','678.901.234-56','roberto.pereira@email.com','2022-04-18'),
(9,'Marcos Vinicius Souza','789.012.345-67','marcos.souza@email.com','2020-06-30'),
(10,'Claudia Regina Martins','890.123.456-78','claudia.martins@email.com','2023-02-14'),
(11,'Eduardo Nogueira Silva','901.234.567-89','eduardo.silva@email.com','2024-03-10'),
(12,'Fernanda Dias Almeida','012.345.678-90','fernanda.almeida@email.com','2026-01-20');
/*!40000 ALTER TABLE `produtor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produtor_telefone`
--

DROP TABLE IF EXISTS `produtor_telefone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `produtor_telefone` (
  `id_produtor` int(11) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  PRIMARY KEY (`id_produtor`,`telefone`),
  CONSTRAINT `fk_tel_produtor` FOREIGN KEY (`id_produtor`) REFERENCES `produtor` (`id_produtor`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produtor_telefone`
--

LOCK TABLES `produtor_telefone` WRITE;
/*!40000 ALTER TABLE `produtor_telefone` DISABLE KEYS */;
INSERT INTO `produtor_telefone` VALUES
(1,'(16) 3611-1001'),
(1,'(16) 99111-1001'),
(2,'(16) 99222-2002'),
(3,'(16) 3633-3003'),
(3,'(16) 99333-3003'),
(4,'(16) 3644-4004'),
(4,'(16) 99444-4004'),
(5,'(16) 99555-5005'),
(6,'(16) 99666-6006'),
(7,'(16) 3677-7007'),
(7,'(16) 99777-7007'),
(8,'(16) 99888-8008'),
(9,'(16) 99999-9009'),
(10,'(16) 98111-1010'),
(11,'(16) 98222-2011'),
(12,'(16) 98333-3012');
/*!40000 ALTER TABLE `produtor_telefone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propriedade`
--

DROP TABLE IF EXISTS `propriedade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `propriedade` (
  `id_propriedade` int(11) NOT NULL AUTO_INCREMENT,
  `id_produtor_proprietario` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `area_total_ha` decimal(10,2) NOT NULL,
  `municipio` varchar(80) NOT NULL,
  `uf` char(2) NOT NULL,
  `estrada_acesso` varchar(120) NOT NULL,
  `tipo_posse` varchar(10) NOT NULL,
  PRIMARY KEY (`id_propriedade`),
  KEY `fk_prop_proprietario` (`id_produtor_proprietario`),
  CONSTRAINT `fk_prop_proprietario` FOREIGN KEY (`id_produtor_proprietario`) REFERENCES `produtor` (`id_produtor`) ON UPDATE CASCADE,
  CONSTRAINT `chk_prop_area` CHECK (`area_total_ha` > 0),
  CONSTRAINT `chk_prop_tipo` CHECK (`tipo_posse` in ('PROPRIA','ARRENDADA'))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propriedade`
--

LOCK TABLES `propriedade` WRITE;
/*!40000 ALTER TABLE `propriedade` DISABLE KEYS */;
INSERT INTO `propriedade` VALUES
(1,1,'Fazenda Sao Joao',250.00,'Ribeirao Preto','SP','Rodovia SP-330 km 312','PROPRIA'),
(2,1,'Sitio Agua Limpa',120.50,'Cravinhos','SP','Estrada Vicinal CRV-04','ARRENDADA'),
(3,2,'Fazenda Bela Vista',180.00,'Sertaozinho','SP','Rodovia SP-322 km 330','PROPRIA'),
(4,3,'Sitio Esperanca',95.00,'Jardinopolis','SP','Estrada do Morro Alto km 5','PROPRIA'),
(5,4,'Fazenda Boa Vista Matriz',640.00,'Jaboticabal','SP','Rodovia SP-333 km 118','PROPRIA'),
(6,4,'Fazenda Boa Vista Norte',310.00,'Guariba','SP','Estrada Municipal GRB-12','ARRENDADA'),
(7,5,'Estancia Primavera',145.00,'Batatais','SP','Rodovia Candido Portinari','PROPRIA'),
(8,6,'Sitio Palmeiras',110.00,'Pontal','SP','Estrada da Usina km 8','PROPRIA'),
(9,7,'Fazenda Santa Rita',520.00,'Pradopolis','SP','Rodovia SP-253 km 190','PROPRIA'),
(10,8,'Chacara Alvorada',85.00,'Dumont','SP','Estrada Vicinal DMT-02','ARRENDADA'),
(11,9,'Fazenda Tres Barras',200.00,'Barrinha','SP','Rodovia SP-255 km 22','PROPRIA'),
(12,10,'Sitio Ipê Amarelo',130.00,'Sertaozinho','SP','Estrada Vicinal STZ-09','ARRENDADA');
/*!40000 ALTER TABLE `propriedade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propriedade_arrendada`
--

DROP TABLE IF EXISTS `propriedade_arrendada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `propriedade_arrendada` (
  `id_propriedade` int(11) NOT NULL,
  `num_contrato` varchar(40) NOT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date NOT NULL,
  `id_produtor_arrendatario` int(11) NOT NULL,
  PRIMARY KEY (`id_propriedade`),
  UNIQUE KEY `num_contrato` (`num_contrato`),
  KEY `fk_prop_arrendatario` (`id_produtor_arrendatario`),
  CONSTRAINT `fk_prop_arrendada` FOREIGN KEY (`id_propriedade`) REFERENCES `propriedade` (`id_propriedade`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_prop_arrendatario` FOREIGN KEY (`id_produtor_arrendatario`) REFERENCES `produtor` (`id_produtor`) ON UPDATE CASCADE,
  CONSTRAINT `chk_arrend_datas` CHECK (`data_fim` >= `data_inicio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propriedade_arrendada`
--

LOCK TABLES `propriedade_arrendada` WRITE;
/*!40000 ALTER TABLE `propriedade_arrendada` DISABLE KEYS */;
INSERT INTO `propriedade_arrendada` VALUES
(2,'CTR-2024-001','2024-04-01','2028-03-31',5),
(6,'CTR-2024-002','2024-05-01','2029-04-30',6),
(10,'CTR-2025-003','2025-01-01','2027-12-31',9),
(12,'CTR-2025-004','2025-03-01','2028-02-28',11);
/*!40000 ALTER TABLE `propriedade_arrendada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propriedade_propria`
--

DROP TABLE IF EXISTS `propriedade_propria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `propriedade_propria` (
  `id_propriedade` int(11) NOT NULL,
  `matricula_imovel` varchar(40) NOT NULL,
  PRIMARY KEY (`id_propriedade`),
  UNIQUE KEY `matricula_imovel` (`matricula_imovel`),
  CONSTRAINT `fk_prop_propria` FOREIGN KEY (`id_propriedade`) REFERENCES `propriedade` (`id_propriedade`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propriedade_propria`
--

LOCK TABLES `propriedade_propria` WRITE;
/*!40000 ALTER TABLE `propriedade_propria` DISABLE KEYS */;
INSERT INTO `propriedade_propria` VALUES
(1,'MAT-1001-RP'),
(3,'MAT-2003-STZ'),
(4,'MAT-3004-JRD'),
(5,'MAT-4005-JBT'),
(7,'MAT-5007-BTT'),
(8,'MAT-6008-PNT'),
(9,'MAT-7009-PRD'),
(11,'MAT-9011-BRR');
/*!40000 ALTER TABLE `propriedade_propria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `safra`
--

DROP TABLE IF EXISTS `safra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `safra` (
  `id_safra` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_safra` varchar(15) NOT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date NOT NULL,
  `ativa` tinyint(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id_safra`),
  UNIQUE KEY `codigo_safra` (`codigo_safra`),
  CONSTRAINT `chk_safra_datas` CHECK (`data_fim` >= `data_inicio`),
  CONSTRAINT `chk_safra_ativa` CHECK (`ativa` in (0,1))
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `safra`
--

LOCK TABLES `safra` WRITE;
/*!40000 ALTER TABLE `safra` DISABLE KEYS */;
INSERT INTO `safra` VALUES
(1,'2017/2018','2017-04-01','2018-03-31',0),
(2,'2018/2019','2018-04-01','2019-03-31',0),
(3,'2019/2020','2019-04-01','2020-03-31',0),
(4,'2020/2021','2020-04-01','2021-03-31',0),
(5,'2021/2022','2021-04-01','2022-03-31',0),
(6,'2022/2023','2022-04-01','2023-03-31',0),
(7,'2023/2024','2023-04-01','2024-03-31',0),
(8,'2024/2025','2024-04-01','2025-03-31',0),
(9,'2025/2026','2025-04-01','2026-03-31',0),
(10,'2026/2027','2026-04-01','2027-03-31',1);
/*!40000 ALTER TABLE `safra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `safra_talhao`
--

DROP TABLE IF EXISTS `safra_talhao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `safra_talhao` (
  `id_safra_talhao` int(11) NOT NULL AUTO_INCREMENT,
  `id_propriedade` int(11) NOT NULL,
  `numero_talhao` int(11) NOT NULL,
  `id_safra` int(11) NOT NULL,
  `variedade_cana` varchar(50) NOT NULL,
  `estagio_corte` int(11) NOT NULL,
  PRIMARY KEY (`id_safra_talhao`),
  UNIQUE KEY `uq_safra_talhao` (`id_propriedade`,`numero_talhao`,`id_safra`),
  KEY `fk_st_safra` (`id_safra`),
  CONSTRAINT `fk_st_safra` FOREIGN KEY (`id_safra`) REFERENCES `safra` (`id_safra`) ON UPDATE CASCADE,
  CONSTRAINT `fk_st_talhao` FOREIGN KEY (`id_propriedade`, `numero_talhao`) REFERENCES `talhao` (`id_propriedade`, `numero_talhao`) ON UPDATE CASCADE,
  CONSTRAINT `chk_st_corte` CHECK (`estagio_corte` > 0)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `safra_talhao`
--

LOCK TABLES `safra_talhao` WRITE;
/*!40000 ALTER TABLE `safra_talhao` DISABLE KEYS */;
INSERT INTO `safra_talhao` VALUES
(1,1,1,9,'RB867515',2),
(2,1,2,9,'CTC4',3),
(3,1,3,9,'SP81-3250',1),
(4,2,1,9,'RB966928',2),
(5,2,2,9,'RB867515',1),
(6,2,3,9,'CTC9001',2),
(7,3,1,9,'CTC4',2),
(8,3,2,9,'RB966928',3),
(9,4,1,9,'RB867515',4),
(10,5,1,9,'CTC9001',1),
(11,5,2,9,'RB966928',2),
(12,6,1,9,'CTC4',2),
(13,1,1,10,'RB867515',3),
(14,1,2,10,'CTC4',4),
(15,1,3,10,'SP81-3250',2),
(16,2,1,10,'RB966928',3),
(17,2,3,10,'CTC9001',3),
(18,3,1,10,'CTC4',3),
(19,4,1,10,'RB867515',5),
(20,5,1,10,'CTC9001',2),
(21,6,1,10,'CTC4',3),
(22,7,1,10,'RB867515',1),
(23,8,1,10,'RB966928',2),
(24,9,1,10,'CTC4',1);
/*!40000 ALTER TABLE `safra_talhao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `talhao`
--

DROP TABLE IF EXISTS `talhao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `talhao` (
  `id_propriedade` int(11) NOT NULL,
  `numero_talhao` int(11) NOT NULL,
  `area_ha` decimal(10,2) NOT NULL,
  `tipo_solo` varchar(50) NOT NULL,
  PRIMARY KEY (`id_propriedade`,`numero_talhao`),
  CONSTRAINT `fk_talhao_propriedade` FOREIGN KEY (`id_propriedade`) REFERENCES `propriedade` (`id_propriedade`) ON UPDATE CASCADE,
  CONSTRAINT `chk_talhao_num` CHECK (`numero_talhao` > 0),
  CONSTRAINT `chk_talhao_area` CHECK (`area_ha` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `talhao`
--

LOCK TABLES `talhao` WRITE;
/*!40000 ALTER TABLE `talhao` DISABLE KEYS */;
INSERT INTO `talhao` VALUES
(1,1,60.00,'Latossolo Vermelho'),
(1,2,55.00,'Latossolo Vermelho'),
(1,3,45.00,'Argissolo'),
(2,1,40.00,'Latossolo Amarelo'),
(2,2,35.00,'Latossolo Amarelo'),
(2,3,30.00,'Argissolo'),
(3,1,70.00,'Latossolo Vermelho'),
(3,2,65.00,'Latossolo Vermelho'),
(4,1,50.00,'Nitossolo'),
(5,1,120.00,'Latossolo Vermelho'),
(5,2,110.00,'Latossolo Vermelho'),
(6,1,90.00,'Argissolo'),
(7,1,60.00,'Latossolo Amarelo'),
(8,1,55.00,'Nitossolo'),
(9,1,130.00,'Latossolo Vermelho'),
(11,1,80.00,'Latossolo Vermelho');
/*!40000 ALTER TABLE `talhao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transportadora`
--

DROP TABLE IF EXISTS `transportadora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `transportadora` (
  `id_transportadora` int(11) NOT NULL AUTO_INCREMENT,
  `razao_social` varchar(100) NOT NULL,
  `cnpj` varchar(18) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  PRIMARY KEY (`id_transportadora`),
  UNIQUE KEY `cnpj` (`cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transportadora`
--

LOCK TABLES `transportadora` WRITE;
/*!40000 ALTER TABLE `transportadora` DISABLE KEYS */;
INSERT INTO `transportadora` VALUES
(1,'TransCana Express Ltda','31.111.111/0001-11','(16) 3511-1100'),
(2,'Rodoviario Cerrado Ltda','32.222.222/0001-22','(16) 3522-2200'),
(3,'Transportes Vale Verde S/A','33.333.333/0001-33','(16) 3533-3300'),
(4,'AgroFrete Paulista Ltda','34.444.444/0001-44','(16) 3544-4400'),
(5,'Expresso Canavieiro Ltda','35.555.555/0001-55','(16) 3555-5500'),
(6,'Rota Agricola Transportes','36.666.666/0001-66','(16) 3566-6600'),
(7,'Logistica Interior SP Ltda','37.777.777/0001-77','(16) 3577-7700'),
(8,'TransSafra Cargas Pesadas','38.888.888/0001-88','(16) 3588-8800'),
(9,'Frota Rural Ribeirao Ltda','39.999.999/0001-99','(16) 3599-9900'),
(10,'Nova Rota Logistica Ltda','40.000.000/0001-00','(16) 3500-0010');
/*!40000 ALTER TABLE `transportadora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'cooperativa_agricola'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-27 11:55:33
