﻿CREATE TABLE [dbo].[Districts] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (250)   NOT NULL,
    [IdRegion] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Districts_ToRegions] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[Regions] ([Id])
);

