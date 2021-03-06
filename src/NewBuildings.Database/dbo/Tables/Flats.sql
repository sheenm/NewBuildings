﻿CREATE TABLE [dbo].[Flats] (
    [Id]          INT NOT NULL IDENTITY(1785354, 1),
    [IdHouse]     INT NOT NULL,
    [RoomsCount]  INT              NOT NULL,
    [FullArea]    FLOAT              NOT NULL,
    [KitchenArea] FLOAT              NOT NULL,
    [Floor]       INT              NOT NULL,
    [Cost]        DECIMAL (18)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Flats_ToHouses] FOREIGN KEY ([IdHouse]) REFERENCES [dbo].[Houses] ([Id])
);

