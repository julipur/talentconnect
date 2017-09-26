USE [qudoos_talentconnect]
GO

SET ANSI_NULLS ON
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Jobs]') AND type in (N'U'))
	CREATE TABLE [dbo].[Jobs](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Title] [nvarchar](128) NOT NULL,
		[ShortDescription] [nvarchar](256) NOT NULL,
		[Description] [nvarchar](max) NOT NULL,
		[City] [nvarchar](64) NOT NULL,
		[Province] [nvarchar](64) NOT NULL,
		[JobType] [nvarchar](128) NOT NULL,
		[YearsOfExperience] [int] NULL,
		[ClosingDate] [datetime] NULL,
		[Hours] [int] NOT NULL,
		[Rate] [nvarchar](max) NULL,
		[Active] [bit] NOT NULL,
		[Filled] [bit] NOT NULL,
		[CreatedDate] [datetime] NOT NULL,
	 CONSTRAINT [PK_dbo.Jobs] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Applications]') AND type in (N'U'))
	CREATE TABLE [dbo].Applications(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](128) NOT NULL,
		[EmailAddress] [nvarchar](256) NOT NULL,
		[ResumeId] uniqueidentifier NOT NULL
	 CONSTRAINT [PK_dbo.Applications] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO