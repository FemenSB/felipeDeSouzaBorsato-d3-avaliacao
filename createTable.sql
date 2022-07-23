CREATE TABLE `felipedesouzaborsato-d3-avaliacao`.`users` (`Id` INT NOT NULL AUTO_INCREMENT , `Nome` VARCHAR(100) NOT NULL , `Email` VARCHAR(100) NOT NULL , `Senha` VARCHAR(100) NOT NULL , PRIMARY KEY (`Id`)) ENGINE = InnoDB;

INSERT INTO `users` (`Id`, `Nome`, `Email`, `Senha`) VALUES (NULL, 'System Admin', 'admin@email.com', '$2a$11$WLO3BpyKDJ47XRHnitU4SeFxX/fq.6itCRxIglGV62nao3.wpG5/O');