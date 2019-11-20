CREATE TABLE [dbo].[BlockedUsers]
(
	 [SenderId]		BIGINT		NOT NULL
	,[ReceiverId]	BIGINT		NOT NULL

	,CONSTRAINT [PK_BlockedUsers]					PRIMARY KEY		([SenderId], [ReceiverId])
	,CONSTRAINT [FK_BlockedUsers_Users_Sender]		FOREIGN KEY		([SenderId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_BlockedUsers_Users_Receiver]	FOREIGN KEY		([ReceiverId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
)
