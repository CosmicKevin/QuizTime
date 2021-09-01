-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 01, 2021 at 02:16 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quiztime`
--
CREATE DATABASE IF NOT EXISTS `quiztime` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `quiztime`;

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

CREATE TABLE `quiz` (
  `ID` int(11) NOT NULL,
  `QuizNaam` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `quiz`
--

INSERT INTO `quiz` (`ID`, `QuizNaam`) VALUES
(38, 'test plaatje');

-- --------------------------------------------------------

--
-- Table structure for table `vraag`
--

CREATE TABLE `vraag` (
  `ID` int(11) NOT NULL,
  `Vraag` varchar(45) NOT NULL,
  `Image` varchar(45) NOT NULL,
  `AntwoordA` varchar(45) NOT NULL,
  `AntwoordB` varchar(45) NOT NULL,
  `AntwoordC` varchar(45) NOT NULL,
  `AntwoordD` varchar(45) NOT NULL,
  `GoedAntwoord` varchar(45) NOT NULL,
  `Timer` int(11) NOT NULL,
  `Quiz_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vraag`
--

INSERT INTO `vraag` (`ID`, `Vraag`, `Image`, `AntwoordA`, `AntwoordB`, `AntwoordC`, `AntwoordD`, `GoedAntwoord`, `Timer`, `Quiz_ID`) VALUES
(49, 'Doe maar iets', 'C:\\Users\\kevin\\OneDrive\\Pictures\\banaan.jpg', 'Antwoord A1', 'Antwoord B1', 'Antwoord C1', 'Antwoord D1', 'AntwoordB', 40, 38);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `vraag`
--
ALTER TABLE `vraag`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `quiz`
--
ALTER TABLE `quiz`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `vraag`
--
ALTER TABLE `vraag`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `vraag`
--
ALTER TABLE `vraag`
  ADD CONSTRAINT `vraag_ibfk_1` FOREIGN KEY (`Quiz_ID`) REFERENCES `quiz` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
