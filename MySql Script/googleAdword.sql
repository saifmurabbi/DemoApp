/*
SQLyog Trial v11.31 (64 bit)
MySQL - 5.6.15 : Database - googleadword
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`googleadword` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `googleadword`;

/*Table structure for table `keywords` */

DROP TABLE IF EXISTS `keywords`;

CREATE TABLE `keywords` (
  `ID_KeywordList` int(11) NOT NULL AUTO_INCREMENT,
  `Keyword` varchar(4000) DEFAULT NULL,
  `updateDate` date DEFAULT NULL,
  `ExpandParent` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_KeywordList`),
  KEY `ExpandParent` (`ExpandParent`),
  CONSTRAINT `Keywords_ibfk_1` FOREIGN KEY (`ExpandParent`) REFERENCES `keywords` (`ID_KeywordList`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `keywords` */

insert  into `keywords`(`ID_KeywordList`,`Keyword`,`updateDate`,`ExpandParent`) values (1,'handle','2014-01-16',1);

/*Table structure for table `keywordsmatrics` */

DROP TABLE IF EXISTS `keywordsmatrics`;

CREATE TABLE `keywordsmatrics` (
  `ID_KeywordMatrics` int(11) NOT NULL AUTO_INCREMENT,
  `Estimated_Average_CPC` varchar(255) DEFAULT NULL,
  `Estimated_Ad_Position` varchar(255) DEFAULT NULL,
  `Estimated_Daily_Clicks` varchar(255) DEFAULT NULL,
  `Estimated_Daily_Costs` varchar(255) DEFAULT NULL,
  `FK_KeywordsList` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_KeywordMatrics`),
  KEY `FK_KeywordList` (`Estimated_Ad_Position`)
) ENGINE=InnoDB AUTO_INCREMENT=131 DEFAULT CHARSET=latin1;

/*Data for the table `keywordsmatrics` */

/* Procedure structure for procedure `SP_InsertKeywordMatrics` */

/*!50003 DROP PROCEDURE IF EXISTS  `SP_InsertKeywordMatrics` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_InsertKeywordMatrics`(
IN KeywordTrafficData VARCHAR(255),
IN FK_KeywordList INT,
IN Avg_MonthlySearchVolume VARCHAR(4000),
IN Keyword_Category VARCHAR(4000),
OUT ID_KeywordMatrics INT    
    )
BEGIN
        INSERT INTO keywordmatrics (Keyword_TrafficData , FK_KeywordList , Avg_MonthlySearchVolume , Keyword_Category)
	VALUES (KeywordTrafficData , FK_KeywordList , Avg_MonthlySearchVolume , Keyword_Category);
	SET @ID_KeywordMatrics = LAST_INSERT_ID();
    END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
