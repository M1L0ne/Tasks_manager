-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Окт 21 2023 г., 10:52
-- Версия сервера: 10.4.28-MariaDB
-- Версия PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `databasetsygvintsev`
--

-- --------------------------------------------------------

--
-- Структура таблицы `c_events`
--

CREATE TABLE `c_events` (
  `ce_description` text NOT NULL,
  `ce_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `c_events`
--

INSERT INTO `c_events` (`ce_description`, `ce_date`) VALUES
('Сходил в магазин', '2023-10-04'),
('Тортик!', '2023-10-05'),
('Мой день рождения', '2023-10-20');

-- --------------------------------------------------------

--
-- Структура таблицы `finances`
--

CREATE TABLE `finances` (
  `id` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `cost` int(11) NOT NULL,
  `type` varchar(1) NOT NULL,
  `f_dateend` date NOT NULL,
  `period` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `finances`
--

INSERT INTO `finances` (`id`, `name`, `cost`, `type`, `f_dateend`, `period`) VALUES
(2, 'ЗП', 100, '+', '2024-03-03', 1),
(3, 'Сапоги', 5000, '-', '2023-10-31', 0),
(4, 'Написал курсовую другу', 2000, '+', '2023-10-31', 0),
(5, 'Нашёл на дороге', 10000, '+', '2023-10-31', 0),
(6, 'Подработка', 5000, '+', '2024-12-31', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `goal`
--

CREATE TABLE `goal` (
  `id` int(11) NOT NULL,
  `g_name` varchar(40) NOT NULL,
  `g_cost` int(11) NOT NULL,
  `g_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `goal`
--

INSERT INTO `goal` (`id`, `g_name`, `g_cost`, `g_date`) VALUES
(1, 'Яхта', 70000, '2024-12-31'),
(2, 'Яхта 2', 30000, '2024-12-12'),
(3, 'Яхта 3', 60000, '2025-01-01');

-- --------------------------------------------------------

--
-- Структура таблицы `notes`
--

CREATE TABLE `notes` (
  `ID` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `text` text NOT NULL,
  `datetime` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `notes`
--

INSERT INTO `notes` (`ID`, `title`, `text`, `datetime`) VALUES
(1, 'asdsad', '{\\rtf1\\ansi\\ansicpg1251\\deff0\\nouicompat\\deflang1049{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset204 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\b\\f0\\fs20\\lang1033 asdasdad\\i asdasd\\b0\\i0\\f1\\lang1049\\par\r\n}\r\n', '2023-10-14 15:00:42');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `FIO` varchar(50) NOT NULL,
  `login` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`FIO`, `login`, `password`) VALUES
('Аблаева_КР', 'ablaeva', '12345');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `finances`
--
ALTER TABLE `finances`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `goal`
--
ALTER TABLE `goal`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `finances`
--
ALTER TABLE `finances`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `goal`
--
ALTER TABLE `goal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `notes`
--
ALTER TABLE `notes`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
