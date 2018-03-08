--
-- Create Table    : 'Person'   
-- PersonID        :  
-- Fornavn         :  
-- Mellemnavn      :  
-- Efternavn       :  
-- PersonType      :  
-- E_mail          :  
--
CREATE TABLE Person (
    PersonID       BIGINT NOT NULL UNIQUE,
    Fornavn        NVARCHAR NOT NULL,
    Mellemnavn     NVARCHAR NULL,
    Efternavn      NVARCHAR NOT NULL,
    PersonType     NVARCHAR NOT NULL,
    E_mail         NVARCHAR NULL UNIQUE,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID))