CREATE TABLE [dbo].[Requests]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Type]					INT				NOT NULL

	,[UserId]				BIGINT			NOT NULL
	,[CommunityId]			BIGINT			NOT NULL


	,CONSTRAINT	[PK_Requests]				PRIMARY KEY		([Id])
	,CONSTRAINT	[FK_Requests_Users]			FOREIGN KEY		([UserId])		REFERENCES	[dbo].[Users]([Id])			ON DELETE CASCADE
	,CONSTRAINT	[FK_Requests_Communities]	FOREIGN KEY		([CommunityId])	REFERENCES	[dbo].[Communities]([Id])	ON DELETE CASCADE

)
