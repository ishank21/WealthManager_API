
/****** Object:  StoredProcedure [dbo].[isAuthenticate]    Script Date: 23-02-2022 12:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[isAuthenticate] @Username NVARCHAR(15)  
AS  
BEGIN  
 DECLARE @IsValid INT = 0;  
 Declare @Roletype Varchar(max);

Declare @AuthCred Table(isvalid int,Roletype varchar(max))

  
    --To check if credntials are valid-
set @isvalid=(
   SELECT 1
   FROM UserLogin_detail  
   WHERE Upper([UserName]) = upper(@Username)
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