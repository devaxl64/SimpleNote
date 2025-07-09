CREATE DATABASE IF NOT EXISTS simplenote;
USE simplenote;


-------------
-- TABELAS --
-------------

-----------------------
-- Usuários e Níveis --
-----------------------
CREATE TABLE IF NOT EXISTS simplenote.levels (
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(25) NOT NULL,
aka VARCHAR(5) NOT NULL, -- aka = also know as
PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS simplenote.users (
id INT NOT NULL AUTO_INCREMENT,
fk_idlevel INT NOT NULL,
name VARCHAR(14) NOT NULL,
lastname VARCHAR(14),
email VARCHAR(60),
password VARCHAR(32) NOT NULL,
active BIT(1) NOT NULL DEFAULT 1,
PRIMARY KEY(id),
FOREIGN KEY(fk_idlevel) REFERENCES simplenote.levels(id),
UNIQUE(email)
);

-------------------
-- Notas e Cores --
-------------------
CREATE TABLE IF NOT EXISTS simplenote.colors (
id INT NOT NULL AUTO_INCREMENT,
typecolor int(2) NOT NULL, -- Tipo de cor, para o usuário poder personalizar a cor. (ou não, dá mais trabalho)
weight INT(2) NOT NULL, -- Peso, para o usuário poder filtrar a ordem das notas
active BIT(1) DEFAULT 1, -- para o usuário poder filtrar a quantidade de cores de notas disponívieis.
PRIMARY KEY(id)
);


CREATE TABLE IF NOT EXISTS simplenote.notes (
id INT NOT NULL AUTO_INCREMENT,
fk_iduser INT NOT NULL,
fk_idcolor INT NOT NULL,
tilte VARCHAR(40) NOT NULL,
textt TEXT NOT NULL, -- TEXT: até 65.535 caracteres (64KB) / TINYTEXT: até 255 caracteres.
datte TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
archived BIT(1) NOT NULL DEFAULT 0,
deleted BIT(1) NOT NULL DEFAULT 0,
PRIMARY KEY (id),
FOREIGN KEY (fk_iduser) REFERENCES simplenote.users(id),
FOREIGN KEY (fk_idcolor) REFERENCES simplenote.colors(id)
);

-----------------------
-- POPULNADO TABELAS --
-----------------------
INSERT INTO simplenote.colors (name) VALUES ('Yellow');

INSERT INTO simplenote.levels (name, aka) VALUES ('Administrador', 'ADM');

INSERT INTO simplenote.users (fk_idlevel, name, email, password)
VALUES (1, 'Marcell', 'marcell@email.com', md5('1234')
);

INSERT INTO simplenote.users (fk_idlevel, name, lastname, email, password)
VALUES (1, 'Elayne', '', 'elayne@email.com', md5('1234')
);


----------------
-- PROCEDURES --
----------------
----------------------
-- procdures levels --
----------------------

DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_level_insert (
spname VARCHAR(25),
spaka VARCHAR(5)
)
BEGIN
INSERT INTO levels (name, aka) VALUES (spname, spaka);
SELECT * FROM levels WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;


DELIMITER $$
USE  simplenote $$
CREATE PROCEDURE sp_level_update (
spid INT,
spname VARCHAR(25),
spaka VARCHAR(5)
)
BEGIN
UPDATE niveis SET name = spname, aka = spaka WHERE id = spid;
END $$
DELIMITER ;

---------------------
-- procdures users --
---------------------

DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_user_insert (
spname VARCHAR(14),
splastname VARCHAR(14),
spemail VARCHAR(60),
sppassword VARCHAR(32)
)
BEGIN
INSERT INTO users (name, lastname, email, password)
VALUES (spname, splastname, spemail, sppassword);
SELECT * FROM users WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;

DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_user_update (
spid INT,
spname VARCHAR(14),
splastname VARCHAR(14),
sppassword VARCHAR(32)
)
BEGIN
UPDATE users SET name = spname, lastname = spastname, password = sppassword WHERE id = spid;
SELECT * FROM users WHERE id = LAST_INSERT_ID();
END$$
DELIMITER ;


DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_user_update_name (
spid INT,
spname VARCHAR(14),
splastname VARCHAR(14)
)
BEGIN
UPDATE users SET name = spname, lastname = spastname WHERE id = spid;
SELECT * FROM users WHERE id = LAST_INSERT_ID();
END$$
DELIMITER ;


DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_user_update_password (
spid INT,
sppassword VARCHAR(32)
)
BEGIN
UPDATE users SET password = sppassword WHERE id = spid;
SELECT * FROM users WHERE id = LAST_INSERT_ID();
END$$
DELIMITER ;

----------------------
-- procdures colors --
----------------------
DELIMITER $$
USE simplenote $$
CREATE PROCEDURE sp_color_insert (
spid INT,
sptypecolor INT,
spweight INT,

