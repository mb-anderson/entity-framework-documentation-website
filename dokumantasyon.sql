-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 11 Haz 2023, 22:41:17
-- Sunucu sürümü: 10.4.17-MariaDB
-- PHP Sürümü: 7.4.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `dokumantasyon`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `categories`
--

CREATE TABLE `categories` (
  `CategoryID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `categories`
--

INSERT INTO `categories` (`CategoryID`, `Name`) VALUES
(1, 'cat11');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `documents`
--

CREATE TABLE `documents` (
  `DokumanID` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Subtitle` varchar(255) NOT NULL,
  `Content` text NOT NULL,
  `CategoryID` int(11) NOT NULL,
  `Created_at` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `documents`
--

INSERT INTO `documents` (`DokumanID`, `Title`, `Subtitle`, `Content`, `CategoryID`, `Created_at`) VALUES
(1, 'Dok', 'üman', '<p>içer</p>', 1, '2023-06-11'),
(3, 'flsaflksdflks', 'afsdsf', 'dsfdfs', 1, '2023-06-11');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `document_images`
--

CREATE TABLE `document_images` (
  `Document_images_ID` int(11) NOT NULL,
  `Document_id` int(11) DEFAULT NULL,
  `File_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `files`
--

CREATE TABLE `files` (
  `FileID` int(11) NOT NULL,
  `File_path` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `roles`
--

CREATE TABLE `roles` (
  `RoleID` int(11) NOT NULL,
  `RoleName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `roles`
--

INSERT INTO `roles` (`RoleID`, `RoleName`) VALUES
(1, 'Admin'),
(2, 'Manager');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Name`, `Surname`, `Email`, `Password`) VALUES
(1, 'core_user', 'Mustafa Burak', 'Yücel', 'mburakyucel38@gmail.com', 'PST9ZvCcu0X5CqFYs1CEWQTFGd/8u4rT49of0Sv2Z5M=');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users_roles`
--

CREATE TABLE `users_roles` (
  `Users_roles_ID` int(11) NOT NULL,
  `User_id` int(11) NOT NULL,
  `Role_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `users_roles`
--

INSERT INTO `users_roles` (`Users_roles_ID`, `User_id`, `Role_id`) VALUES
(1, 1, 1),
(2, 1, 2);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Tablo için indeksler `documents`
--
ALTER TABLE `documents`
  ADD PRIMARY KEY (`DokumanID`),
  ADD UNIQUE KEY `Title` (`Title`),
  ADD KEY `documents_categories_ibfk_1` (`CategoryID`);

--
-- Tablo için indeksler `document_images`
--
ALTER TABLE `document_images`
  ADD PRIMARY KEY (`Document_images_ID`),
  ADD KEY `document_images_ibfk_1` (`Document_id`),
  ADD KEY `document_images_ibfk_2` (`File_id`);

--
-- Tablo için indeksler `files`
--
ALTER TABLE `files`
  ADD PRIMARY KEY (`FileID`);

--
-- Tablo için indeksler `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`RoleID`),
  ADD UNIQUE KEY `Role` (`RoleName`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Tablo için indeksler `users_roles`
--
ALTER TABLE `users_roles`
  ADD PRIMARY KEY (`Users_roles_ID`),
  ADD UNIQUE KEY `Role_id` (`Role_id`,`User_id`),
  ADD KEY `User_id` (`User_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `categories`
--
ALTER TABLE `categories`
  MODIFY `CategoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `documents`
--
ALTER TABLE `documents`
  MODIFY `DokumanID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `document_images`
--
ALTER TABLE `document_images`
  MODIFY `Document_images_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `files`
--
ALTER TABLE `files`
  MODIFY `FileID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `roles`
--
ALTER TABLE `roles`
  MODIFY `RoleID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `users_roles`
--
ALTER TABLE `users_roles`
  MODIFY `Users_roles_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `documents`
--
ALTER TABLE `documents`
  ADD CONSTRAINT `documents_categories_ibfk_1` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`);

--
-- Tablo kısıtlamaları `document_images`
--
ALTER TABLE `document_images`
  ADD CONSTRAINT `document_images_ibfk_1` FOREIGN KEY (`Document_id`) REFERENCES `documents` (`DokumanID`),
  ADD CONSTRAINT `document_images_ibfk_2` FOREIGN KEY (`File_id`) REFERENCES `files` (`FileID`);

--
-- Tablo kısıtlamaları `users_roles`
--
ALTER TABLE `users_roles`
  ADD CONSTRAINT `users_roles_ibfk_1` FOREIGN KEY (`User_id`) REFERENCES `users` (`UserID`),
  ADD CONSTRAINT `users_roles_ibfk_2` FOREIGN KEY (`Role_id`) REFERENCES `roles` (`RoleID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
