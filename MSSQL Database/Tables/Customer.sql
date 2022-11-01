CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CountryId] INT NOT NULL, 
    [CustomerName] NVARCHAR(50) NOT NULL, 
    [FatherName] NVARCHAR(50) NOT NULL, 
    [MotherName] NVARCHAR(50) NOT NULL, 
    [MaritalStatus] INT NOT NULL, 
    [CustomerPhoto] VARBINARY(MAX) NOT NULL, 
    CONSTRAINT [FK_Customer_Country] FOREIGN KEY (CountryId) REFERENCES Country(Id)
)
