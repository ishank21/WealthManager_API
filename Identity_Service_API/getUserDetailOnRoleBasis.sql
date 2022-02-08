Alter PROCEDURE getUserDetailOnRoleBasis @Username NVARCHAR(15)  
 ,@Password NVARCHAR(30)  
AS  
BEGIN  
--Exec getUserDetailOnRoleBasis 'Ishank12','Ishank123#'  
  
 DECLARE @Emp_Role VARCHAR(10);  
 DECLARE @IsValid INT = 0;  
  
    --To check if credntials are valid--  
 SELECT @isvalid = (  
   SELECT 1  
   FROM UserLogin_detail  
   WHERE Upper([UserName]) = upper(@Username)  
    AND  [Password] = @Password  
   )  
  
 IF (@isvalid = 1)  
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
   ,A.AgentId as AgentId
  FROM Agent_Detail A  
  INNER JOIN UserLogin_detail U ON U.UserId = A.AgentId  
  INNER JOIN Role_Detail R ON R.Id = U.roleId  
  WHERE upper(U.Username) = upper(@Username)  
 End   
 ELSE --For Client  
  SELECT C.Firstname  
   ,c.lastname  
   ,c.address  
   ,c.email  
   ,c.clientType  
   ,U.hasActiverole   
  FROM Client_Detail C  
  INNER JOIN UserLogin_detail U ON U.userId = c.AgentiD  
  WHERE Upper(U.Username) = Upper(@Username)  
END  
--insert into  UserLogin_detail values ('Ishank12', 'Ishank123#', 'avbdhfhfjhf', 1, 0, 'AG1234')  
-- insert into Agent_Detail values('Ishank34','Khurana21','Ishank21@gmail.com','34-appstreet','989785','AG1234')  
--update UserLogin_details set roleId=2 where id=3  
--insert into Role_Detail values (1,'Agent')  
--Insert into Client_Details values (1,'Ishank','Khurana','11,ABP street','ishankk21@hmail.com','292009',1,'CL12345','CL1234')  
  
  
-- select * from UserLogin_detail