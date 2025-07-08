CREATE DATABASE IF NOT EXISTS simplenote;
USE simplenote;

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
actve BIT(1) NOT NULL DEFAULT 1,
PRIMARY KEY(id),
FOREIGN KEY(fk_idlevel) REFERENCES simplenote.levels(id),
UNIQUE(email)
);


CREATE TABLE IF NOT EXISTS simplenote.colors (
id INT NOT NULL AUTO_INCREMENT,
color VARCHAR(25) NOT NULL,
PRIMARY KEY(id)
);


CREATE TABLE IF NOT EXISTS simplenote.notes (
id INT NOT NULL AUTO_INCREMENT,
fk_idcolor INT NOT NULL DEFAULT 1,
tilte VARCHAR(40) NOT NULL,
text VARCHAR(50000) NOT NULL,
datte TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
archived BIT(1) NOT NULL DEFAULT 0,
deleted BIT(1) NOT NULL DEFAULT 0,
PRIMARY KEY (id),
FOREIGN KEY (fk_idcolor) REFERENCES simplenote.colors(id)
);

------------------------
-- POPULNADO TABELAS: --
------------------------
INSERT INTO simplenote.levels (name, aka) VALUES ('Administrador', 'ADM');

INSERT INTO simplenote.users (fk_idlevel, name, email, password)
VALUES (1, 'Marcell', 'marcell@email.com', md5('1234')
);

