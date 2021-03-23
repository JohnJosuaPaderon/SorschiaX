USE [Sorschia];
GO

CREATE TABLE [dbo].[UserApplication]
(
    [Id] BIGINT IDENTITY,
    [UserId] INT NOT NULL,
    [ApplicationId] SMALLINT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_UserApplication] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserApplication_UserId] FOREIGN KEY([UserId]) REFERENCES [dbo].[User]([Id]),
    CONSTRAINT [FK_UserApplication_ApplicationId] FOREIGN KEY([ApplicationId]) REFERENCES [dbo].[Application]([Id])
);

ALTER TABLE [dbo].[UserApplication] ADD
    CONSTRAINT [DF_UserApplication_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO