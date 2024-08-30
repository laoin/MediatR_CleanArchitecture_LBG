IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SamplesDB')
BEGIN
    CREATE DATABASE SamplesDB;
END
GO

USE [SamplesDB]
GO
/****** Object:  Table [dbo].[DecisionMadeData]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DecisionMadeData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NULL,
	[Policy] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[ProductCategory] [nvarchar](50) NULL,
	[Premium] [nvarchar](50) NULL,
	[LastUpdated] [datetime] NULL,
	[ExpiresIn] [nvarchar](50) NULL,
	[Decision] [nvarchar](50) NULL,
	[NeedAttention] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LivePoliciesData]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LivePoliciesData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NULL,
	[Policy] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[ProductCategory] [nvarchar](50) NULL,
	[Premium] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
	[SummaryIssue] [nvarchar](max) NULL,
	[NeedAttention] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferredCasesData]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferredCasesData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NULL,
	[Policy] [nvarchar](max) NULL,
	[Product] [nvarchar](max) NULL,
	[ProductCategory] [nvarchar](max) NULL,
	[LastUpdated] [datetime] NOT NULL,
	[CurrentStatus] [nvarchar](max) NULL,
	[NeedAttention] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TodoItems]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ListId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Priority] [int] NOT NULL,
	[Reminder] [datetime2](7) NULL,
	[Done] [bit] NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetimeoffset](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TodoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TodoLists]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Colour_Code] [nvarchar](max) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetimeoffset](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TodoLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnsubmittedData]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnsubmittedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NULL,
	[ReferenceNumber] [nvarchar](50) NULL,
	[Product] [nvarchar](100) NULL,
	[ProductCategory] [nvarchar](50) NULL,
	[Premium] [nvarchar](20) NULL,
	[Stage] [nvarchar](50) NULL,
	[StageName] [nvarchar](50) NULL,
	[DateCreated] [datetimeoffset](7) NULL,
	[CurrentStep] [nvarchar](100) NULL,
	[ExpiresIn] [nvarchar](20) NULL,
	[ContinueStep] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DecisionMadeData] ON 
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (1, N'Martin Clyde', N'666612340001', N'Life cover', N'Business', N'£24.40', CAST(N'2024-08-08T14:30:00.000' AS DateTime), N'90 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (2, N'Siena Sutherland', N'666612340003', N'Life cover', N'Business', N'£28.31', CAST(N'2024-08-08T10:25:00.000' AS DateTime), N'90 days', N'Non-standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (3, N'Emma Conhan', N'666612340234', N'Life & CiC', N'Personal', N'£27.78', CAST(N'2024-08-08T11:30:00.000' AS DateTime), N'30 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (4, N'Jayne Clark-Smith, Emma Clark-Smith', N'666612340111', N'Life cover', N'Personal', N'£30.78', CAST(N'2024-08-08T18:30:00.000' AS DateTime), N'83 days', N'Postponed', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (5, N'Gemma Smith', N'666612340451', N'Life & CiC', N'Business', N'£35.55', CAST(N'2024-08-08T17:30:00.000' AS DateTime), N'12 hours ago', N'Declined', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (6, N'Mary Miller', N'666612340234', N'Life cover', N'Personal', N'£19.00', CAST(N'2024-08-08T19:30:00.000' AS DateTime), N'30 days', N'Standard (in claim)', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (7, N'Glenda Glasgow', N'666612340556', N'Life cover', N'Business', N'£35.50', CAST(N'2024-08-07T10:30:00.000' AS DateTime), N'30 days', N'Non-Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (8, N'Gary Glasgow, Glenda Glasgow', N'666612340654', N'Life cover', N'Personal', N'£45.00', CAST(N'2024-08-07T09:00:00.000' AS DateTime), N'28 days', N'Non-standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (9, N'Gary Glasgow', N'666612340555', N'Life & CiC', N'Personal', N'£24.40', CAST(N'2023-08-07T09:00:00.000' AS DateTime), N'30 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (10, N'Lisa Moore', N'666612340567', N'Life & CiC', N'Personal', N'£45.00', CAST(N'2024-08-06T09:00:00.000' AS DateTime), N'Expired', N'Not taken up (client''s decision)', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (11, N'John Smith', N'666612340009', N'Life cover', N'Business', N'£22.35', CAST(N'2024-08-08T14:30:00.000' AS DateTime), N'90 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (12, N'Anna Johnson', N'666612340012', N'Life cover', N'Business', N'£32.58', CAST(N'2024-08-08T10:25:00.000' AS DateTime), N'90 days', N'Non-standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (13, N'Olivia Brown', N'666612340231', N'Life & CiC', N'Personal', N'£21.33', CAST(N'2024-08-08T11:30:00.000' AS DateTime), N'30 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (14, N'Emily Davis, Sophia Davis', N'666612340118', N'Life cover', N'Personal', N'£22.75', CAST(N'2024-08-08T18:30:00.000' AS DateTime), N'83 days', N'Postponed', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (15, N'Isabella Taylor', N'666612340449', N'Life & CiC', N'Business', N'£26.68', CAST(N'2024-08-08T17:30:00.000' AS DateTime), N'12 hours ago', N'Declined', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (16, N'Charlotte Wilson', N'666612340226', N'Life cover', N'Personal', N'£17.50', CAST(N'2024-08-08T19:30:00.000' AS DateTime), N'30 days', N'Standard (in claim)', 0)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (17, N'Mia Harris', N'666612340548', N'Life cover', N'Business', N'£40.00', CAST(N'2024-08-07T10:30:00.000' AS DateTime), N'30 days', N'Non-Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (18, N'William Thompson, Ella Thompson', N'666612340647', N'Life cover', N'Personal', N'£36.80', CAST(N'2024-08-07T09:00:00.000' AS DateTime), N'28 days', N'Non-standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (19, N'James White', N'666612340561', N'Life & CiC', N'Personal', N'£29.20', CAST(N'2023-08-07T09:00:00.000' AS DateTime), N'30 days', N'Standard', 1)
GO
INSERT [dbo].[DecisionMadeData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [LastUpdated], [ExpiresIn], [Decision], [NeedAttention]) VALUES (20, N'Amelia Lewis', N'666612340572', N'Life & CiC', N'Personal', N'£37.90', CAST(N'2024-08-06T09:00:00.000' AS DateTime), N'Expired', N'Not taken up (client''s decision)', 0)
GO
SET IDENTITY_INSERT [dbo].[DecisionMadeData] OFF
GO
SET IDENTITY_INSERT [dbo].[LivePoliciesData] ON 
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (1, N'Johnny Jones', N'666672539555', N'CiC', N'Personal', N'£21.00', CAST(N'2002-03-19T00:00:00.000' AS DateTime), CAST(N'2024-08-08T14:30:00.000' AS DateTime), N'The policy is in claim.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (2, N'Craig Clinton', N'666675559413', N'Life & CiC', N'Business', N'£24.40', CAST(N'2023-06-27T00:00:00.000' AS DateTime), CAST(N'2024-08-08T11:44:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (3, N'David Dundee', N'666675556713', N'Life & CiC', N'Personal', N'£24.40', CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:44:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (4, N'Edna Elgin', N'666675555678', N'Life cover', N'Business', N'£29.88', CAST(N'2022-04-26T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'Two direct debits have been missed.', 1)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (5, N'Jennifer Jones', N'666672853888', N'Life cover', N'Personal', N'£22.99', CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (6, N'Michael Lee', N'666673333331', N'Life cover', N'Business', N'£19.00', CAST(N'2023-06-26T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'The policy is on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (7, N'Meghan Morgan', N'666672639412', N'Life cover', N'Business', N'£29.88', CAST(N'2022-05-15T00:00:00.000' AS DateTime), CAST(N'2024-08-08T10:58:10.000' AS DateTime), N'Three direct debits have been missed, the policy will be cancelled on 15 August 2023.', 1)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (8, N'Siena Velencia', N'666672535432', N'Life cover', N'Business', N'£24.40', CAST(N'2023-06-27T00:00:00.000' AS DateTime), CAST(N'2024-08-08T10:58:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (9, N'Henry Brown', N'666672539559', N'CiC', N'Personal', N'£27.50', CAST(N'2002-03-19T00:00:00.000' AS DateTime), CAST(N'2024-08-08T14:30:00.000' AS DateTime), N'The policy is in claim.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (10, N'Oliver Davis', N'666675559415', N'Life & CiC', N'Business', N'£30.20', CAST(N'2023-06-27T00:00:00.000' AS DateTime), CAST(N'2024-08-08T11:44:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (11, N'Mason Harris', N'666675556709', N'Life & CiC', N'Personal', N'£17.85', CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:44:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (12, N'Ava Johnson', N'666675555685', N'Life cover', N'Business', N'£23.45', CAST(N'2022-04-26T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'Two direct debits have been missed.', 1)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (13, N'Sophia Miller', N'666672853885', N'Life cover', N'Personal', N'£20.50', CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (14, N'Elijah Moore', N'666673333329', N'Life cover', N'Business', N'£22.80', CAST(N'2023-06-26T00:00:00.000' AS DateTime), CAST(N'2024-08-08T12:58:10.000' AS DateTime), N'The policy is on risk.', 0)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (15, N'Amelia Anderson', N'666672639414', N'Life cover', N'Business', N'£34.50', CAST(N'2022-05-15T00:00:00.000' AS DateTime), CAST(N'2024-08-08T10:58:10.000' AS DateTime), N'Three direct debits have been missed, the policy will be cancelled on 15 August 2023.', 1)
GO
INSERT [dbo].[LivePoliciesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [Premium], [StartDate], [LastUpdated], [SummaryIssue], [NeedAttention]) VALUES (16, N'James Thompson', N'666672535424', N'Life cover', N'Business', N'£33.80', CAST(N'2023-06-27T00:00:00.000' AS DateTime), CAST(N'2024-08-08T10:58:10.000' AS DateTime), N'The policy is due to go on risk.', 0)
GO
SET IDENTITY_INSERT [dbo].[LivePoliciesData] OFF
GO
SET IDENTITY_INSERT [dbo].[ReferredCasesData] ON 
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (1, N'Charlie Clyde', N'666612340321', N'Life & CiC', N'Business', CAST(N'2024-08-08T12:10:00.000' AS DateTime), N'Medical Consent (AMRA) received.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (2, N'Dave Dundee', N'666612340222', N'Life & CiC', N'Personal', CAST(N'2024-08-08T07:30:00.000' AS DateTime), N'Further information requested from you via email on 4 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (3, N'Emma Clark-Smith', N'666612340345', N'Life & CiC', N'Personal', CAST(N'2024-08-07T18:36:00.000' AS DateTime), N'Medical Consent (AMRA) received.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (4, N'Frida Jones, Molly Jones', N'666612340478', N'Life cover', N'Personal', CAST(N'2024-08-07T14:41:00.000' AS DateTime), N'GP report requested from Holland Clinic via post on 30 June 2023.', 1)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (5, N'Gary Glasgow', N'666612340978', N'Life & CiC', N'Personal', CAST(N'2024-08-07T12:21:00.000' AS DateTime), N'Not taken up. Policy has been cancelled as underwriting information was not received.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (6, N'Jonathan Johnstone', N'666612340999', N'Life & CiC', N'Personal', CAST(N'2024-08-06T14:55:00.000' AS DateTime), N'Declaration of Continued Good Health (DCGH) received on 3 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (7, N'Iain Inchinnan', N'666612340098', N'Life cover', N'Personal', CAST(N'2024-08-06T20:16:00.000' AS DateTime), N'Financial questionnaire received on 3 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (8, N'Gary Green, Georgia Green', N'666612340765', N'Life cover', N'Personal', CAST(N'2024-08-12T09:15:00.000' AS DateTime), N'Further information requested from Madison Clinic via post on 2 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (9, N'Lisa More', N'666612340678', N'Life cover', N'Personal', CAST(N'2024-08-03T15:40:00.000' AS DateTime), N'GP report requested from Holland Clinic via post on 30 June 2023.', 1)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (10, N'Sienna Valencia', N'666612340584', N'Life & CiC', N'Personal', CAST(N'2024-08-04T17:25:00.000' AS DateTime), N'Not taken up. Policy has been cancelled as underwriting information was not received.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (11, N'Edna Elgin', N'666612340219', N'Life & CiC', N'Personal', CAST(N'2024-07-30T16:16:00.000' AS DateTime), N'Declaration of Continued Good Health (DCGH) received on 3 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (12, N'Matthew Williams', N'666612340192', N'Life cover', N'Personal', CAST(N'2024-08-05T16:46:00.000' AS DateTime), N'Financial questionnaire received on 3 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (13, N'Noa Anderson', N'666612340261', N'Life cover', N'Personal', CAST(N'2024-08-05T19:36:00.000' AS DateTime), N'Further information requested from Madison Clinic via post on 2 July 2023.', 0)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (14, N'Alan Ayr', N'666612340001', N'Life cover', N'Business', CAST(N'2024-08-08T08:30:00.000' AS DateTime), N'Further information requested from you via email on 4 July 2023.', 1)
GO
INSERT [dbo].[ReferredCasesData] ([Id], [ClientName], [Policy], [Product], [ProductCategory], [LastUpdated], [CurrentStatus], [NeedAttention]) VALUES (15, N'James Cordell', N'666612340123', N'Life & CiC', N'Personal', CAST(N'2024-08-03T17:22:00.000' AS DateTime), N'This policy needs to be referred to our underwriters.', 1)
GO
SET IDENTITY_INSERT [dbo].[ReferredCasesData] OFF
GO
SET IDENTITY_INSERT [dbo].[TodoItems] ON 
GO
INSERT [dbo].[TodoItems] ([Id], [ListId], [Title], [Note], [Priority], [Reminder], [Done], [Created], [CreatedBy], [LastModified], [LastModifiedBy]) VALUES (1, 1, N'Make a todo list 📃', NULL, 0, NULL, 0, CAST(N'2024-08-15T20:56:50.0073666+00:00' AS DateTimeOffset), NULL, CAST(N'2024-08-15T20:56:50.0073666+00:00' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TodoItems] ([Id], [ListId], [Title], [Note], [Priority], [Reminder], [Done], [Created], [CreatedBy], [LastModified], [LastModifiedBy]) VALUES (2, 1, N'Check off the first item ✅', NULL, 0, NULL, 0, CAST(N'2024-08-15T20:56:50.0073688+00:00' AS DateTimeOffset), NULL, CAST(N'2024-08-15T20:56:50.0073688+00:00' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TodoItems] ([Id], [ListId], [Title], [Note], [Priority], [Reminder], [Done], [Created], [CreatedBy], [LastModified], [LastModifiedBy]) VALUES (3, 1, N'Realise you''ve already done two things on the list! 🤯', NULL, 0, NULL, 0, CAST(N'2024-08-15T20:56:50.0073693+00:00' AS DateTimeOffset), NULL, CAST(N'2024-08-15T20:56:50.0073693+00:00' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TodoItems] ([Id], [ListId], [Title], [Note], [Priority], [Reminder], [Done], [Created], [CreatedBy], [LastModified], [LastModifiedBy]) VALUES (4, 1, N'Reward yourself with a nice, long nap 🏆', NULL, 0, NULL, 0, CAST(N'2024-08-15T20:56:50.0073696+00:00' AS DateTimeOffset), NULL, CAST(N'2024-08-15T20:56:50.0073696+00:00' AS DateTimeOffset), NULL)
GO
SET IDENTITY_INSERT [dbo].[TodoItems] OFF
GO
SET IDENTITY_INSERT [dbo].[TodoLists] ON 
GO
INSERT [dbo].[TodoLists] ([Id], [Title], [Colour_Code], [Created], [CreatedBy], [LastModified], [LastModifiedBy]) VALUES (1, N'Todo List', N'#FFFFFF', CAST(N'2024-08-15T20:56:50.0069255+00:00' AS DateTimeOffset), NULL, CAST(N'2024-08-15T20:56:50.0069255+00:00' AS DateTimeOffset), NULL)
GO
SET IDENTITY_INSERT [dbo].[TodoLists] OFF
GO
SET IDENTITY_INSERT [dbo].[UnsubmittedData] ON 
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (1, N'Michael Smith, Sandra Smith', N'333312340762', N'Multi-policies', N'Personal', N'£44.05', N'4/4,4/5', N'Application', CAST(N'2023-07-30T13:15:00.0000000-03:00' AS DateTimeOffset), N'Policy ownership', N'29 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (2, N'Molly Wager', N'333312340678', N'Life Cover', N'Personal', N'£23.55', N'4/4,5/5', N'Application', CAST(N'2023-07-29T10:45:00.0000000-03:00' AS DateTimeOffset), N'health & lifestyle details', N'28 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (3, N'Gemma Smith', N'333312340551', N'Life & CiC', N'Personal', N'£22.32', N'4/4,3/5', N'Application', CAST(N'2023-07-28T07:32:00.0000000-03:00' AS DateTimeOffset), N'Client contact details', N'27 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (4, N'Mike Smith', N'333312340547', N'Life cover', N'Personal', N'£20.98', N'4/4,2/5', N'Application', CAST(N'2023-07-17T08:31:00.0000000-03:00' AS DateTimeOffset), N'Agent details', N'14 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (5, N'Amy Friedman, Brian Brechin, Claire White, Edina Elgin, Frida Falkirk, Gary Glasgow, Harry Hawick, Lain Inchinnan, Jack Williams, James Sands, Jill Smith, Mark Roberts, Mary Jackson, Mary Smith, Olga Brady, Owen Cassidy, Wayne Colleman', N'1100012340234', N'Multi-policies', N'Business', N'£421.90', N'4/4,0/5', N'Quote', CAST(N'2023-07-16T14:30:00.0000000-03:00' AS DateTimeOffset), N'Review quote details', N'13 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (6, N'Theresa Gold', N'333312340309', N'CiC', N'Business', N'£24.88', N'4/4,0/5', N'Quote', CAST(N'2023-07-14T13:44:00.0000000-03:00' AS DateTimeOffset), N'Review Quote details', N'12 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (7, N'John Davis, Emma Davis', N'333312340768', N'Multi-policies', N'Personal', N'£37.50', N'4/4,4/5', N'Application', CAST(N'2023-07-30T13:15:00.0000000-03:00' AS DateTimeOffset), N'Policy ownership', N'29 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (8, N'Sophie Williams', N'333312340683', N'Life Cover', N'Personal', N'£30.00', N'4/4,5/5', N'Application', CAST(N'2023-07-29T10:45:00.0000000-03:00' AS DateTimeOffset), N'health & lifestyle details', N'28 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (9, N'Laura Johnson', N'333312340558', N'Life & CiC', N'Personal', N'£19.75', N'4/4,3/5', N'Application', CAST(N'2023-07-28T07:32:00.0000000-03:00' AS DateTimeOffset), N'Client contact details', N'27 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (10, N'James Taylor', N'333312340542', N'Life cover', N'Personal', N'£29.00', N'4/4,2/5', N'Application', CAST(N'2023-07-17T08:31:00.0000000-03:00' AS DateTimeOffset), N'Agent details', N'14 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (11, N'Olivia Martin, Daniel Moore, Charlotte Clark, Grace Green, Sophia Adams, Jacob White, Ethan Harris, Mia Lewis, Liam Walker, Noah King, Ava Scott, Lucas Hall, Isabella Young, Amelia Allen, Harper King, Ella Wright, Mason Evans', N'1100012340240', N'Multi-policies', N'Business', N'£432.00', N'4/4,0/5', N'Quote', CAST(N'2023-07-16T14:30:00.0000000-03:00' AS DateTimeOffset), N'Review quote details', N'13 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (12, N'Lily Carter', N'333312340310', N'CiC', N'Business', N'£28.10', N'4/4,0/5', N'Quote', CAST(N'2023-07-14T13:44:00.0000000-03:00' AS DateTimeOffset), N'Review Quote details', N'12 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (13, N'Alice Brown, Tom Brown', N'333312340761', N'Multi-policies', N'Personal', N'£34.80', N'4/4,4/5', N'Application', CAST(N'2023-07-30T13:15:00.0000000-03:00' AS DateTimeOffset), N'Policy ownership', N'29 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (14, N'Eleanor Wright', N'333312340680', N'Life Cover', N'Personal', N'£27.50', N'4/4,5/5', N'Application', CAST(N'2023-07-29T10:45:00.0000000-03:00' AS DateTimeOffset), N'health & lifestyle details', N'28 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (15, N'Oliver King', N'333312340559', N'Life & CiC', N'Personal', N'£18.00', N'4/4,3/5', N'Application', CAST(N'2023-07-28T07:32:00.0000000-03:00' AS DateTimeOffset), N'Client contact details', N'27 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (16, N'Emily Scott', N'333312340549', N'Life cover', N'Personal', N'£25.75', N'4/4,2/5', N'Application', CAST(N'2023-07-17T08:31:00.0000000-03:00' AS DateTimeOffset), N'Agent details', N'14 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (17, N'George Lewis, Harper Hall, Mia Walker, Isabella Wright, Benjamin Green, Lucas Adams, Avery Allen, Lily King, Ella Carter, Amelia Thompson, Ethan Scott, Sophia Evans, Zoe Harris, Noah Clark, Olivia White, Jacob Taylor, Liam Jones', N'1100012340230', N'Multi-policies', N'Business', N'£410.00', N'4/4,0/5', N'Quote', CAST(N'2023-07-16T14:30:00.0000000-03:00' AS DateTimeOffset), N'Review quote details', N'13 days', N'https://www.google.com')
GO
INSERT [dbo].[UnsubmittedData] ([Id], [ClientName], [ReferenceNumber], [Product], [ProductCategory], [Premium], [Stage], [StageName], [DateCreated], [CurrentStep], [ExpiresIn], [ContinueStep]) VALUES (18, N'Sophia Brown', N'333312340318', N'CiC', N'Business', N'£21.75', N'4/4,0/5', N'Quote', CAST(N'2023-07-14T13:44:00.0000000-03:00' AS DateTimeOffset), N'Review Quote details', N'12 days', N'https://www.google.com')
GO
SET IDENTITY_INSERT [dbo].[UnsubmittedData] OFF
GO
ALTER TABLE [dbo].[TodoItems]  WITH CHECK ADD  CONSTRAINT [FK_TodoItems_TodoLists_ListId] FOREIGN KEY([ListId])
REFERENCES [dbo].[TodoLists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TodoItems] CHECK CONSTRAINT [FK_TodoItems_TodoLists_ListId]
GO
/****** Object:  StoredProcedure [dbo].[GetReferredCasesData]    Script Date: 29/8/2024 18:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetReferredCasesData]
AS
BEGIN
    SELECT
        ClientName,
        Policy,
        Product,
        ProductCategory,
        LastUpdated,
        CurrentStatus,
        NeedAttention
    FROM ReferredCasesData;
END


GO
