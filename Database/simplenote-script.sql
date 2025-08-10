DROP DATABASE IF EXISTS simplenote;
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
lastname VARCHAR(14) NOT NULL,
email VARCHAR(60) NOT NULL,
password VARCHAR(32) NOT NULL,
enable BIT(1) NOT NULL DEFAULT 1,
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
enable BIT(1) DEFAULT 1, -- para o usuário poder filtrar a quantidade de cores de notas disponívieis.
PRIMARY KEY(id)
);


CREATE TABLE IF NOT EXISTS simplenote.notes (
id INT NOT NULL AUTO_INCREMENT,
fk_iduser INT NOT NULL,
fk_idcolor INT NOT NULL,
title VARCHAR(40) NOT NULL,
textt TEXT NOT NULL, -- TEXT: até 65.535 caracteres (64KB) / TINYTEXT: até 255 caracteres.
datte TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
archived BIT(1) NOT NULL DEFAULT 0,
deleted BIT(1) NOT NULL DEFAULT 0,
PRIMARY KEY (id),
FOREIGN KEY (fk_iduser) REFERENCES simplenote.users(id),
FOREIGN KEY (fk_idcolor) REFERENCES simplenote.colors(id)
);

-- ALTER TABLE notes 
-- MODIFY datte DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;

-----------------------
-- POPULNADO TABELAS --
-----------------------

INSERT INTO simplenote.colors (typecolor, weight) VALUES (1, 1);

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
DROP PROCEDURE IF EXISTS sp_level_insert $$
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
DROP PROCEDURE IF EXISTS sp_level_update $$
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
DROP PROCEDURE IF EXISTS sp_user_insert $$
CREATE PROCEDURE sp_user_insert (
spname VARCHAR(14),
splastname VARCHAR(14),
spemail VARCHAR(60),
sppassword VARCHAR(32)
)
BEGIN
INSERT INTO simplenote.users (name, lastname, email, password)
VALUES (spname, splastname, spemail, sppassword);
SELECT * FROM simplenote.users WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;

DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_user_update $$
CREATE PROCEDURE sp_user_update (
spid INT,
spname VARCHAR(14),
splastname VARCHAR(14),
sppassword VARCHAR(32)
)
BEGIN
UPDATE simplenote.users SET name = spname, lastname = spastname, password = sppassword WHERE id = spid;
SELECT * FROM simplenote.users WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;


DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_user_update_name $$
CREATE PROCEDURE sp_user_update_name (
spid INT,
spname VARCHAR(14),
splastname VARCHAR(14)
)
BEGIN
UPDATE users SET name = spname, lastname = spastname WHERE id = spid;
SELECT * FROM simplenote.users WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;


DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_user_update_password $$
CREATE PROCEDURE sp_user_update_password (
spid INT,
sppassword VARCHAR(32)
)
BEGIN
UPDATE simplenote.users SET password = sppassword WHERE id = spid;
SELECT * FROM simplenote.users WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;

----------------------
-- procdures colors --
----------------------
DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_color_insert $$
CREATE PROCEDURE sp_color_insert (
sptypecolor INT,
spweight INT
)
BEGIN
INSERT INTO simplenote.colors (typecolor, weight)
VALUES (sptypecolor, spweight);
SELECT * FROM simplenote.colors WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;

DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_color_update $$
CREATE PROCEDURE sp_color_update (
spid INT,
sptypecolor INT,
spweight INT
)
BEGIN
UPDATE simplenote.colors SET typecolor = sptypecolor, weight = spweight WHERE id = spid;
SELECT * FROM simplenote.colors WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;


---------------------
-- procdures notes --
---------------------
DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_note_insert $$
CREATE PROCEDURE sp_note_insert (
spfk_iduser INT,
spfk_idcolor INT,
sptitle VARCHAR(40),
sptextt TEXT
)
BEGIN
INSERT INTO simplenote.notes (fk_iduser, fk_idcolor, title, textt) 
VALUES (spfk_iduser, spfk_idcolor, sptitle, sptextt);
SELECT * FROM simplenote.colors WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;

DELIMITER $$
USE simplenote $$
DROP PROCEDURE IF EXISTS sp_note_update $$
CREATE PROCEDURE sp_note_update (
spid INT,
spfk_iduser INT,
spfk_idcolor INT,
sptitle VARCHAR(40),
sptextt TEXT
)
BEGIN
UPDATE simplenote.notes SET 
fk_iduser = spfk_iduser,  
fk_idcolor = spfk_idcolor, 
title = sptitle, 
textt = sptextt
WHERE id = spid;
SELECT * FROM simplenote.colors WHERE id = LAST_INSERT_ID();
END $$
DELIMITER ;


INSERT INTO simplenote.notes (fk_iduser, fk_idcolor, title, textt) 
VALUES (1, 1, 'titulo', 'texto');

INSERT INTO simplenote.notes (fk_iduser, fk_idcolor, title, textt) 
VALUES (1, 1, 'title', 'teste 2');

INSERT INTO simplenote.notes (fk_iduser, fk_idcolor, title, textt) 
VALUES (2, 1, 'title', 'teste 2'); -- User 2






