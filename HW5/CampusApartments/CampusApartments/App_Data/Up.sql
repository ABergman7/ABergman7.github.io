--- Create the Database

CREATE TABLE [dbo].[Tenants]
(
	[ID]		 INT IDENTITY (1,1)  NOT NULL,
	[FirstName]  NVARCHAR(64)		 NOT NULL,
	[LastName]   NVARCHAR(128)		 NOT NULL,
	[UnitNumber] INT				 NOT NULL,
	[AptName]	 NVARCHAR(40)		 NOT NULL,
	[Reason]	 NVARCHAR(1000)		 NOT NULL,
	[PhonNum]	 BIGINT			     NOT NULL,
	[Permission] BIT				 NOT NULL,
	[DateReq]	 DATETIME			 NOT NULL,

	CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)

);

INSERT INTO [dbo].[Tenants] (FirstName, LastName, UnitNumber, AptName, Reason, PhonNum, Permission, DateReq) VALUES
('Jim','Johnson','317','Bobs Apartments','Broken Toilet', '5552228888', '1', '2018-10-24  12:45:23'),
('Bill','Williams','215','Bobs Apartments','Broken Window', '5552334444', '0', '2018-08-12  12:45:23'),
('John','Johnson','318','Bobs Apartments','Broken Toilet', '5552228888', '1', '2018-05-12  12:45:23')

GO


