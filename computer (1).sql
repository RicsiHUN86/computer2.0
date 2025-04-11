-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 11. 12:27
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `computer`
--
CREATE DATABASE IF NOT EXISTS `computer` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `computer`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `comp`
--

CREATE TABLE `comp` (
  `Id` char(36) NOT NULL,
  `Brand` varchar(37) DEFAULT NULL,
  `Type` varchar(30) DEFAULT NULL,
  `Display` double DEFAULT NULL,
  `Memory` int(11) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `OsId` char(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `comp`
--

INSERT INTO `comp` (`Id`, `Brand`, `Type`, `Display`, `Memory`, `CreatedTime`, `OsId`) VALUES
('61842ea7-0639-11f0-aa2d-484d7ea4f93e', 'Dell', 'Laptop', 15.6, 16, '2025-03-21 10:46:36', '617f6963-0639-11f0-aa2d-484d7ea4f93e'),
('61845955-0639-11f0-aa2d-484d7ea4f93e', 'HP', 'Desktop', 27, 32, '2025-03-21 10:46:36', '617fbd59-0639-11f0-aa2d-484d7ea4f93e');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `osystem`
--

CREATE TABLE `osystem` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `osystem`
--

INSERT INTO `osystem` (`Id`, `Name`) VALUES
('617f6963-0639-11f0-aa2d-484d7ea4f93e', 'Windows 11'),
('617fbd59-0639-11f0-aa2d-484d7ea4f93e', 'Ubuntu 22.04');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`) VALUES
(1, 'admin1', 'a1'),
(2, 'admin2', 'a2'),
(3, 'admin', 'aa'),
(4, 'user1', 'jelszo'),
(5, 'szeli', 'sz1');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `comp`
--
ALTER TABLE `comp`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `idx_OsId` (`OsId`);

--
-- A tábla indexei `osystem`
--
ALTER TABLE `osystem`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `comp`
--
ALTER TABLE `comp`
  ADD CONSTRAINT `fk_OsId` FOREIGN KEY (`OsId`) REFERENCES `osystem` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
