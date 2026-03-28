-- Tablas sin FK

CREATE TABLE MoveCategory(
	MoveCategoryID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);

CREATE TABLE Type(
	TypeID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);

CREATE TABLE Ability(
	AbilityID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL,
	Effect VARCHAR(255) NOT NULL,
);

CREATE TABLE EvolutionChain(
	EvolutionChainID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY
);

CREATE TABLE MachineType(
	MachineTypeID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	DisplayName VARCHAR(30) NOT NULL
);

-- Tablas normales
CREATE TABLE Move(
	MoveID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	TypeID INT NOT NULL REFERENCES Type(TypeID),
	MoveCategoryID INT NOT NULL REFERENCES MoveCategory(MoveCategoryID),
	DisplayName VARCHAR(30) NOT NULL,
	Power INT NOT NULL,
	Accuracy INT NOT NULL,
	MinPP INT NOT NULL,
	MaxPP INT NOT NULL,
	Effect VARCHAR(255) DEFAULT 'Inflicts regular damage with no additional effect.'
);

CREATE TABLE Pokemon(
	PokemonID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	EvolutionChainID UNIQUEIDENTIFIER NOT NULL REFERENCES EvolutionChain(EvolutionChainID),
	Description VARCHAR(255) NOT NULL,
	Generation INT NOT NULL,
	HP INT NOT NULL,
	Attack INT NOT NULL,
	Defense INT NOT NULL,
	SpecialAttack INT NOT NULL,
	SpecialDefense INT NULL,
	Speed INT NOT NULL
);

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

CREATE TABLE PokemonType(
	PokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	TypeID INT NOT NULL REFERENCES Type(TypeID),
	Slot INT NOT NULL,
	CONSTRAINT PK_PokemonType_Pokemon_Slot
		PRIMARY KEY (PokemonID, Slot),
	CONSTRAINT UK_PokemonType_Pokemon_Type
		UNIQUE (PokemonID, TypeID),
	CONSTRAINT CK_PokemonType_Slot
		CHECK (Slot IN (1,2))
);

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
--		Validar que un Pokémon no pueda tener más de una habilidad oculta
--		Validar que cuando un Pokémon tiene más de una habilidad, una de ellas debe ser oculta
);

CREATE TABLE PokemonEvolution(
	FromPokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	ToPokemonID INT NOT NULL REFERENCES Pokemon(PokemonID),
	MinLevel INT NULL,
	IsTrade BIT DEFAULT 0,
	RequiredItem VARCHAR(50),
	ConditionDescription VARCHAR(255),
	CONSTRAINT PK_PokemonEvolution_From_To
		PRIMARY KEY (FromPokemonID, ToPokemonID),
--	ACLARACIÓN:
--		Normalmente RequieredItem sería una Tabla Item, pero por limitaciones de la Pokedex no se agregará dicha tabla
);