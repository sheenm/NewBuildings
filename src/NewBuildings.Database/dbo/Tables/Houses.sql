CREATE TABLE [dbo].[Houses] (
    [Id]                     INT NOT NULL,
    [ConstructionStage]      INT              NOT NULL,
    [HousingNumber]          INT              NOT NULL,
    [ResidentialComplexName] NVARCHAR (250)   NOT NULL,
    [IdDistrict]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Houses_ToDistricts] FOREIGN KEY ([IdDistrict]) REFERENCES [dbo].[Districts] ([Id])
);

