CREATE TABLE [dbo].[Notifications]
(
	 [Id]			BIGINT			NOT NULL	IDENTITY (1,1)
	,[Type]			INT				NOT NULL
	,[Content]		NVARCHAR(2000)	NULL

	,[UserId]		BIGINT			NOT NULL


	,CONSTRAINT [PK_Notifications]			PRIMARY KEY		([Id])
	,CONSTRAINT [FK_Notifications_Users]	FOREIGN KEY		([UserId])		REFERENCES	[dbo].[Users]([Id])		ON DELETE CASCADE
)
