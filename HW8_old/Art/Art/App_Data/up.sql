CREATE TABLE [dbo].[Artists]
(
	[ARTISTID] INT IDENTITY(1,1) NOT NULL,
	[ARTISTNAME] NVARCHAR(50) NOT NULL,
	[ARTISTDOB] NVARCHAR(64) NOT NULL,
	[BIRTHCITY] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED ([ARTISTID] ASC) 

);

CREATE TABLE [dbo].[ArtWorks]
(
	[ARTWORKID] INT IDENTITY(1,1) NOT NULL,
	[ARTWORKTITLE] NVARCHAR(50) NOT NULL,
	[ARTISTID] INT NOT NULL,

	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY CLUSTERED ([ARTWORKID] ASC),
	CONSTRAINT [FK_dbo.ArtWork_Artists] FOREIGN KEY ([ARTISTID]) REFERENCES dbo.Artists([ARTISTID])

);

CREATE TABLE [dbo].[Genres]
(
	[GENREID] INT IDENTITY(1,1) NOT NULL,
	[GENRENAME] NVARCHAR(50), 

	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED ([GENREID] ASC),

);

CREATE TABLE [dbo].[Classes]
(
	[CLASSID] INT IDENTITY(1,1) NOT NULL,
	[ARTWORKID] INT NOT NULL,
	[GENREID] INT NOT NULL,

	CONSTRAINT [PK_dbo.Classes] PRIMARY KEY CLUSTERED ([CLASSID] ASC),
	CONSTRAINT [FK_dbo.Class_ArtWorks] FOREIGN KEY ([ARTWORKID]) REFERENCES dbo.ArtWorks([ARTWORKID]),
	CONSTRAINT [FK_dbo.Class_Genres] FOREIGN KEY ([GENREID]) REFERENCES dbo.Genres([GENREID])
);


INSERT INTO [dbo].[Artists](ARTISTNAME, ARTISTDOB, BIRTHCITY) VALUES
('M.C. Escher','06/17/1898', 'Leeuwarden, Netherlands'),
('Leonardo Da Vinci', '05/02/1519', 'Vinci, Italy'),
('Hatip Mehmed Efendi', '11/18/1680', 'Unknown' ),
('Salvador Dali', '05/11/1904', 'Figueres, Spain');

INSERT INTO [dbo].[ArtWorks] (ARTWORKTITLE, ARTISTID) VALUES
('Circle Limit III', '1'),
('Twon Tree', '1'),
('Mona Lisa', '2'),
('The Vitruvian Man', '2'),
('Ebru', '3'),
('Honey Is Sweeter Than Blood', '4');

INSERT INTO [dbo].[Genres](GENRENAME) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');

INSERT INTO [dbo].[Classes](ARTWORKID, GENREID) VALUES
('1','1'),
('2','1'),
('2','2'),
('3','3'),
('3','4'),
('4','4'),
('5','1'),
('6','2');


