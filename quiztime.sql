-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 09, 2021 at 01:09 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quiztime`
--

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
(36, 'Geld');

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
(44, 'Geld', 'img/img', 'Antwoord A1', 'Antwoord B1', 'Antwoord C1', 'Antwoord D1', 'AntwoordC', 70, 36),
(46, 'Vraag1', 'Image1', 'AntwoordA1', 'AntwoordB1', 'AntwoordC1', 'AntwoordD1', 'AntwoordC', 90, 36);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `vraag`
--
ALTER TABLE `vraag`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

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
