-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2022-07-05 11:20:13
-- 伺服器版本： 10.4.24-MariaDB
-- PHP 版本： 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `tickettracking`
--

-- --------------------------------------------------------

--
-- 資料表結構 `bugs`
--

CREATE TABLE `bugs` (
  `id` int(8) NOT NULL,
  `name` varchar(20) NOT NULL,
  `statement` varchar(50) NOT NULL DEFAULT 'None',
  `isResolved` tinyint(1) NOT NULL DEFAULT 0,
  `isDel` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `bugs`
--

INSERT INTO `bugs` (`id`, `name`, `statement`, `isResolved`, `isDel`) VALUES
(1, 'SystemError', 'Version incorrect', 0, 1),
(2, 'DataBaseCrash', 'Need Restart', 1, 1),
(3, 'WebsiteConnectFail', 'Error 404', 0, 1),
(18, 'Example', 'Demo', 0, 1),
(19, 'Example', 'Demo', 0, 1),
(20, 'Example', 'Demo', 0, 1),
(21, 'Example', 'Demo', 0, 1),
(22, 'Example', 'Demo', 1, 1),
(23, 'Example', 'Demo2', 1, 0),
(24, 'Example', 'Demo', 1, 0),
(25, 'Example', 'Demo', 1, 0),
(26, 'Example', 'Demo', 0, 1),
(27, 'Example', 'Demo', 0, 0),
(28, 'Example', 'Demo', 0, 0),
(29, 'Example', 'Demo', 0, 0),
(30, 'Example', 'Demo', 0, 0),
(31, 'Hello', 'World', 0, 1),
(32, 'Example', 'Demo', 0, 0),
(33, 'Example', 'Demo', 0, 0);

-- --------------------------------------------------------

--
-- 資料表結構 `user`
--

CREATE TABLE `user` (
  `id` int(8) NOT NULL,
  `account` varchar(12) NOT NULL,
  `password` varchar(12) NOT NULL,
  `level` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `user`
--

INSERT INTO `user` (`id`, `account`, `password`, `level`) VALUES
(1, 'user01', '12345', 'QA'),
(2, 'user02', '12345', 'RD');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `bugs`
--
ALTER TABLE `bugs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- 資料表索引 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`,`account`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `bugs`
--
ALTER TABLE `bugs`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `user`
--
ALTER TABLE `user`
  MODIFY `id` int(8) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
