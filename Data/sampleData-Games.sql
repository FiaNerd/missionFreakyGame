USE FreakyGame

SELECT * FROM HighScores
SELECT * FROM Games

INSERT INTO Games(Title, Description, Genre, ReleaseYear, ImageUrl, UrlSlug)
VALUES 
('Tetris', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Puzzel', 1939, 'https://via.placeholder.com/320x320.png?text=Tetris', 'Tetris'),
('Snake', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Video game', 1928, 'https://via.placeholder.com/320x320.png?text=Snake','Snake'),
('Pacman', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Tv-game', 1984, 'https://via.placeholder.com/320x320.png?text=Pacman', 'Packman'),
('Donky Kong', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'Video game', 1954, 'https://via.placeholder.com/320x320.png?text=DonkyKong', 'DonkyKong')