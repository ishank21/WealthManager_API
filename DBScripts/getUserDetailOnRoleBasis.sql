USE [AM_DB]
GO
/****** Object:  StoredProcedure [dbo].[getUserDetailOnRoleBasis]    Script Date: 13-02-2022 15:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getUserDetailOnRoleBasis] @Username NVARCHAR(15)  
AS  
BEGIN  
  --Exec getUserDetailOnRoleBasis 'UR1234'
 DECLARE @Emp_Role VARCHAR(10);  
  
  SELECT @Emp_Role = (  
    SELECT R.RoleType  
    FROM UserLogin_detail U  
    INNER JOIN Role_Detail R ON R.Id = U.roleId  
    WHERE Upper(U.[UserName]) = upper(@Username)  
    )  
 IF ( @Emp_Role = 'Admin')  
 BEGIN  
  SELECT 
    A.Id,
	A.AdminId as UserId,
	U.userName,
	A.Firstname  
   ,A.lastname 
   ,A.Address
   ,A.email  
   ,A.PhoneNo  
   ,U.hasActiveRole  
   ,R.RoleType  
   ,'' AS AgentId
  FROM Admin_detail A  
  INNER JOIN UserLogin_detail U ON U.UserId = A.AdminId  
  INNER JOIN Role_Detail R ON R.Id = U.roleId  
  WHERE upper(U.Username) = upper(@Username)  
  
 END  
 Else if(@Emp_Role = 'Agent')  
 Begin  
 SELECT A.id as Id,
 A.AgentId AS UserId,
 U.userName,
 A.Firstname  
   ,A.lastname 
   ,A.Address
   ,A.email  
   ,A.pHoneNo  
   ,U.hasActiveRole  
   ,R.RoleType  
   ,'' AS AgentId
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
   ,R.RoleType
   ,u.hasActiveRole
   ,c.AgentId
  FROM Client_Detail C  
  INNER JOIN UserLogin_detail U ON U.userId = c.ClientId  
  INNER JOIN Role_Detail R ON R.Id = U.roleId 
  WHERE Upper(U.Username) = Upper(@Username)  
END  
--insert into  UserLogin_detail values ('Ishank123', 'Ishank12#', 'avbdhfhfjhf', 2, 0, 'CL1234') 
--update UserLogin_Detail set UserId='AG1235' where 
-- insert into Agent_Detail values('Ishank34','Khurana21','Ishank21@gmail.com','34-appstreet','989785','AG1234')  
--update UserLogin_details set roleId=2 where id=3  
--insert into Role_Detail values (2,'Client')  
--Insert into Client_Detail values ('CL1234','Khurana','ishank','ishankk21@hmail.com','11-abpstreet',1,'12345','AG1234')  
  
  
-- select * from UserLogin_detail
