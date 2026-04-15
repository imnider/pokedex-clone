USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PokedexClone')
    CREATE DATABASE PokedexClone;
GO

USE PokedexClone;
GO

-- Sistema
CREATE TABLE Trainer(
	TrainerID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	UserName VARCHAR(30) NOT NULL UNIQUE,
	DisplayName VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Password VARCHAR(255) NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt DATETIME2 NULL,
	DeletedAt DATETIME2 NULL
);
GO

-- Tablas sin FK

CREATE TABLE MoveCategory(
	MoveCategoryID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);
GO

CREATE TABLE ElementalType(
	TypeID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);
GO

CREATE TABLE Ability(
	AbilityID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL,
	Effect VARCHAR(255) NOT NULL,
);
GO

CREATE TABLE EvolutionChain(
	EvolutionChainID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY
);
GO

CREATE TABLE MachineType(
	MachineTypeID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);
GO

-- Tablas normales
CREATE TABLE Move(
	MoveID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	TypeID INT NOT NULL REFERENCES ElementalType(TypeID),
	MoveCategoryID INT NOT NULL REFERENCES MoveCategory(MoveCategoryID),
	DisplayName VARCHAR(30) NOT NULL,
	Power INT NOT NULL,
	Accuracy INT NOT NULL,
	MinPP INT NOT NULL,
	MaxPP INT NOT NULL,
	Effect VARCHAR(255) DEFAULT 'Inflicts regular damage with no additional effect.',
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt DATETIME2 NULL,
	DeletedAt DATETIME2 NULL
);
GO

CREATE TABLE Pokemon(
	PokemonID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL,
	Description VARCHAR(255) NOT NULL,
	SpriteUrl VARCHAR(255) NOT NULL,
	Generation INT NOT NULL,
	HP INT NOT NULL,
	Attack INT NOT NULL,
	Defense INT NOT NULL,
	SpecialAttack INT NOT NULL,
	SpecialDefense INT NOT NULL,
	Speed INT NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	UpdatedAt DATETIME2 NULL,
	DeletedAt DATETIME2 NULL
);
GO

-- Tablas intermedias (N:M)
CREATE TABLE PokemonMove(
	PokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	MoveID UNIQUEIDENTIFIER NOT NULL REFERENCES Move(MoveID),
	MachineTypeID INT REFERENCES MachineType(MachineTypeID),
	RequiredLevel INT,
	RequiresMachine BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_PokemonMove_Pokemon_Move
		PRIMARY KEY (PokemonID, MoveID),
	CONSTRAINT CK_PokemonMove_MachineType
		CHECK ((RequiresMachine = 0) OR (RequiresMachine = 1 AND MachineTypeID IS NOT NULL))
);
GO

CREATE TABLE PokemonType(
	PokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	TypeID INT NOT NULL REFERENCES ElementalType(TypeID),
	Slot INT NOT NULL,
	CONSTRAINT PK_PokemonType_Pokemon_Slot
		PRIMARY KEY (PokemonID, Slot),
	CONSTRAINT UK_PokemonType_Pokemon_Type
		UNIQUE (PokemonID, TypeID),
	CONSTRAINT CK_PokemonType_Slot
		CHECK (Slot IN (1,2))
);
GO

CREATE TABLE PokemonAbility(
	PokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	AbilityID UNIQUEIDENTIFIER NOT NULL REFERENCES Ability(AbilityID),
	IsHidden BIT NOT NULL,
	Slot INT NOT NULL,
	CONSTRAINT PK_PokemonAbility_Pokemon_Slot
		PRIMARY KEY (PokemonID, Slot),
	CONSTRAINT UK_PokemonAbility_Pokemon_Ability
		UNIQUE (PokemonID, AbilityID),
	CONSTRAINT CK_PokemonAbility_Slot
		CHECK (Slot IN (1,3))
--	BACKEND:
--		Validar que un Pok�mon no pueda tener m�s de una habilidad oculta
--		Validar que cuando un Pok�mon tiene m�s de una habilidad, una de ellas debe ser oculta
);
GO

CREATE TABLE PokemonEvolution(
	FromPokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	ToPokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	MinLevel INT NULL,
	IsTrade BIT DEFAULT 0,
	RequiredItem VARCHAR(50),
	ConditionDescription VARCHAR(255),
	CONSTRAINT PK_PokemonEvolution_From_To
		PRIMARY KEY (FromPokemonID, ToPokemonID),
--	ACLARACI�N:
--		Normalmente RequieredItem ser�a una Tabla Item, pero por limitaciones de la Pokedex no se agregar� dicha tabla
);
GO