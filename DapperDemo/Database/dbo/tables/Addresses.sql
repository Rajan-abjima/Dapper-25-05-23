CREATE TABLE [dbo].[Addresses]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [ContactId] INT NOT NULL, 
    [AddressType] NCHAR(10) NOT NULL, 
    [StreetAddress] NCHAR(50) NOT NULL, 
    [City] NCHAR(50) NOT NULL, 
    [StateId] INT NOT NULL, 
    [PostalCode] NCHAR(20) NOT NULL, 
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresses_Contacts] FOREIGN KEY([ContactId]) REFERENCES Contacts(Id),
    CONSTRAINT [FK_Addresses_States] FOREIGN kEY([StateId]) REFERENCES States(Id)
)
