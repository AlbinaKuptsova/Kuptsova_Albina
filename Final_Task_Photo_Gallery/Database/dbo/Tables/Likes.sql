CREATE TABLE [dbo].[Likes] (
    [PhotoID]  INT           NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    CONSTRAINT [FK_Likes_Photos] FOREIGN KEY ([PhotoID]) REFERENCES [dbo].[Photos] ([ID]) ON DELETE CASCADE
);

