CREATE TABLE [dbo].[Photos] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256) NULL,
    [Description] NVARCHAR (256) NULL,
    [UploadDate]  DATETIME       NOT NULL,
    [FileName]    NVARCHAR (50)  NOT NULL,
    [Owner]       NVARCHAR (256) NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([ID] ASC)
);

