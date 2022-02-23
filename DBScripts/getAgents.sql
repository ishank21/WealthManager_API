USE [AM_DB]
GO

/****** Object:  View [dbo].[getAgents]    Script Date: 13-02-2022 10:54:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[getAgents] as
select 
ad.Id,
ul.userName,
rd.RoleType,
FirstName,
LastName ,
Email	 ,
Address	 ,
PhoneNo	 ,
AgentId AS UserId,
ul.hasActiveRole
from Agent_Detail ad
JOIN UserLogin_Detail ul ON ad.AgentId = ul.UserId
JOIN Role_Detail rd ON rd.RoleId = ul.RoleId
GO


