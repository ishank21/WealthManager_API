Create PROCEDURE isAuthenticate @Username NVARCHAR(15)  
 ,@Password NVARCHAR(30)  
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
    AND  [Password] = @Password  
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