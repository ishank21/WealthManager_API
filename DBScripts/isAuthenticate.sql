<<<<<<< HEAD
USE [AM_DB]
GO
/****** Object:  StoredProcedure [dbo].[isAuthenticate]    Script Date: 22-02-2022 16:55:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[isAuthenticate] @Username NVARCHAR(15)  
=======
Alter PROCEDURE isAuthenticate @Username NVARCHAR(15)  
>>>>>>> b59b9e02f988b0655ebf1b030c681a8f981e8ddf
AS  
BEGIN  
 DECLARE @IsValid INT = 0;  
 Declare @Roletype Varchar(max);

Declare @AuthCred Table(isvalid int,Roletype varchar(max))

  
    --To check if credntials are valid-
set @isvalid=(
   SELECT 1
   FROM UserLogin_detail  
<<<<<<< HEAD
   WHERE Upper([UserName]) = upper(@Username)
=======
   WHERE Upper([UserName]) = upper(@Username)  
>>>>>>> b59b9e02f988b0655ebf1b030c681a8f981e8ddf
	)

   Set @Roletype = (SELECT R.RoleType
   FROM UserLogin_detail U
   inner join Role_Detail R on R.RoleId=U.RoleId
   WHERE Upper([UserName]) = upper(@Username)  
   )
   Insert into @AuthCred values (@IsValid,@Roletype)
   Select isvalid,roletype from @AuthCred
   END

   --Exec isAuthenticate 'Ishank123','Ishank12#'