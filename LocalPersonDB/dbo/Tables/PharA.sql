--
-- Create Table    : 'PharA'   
-- PersonID        :  (references Person.PersonID)
-- Adresse         :  (references Adresse.Adresse)
--
CREATE TABLE PharA (
    PersonID       BIGINT NOT NULL,
    Adresse        NVARCHAR NOT NULL,
CONSTRAINT pk_PharA PRIMARY KEY CLUSTERED (PersonID,Adresse),
CONSTRAINT fk_PharA FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_PharA2 FOREIGN KEY (Adresse)
    REFERENCES Adresse (Adresse)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)