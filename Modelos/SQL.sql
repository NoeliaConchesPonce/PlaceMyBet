-- MySQL Script generated by MySQL Workbench
-- Thu Sep 24 20:01:04 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Mercados`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Mercados` (
  `IDMercados` FLOAT NOT NULL,
  `IDEventos` VARCHAR(45) NOT NULL,
  `cuotaOver` FLOAT NOT NULL,
  `cuotaUnder` FLOAT NOT NULL,
  `dineroApostOver` FLOAT NOT NULL,
  `dineroApostUnder` FLOAT NOT NULL,mysqlmysqlmydbmercados
  `Email` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`IDMercados`, `IDEventos`, `Email`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Eventos de futbol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Eventos de futbol` (
  `NombreEquipoLocal` VARCHAR(15) NOT NULL,
  `NombreEquipoVisitante` VARCHAR(45) NOT NULL,
  `Fecha` DATETIME NOT NULL,
  `IDEventos` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IDEventos`),
  CONSTRAINT `eventos`
    FOREIGN KEY (`IDEventos`)
    REFERENCES `mydb`.`Mercados` (`IDEventos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Usuarios` (
  `Email` VARCHAR(40) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellidos` VARCHAR(45) NOT NULL,
  `Edad` INT NOT NULL,
  `numTarjeta` INT NOT NULL,
  `IDapuestas` INT NOT NULL,
  PRIMARY KEY (`Email`, `numTarjeta`, `IDapuestas`),
  CONSTRAINT `email`
    FOREIGN KEY (`Email`)
    REFERENCES `mydb`.`Mercados` (`Email`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Cuenta Vinculada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Cuenta Vinculada` (
  `SaldoActual` FLOAT NOT NULL,
  `NombreBanco` VARCHAR(45) NOT NULL,
  `numTarjeta` INT NOT NULL,
  PRIMARY KEY (`numTarjeta`),
  CONSTRAINT `num`
    FOREIGN KEY (`numTarjeta`)
    REFERENCES `mydb`.`Usuarios` (`numTarjeta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Apuestas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Apuestas` (
  `NombreMercado` VARCHAR(40) NOT NULL,
  `TipoApuesta` VARCHAR(45) NOT NULL,
  `Cuota` INT NOT NULL,
  `Fecha` DATETIME NOT NULL,
  `IDapuestas` INT NOT NULL,
  PRIMARY KEY (`IDapuestas`),
  CONSTRAINT `id`
    FOREIGN KEY (`IDapuestas`)
    REFERENCES `mydb`.`Usuarios` (`IDapuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
