IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [ItemId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [ProductId] int NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Category_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Items] (
    [Id] int NOT NULL,
    [Price] Money NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Items_Products_Id] FOREIGN KEY ([Id]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ItemId', N'Name') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Description], [ItemId], [Name])
VALUES (1, N'Tomato sauce, mozarella, basil.', 1, N'Margharita'),
(2, N'Tomato sauce, mozarella, ham, mushrooms.', 2, N'Capriciosa'),
(3, N'Tomato sauce, mozarella, spicy salami, red onion.', 3, N'Diavola'),
(4, N'Tomato sauce, mozarella, pineapple, ham.', 4, N'Hawaiian');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ItemId', N'Name') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Price') AND [object_id] = OBJECT_ID(N'[Items]'))
    SET IDENTITY_INSERT [Items] ON;
INSERT INTO [Items] ([Id], [Price])
VALUES (1, 20.0),
(2, 22.0),
(3, 24.0),
(4, 22.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Price') AND [object_id] = OBJECT_ID(N'[Items]'))
    SET IDENTITY_INSERT [Items] OFF;
GO

CREATE INDEX [IX_Category_ProductId] ON [Category] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210304164757_QueryingData', N'5.0.3');
GO

COMMIT;
GO

