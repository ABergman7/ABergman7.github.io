CREATE TABLE [dbo].[Buyers]
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
	[ITEMID] INT IDENTITY(1001,1) NOT NULL,
	[ITEMNAME] NVARCHAR(128) NOT NULL,
	[ITEMDESC] NVARCHAR(MAX) NOT NULL,
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

INSERT INTO [dbo].[Buyers](BUYERNAME) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO [dbo].[Sellers](SELLERNAME) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO [dbo].[Items](ITEMNAME,ITEMDESC, SELLERID) VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 1),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 2),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 3);

INSERT INTO [dbo].[Bids](ITEMID, BUYERID, PRICE, TIMESTAMP) VALUES
(1001, 3, 250000,'12/04/2017 09:04:22'),
(1003, 1, 95000 ,'12/04/2017 08:44:03');

GO
