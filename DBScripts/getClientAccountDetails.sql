Alter FUNCTION getAccountInformationForClient (@ClientId Varchar(255))  
RETURNS TABLE  
AS  
RETURN  
   SELECT 
   Id,
   AccountId,  
CustodianId,  
CustodianName,  
RegisteredName,  
ClientID,  
CustodianAccountNumber,  
MarketValue,  
ProgramId,  
ProgramName,  
IsClosed  
FROM ClientAccount_Detail where ClientID=@ClientId  

 --insert into ClientAccount_Detail values('1234','3456','alpha','beta','CL1234','123456','32','12','ishankp',0)