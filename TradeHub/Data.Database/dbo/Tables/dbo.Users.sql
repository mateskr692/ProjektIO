CREATE TABLE [dbo].[Users]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Login]				NVARCHAR(50)	NOT NULL
	,[Email]				NVARCHAR(200)	NOT NULL
	,[Password]				BINARY(32)		NOT NULL
	,[Salt]					BINARY(4)		NOT NULL
	,[FirstName]			NVARCHAR(50)	NULL
	,[LastName]				NVARCHAR(50)	NULL
	,[NameVisibility]		INT				NOT NULL	DEFAULT 1	--visible
	,[Contact]				NVARCHAR(200)	NULL
	,[ContactVisibility]	INT				NOT NULL	DEFAULT 1	--visible
	,[Address]				NVARCHAR(200)	NULL
	,[AdressVisibility]		INT				NOT NULL	DEFAULT 1	--visible

	,CONSTRAINT [PK_Users]			PRIMARY KEY		([Id])
	,CONSTRAINT [UK_Users_Login]	UNIQUE			([Login])
	,CONSTRAINT [UK_Users_Email]	UNIQUE			([Email])
)
