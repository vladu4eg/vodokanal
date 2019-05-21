-- --------------------------------------------------------
-- Хост:                         192.168.27.79
-- Версия сервера:               5.5.62-0ubuntu0.14.04.1 - (Ubuntu)
-- ОС Сервера:                   debian-linux-gnu
-- HeidiSQL Версия:              9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Дамп структуры базы данных ignas
/*
CREATE DATABASE IF NOT EXISTS `ignas` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;
USE `ignas`;


-- Дамп структуры для таблица ignas.plan
CREATE TABLE IF NOT EXISTS `plan` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `delivery` int(1) NOT NULL DEFAULT '0',
  `sendDate` datetime NOT NULL COMMENT 'Отправлено',
  `reciveDate` datetime DEFAULT NULL COMMENT 'Получено',
  `licscht` int(11) NOT NULL COMMENT 'Лицевой счет',
  `phone` varchar(254) NOT NULL COMMENT 'Телефон',
  `msg_type` int(11) NOT NULL DEFAULT '0' COMMENT 'Тип сообщения',
  `sms` varchar(198) DEFAULT NULL COMMENT 'Текст сообщения',
  `msg` text,
  `sms_id` int(11) NOT NULL DEFAULT '0' COMMENT 'id сообщения',
  `delivery_type` varchar(50) NOT NULL DEFAULT '0' COMMENT 'состояние доставки',
  `dolg` float(12,2) DEFAULT NULL COMMENT 'долг',
  `opl` float(12,2) DEFAULT NULL COMMENT 'оплата',
  PRIMARY KEY (`id`),
  KEY `phone` (`phone`),
  KEY `licscht` (`licscht`),
  KEY `sms_id` (`sms_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Экспортируемые данные не выделены.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
