-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-10-2020 a las 16:36:25
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.2.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuestas`
--

CREATE DATABASE placemybet;
USE placemybet;

CREATE TABLE `apuestas` (
  `IdMercado` int NOT NULL,
  `TipoApuesta` varchar(45) NOT NULL,
  `Cuota` double NOT NULL,
  `DineroApuesta` double NOT NULL,
  `Fecha` datetime NOT NULL,
  `IdEvento` int(11) NOT NULL,
  `Emailusuario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `apuestas`
--

INSERT INTO `apuestas` (`IdMercado`, `TipoApuesta`, `Cuota`, `DineroApuesta`, `Fecha`, `IdEvento`, `Emailusuario`) VALUES
(2.5, 'over', 31233, 32, '2020-10-05 20:23:54', 2, 'usuario4@gmail.com'),
(2.5, 'over', 31233, 32, '2020-10-05 20:23:54', 3, 'usuario4@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `Saldo Cuenta` double NOT NULL,
  `Nombre Banco` varchar(20) NOT NULL,
  `Numero_cuenta` varchar(20) NOT NULL,
  `EmailUsuario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE `eventos` (
  `IDEvento` int(11) NOT NULL,
  `Nombre Equipo local` varchar(40) NOT NULL,
  `Visitante` varchar(40) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`IDEvento`, `Nombre Equipo local`, `Visitante`, `Fecha`) VALUES
(1, 'Valencia', 'Madrid', '2020-10-06 20:30:00'),
(2, 'Barcelona', 'Valladolid', '2020-10-07 15:00:00'),
(3, 'Betis', 'Rallo Vallecano', '2020-10-07 21:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercados`
--

CREATE TABLE `mercados` (
  `IdMercado` int NOT NULL,
  `OverUnder` double NOT NULL,
  `Cuota Over` double NOT NULL,
  `Cuota Under` double NOT NULL,
  `Dinero Over` double NOT NULL,
  `Dinero Under` double NOT NULL,
  `IdEvento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mercados`
--

INSERT INTO `mercados` (`OverUnder`, `Cuota Over`, `Cuota Under`, `Dinero Over`, `Dinero Under`, `IdEvento`) VALUES
(1.5, 1.43, 2385, 100, 50, 1),
(2.5, 1.9, 1.9, 100, 100, 2),
(3.5, 2.85, 1.43, 50, 100, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Email` varchar(50) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Apellidos` varchar(20) NOT NULL,
  `Edad` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Email`, `Nombre`, `Apellidos`, `Edad`) VALUES
('usuario4@gmail.com', 'usuario4', 'usuario4', 19);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD PRIMARY KEY (`IdMercado`,`IdEvento`,`Emailusuario`),
  ADD KEY `idx_Emailusuario` (`Emailusuario`),
  ADD KEY `idx_IdMercado` (`IdMercado`),
  ADD KEY `IdEvento` (`IdEvento`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`Numero_cuenta`),
  ADD KEY `Email` (`EmailUsuario`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`IDEvento`);

--
-- Indices de la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD PRIMARY KEY (`IdMercado`,`IdEvento`),
  ADD KEY `merca` (`IdEvento`),
  ADD KEY `idx_OverUnder` (`IdMercado`),
  ADD KEY `idx_OverUnder2` (`IdMercado`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Email`),
  ADD KEY `idx_Email` (`Email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `IDEvento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD CONSTRAINT `apuestas_ibfk_1` FOREIGN KEY (`Emailusuario`) REFERENCES `usuarios` (`Email`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `apuestas_ibfk_2` FOREIGN KEY (`IdEvento`) REFERENCES `eventos` (`IDEvento`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `idx_OverUnder2` FOREIGN KEY (`IdMercado`) REFERENCES `mercados` (`OverUnder`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`EmailUsuario`) REFERENCES `usuarios` (`Email`);

--
-- Filtros para la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD CONSTRAINT `merca` FOREIGN KEY (`IdEvento`) REFERENCES `eventos` (`IDEvento`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
