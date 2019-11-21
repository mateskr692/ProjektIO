CREATE TABLE [dbo].[Messages]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[Title]				NVARCHAR(100)	NOT NULL
	,[Content]				NVARCHAR(2000)	NULL
	,[SendDate]				DATETIME		NOT NULL

	,[SenderId]				BIGINT			NULL
	,[ReceiverId]			BIGINT			NULL


	,CONSTRAINT [PK_Messages]					PRIMARY KEY		([Id])
	,CONSTRAINT [FK_Messages_Users_Sender]		FOREIGN KEY		([SenderId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Messages_Users_Receiver]	FOREIGN KEY		([ReceiverId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
)
