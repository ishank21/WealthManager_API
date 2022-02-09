Alter PROCEDURE getUserDetailOnRoleBasis @Username NVARCHAR(15)  
AS  
BEGIN  
--Exec getUserDetailOnRoleBasis 'Ishank123'
  
 DECLARE @Emp_Role VARCHAR(10);  
  
  SELECT @Emp_Role = (  
    SELECT R.RoleType  
    FROM UserLogin_detail U  
    INNER JOIN Role_Detail R ON R.Id = U.roleId  
    WHERE Upper(U.[UserName]) = upper(@Username)  
    )  
 IF ( @Emp_Role = 'Admin')  
 BEGIN  
  SELECT A.Firstname  
   ,A.lastname  
   ,A.email  
   ,A.PhoneNo  
   ,U.hasActiveRole  
   ,R.RoleType  
   ,A.AdminId 
  FROM Admin_detail A  
  INNER JOIN UserLogin_detail U ON U.UserId = A.AdminId  
  INNER JOIN Role_Detail R ON R.Id = U.roleId  
  WHERE upper(U.Username) = upper(@Username)  
  
 END  
 Else if(@Emp_Role = 'Agent')  
 Begin  
 SELECT A.id as Id,
 A.Firstname  
   ,A.lastname  
   ,A.email  
   ,A.pHoneNo  
   ,U.hasActiveRole  
   ,R.RoleType  
   ,A.AgentId 
  FROM Agent_Detail A  
  INNER JOIN UserLogin_detail U ON U.UserId = A.AgentId  
  INNER JOIN Role_Detail R ON R.Id = U.roleId  
  WHERE upper(U.Username) = upper(@Username)  
 End   
 ELSE If(@Emp_Role='Client')  
  SELECT u.Id,
  u.userName,
  u.UserId,
  c.clientType ,
  C.Firstname  
   ,c.lastname  
   ,c.Address 
   ,c.email  
   ,c.PhoneNo
   ,u.hasActiveRole
   ,c.AgentId
  FROM Client_Detail C  
  INNER JOIN UserLogin_detail U ON U.userId = c.ClientId  
  WHERE Upper(U.Username) = Upper(@Username)  
END  
--insert into  UserLogin_detail values ('Ishank123', 'Ishank12#', 'avbdhfhfjhf', 2, 0, 'CL1234') 
--update UserLogin_Detail set UserId='AG1235' where 
-- insert into Agent_Detail values('Ishank34','Khurana21','Ishank21@gmail.com','34-appstreet','989785','AG1234')  
--update UserLogin_details set roleId=2 where id=3  
--insert into Role_Detail values (2,'Client')  
--Insert into Client_Detail values ('CL1234','Khurana','ishank','ishankk21@hmail.com','11-abpstreet',1,'12345','AG1234')  
  
  
-- select * from UserLogin_detail