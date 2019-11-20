CREATE TABLE [dbo].[CommunityBannedUsers]
(
	 [CommunityId]		BIGINT		NOT NULL
	,[UserId]			BIGINT		NOT NULL

	,CONSTRAINT [PK_CommunityBannedUsers]				PRIMARY KEY		([CommunityId], [UserId])
	,CONSTRAINT [FK_CommunityBannedUsers_Communities]	FOREIGN KEY		([CommunityId])		REFERENCES	[dbo].[Communities]([Id])	--ON DELETE CASCADE
	,CONSTRAINT [FK_CommunityBannedUsers_Users]			FOREIGN KEY		([UserId])			REFERENCES	[dbo].[Users]([Id])			--ON DELETE CASCADE
)
