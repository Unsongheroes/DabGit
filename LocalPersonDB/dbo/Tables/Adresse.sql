--
-- Create Table    : 'Adresse'   
-- Adresse         :  
-- Vejnavn         :  
-- Husnummer       :  
-- By_PostNummer   : Foreign Key 
-- PostNummer      :  (references By_Postnummer.PostNummer)
--
CREATE TABLE Adresse (
    Adresse        NVARCHAR NOT NULL,
    Vejnavn        NVARCHAR NOT NULL,
    Husnummer      NVARCHAR NOT NULL,
    By_PostNummer  NVARCHAR NOT NULL,
    PostNummer     BIGINT NOT NULL,
CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (Adresse),
CONSTRAINT fk_Adresse FOREIGN KEY (PostNummer)
    REFERENCES By_Postnummer (PostNummer)
    ON DELETE CASCADE
    ON UPDATE CASCADE)