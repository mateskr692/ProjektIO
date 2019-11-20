CREATE TABLE [dbo].[Tools]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Name]					NVARCHAR(100)	NOT NULL
	,[Description]			NVARCHAR(2000)	NULL
	,[Quality]				BIT				NOT NULL	DEFAULT 0	--regular
	,[Availability]			BIT				NOT NULL	DEFAULT 1	--available
	,[Visibility]			INT				NOT NULL	DEFAULT 0	--public

	,[UserId]				BIGINT			NOT NULL


	,CONSTRAINT [PK_Tools]			PRIMARY KEY		([Id])
	,CONSTRAINT [FK_Tools_Users]	FOREIGN KEY		([UserId])	REFERENCES	[dbo].[Users]([Id])		ON DELETE CASCADE
)
