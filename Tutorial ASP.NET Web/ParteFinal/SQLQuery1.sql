UPDATE Movie SET Title = 'Unknown Title' WHERE Title IS NULL;
UPDATE Movie SET Genre = 'Unknown' WHERE Genre IS NULL;
UPDATE Movie SET Rating = 'NR' WHERE Rating IS NULL;

SELECT * FROM Movie WHERE Title IS NULL OR Genre IS NULL OR Rating IS NULL;

