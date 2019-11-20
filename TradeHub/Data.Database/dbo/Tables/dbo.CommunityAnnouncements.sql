CREATE TABLE [dbo].[CommunityAnnouncements]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Title]				NVARCHAR(100)	NOT NULL
	,[Description]			NVARCHAR(2000)	NULL

	,[CommunityId]			BIGINT			NOT NULL
	,[CreatorId]			BIGINT			NOT NULL

	,CONSTRAINT [PK_CommunityAnnouncements]					PRIMARY KEY		([Id])
	,CONSTRAINT	[FK_CommunityAnnouncements_Communities]		FOREIGN KEY ([CommunityId])		REFERENCES [dbo].[Communities]([ID])		--ON DELETE CASCADE
	,CONSTRAINT [FK_CommunityAnnouncements_Users]			FOREIGN KEY ([CreatorId])		REFERENCES [dbo].[Users]([ID])				--ON DELETE CASCADE
)
