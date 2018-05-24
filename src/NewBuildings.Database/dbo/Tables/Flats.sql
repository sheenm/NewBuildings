CREATE TABLE [dbo].[Flats] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [IdHouse]     UNIQUEIDENTIFIER NOT NULL,
    [RoomsCount]  INT              NOT NULL,
    [FullArea]    INT              NOT NULL,
    [KitchenArea] INT              NOT NULL,
    [Floor]       INT              NOT NULL,
    [Cost]        DECIMAL (18)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Flats_ToHouses] FOREIGN KEY ([IdHouse]) REFERENCES [dbo].[Houses] ([Id])
);

