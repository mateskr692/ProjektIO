CREATE TABLE [dbo].[CommunityHiddenTools]
(
	 [CommunityId]		BIGINT		NOT NULL
	,[ToolId]			BIGINT		NOT NULL

	,CONSTRAINT [PK_CommunityHiddenTools]				PRIMARY KEY		([CommunityId], [ToolId])
	,CONSTRAINT [FK_CommunityHiddenTools_Communities]	FOREIGN KEY		([CommunityId])		REFERENCES	[dbo].[Communities]([Id])	--ON DELETE CASCADE
	,CONSTRAINT [FK_CommunityHiddenTools_Tools]			FOREIGN KEY		([ToolId])			REFERENCES	[dbo].[Tools]([Id])			--ON DELETE CASCADE
)
