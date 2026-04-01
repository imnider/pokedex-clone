USE PokedexClone;
GO

-- DEFAULT VALUES
INSERT INTO [MoveCategory]
	(DisplayName)
VALUES
	('Physical'),
	('Special'),
	('Status');
GO

INSERT INTO [ElementalType]
	(DisplayName)
VALUES
	('Normal'),
    ('Fire'),
    ('Water'),
    ('Grass'),
    ('Electric'),
    ('Ice'),
    ('Fighting'),
    ('Poison'),
    ('Ground'),
    ('Flying'),
    ('Psychic'),
    ('Bug'),
    ('Rock'),
    ('Ghost'),
    ('Dragon'),
    ('Steel'),
    ('Dark'),
    ('Fairy');
GO

INSERT INTO MachineType
	(DisplayName)
VALUES
	('Technical Machine'),
	('Hidden Machine')
GO