USE `Soft`;

LOCK TABLES `Accounts` WRITE;

ALTER TABLE `Accounts` 
	ADD		`UpdatedByAccountId`		BIGINT UNSIGNED		NOT NULL		DEFAULT 1;

UNLOCK TABLES;