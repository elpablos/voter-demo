CREATE TYPE [dbo].[DN] FROM [nvarchar](255) NOT NULL
GO

CREATE TYPE [dbo].[GUID] FROM [uniqueidentifier] NOT NULL
GO

CREATE TYPE [dbo].[ID] FROM [int] NOT NULL
GO

CREATE TYPE [dbo].[IDVC] FROM [nvarchar](50) NOT NULL
GO

CREATE TYPE [dbo].[IsActive] FROM [bit] NOT NULL
GO

CREATE TYPE [dbo].[Note] FROM [nvarchar](max) NULL
GO

CREATE TYPE [dbo].[ValidateMessages] AS TABLE(
	[Property] [nvarchar](255) NULL,
	[DisplayName] [nvarchar](255) NULL,
	[ResourceName] [nvarchar](255) NULL,
	[Args] [nvarchar](max) NULL
)
GO

CREATE TABLE [dbo].[CR_Module](
	[ID] [dbo].[IDVC] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_CR_Module] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CR_Module] ADD  CONSTRAINT [DF_CR_Module_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jedineèné ID modulu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Module', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zda je záznam aktivní' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Module', @level2type=N'COLUMN',@level2name=N'IsActive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Název' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Module', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO

CREATE TABLE [dbo].[CR_Table](
	[ID] [dbo].[IDVC] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[ID_TableParent] [dbo].[IDVC] NULL,
	[IsActionParent] [bit] NOT NULL,
	[ID_Module] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CR_Table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CR_Table] ADD  CONSTRAINT [DF_CR_Table_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[CR_Table] ADD  CONSTRAINT [DF_CR_Table_Module]  DEFAULT (N'core') FOR [ID_Module]
GO

ALTER TABLE [dbo].[CR_Table]  WITH CHECK ADD  CONSTRAINT [FK_CR_Table_CR_Module] FOREIGN KEY([ID_Module])
REFERENCES [dbo].[CR_Module] ([ID])
GO

ALTER TABLE [dbo].[CR_Table] CHECK CONSTRAINT [FK_CR_Table_CR_Module]
GO

ALTER TABLE [dbo].[CR_Table]  WITH CHECK ADD  CONSTRAINT [FK_CR_Table_CR_TableParent] FOREIGN KEY([ID_TableParent])
REFERENCES [dbo].[CR_Table] ([ID])
GO

ALTER TABLE [dbo].[CR_Table] CHECK CONSTRAINT [FK_CR_Table_CR_TableParent]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jedineèné ID tabulky' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zda je záznam aktivní' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'IsActive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabulka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nadøízená tabulka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'ID_TableParent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ovìøování akcí v nadøízené tabulce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'IsActionParent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Modul' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Table', @level2type=N'COLUMN',@level2name=N'ID_Module'
GO

CREATE TABLE [dbo].[CR_ActionType](
	[ID] [dbo].[IDVC] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_CR_ActionType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CR_ActionType] ADD  CONSTRAINT [DF_CR_ActionType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jedineèné ID typu akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_ActionType', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Je aktivní' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_ActionType', @level2type=N'COLUMN',@level2name=N'IsActive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_ActionType', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO

-- Data: CR_ActionType
if not exists(select * from [CR_ActionType] where [ID]=N'all')
  insert into [CR_ActionType] ([ID], [IsActive], [DisplayName]) values (N'all', 1, N'Výèet')
else
  update [CR_ActionType] set
    [IsActive]=1,
    [DisplayName]=N'Výèet'
  where [ID]=N'all'

GO

if not exists(select * from [CR_ActionType] where [ID]=N'del')
  insert into [CR_ActionType] ([ID], [IsActive], [DisplayName]) values (N'del', 1, N'Smazání')
else
  update [CR_ActionType] set
    [IsActive]=1,
    [DisplayName]=N'Smazání'
  where [ID]=N'del'

GO

if not exists(select * from [CR_ActionType] where [ID]=N'detail')
  insert into [CR_ActionType] ([ID], [IsActive], [DisplayName]) values (N'detail', 1, N'Detail')
else
  update [CR_ActionType] set
    [IsActive]=1,
    [DisplayName]=N'Detail'
  where [ID]=N'detail'

GO

if not exists(select * from [CR_ActionType] where [ID]=N'edit')
  insert into [CR_ActionType] ([ID], [IsActive], [DisplayName]) values (N'edit', 1, N'Úprava')
else
  update [CR_ActionType] set
    [IsActive]=1,
    [DisplayName]=N'Úprava'
  where [ID]=N'edit'

GO

if not exists(select * from [CR_ActionType] where [ID]=N'new')
  insert into [CR_ActionType] ([ID], [IsActive], [DisplayName]) values (N'new', 1, N'Založení')
else
  update [CR_ActionType] set
    [IsActive]=1,
    [DisplayName]=N'Založení'
  where [ID]=N'new'

GO



CREATE TABLE [dbo].[CR_Action](
	[ID] [dbo].[IDVC] NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[ID_Table] [nvarchar](50) NOT NULL,
	[ID_TableRelation] [dbo].[IDVC] NULL,
	[ID_ActionType] [nvarchar](50) NOT NULL,
	[RequiredRecord] [bit] NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
 CONSTRAINT [PK_CR_Action] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CR_Action]  WITH CHECK ADD  CONSTRAINT [FK_CR_Action_CR_ActionType] FOREIGN KEY([ID_ActionType])
REFERENCES [dbo].[CR_ActionType] ([ID])
GO

ALTER TABLE [dbo].[CR_Action] CHECK CONSTRAINT [FK_CR_Action_CR_ActionType]
GO

ALTER TABLE [dbo].[CR_Action]  WITH CHECK ADD  CONSTRAINT [FK_CR_Action_CR_Table] FOREIGN KEY([ID_Table])
REFERENCES [dbo].[CR_Table] ([ID])
GO

ALTER TABLE [dbo].[CR_Action] CHECK CONSTRAINT [FK_CR_Action_CR_Table]
GO

ALTER TABLE [dbo].[CR_Action]  WITH CHECK ADD  CONSTRAINT [FK_CR_Action_CR_TableRelation] FOREIGN KEY([ID_TableRelation])
REFERENCES [dbo].[CR_Table] ([ID])
GO

ALTER TABLE [dbo].[CR_Action] CHECK CONSTRAINT [FK_CR_Action_CR_TableRelation]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jedineèné ID akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Název akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabulka akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'ID_Table'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Podøízená tabulka' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'ID_TableRelation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ akce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'ID_ActionType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zda vyžaduje záznam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'RequiredRecord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zda lze volat anonymnì' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CR_Action', @level2type=N'COLUMN',@level2name=N'IsAnonymous'
GO

CREATE FUNCTION [dbo].[FN_GetValidationXml]
(
@Messages ValidateMessages readonly
)
RETURNS Note
BEGIN
	return '<validation>' + (select * from @Messages for xml path) + '</validation>'
END
GO

CREATE FUNCTION [dbo].[FN_GetErrorXml]
(
@Messages ValidateMessages readonly
)
RETURNS Note
BEGIN
	return '<error>' + (select * from @Messages for xml path) + '</error>'
END
GO
