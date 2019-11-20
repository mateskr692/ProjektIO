CREATE TABLE [dbo].[Offerts]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[ProposedReturn]		DATETIME		NOT NULL
	,[Comment]				NVARCHAR(2000)	NULL
	,[State]				INT				NOT NULL	DEFAULT 0	--not accepted

	,[SenderId]				BIGINT			NULL
	,[ReceiverId]			BIGINT			NULL
	,[SenderToolId]			BIGINT			NULL
	,[ReceiverToolId]		BIGINT			NULL

	,CONSTRAINT [PK_Offerts]				PRIMARY KEY		([Id])
	,CONSTRAINT [FK_Offerts_Users_Sender]	FOREIGN KEY		([SenderId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Offerts_Users_Receiver]	FOREIGN KEY		([ReceiverId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Offerts_Tools_Sender]	FOREIGN KEY		([SenderToolId])	REFERENCES	[dbo].[Tools]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Offerts_Tools_Receiver]	FOREIGN KEY		([ReceiverToolId])	REFERENCES	[dbo].[Tools]([Id])		--ON DELETE CASCADE

)
