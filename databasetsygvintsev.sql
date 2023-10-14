-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Окт 14 2023 г., 18:53
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
  `f_dateend` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `finances`
--

INSERT INTO `finances` (`id`, `name`, `cost`, `type`, `f_dateend`) VALUES
(2, 'ЗП', 100, '+', '2024-03-03'),
(3, 'Сапоги', 5000, '-', '2023-10-31'),
(4, 'Написал курсовую другу', 2000, '+', '2023-10-31'),
(5, 'Нашёл на дороге', 10000, '+', '2023-10-31'),
(0, 'напечатал', 100, '+', '2023-10-31');

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
(2, 'Дом', 500000, '2030-10-10');

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
(1, '213', '{\\rtf1\\ansi\\ansicpg1251\\deff0\\nouicompat\\deflang1049{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset204 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.18362}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs20\\lang1033 asdads\\b asd\\i asdasd\\b0\\i0\\f1\\lang1049\\par\r\n}\r\n', '2023-10-11 19:11:30'),
(2, 'Полёт в кино', '{\\rtf1\\ansi\\ansicpg1251\\deff0\\nouicompat\\deflang1049{\\fonttbl{\\f0\\fnil\\fcharset204 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.18362}\\viewkind4\\uc1 \r\n\\pard\\b\\f0\\fs20\\\'c1\\\'db\\\'cb\\\'ce \\\'ce\\\'d7\\\'c5\\\'cd\\\'dc \\\'c2\\\'c5\\\'d1\\\'c5\\\'cb\\\'ce\\par\r\n\\b0\\i\\\'ec\\\'fb \\\'f5\\\'ee\\\'e4\\\'e8\\\'eb\\\'e8 \\\'e2 \\\'ea\\\'e8\\\'ed\\\'ee\\par\r\n\\b\\\'e8 \\\'f2\\\'e0\\\'ec \\\'e1\\\'fb\\\'eb\\\'ee \\\'ea\\\'e8\\\'ed\\\'ee\\par\r\n\\b0\\i0\\\'ea\\\'eb\\\'e0\\\'f1\\\'f1\\par\r\n}\r\n', '2023-10-11 19:18:41');

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
-- Индексы таблицы `c_events`
--
ALTER TABLE `c_events`
  ADD PRIMARY KEY (`ce_date`);

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
-- AUTO_INCREMENT для таблицы `notes`
--
ALTER TABLE `notes`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
