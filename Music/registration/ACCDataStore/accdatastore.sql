-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: accdatastore
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `forgotpassword1`
--

DROP TABLE IF EXISTS `forgotpassword1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `forgotpassword1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Token` varchar(200) DEFAULT NULL,
  `TokenStart` varchar(200) DEFAULT NULL,
  `TokenExpired` tinyint(4) DEFAULT NULL,
  `PasswordChanged` tinyint(4) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `forgotpassword1`
--

LOCK TABLES `forgotpassword1` WRITE;
/*!40000 ALTER TABLE `forgotpassword1` DISABLE KEYS */;
/*!40000 ALTER TABLE `forgotpassword1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Schoolpro` tinyint(1) DEFAULT NULL,
  `Datahub` tinyint(1) DEFAULT NULL,
  `Widerach` tinyint(1) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
INSERT INTO `request` VALUES (1,1,1,1,1),(2,1,1,0,2),(3,0,0,1,3),(4,0,0,1,4),(5,1,1,1,5),(6,1,1,1,6);
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `roles_view`
--

DROP TABLE IF EXISTS `roles_view`;
/*!50001 DROP VIEW IF EXISTS `roles_view`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `roles_view` AS SELECT 
 1 AS `USERID`,
 1 AS `test`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(200) DEFAULT NULL,
  `Fullname` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `IsAdministrator` text,
  `Enable` enum('Y','N') DEFAULT NULL,
  `Gender` enum('Male','Female') DEFAULT NULL,
  `Password1` varchar(200) DEFAULT NULL,
  `Occupation` varchar(50) DEFAULT NULL,
  `Organization` varchar(150) DEFAULT NULL,
  `Token` varchar(200) DEFAULT NULL,
  `TokenStart` varchar(200) DEFAULT NULL,
  `TokenExpired` tinyint(4) DEFAULT NULL,
  `EmailConfirmed` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Email_UNIQUE` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='Janny''s request))';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,NULL,'/oCKT5dAKAtIcN6puvdtOw==','testing','testing@testing.com',NULL,NULL,'Male','XzD6cLlKqrty9j1Z5S09Yw==','testing','testing','fWmwLvC1EgjDS+xuHZ4TZmA4zgHj3ap','fWmwLv/C1Eg=',0,0),(2,NULL,'q8KnxNBE2wrkvHsiVTI7+Q==','Hanan','admin@gmail.com',NULL,NULL,'Female','X7i/yU8qQA3lW+g4+0qUCQ==','Hanan','hanan','XuGRSJD1Ei8994sH00nRbZHzfrSaQtp','XuGRSJ/D1Eg=',0,1),(6,NULL,'lDM0o11cOgkZjmmJnv0FUw==','Samar','thuniya.alhabsi@gmail.com',NULL,NULL,'Female','Ga1hQ8qL2WLt0ATRrk8BFg==','Test','Test','1Qr1q3Y1EhfQcKe6U7dTLtJ5ENDwAM','1Qr1q+3Y1Eg=',0,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'accdatastore'
--
/*!50003 DROP PROCEDURE IF EXISTS `validate_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `validate_procedure`(in testemail char(20))
BEGIN
SELECT Email From users WHERE Email=testemail;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `roles_view`
--

/*!50001 DROP VIEW IF EXISTS `roles_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `roles_view` AS (select `request`.`UserID` AS `USERID`,(case when (`request`.`Schoolpro` = 1) then 'schoolpro' end) AS `test` from `request` where (`request`.`Schoolpro` is not null)) union all (select `request`.`UserID` AS `USERID`,(case when (`request`.`Datahub` = 1) then 'datahub' end) AS `test` from `request` where (`request`.`Datahub` is not null)) union all (select `request`.`UserID` AS `USERID`,(case when (`request`.`Widerach` = 1) then 'widerach' end) AS `test` from `request` where (`request`.`Widerach` is not null)) order by `USERID` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-08-08 22:38:20
