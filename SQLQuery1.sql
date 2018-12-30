

drop table  [dbo].[Director];
drop table  [dbo].[star];
drop table  [dbo].[genre];
drop table  [dbo].[Movie];
drop table  [dbo].[movieimg];



CREATE TABLE [dbo].[movieimg] (
    [idimg]  INT            DEFAULT (NEXT VALUE FOR [dbo].[id]) NOT NULL,
    [img]    VARCHAR (150)  NOT NULL,
    [title]  NVARCHAR (130) NOT NULL,
    [alt]    NVARCHAR (130) NULL,
    [width]  NVARCHAR (30)  NULL,
    [height] NVARCHAR (30)  NULL,
    CONSTRAINT [PK_movieimg] PRIMARY KEY CLUSTERED ([idimg] ASC)
);



CREATE TABLE [dbo].[Movie] (
    [idmovie]     INT            NOT NULL,
    [title]       NVARCHAR (150) NOT NULL,
    [idimg]       INT            NOT NULL,
    [time]        NVARCHAR (150) NOT NULL,
    [rating]      INT            NOT NULL,
    [Certificate] NVARCHAR (150) NOT NULL,
    [outline]     NVARCHAR (550) NOT NULL,
    [date]        DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([idmovie] ASC),
    UNIQUE NONCLUSTERED ([idimg] ASC),
    CONSTRAINT [FK_dbo.movieimg_dbo.movie_imgId] FOREIGN KEY ([idimg]) REFERENCES [dbo].[movieimg] ([idimg]) ON DELETE CASCADE
);
 CREATE TABLE [dbo].[Director] (
    [NameDirector] NVARCHAR (20) NOT NULL,
    [idmovie]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idmovie] ASC, [NameDirector] ASC),
    CONSTRAINT [FK_dbo.Director_dbo.movie_movieId] FOREIGN KEY ([idmovie]) REFERENCES [dbo].[Movie] ([idmovie]) ON DELETE CASCADE
);
 CREATE TABLE [dbo].[star] (
    [Namestar] NVARCHAR (20) NOT NULL,
    [idmovie]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idmovie] ASC, [Namestar] ASC),
    CONSTRAINT [FK_dbo.star_dbo.movie_movieId] FOREIGN KEY ([idmovie]) REFERENCES [dbo].[Movie] ([idmovie]) ON DELETE CASCADE
);
 CREATE TABLE [dbo].[genre] (
    [Namegenre] NVARCHAR (20) NOT NULL,
    [idmovie]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idmovie] ASC, [Namegenre] ASC),
    CONSTRAINT [FK_dbo.genre_dbo.movie_movieId] FOREIGN KEY ([idmovie]) REFERENCES [dbo].[Movie] ([idmovie]) ON DELETE CASCADE
);
 INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (1, N'https://m.media-amazon.com/images/M/MV5BNTkxNzMyMDMyNF5BMl5BanBnXkFtZTgwNjYwMzgxNjM@._V1_UX140_CR0,0,140,209_AL_.jpg', N'The Wedding (2018)', N'The Wedding (2018) Poster', N'140', N'209')
INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (2, N'https://m.media-amazon.com/images/M/MV5BZWVkMzY5NzgtMTdlNS00NjY5LThjOTktZWFkNDU3NmQzMDIwXkEyXkFqcGdeQXVyODk2NDQ3MTA@._V1_UY209_CR0,0,140,209_AL_.jpg', N'If Beale Street Could Talk (2018)', N'If Beale Street Could Talk (2018) Poster', N'140', N'209')
INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (3, N'https://m.media-amazon.com/images/M/MV5BNzY1MDA2OTQ0N15BMl5BanBnXkFtZTgwMTkzNjU2NTM@._V1_UX140_CR0,0,140,209_AL_.jpg', N'Mortal Engines (2018)', N'Mortal Engines (2018) Poster', N'140', N'209')
INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (4, N'https://m.media-amazon.com/images/M/MV5BMTc1OTc5NzA4OF5BMl5BanBnXkFtZTgwOTAzMzE2NjM@._V1_UY209_CR0,0,140,209_AL_.jpg', N'The Mule (2018)', N'The Mule (2018) Poster', N'140', N'209')
INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (5, N'https://m.media-amazon.com/images/M/MV5BMjMzMzQ0NzI5Nl5BMl5BanBnXkFtZTgwNjc2NTY0NjM@._V1_UY209_CR0,0,140,209_AL_.jpg', N'Spider-Man: Into the Spider-Verse (2018)', N'Spider-Man: Into the Spider-Verse (2018) Poster', N'140', N'209')
INSERT INTO [dbo].[movieimg] ([idimg], [img], [title], [alt], [width], [height]) VALUES (6, N'https://m.media-amazon.com/images/M/MV5BNjk1Njk3YjctMmMyYS00Y2I4LThhMzktN2U0MTMyZTFlYWQ5XkEyXkFqcGdeQXVyODM2ODEzMDA@._V1_UY209_CR34,0,140,209_AL_.jpg', N'Deadpool 2 (2018)', N'Deadpool 2 (2018) Poster', N'140', N'209')
  INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (2, N'The Wedding (2018)', 1, N'75', 34, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/r-2493392566._CB484113634_.png', N' Rami, a young Muslim man, is preparing for his wedding with Sara while fulfilling a queer sexuality in secret due to a strict religious and cultural upbringing.', N'2018-12-15')
INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (3, N'If Beale Street Could Talk (2018)', 2, N'119', 89, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/r-2493392566._CB484113634_.png', N' A woman in Harlem desperately scrambles to prove her fiancé innocent of a crime while carrying their first child.', N'2018-12-15')
INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (4, N'Mortal Engines (2018)', 3, N'128', 45, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/pg_13-2767653680._CB470042446_.png', N' In a post-apocalyptic world where cities ride on wheels and consume each other to survive, two people meet in London and try to stop a conspiracy.', N'2018-12-15')
INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (5, N'The Mule (2018)', 4, N'116', 60, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/r-2493392566._CB484113634_.png', N'A 90-year-old horticulturist and WWII veteran is caught transporting $3 million worth of cocaine through Michigan for a Mexican drug cartel.', N'2018-12-15')
INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (6, N'Spider-Man: Into the Spider-Verse (2018)', 5, N'117', 87, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/pg-1313470000._CB470042461_.png', N'Miles Morales becomes the Spider-Man of his reality and crosses paths with his counterparts from other dimensions to stop a threat to all reality.', N'2018-12-15')
INSERT INTO [dbo].[Movie] ([idmovie], [title], [idimg], [time], [rating], [Certificate], [outline], [date]) VALUES (7, N'Deadpool 2 (2018)', 6, N'119', 66, N'https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/r-2493392566._CB484113634_.png', N'Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool), brings together a team of fellow mutant rogues to protect a young boy with supernatural abilities from the brutal, time-traveling cyborg, Cable.', N'2018-12-15')

 

 INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Sam Abbas', 2)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Barry Jenkins', 3)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Christian Rivers', 4)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Clint Eastwood', 5)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Bob Persichetti', 6)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Peter Ramsey', 6)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'Rodney Rothman', 6)
INSERT INTO [dbo].[Director] ([NameDirector], [idmovie]) VALUES (N'David Leitch', 7)

INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Drama', 2)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Romance', 2)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Crime', 3)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Drama', 3)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Romance', 3)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Action', 4)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Adventure', 4)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Fantasy', 4)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Sci-Fi', 4)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Thriller', 4)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Crime', 5)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Drama', 5)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Mystery', 5)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Thriller', 5)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Action', 6)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Adventure', 6)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Comedy', 6)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Family', 6)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Sci-Fi', 6)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Action', 7)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Adventure', 7)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Comedy', 7)
INSERT INTO [dbo].[genre] ([Namegenre], [idmovie]) VALUES (N'Sci-Fi', 7)

INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Harry Aspinwall', 2)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Hend Ayoub', 2)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Nikohl Boosheri', 2)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Sam Abbas', 2)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Colman Domingo', 3)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'KiKi Layne', 3)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Regina King', 3)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Stephan James', 3)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Hera Hilmar', 4)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Hugo Weaving', 4)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Robert Sheehan', 4)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Bradley Cooper', 5)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Clint Eastwood', 5)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Michael Peña', 5)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Taissa Farmiga', 5)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Hailee Steinfeld', 6)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Jake Johnson', 6)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Mahershala Ali', 6)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Shameik Moore', 6)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Josh Brolin', 7)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Julian Dennison', 7)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Morena Baccarin', 7)
INSERT INTO [dbo].[star] ([Namestar], [idmovie]) VALUES (N'Ryan Reynolds', 7)