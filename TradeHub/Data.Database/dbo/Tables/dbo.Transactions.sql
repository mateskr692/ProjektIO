CREATE TABLE [dbo].[Transactions]
(
	 [Id]					BIGINT			NOT NULL	IDENTITY (1,1)
	,[IsFinished]			BIT				NOT NULL	DEFAULT 0	--not finished
	,[StartDate]			DATETIME		NOT NULL
	,[FinishDate]			DATETIME		NOT NULL
	,[StartLocation]		NVARCHAR(200)	NULL
	,[FinishLocation]		NVARCHAR(200)	NULL
	,[ToolState]			INT				NOT NULL	DEFAULT 0	--same as before
	,[LenderComment]		NVARCHAR(2000)	NULL
	,[LenderOpinion]		INT				NOT NULL	DEFAULT 0	--from range -5 ; 5
	,[BorrowerComment]		NVARCHAR(2000)	NULL
	,[BorrowerOpinion]		INT				NOT NULL	DEFAULT 0

	,[LenderId]				BIGINT			NULL
	,[BorowerId]			BIGINT			NULL
	,[LenderToolId]			BIGINT			NULL
	,[BorowerToolId]		BIGINT			NULL



	,CONSTRAINT [PK_Transactions]					PRIMARY KEY		([Id])
	,CONSTRAINT [FK_Transactions_Users_Lender]		FOREIGN KEY		([LenderId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Transactions_Users_Borrower]	FOREIGN KEY		([BorowerId])		REFERENCES	[dbo].[Users]([Id])		--ON DELETE CASCADE
	,CONSTRAINT [FK_Transactions_Tools_Lender]		FOREIGN KEY		([LenderToolId])	REFERENCES	[dbo].[Tools]([Id])		--ON DELETE SET NULL
	,CONSTRAINT [FK_Transactions_Tools_Borrower]	FOREIGN KEY		([BorowerToolId])	REFERENCES	[dbo].[Tools]([Id])		--ON DELETE SET NULL
)
