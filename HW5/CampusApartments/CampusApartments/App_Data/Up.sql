--- Create the Database

CREATE TABLE [dbo].[Tenants]
(
	[ID]		 INT IDENTITY (1,1)  NOT NULL,
	[FirstName]  NVARCHAR(64)		 NOT NULL,
	[LastName]   NVARCHAR(128)		 NOT NULL,
	[UnitNumber] SMALLINT(999)		 NOT NULL,
	[AptName]	 NVARCHAR(128)		 NOT NULL,
	[Reason]	 NVARCHAR			 NOT NULL,
	[DateReq]	 DATETIME			 NOT NULL,
	[PhonNum]	 INT(10)			 NOT NULL,
	[Permission] BIT				 NOT NULL,


	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)

);