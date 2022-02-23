CREATE FUNCTION [dbo].[getClientDetailsForAgent] (@AgentId Varchar(255))  
RETURNS TABLE  
AS  
RETURN  
   SELECT
   u1.Id,
   u1.userName,
   u1.UserId,
   u1.hasActiveRole,
   c.FirstName,  
c.LastName,  
c.Address,  
c.Email,  
c.PhoneNo, 
rd.RoleType,
c.ClientType,    
c.AgentId  
FROM Client_detail C
inner join UserLogin_Detail u1 on u1.UserId=C.ClientId 
inner join UserLogin_Detail u2 on u2.UserId=C.AgentId 
JOIN Role_Detail rd ON rd.RoleId = u1.RoleId where c.AgentId=@AgentId  

--select * from getClientDetailsForAgent('AG1234')