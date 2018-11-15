﻿CREATE TABLE [dbo].[Buyers]
(
	[BUYERID] INT IDENTITY(1,1) NOT NULL,
	[BUYERNAME]	NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED([BUYERID] ASC)
);

CREATE TABLE [dbo].[Sellers]
(
	[SELLERID] INT IDENTITY(1,1) NOT NULL,
	[SELLERNAME] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED([SELLERID] ASC)
);

CREATE TABLE [dbo].[Items]
(
	[ITEMID] INT IDENTITY(1,1) NOT NULL,
	[ITEMNAME] NVARCHAR(128) NOT NULL,
	[SELLERID] INT NOT NULL,

	CONSTRAINT[PK_dbo.Items] PRIMARY KEY CLUSTERED ([ITEMID] ASC),
	CONSTRAINT[FK_dbo.Items_Sellers] FOREIGN KEY ([SELLERID]) REFERENCES dbo.Sellers([SELLERID])
);

CREATE TABLE [dbo].[Bids]
(
	[BIDID] INT IDENTITY(1,1) NOT NULL,
	[PRICE] DECIMAL NOT NULL,
	[ITEMID] INT NOT NULL,
	[BUYERID] INT NOT NULL,
	[TIMESTAMP] DATETIME NOT NULL,

	CONSTRAINT[PK_dbo.Bids] PRIMARY KEY CLUSTERED ([ITEMID] ASC),
	CONSTRAINT[FK_dbo.Bids_Items] FOREIGN KEY ([ITEMID]) REFERENCES dbo.Items([ITEMID]),
	CONSTRAINT[FK_dbo.Bids_Buyers] FOREIGN KEY ([BUYERID]) REFERENCES dbo.Buyers([BUYERID])

);