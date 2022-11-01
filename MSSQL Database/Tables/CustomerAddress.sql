CREATE TABLE [dbo].[CustomerAddress]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [CustomerAddress] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_CustomerAddress_Customer] FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
)
