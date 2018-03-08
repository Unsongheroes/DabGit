--
-- Create Table    : 'TelefonNummer'   
-- TelefonNummer   :  
-- TelefonNummerType :  
-- Teleselskab     :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE TelefonNummer (
    TelefonNummer  BIGINT NOT NULL UNIQUE,
    TelefonNummerType NVARCHAR NOT NULL,
    Teleselskab    NVARCHAR NULL,
    PersonID       BIGINT NULL,
CONSTRAINT pk_TelefonNummer PRIMARY KEY CLUSTERED (TelefonNummer),
CONSTRAINT fk_TelefonNummer FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON UPDATE CASCADE)