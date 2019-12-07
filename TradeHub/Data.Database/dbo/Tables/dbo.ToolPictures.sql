CREATE TABLE [dbo].[ToolPictures]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[PictureData]			VARBINARY(MAX)	NOT NULL
	
	,[ToolId]				BIGINT			NOT NULL


	,CONSTRAINT [PK_ToolPictures]			PRIMARY KEY		([Id])
	,CONSTRAINT	[FK_ToolPictures_Tools]		FOREIGN KEY ([ToolId])		REFERENCES [dbo].[Tools]([ID])		ON DELETE CASCADE
)
