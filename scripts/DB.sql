SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema locafacil
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `locafacil` DEFAULT CHARACTER SET latin1 ;
USE `locafacil` ;

-- -----------------------------------------------------
-- Table `locafacil`.`__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`__efmigrationshistory` (
  `MigrationId` VARCHAR(150) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `ProductVersion` VARCHAR(32) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `locafacil`.`uf`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`uf` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Sigla` VARCHAR(2) CHARACTER SET 'latin1' NOT NULL,
  `Nome` VARCHAR(20) CHARACTER SET 'latin1' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`endereco` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Cep` VARCHAR(8) CHARACTER SET 'latin1' NOT NULL,
  `Logradouro` VARCHAR(60) CHARACTER SET 'latin1' NOT NULL,
  `Numero` INT NOT NULL,
  `Complemento` VARCHAR(20) CHARACTER SET 'latin1' NULL DEFAULT NULL,
  `Bairro` VARCHAR(40) CHARACTER SET 'latin1' NOT NULL,
  `Localidade` VARCHAR(60) CHARACTER SET 'latin1' NOT NULL,
  `UfId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_Endereco_UfId` (`UfId` ASC) VISIBLE,
  CONSTRAINT `FK_Endereco_Uf_UfId`
    FOREIGN KEY (`UfId`)
    REFERENCES `locafacil`.`uf` (`Id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`telefone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`telefone` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ddd` VARCHAR(2) CHARACTER SET 'latin1' NULL DEFAULT NULL,
  `numero` VARCHAR(9) CHARACTER SET 'latin1' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`locatario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`locatario` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(60) CHARACTER SET 'latin1' NOT NULL,
  `TelefoneId` INT NOT NULL,
  `EnderecoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_Locatario_EnderecoId` (`EnderecoId` ASC) VISIBLE,
  INDEX `IX_Locatario_TelefoneId` (`TelefoneId` ASC) VISIBLE,
  CONSTRAINT `FK_Locatario_Endereco_EnderecoId`
    FOREIGN KEY (`EnderecoId`)
    REFERENCES `locafacil`.`endereco` (`Id`)
    ON DELETE RESTRICT,
  CONSTRAINT `FK_Locatario_Telefone_TelefoneId`
    FOREIGN KEY (`TelefoneId`)
    REFERENCES `locafacil`.`telefone` (`Id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`proprietario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`proprietario` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(60) CHARACTER SET 'latin1' NOT NULL,
  `TelefoneId` INT NOT NULL,
  `EnderecoId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_Proprietario_EnderecoId` (`EnderecoId` ASC) VISIBLE,
  INDEX `IX_Proprietario_TelefoneId` (`TelefoneId` ASC) VISIBLE,
  CONSTRAINT `FK_Proprietario_Endereco_EnderecoId`
    FOREIGN KEY (`EnderecoId`)
    REFERENCES `locafacil`.`endereco` (`Id`)
    ON DELETE RESTRICT,
  CONSTRAINT `FK_Proprietario_Telefone_TelefoneId`
    FOREIGN KEY (`TelefoneId`)
    REFERENCES `locafacil`.`telefone` (`Id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`tipoimovel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`tipoimovel` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(60) CHARACTER SET 'latin1' NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `locafacil`.`imovel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `locafacil`.`imovel` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `TipoImovelId` INT NOT NULL,
  `EnderecoId` INT NOT NULL,
  `ValorAluguel` DECIMAL(8,2) NOT NULL,
  `ValorCondominio` DECIMAL(8,2) NOT NULL,
  `ValorIPTU` DECIMAL(8,2) NOT NULL,
  `VagaGaragem` DECIMAL(5,0) NOT NULL,
  `Descricao` VARCHAR(400) CHARACTER SET 'latin1' NOT NULL,
  `ProprietarioId` INT NOT NULL,
  `LocatarioId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_Imovel_EnderecoId` (`EnderecoId` ASC) VISIBLE,
  INDEX `IX_Imovel_LocatarioId` (`LocatarioId` ASC) VISIBLE,
  INDEX `IX_Imovel_ProprietarioId` (`ProprietarioId` ASC) VISIBLE,
  INDEX `IX_Imovel_TipoImovelId` (`TipoImovelId` ASC) VISIBLE,
  CONSTRAINT `FK_Imovel_Endereco_EnderecoId`
    FOREIGN KEY (`EnderecoId`)
    REFERENCES `locafacil`.`endereco` (`Id`)
    ON DELETE RESTRICT,
  CONSTRAINT `FK_Imovel_Locatario_LocatarioId`
    FOREIGN KEY (`LocatarioId`)
    REFERENCES `locafacil`.`locatario` (`Id`)
    ON DELETE RESTRICT,
  CONSTRAINT `FK_Imovel_Proprietario_ProprietarioId`
    FOREIGN KEY (`ProprietarioId`)
    REFERENCES `locafacil`.`proprietario` (`Id`)
    ON DELETE RESTRICT,
  CONSTRAINT `FK_Imovel_TipoImovel_TipoImovelId`
    FOREIGN KEY (`TipoImovelId`)
    REFERENCES `locafacil`.`tipoimovel` (`Id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


-- Tabela de UF
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('AC','Acre');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('AL','Alagoas');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('AP','Amap??');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('AM','Amazonas');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('BA','Bahia');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('CE','Ceara');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('DF','Distrito Federal');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('ES','Esp??rito Santo');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('GO','Goi??s');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('MA','Maranh??o');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('MT','Mato Grosso');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('MS','Mato Grosso do Sul');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('MG','Minas Gerais');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('PA','Par??');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('PB','Para??ba');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('PR','Paran??');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('PE','Pernambuco');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('PI','Piau??');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('RJ','Rio de Janeiro');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('RN','Rio Grande do Norte');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('RS','Rio Grande do Sul');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('RO','Rond??nia');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('RR','Roraima');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('SC','Santa Catarina');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('SP','S??o Paulo');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('SE','Sergipe');
INSERT INTO `uf` (`sigla`,`nome`) VALUES ('TO','Tocantins');

-- Tabela de Tipos de Im??veis
INSERT INTO `tipoimovel` (`descricao`) VALUES ('Apartamento');
INSERT INTO `tipoimovel` (`descricao`) VALUES ('Casa');
INSERT INTO `tipoimovel` (`descricao`) VALUES ('Sala comercial');
INSERT INTO `tipoimovel` (`descricao`) VALUES ('Galp??o');
INSERT INTO `tipoimovel` (`descricao`) VALUES ('Lote');

