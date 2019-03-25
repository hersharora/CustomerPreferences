USE master
GO

CREATE DATABASE Shoelace
GO

USE [Shoelace]
GO

EXECUTE('CREATE SCHEMA [Preferences]')

/****** Object:  Table [Preferences].[CustomerPreferences]    Script Date: 2019-03-24 11:05:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Preferences].[CustomerPreferences](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[CustomerId] [INT] NOT NULL,
	[Name] [NVARCHAR](100) NOT NULL,
	[TemplateId] [INT] NOT NULL,
	[StartDate] [DATETIME] NULL,
	[Repeat] [INT] NOT NULL,
	[IsActive] [BIT] NOT NULL,
 CONSTRAINT [PK_Preferences.CustomerPreferences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO