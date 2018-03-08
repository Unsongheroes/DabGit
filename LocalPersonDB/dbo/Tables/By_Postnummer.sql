--
-- Create Table    : 'By_Postnummer'   
-- PostNummer      :  
-- Bynavn          :  
-- Land            :  
--
CREATE TABLE By_Postnummer (
    PostNummer     BIGINT NOT NULL,
    Bynavn         NVARCHAR NOT NULL,
    Land           NVARCHAR NOT NULL,
CONSTRAINT pk_By_Postnummer PRIMARY KEY CLUSTERED (PostNummer))