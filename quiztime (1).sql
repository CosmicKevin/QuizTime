-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2021 at 08:41 AM
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
-- Table structure for table `antwoorden`
--

CREATE TABLE `antwoorden` (
  `ID` int(11) NOT NULL,
  `GoedAntwoord` varchar(45) NOT NULL,
  `Vraag_ID` int(11) NOT NULL,
  `Quiz_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

CREATE TABLE `quiz` (
  `ID` int(11) NOT NULL,
  `Quiz_ID` int(11) NOT NULL,
  `QuizNaam` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `vraag`
--

CREATE TABLE `vraag` (
  `ID` int(11) NOT NULL,
  `QuizNaam` varchar(45) NOT NULL,
  `Vraag` varchar(45) NOT NULL,
  `Image` varchar(45) NOT NULL,
  `AntwoordA` varchar(45) NOT NULL,
  `AntwoordB` varchar(45) NOT NULL,
  `AntwoordC` varchar(45) NOT NULL,
  `AntwoordD` varchar(45) NOT NULL,
  `GoedAntwoord` varchar(45) NOT NULL,
  `Timer` int(11) NOT NULL,
  `Quiz_ID` int(11) NOT NULL,
  `Vraag_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vraag`
--

INSERT INTO `vraag` (`ID`, `QuizNaam`, `Vraag`, `Image`, `AntwoordA`, `AntwoordB`, `AntwoordC`, `AntwoordD`, `GoedAntwoord`, `Timer`, `Quiz_ID`, `Vraag_ID`) VALUES
(1, 'Naam1', 'Vraag1', 'Image1', 'AntwoordA1', 'AntwoordB1', 'AntwoordC1', 'AntwoordD1', 'AntwoordA', 111, 1, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `antwoorden`
--
ALTER TABLE `antwoorden`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Vraag_ID` (`Vraag_ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- Indexes for table `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`);

--
-- Indexes for table `vraag`
--
ALTER TABLE `vraag`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Quiz_ID` (`Quiz_ID`),
  ADD KEY `Vraag_ID` (`Vraag_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `antwoorden`
--
ALTER TABLE `antwoorden`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `quiz`
--
ALTER TABLE `quiz`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `vraag`
--
ALTER TABLE `vraag`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
