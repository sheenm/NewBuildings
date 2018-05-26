CREATE TABLE [dbo].[Districts] (
    [Id]       INT NOT NULL IDENTITY (13006,1),
    [Name]     NVARCHAR (250)   NOT NULL,
    [IdRegion] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Districts_ToRegions] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[Regions] ([Id])
);

