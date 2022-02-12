-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 16 2021 г., 16:06
-- Версия сервера: 5.6.41
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bankstoredbd`
--

-- --------------------------------------------------------

--
-- Структура таблицы `bill_counters`
--

CREATE TABLE `bill_counters` (
  `IDBC` int(5) NOT NULL,
  `Bill_Counters_name` varchar(100) DEFAULT NULL,
  `Bill_Counters_brand` int(5) DEFAULT NULL,
  `Bill_Counters_ScorBac` int(100) DEFAULT NULL,
  `Bill_Counters_ObemLotka` int(100) DEFAULT NULL,
  `Bill_Counters_Valuta` int(1) DEFAULT NULL,
  `Bill_Counters_price` decimal(10,2) DEFAULT NULL,
  `image_B` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `bill_counters`
--

INSERT INTO `bill_counters` (`IDBC`, `Bill_Counters_name`, `Bill_Counters_brand`, `Bill_Counters_ScorBac`, `Bill_Counters_ObemLotka`, `Bill_Counters_Valuta`, `Bill_Counters_price`, `image_B`) VALUES
(1, 'PRO NC 3300', 0, 1500, 500, 1, '54890.00', NULL),
(2, 'DORS 800', 2, 1500, 800, 1, '49900.00', NULL),
(3, 'PRO 85', 0, 1500, 500, 1, '16790.00', NULL),
(4, 'Laurel J-700', 5, 1500, 300, 1, '27500.00', NULL),
(5, 'HITACHI iH-110', 6, 1300, 500, 1, '99950.00', NULL),
(6, 'SBM SB-5000', 7, 1000, 700, 1, '894700.00', NULL),
(7, 'Kisan K 5 HD', 8, 1000, 200, 1, '703000.00', NULL),
(8, 'SBM SB-3000', 7, 1000, 500, 1, '442200.00', NULL),
(9, 'Kisan Smart', 8, 1000, 1000, 2, '418500.00', NULL),
(10, 'Mbox DS-100', 3, 1900, 300, 1, '13000.00', NULL),
(11, 'Axiom RUB/USD/EUR/CHF/GBP/JPY/CNY + 3 валюты', 9, 1500, 1000, 1, '165000.00', NULL),
(12, 'MAGNER 175', 10, 1500, 800, 1, '99900.00', NULL),
(13, 'DoCash 3040', 1, 1000, 200, 3, '5890.00', NULL),
(14, 'PRO 15', 0, 900, 100, 1, '5910.00', NULL),
(15, 'PRO 40 U Neo', 0, 800, 100, 1, '7190.00', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `brand`
--

CREATE TABLE `brand` (
  `Brand_id` int(5) NOT NULL DEFAULT '0',
  `Brand_name` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `brand`
--

INSERT INTO `brand` (`Brand_id`, `Brand_name`) VALUES
(0, 'PRO'),
(1, 'DOCASH'),
(2, 'DORS'),
(3, 'MBOX'),
(4, 'CASSIDA'),
(5, 'LAUREL'),
(6, 'HITACHI'),
(7, 'SBM'),
(8, 'KISAN'),
(9, 'AXIOM'),
(10, 'MAGNER'),
(11, 'MULTI CASH'),
(12, 'DEEP'),
(13, 'RIBAO'),
(14, 'МЕРКУРИЙ'),
(15, 'СПЕКТР-ВИДЕО');

-- --------------------------------------------------------

--
-- Структура таблицы `coin_counters`
--

CREATE TABLE `coin_counters` (
  `IDCC` int(5) NOT NULL,
  `Coin_Counters_name` varchar(100) DEFAULT NULL,
  `Coin_Counters_brand` int(5) DEFAULT NULL,
  `Coin_Counters_ScorSch` int(100) DEFAULT NULL,
  `Coin_Counters_ObemBunker` int(100) DEFAULT NULL,
  `Coin_Counters_price` decimal(10,2) DEFAULT NULL,
  `image_C` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `coin_counters`
--

INSERT INTO `coin_counters` (`IDCC`, `Coin_Counters_name`, `Coin_Counters_brand`, `Coin_Counters_ScorSch`, `Coin_Counters_ObemBunker`, `Coin_Counters_price`, `image_C`) VALUES
(1, 'Multi Cash MC 1-14', 11, 1200, 1250, '54890.00', NULL),
(2, 'DEEP CМХ-02', 12, 3400, 10000, '49900.00', NULL),
(3, 'MBOX CS-211S', 3, 1500, 500, '16790.00', NULL),
(4, 'MBOX CS-910S+', 3, 1500, 300, '27500.00', NULL),
(5, 'DEEP CH-C205', 12, 1300, 500, '99950.00', NULL),
(6, 'MAGNER 926', 10, 1000, 700, '894700.00', NULL),
(7, 'DEEP CMX-01', 12, 1000, 200, '703000.00', NULL),
(8, 'Ribao CS 2000', 13, 1000, 500, '442200.00', NULL),
(9, 'PRO CS 80R LCD', 0, 1000, 1000, '418500.00', NULL),
(10, 'PRO CS 80R', 0, 1900, 300, '13000.00', NULL),
(11, 'CassidaCoinMax', 3, 1500, 1000, '165000.00', NULL),
(12, 'DoCash 913', 1, 1500, 800, '99900.00', NULL),
(13, 'Cassida C-100', 3, 1000, 200, '5890.00', NULL),
(14, 'DORS CT 3010', 2, 900, 100, '5910.00', NULL),
(15, 'MBOX CS 110', 3, 800, 100, '7190.00', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `currency_detectors`
--

CREATE TABLE `currency_detectors` (
  `IDCD` int(5) NOT NULL,
  `Currency_Detectors_name` varchar(100) DEFAULT NULL,
  `Currency_Detectors_brand` int(5) DEFAULT NULL,
  `Currency_Detectors_TypeDetector` int(1) DEFAULT NULL,
  `Currency_Detectors_sensorgps` varchar(255) DEFAULT NULL,
  `Currency_Detectors_battery` int(1) DEFAULT NULL,
  `Currency_Detectors_price` decimal(10,2) DEFAULT NULL,
  `image_D` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `currency_detectors`
--

INSERT INTO `currency_detectors` (`IDCD`, `Currency_Detectors_name`, `Currency_Detectors_brand`, `Currency_Detectors_TypeDetector`, `Currency_Detectors_sensorgps`, `Currency_Detectors_battery`, `Currency_Detectors_price`, `image_D`) VALUES
(1, 'PRO CL 200', 0, 0, 'Инфракрасная, Ультрафиолетовая', 2, '7990.00', NULL),
(2, 'DORS 200', 2, 0, 'Инфракрасная, Оптическая, Магнитная', 2, '6500.00', NULL),
(3, 'DoCash CUBE', 1, 0, 'Инфракрасная, Ультрафиолетовая, Оптическая', 2, '28590.00', NULL),
(4, 'DORS 230 М2', 2, 0, 'Инфракрасная, Оптическая, Геометрическая', 2, '18390.00', NULL),
(5, 'PRO KRICKET', 0, 1, 'Оптическая, Антистокс', 1, '5190.00', NULL),
(6, 'DORS 60 УФ', 2, 2, 'Ультрафиолетовая', 1, '1390.00', NULL),
(7, 'MERCURY D-110 ANTISTOKS', 14, 2, 'Антистокс', 2, '2770.00', NULL),
(8, 'DORS 1000 M3', 2, 2, 'Инфракрасная', 2, '4450.00', NULL),
(9, 'DORS 1250 Standart', 2, 2, 'Инфракрасная, Оптическая', 1, '10790.00', NULL),
(10, 'PRO-12 LED', 0, 2, 'Ультрафиолетовая', 0, '3300.00', NULL),
(11, 'PRO 4 LED', 0, 3, 'Оптическая, Светодиодная', 2, '1290.00', NULL),
(12, 'DoCash 530', 1, 3, 'Ультрафиолетовая, Оптическая, Геометрическая', 0, '1990.00', NULL),
(13, 'MD-8007', 3, 2, 'Инфракрасная, Ультрафиолетовая, Магнитная', 2, '22135.00', NULL),
(14, 'Спектр-Видео-К LCD', 15, 2, 'Инфракрасная', 0, '3570.00', NULL),
(15, 'Cassida Sirius S', 5, 0, 'Ультрафиолетова, Антистокс', 2, '3850.00', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `roles`
--

CREATE TABLE `roles` (
  `idroles` int(11) NOT NULL,
  `role_name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `roles`
--

INSERT INTO `roles` (`idroles`, `role_name`) VALUES
(0, 'AuthorizedUser'),
(1, 'Admin');

-- --------------------------------------------------------

--
-- Структура таблицы `typedetector`
--

CREATE TABLE `typedetector` (
  `TypeDetector_id` int(5) NOT NULL DEFAULT '0',
  `TypeDetector_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `typedetector`
--

INSERT INTO `typedetector` (`TypeDetector_id`, `TypeDetector_name`) VALUES
(0, 'Автоматический'),
(1, 'Детектор акцизных марок и документов'),
(2, 'Просмотровый'),
(3, 'Компактный УФ');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id_users` int(11) NOT NULL,
  `role_id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) NOT NULL,
  `login` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id_users`, `role_id`, `first_name`, `last_name`, `middle_name`, `login`, `email`, `password`) VALUES
(1, 1, 'Test', 'Test', 'Test', 'Test', 'test@email.com', '12Test88'),
(2, 0, 'Андрей', 'Владимиров', 'Николаевич', 'ASrty', 'Anwerty@gmail.com', '123456789'),
(3, 1, 'Алексей', 'Иванович', 'Скадов', 'Scadov', 'Scadov@mail.ru', 'dgdgdg'),
(4, 0, 'Светлана', 'Ирслановна', 'Зубко', 'SvetIN', 'svetINtonel@mail.ru', 'JF;;JK'),
(5, 1, 'Михаил', 'Алексеевич', 'Иванов', ' Mihalych ', 'Mihalych@gmail.ru', 'dfsdfhl'),
(6, 0, 'Алексей', 'Вячеславович', 'Кукс', 'Kyks', 'Kyks@mail.ru', 'klsdjf'),
(7, 0, 'Русский', 'Искандаревич', 'Муров', 'Tyuon', 'Mur@mail.ru', 'www'),
(8, 0, 'Иван', 'Иванович', 'Иванов', 'IVAN', 'Ivan@mail.ru', 'Sdmnlk'),
(9, 0, 'Алексей', 'Александрович', 'Федоров', 'Fedor', 'Fedor@mail.ru', 'SDLFLK'),
(10, 0, 'Артур', 'Ашшаров', 'Рахимов', 'Asharov', ' Asharov @mail.ru', 'cnxvj7l'),
(11, 0, 'Денис', 'Ноумов', 'Шашаш', 'Shabash', ' Shabash @mail.ru', 'sk;do90l.'),
(12, 0, 'Александра', 'Ивановна', 'Сноу', 'Snow', 'Snow@mail.ru', 'l;hf/kj;u');

-- --------------------------------------------------------

--
-- Структура таблицы `valuta_index`
--

CREATE TABLE `valuta_index` (
  `Valuta_id` int(1) NOT NULL DEFAULT '0',
  `Valuta_type` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `valuta_index`
--

INSERT INTO `valuta_index` (`Valuta_id`, `Valuta_type`) VALUES
(0, 'RUB'),
(1, 'USD'),
(2, 'EUR'),
(3, 'CHF'),
(4, 'мультивалютный');

-- --------------------------------------------------------

--
-- Структура таблицы `yesno`
--

CREATE TABLE `yesno` (
  `YesNo_id` int(1) NOT NULL DEFAULT '0',
  `YesNo_name` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `yesno`
--

INSERT INTO `yesno` (`YesNo_id`, `YesNo_name`) VALUES
(0, 'Нет'),
(1, 'Да'),
(2, 'Неизвестно');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `bill_counters`
--
ALTER TABLE `bill_counters`
  ADD PRIMARY KEY (`IDBC`),
  ADD UNIQUE KEY `Bill_Counters_name` (`Bill_Counters_name`),
  ADD KEY `IDBC` (`IDBC`),
  ADD KEY `Bill_Counters_brand` (`Bill_Counters_brand`),
  ADD KEY `Bill_Counters_Valuta` (`Bill_Counters_Valuta`);

--
-- Индексы таблицы `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`Brand_id`);

--
-- Индексы таблицы `coin_counters`
--
ALTER TABLE `coin_counters`
  ADD PRIMARY KEY (`IDCC`),
  ADD UNIQUE KEY `Coin_Counters_name` (`Coin_Counters_name`),
  ADD KEY `IDCC` (`IDCC`),
  ADD KEY `Coin_Counters_brand` (`Coin_Counters_brand`);

--
-- Индексы таблицы `currency_detectors`
--
ALTER TABLE `currency_detectors`
  ADD PRIMARY KEY (`IDCD`),
  ADD UNIQUE KEY `Currency_Detectors_name` (`Currency_Detectors_name`),
  ADD KEY `IDCD` (`IDCD`),
  ADD KEY `Currency_Detectors_brand` (`Currency_Detectors_brand`),
  ADD KEY `Currency_Detectors_TypeDetector` (`Currency_Detectors_TypeDetector`),
  ADD KEY `Currency_Detectors_battery` (`Currency_Detectors_battery`);

--
-- Индексы таблицы `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`idroles`);

--
-- Индексы таблицы `typedetector`
--
ALTER TABLE `typedetector`
  ADD PRIMARY KEY (`TypeDetector_id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_users`),
  ADD KEY `role_id` (`role_id`);

--
-- Индексы таблицы `valuta_index`
--
ALTER TABLE `valuta_index`
  ADD PRIMARY KEY (`Valuta_id`);

--
-- Индексы таблицы `yesno`
--
ALTER TABLE `yesno`
  ADD PRIMARY KEY (`YesNo_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `bill_counters`
--
ALTER TABLE `bill_counters`
  MODIFY `IDBC` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `coin_counters`
--
ALTER TABLE `coin_counters`
  MODIFY `IDCC` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `currency_detectors`
--
ALTER TABLE `currency_detectors`
  MODIFY `IDCD` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id_users` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `bill_counters`
--
ALTER TABLE `bill_counters`
  ADD CONSTRAINT `bill_counters_ibfk_1` FOREIGN KEY (`Bill_Counters_brand`) REFERENCES `brand` (`Brand_id`),
  ADD CONSTRAINT `bill_counters_ibfk_2` FOREIGN KEY (`Bill_Counters_Valuta`) REFERENCES `valuta_index` (`Valuta_id`);

--
-- Ограничения внешнего ключа таблицы `coin_counters`
--
ALTER TABLE `coin_counters`
  ADD CONSTRAINT `coin_counters_ibfk_1` FOREIGN KEY (`Coin_Counters_brand`) REFERENCES `brand` (`Brand_id`);

--
-- Ограничения внешнего ключа таблицы `currency_detectors`
--
ALTER TABLE `currency_detectors`
  ADD CONSTRAINT `currency_detectors_ibfk_1` FOREIGN KEY (`Currency_Detectors_brand`) REFERENCES `brand` (`Brand_id`),
  ADD CONSTRAINT `currency_detectors_ibfk_2` FOREIGN KEY (`Currency_Detectors_TypeDetector`) REFERENCES `typedetector` (`TypeDetector_id`),
  ADD CONSTRAINT `currency_detectors_ibfk_3` FOREIGN KEY (`Currency_Detectors_battery`) REFERENCES `yesno` (`YesNo_id`);

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`idroles`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
