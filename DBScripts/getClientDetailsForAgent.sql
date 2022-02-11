Alter FUNCTION getClientDetailsForAgent (@AgentId Varchar(255))    
RETURNS TABLE    
AS    
RETURN    
   SELECT  
   u.Id,  
   u.userName,  
   u.UserId,  
   u.hasActiveRole,  
   c.FirstName,    
c.LastName,    
c.Address,    
c.Email,    
c.PhoneNo,    
c.ClientType,    
c.ClientID,    
c.AgentId,
R.RoleType
FROM Client_detail C  
inner join UserLogin_Detail U on u.UserId=C.AgentId
inner join Role_Detail R on R.RoleId=u.RoleId where c.AgentId=@AgentId    
  
--select * from getClientDetailsForAgent('AG1234')