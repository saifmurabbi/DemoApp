-- phpMyAdmin SQL Dump
-- version 3.5.6
-- http://www.phpmyadmin.net
--
-- Host: 208.91.199.11:3306
-- Generation Time: Jan 15, 2014 at 02:53 PM
-- Server version: 5.5.30-log
-- PHP Version: 5.3.10

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `googleAdword`
--

-- --------------------------------------------------------

--
-- Table structure for table `Keywords`
--

CREATE TABLE IF NOT EXISTS `Keywords` (
  `ID_KeywordList` int(11) NOT NULL AUTO_INCREMENT,
  `Keyword` varchar(4000) DEFAULT NULL,
  `updateDate` date DEFAULT NULL,
  `ExpandParent` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_KeywordList`),
  KEY `ExpandParent` (`ExpandParent`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `Keywords`
--

INSERT INTO `Keywords` (`ID_KeywordList`, `Keyword`, `updateDate`, `ExpandParent`) VALUES
(1, 'handle', '2014-01-16', 1);

-- --------------------------------------------------------

--
-- Table structure for table `KeywordsMatrics`
--

CREATE TABLE IF NOT EXISTS `KeywordsMatrics` (
  `ID_KeywordMatrics` int(11) NOT NULL AUTO_INCREMENT,
  `Keyword_TrafficData` varchar(4000) DEFAULT NULL,
  `FK_KeywordList` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_KeywordMatrics`),
  KEY `FK_KeywordList` (`FK_KeywordList`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `KeywordsMatrics`
--

INSERT INTO `KeywordsMatrics` (`ID_KeywordMatrics`, `Keyword_TrafficData`, `FK_KeywordList`) VALUES
(1, 'red herring c4e9c927,red herring 3cd34d96,red herring 8fa0b73,red herring b0768c35,handle b5517b29,red herring 48dea7d6,handle a5f4834,handle 43e1ba50,red herring f59710b8,red herring b2e1f08d,red herring 4e3e1456,handle 6983155,handle a4928214,handle 3ab9efbb,handle fede12af,red herring 5b4e67ac,red herring a4b996da,handle 70849689,red herring 63387b9f,red herring f9629e4,handle b206fe4d,handle 52112915,handle c0ca2677,red herring 4869ad7a,red herring 8b4b2b05,red herring 4184489c,red herring f967dc14,handle c87c2017,handle 1479a0de,red herring 4c205269,handle 957382b9,red herring a8441f6b,handle 84dbd01e,red herring deff8927,red herring 934da934,red herring 7b02b3e3,red herring e3f9439,red herring 7e41a455,red herring 831b4048,handle b764a510,red herring f877e0e6,red herring b7476420,handle 68e76414,red herring a293ae75,handle 4ec211d1,red herring 44b12c69,red herring 4cd68040,red herring 6598608,handle 4694ab03,handle a3a19d35,red herring 8909fbdc,handle 9a79d5df,handle f3e43b5e,red herring 4e95137,handle d0df1645,handle c7810b2d,red herring 8accaf2a,red herring 5ff8e8f4,red herring 623991e0,red herring c3329a59,red herring e902725e,handle 37cefd98,red herring 3aff7d02,red herring a734dcfa,handle 792cef36,red herring 65504926,red herring 8ef6736b,red herring c09d13f,red herring 45000ce,handle a4ed2108,handle a114f628,red herring 2207d761,red herring da9ae90c,handle 9e1c5b42,handle c622189f,red herring 8a8c2cc0,handle c7e43b56,red herring d84076b0,red herring 67315ab8,red herring 6d9bab4b,handle 1bd36291,handle e4b3df8d,handle 666c18af,red herring ececfae1,red herring a530327,red herring 7cc1f169,handle 9c138a74,handle 7164795c,red herring 70d29219,handle cf4f75b3,handle 3c1e51a,red herring c0304c02,red herring 5d6cd42b,handle b2252692,handle dc020aee,red herring e816e5b3,red herring d6beca0c,handle c8cd08fa,handle c088ba24,handle 32988106,red herring ad6acced,handle 2cceac2d,red herring 3ab8e2dd,handle fce2e126,red herring 74e72c10,handle eacc6d03,red herring c9156489,red herring ca785b6b,handle e9fffdd6,handle 87a06e5d,handle b6e95ab8,handle 7777b0ba,handle c21b2ecf,handle 8d66f1e1,handle 32633f55,red herring 6387007f,red herring 300d084a,handle d278c0e6,red herring b304ab1,red herring 8b81ede7,red herring bef59c9c,handle e2da5e7d,handle 6d6dbbdf,handle 68866dfd,red herring 437bce4f,handle a5dc3231,red herring 9117b94b,handle 7f01d8b6,handle 29ea8b19,red herring f67f6893,handle fa28d252,handle d8d0d95a,handle 246a3e8a,handle 19952b0d,handle 9afa4569,red herring 700a3642,handle 7a14417e,red herring e27f47cc,handle 9cd322f0,handle c70a2bb9,red herring 978890de,handle d30aeac1,red herring cd6d25ab,handle 36aa0fb,handle fe4c0b93,red herring 7fa7b292,handle 198fdef,red herring 597ecafd,handle 6b1928ef,red herring a1bc748a,handle 7758d173,handle fb44813e,red herring c1075fc5,red herring b75d2e9b,red herring 52ceaf78,handle cbc3e398,handle 30358c88,handle f47e45a,handle 9b200e05,red herring 1d5ba89a,red herring 796f0f4e,red herring 99ff9da2,red herring abfe7979,handle a95b74c7,handle dcf6377,red herring 6c2dacb7,handle e9c599a3,handle 5c43b00b,red herring dea88c90,red herring 53159c60,red herring 4b330f6b,red herring a105ad3e,red herring 6a4c7f8b,red herring 94cc8ba4,red herring 8cabde6b,handle 8d3b7d4b,red herring 1c09e99b,handle 9c015367,handle ec7f391d,handle 2316ddf3,red herring c46dca50,red herring 8d5400d7,red herring 6ea317eb,red herring c69e9a18,handle d66e5b2,red herring e7510f33,red herring eea3d58f,handle a92751a2,red herring 8d0ce88d,red herring 31d4b92b,red herring 6bd05332,red herring 2b2f9020,red herring 11341d0b,red herring f51389e7,red herring 3b9247eb,handle ec7523d0,red herring c24266de,handle 3ef4e1f5,handle 868231d,red herring 4869a4d5,red herring 501b2fe4,red herring 525b8aa9,red herring 8f7aaaff,handle 5fd0be30,handle 272bc28a,handle a4c6114a,red herring f0ab53e6,handle b351d406,red herring 90496a77,red herring 76cd780c,red herring 6f6965a6,red herring c5d46d44,handle 5fdedf9d,handle bcd9873,handle 776ed1ff', 1);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Keywords`
--
ALTER TABLE `Keywords`
  ADD CONSTRAINT `Keywords_ibfk_1` FOREIGN KEY (`ExpandParent`) REFERENCES `Keywords` (`ID_KeywordList`);

--
-- Constraints for table `KeywordsMatrics`
--
ALTER TABLE `KeywordsMatrics`
  ADD CONSTRAINT `KeywordsMatrics_ibfk_1` FOREIGN KEY (`FK_KeywordList`) REFERENCES `Keywords` (`ID_KeywordList`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
