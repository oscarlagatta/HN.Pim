CREATE TABLE [dbo].[StyleColour] (
    [StyleID]             INT      NOT NULL,
    [Colour]              CHAR (4) NOT NULL,
    [HasImage]            BIT      NOT NULL,
    [MagentoIndexValue]   INT      NULL,
    [StyleColourID]       INT      NOT NULL,
    [IncludeInFeed]       BIT      NULL,
    [IsDirty]             BIT      NULL,
    [MagentoID]           INT      NULL,
    [EnabledMagento]      BIT      NULL,
    [FirstEnabled]        DATETIME NULL,
    [IsExportedToYesmail] BIT      NOT NULL
);

