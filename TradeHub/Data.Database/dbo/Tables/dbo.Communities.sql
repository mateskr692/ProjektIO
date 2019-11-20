CREATE TABLE [dbo].[Communities]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Name]					NVARCHAR(100)	NOT NULL
	,[Description]			NVARCHAR(2000)	NULL
	,[Location]				NVARCHAR(200)	NOT NULL


	,CONSTRAINT [PK_Communities]			PRIMARY KEY		([Id])
)
