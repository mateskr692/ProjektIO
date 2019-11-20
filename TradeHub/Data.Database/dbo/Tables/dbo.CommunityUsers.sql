CREATE TABLE [dbo].[CommunityUsers]
(
	 [CommunityId]		BIGINT		NOT NULL
	,[UserId]			BIGINT		NOT NULL

	,CONSTRAINT [PK_CommunityUsers]					PRIMARY KEY		([CommunityId], [UserId])
	,CONSTRAINT [FK_CommunityUsers_Communities]		FOREIGN KEY		([CommunityId])		REFERENCES	[dbo].[Communities]([Id])	--ON DELETE CASCADE
	,CONSTRAINT [FK_CommunityUsers_Users]			FOREIGN KEY		([UserId])			REFERENCES	[dbo].[Users]([Id])			--ON DELETE CASCADE
)
