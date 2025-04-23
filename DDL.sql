USE [AISportsPlatform]
GO

/****** Object:  Table [dbo].[AI_Model]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AI_Model](
	[Model_Id] [int] IDENTITY(1,1) NOT NULL,
	[Model_Type] [varchar](50) NULL,
	[Version] [varchar](20) NULL,
	[Model_Source] [varchar](100) NULL,
	[Status] [varchar](20) NULL,
	[Trained_On] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Model_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Category]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[CategoryName] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Life] [int] NULL,
	[Is_Checkout] [varchar](50) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Commentary_Feed]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Commentary_Feed](
	[Feed_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Match_Id] [int] NULL,
	[Language_Code] [varchar](10) NULL,
	[Commentary_Text] [nvarchar](max) NULL,
	[Voice_Profile] [varchar](100) NULL,
	[Timestamp] [datetime] NULL,
	[Tone] [varchar](50) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feed_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Commentary_Log]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Commentary_Log](
	[Log_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Feed_Id] [bigint] NULL,
	[Engagement_Score] [decimal](5, 2) NULL,
	[Latency_Millis] [int] NULL,
	[Sentiment_Score] [decimal](5, 2) NULL,
	[Feedback_Text] [nvarchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Commentary_Segment]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Commentary_Segment](
	[Segment_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Feed_Id] [bigint] NULL,
	[Segment_Text] [nvarchar](max) NULL,
	[Segment_Timestamp] [datetime] NULL,
	[Segment_Type] [varchar](50) NULL,
	[Emotion_Tag] [varchar](50) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Segment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Custom_Audience_Segment]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Custom_Audience_Segment](
	[Segment_Id] [int] IDENTITY(1,1) NOT NULL,
	[Segment_Name] [varchar](100) NULL,
	[Filter_Logic] [nvarchar](max) NULL,
	[Language_Preference] [varchar](10) NULL,
	[Commentary_Mode] [varchar](50) NULL,
	[Voice_Id] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Segment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Customer]    Script Date: 4/22/2025 11:26:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,
	[CustomerName] [varchar](255) NOT NULL,
	[ContactName] [varchar](255) NULL,
	[ContactTitle] [varchar](100) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [char](1) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[AddressLine1] [varchar](255) NOT NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](100) NOT NULL,
	[WebsiteURL] [varchar](255) NULL,
	[CustomerSince] [date] NOT NULL,
	[AccountBalance] [decimal](18, 2) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Data_Retention_Policy]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Data_Retention_Policy](
	[Policy_Id] [int] IDENTITY(1,1) NOT NULL,
	[Data_Type] [varchar](100) NULL,
	[Retention_Period_Days] [int] NULL,
	[Auto_Anonymize] [bit] NULL,
	[Region_Lock] [bit] NULL,
	[Enforced_From] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Policy_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Department]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
	[DepartmentCode] [nvarchar](20) NULL,
	[ParentID] [int] NULL,
	[ManagerID] [int] NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Budget] [decimal](18, 2) NULL,
	[EstablishedDate] [date] NULL,
	[Status] [char](1) NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK__Departme__B2079BCDFEF95305] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Dynamic_Pricing_History]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dynamic_Pricing_History](
	[Pricing_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Language_Code] [varchar](10) NULL,
	[Match_Id] [int] NULL,
	[Stream_Type] [varchar](50) NULL,
	[Price_Per_Minute] [decimal](10, 2) NULL,
	[Applied_At] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pricing_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Employee]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[HireDate] [date] NOT NULL,
	[JobTitle] [nvarchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[ManagerId] [int] NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[Gender] [char](1) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[AddressLine1] [varchar](255) NOT NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](100) NOT NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Feedback]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Feedback](
	[Feedback_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Match_Id] [int] NULL,
	[Feedback_Type] [varchar](50) NULL,
	[Rating] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[Submitted_At] [datetime] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feedback_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Group]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Group](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Location_ID] [int] NULL,
	[GroupName] [varchar](250) NOT NULL,
	[Description] [varchar](1000) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Incident_Log]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Incident_Log](
	[Incident_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Component_Name] [varchar](100) NULL,
	[Incident_Type] [varchar](50) NULL,
	[Details] [nvarchar](max) NULL,
	[Detected_At] [datetime] NULL,
	[Resolved_At] [datetime] NULL,
	[Status] [varchar](20) NULL,
	[Resolved_By] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Incident_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Language]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Language](
	[Language_Code] [varchar](10) NOT NULL,
	[Language_Name] [varchar](100) NULL,
	[Region] [varchar](100) NULL,
	[Is_Supported] [bit] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Language_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Live_Match]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Live_Match](
	[Match_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sport_Type] [varchar](50) NULL,
	[Home_Team] [varchar](100) NULL,
	[Away_Team] [varchar](100) NULL,
	[Match_Date] [datetime] NULL,
	[Broadcast_URL] [varchar](255) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Match_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Localization_Token]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Localization_Token](
	[Token_Id] [int] IDENTITY(1,1) NOT NULL,
	[Key_Name] [varchar](255) NULL,
	[Language_Code] [varchar](10) NULL,
	[Localized_Value] [nvarchar](max) NULL,
	[Is_UI_Only] [bit] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Token_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Location]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[Location_ID] [int] IDENTITY(1,1) NOT NULL,
	[TenantId] [int] NULL,
	[LocationName] [varchar](30) NOT NULL,
	[Short_Code] [varchar](6) NOT NULL,
	[Long_Code] [varchar](15) NOT NULL,
	[Short_Name] [varchar](10) NOT NULL,
	[Description] [varchar](max) NULL,
	[Parent_Location_ID] [int] NULL,
	[Location_Type_Id] [int] NOT NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Location_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Location_Detail]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location_Detail](
	[Loc_Detail_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NOT NULL,
	[Downtime] [bit] NULL,
	[AddressLine1] [varchar](255) NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[PostalCode] [varchar](20) NULL,
	[FaxNumber] [varchar](20) NULL,
	[PhoneNumber1] [varchar](20) NULL,
	[PhoneNumber2] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[WebsiteURL] [varchar](255) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED 
(
	[Loc_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Location_Type]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location_Type](
	[Location_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationTypeName] [varchar](30) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Parent_Location_Type_ID] [int] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Location_Type] PRIMARY KEY CLUSTERED 
(
	[Location_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Manufacturer]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[ManufacturerCode] [nvarchar](50) NOT NULL,
	[ManufacturerName] [varchar](255) NOT NULL,
	[ContactName] [varchar](255) NULL,
	[ContactTitle] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[AddressLine1] [varchar](255) NOT NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](100) NOT NULL,
	[WebsiteURL] [varchar](255) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Match_Stat]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Match_Stat](
	[Stat_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Match_Id] [int] NULL,
	[Player_Name] [varchar](100) NULL,
	[Event_Type] [varchar](50) NULL,
	[Event_Description] [nvarchar](max) NULL,
	[Timestamp] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Stat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Model_Training_Job]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Model_Training_Job](
	[Job_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Model_Id] [int] NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[Status] [varchar](50) NULL,
	[Triggered_By] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Job_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PhysicalLocation]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PhysicalLocation](
	[PhysicalLocation_ID] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[PhysicalLocationName] [varchar](30) NOT NULL,
	[Short_Code] [varchar](6) NOT NULL,
	[Long_Code] [varchar](15) NOT NULL,
	[Short_Name] [varchar](10) NOT NULL,
	[Description] [varchar](max) NULL,
	[Parent_PhysicalLocation_ID] [int] NULL,
	[PhysicalLocation_Type_Id] [int] NOT NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_PhysicalLocation] PRIMARY KEY CLUSTERED 
(
	[PhysicalLocation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PhysicalLocation_Detail]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PhysicalLocation_Detail](
	[PhysicalLoc_Detail_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PhysicalLocation_ID] [int] NOT NULL,
	[Downtime] [bit] NULL,
	[AddressLine1] [varchar](255) NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[PostalCode] [varchar](20) NULL,
	[FaxNumber] [varchar](20) NULL,
	[PhoneNumber1] [varchar](20) NULL,
	[PhoneNumber2] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[WebsiteURL] [varchar](255) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_PhysicalLocationDetail] PRIMARY KEY CLUSTERED 
(
	[PhysicalLoc_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PhysicalLocation_Type]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PhysicalLocation_Type](
	[PhysicalLocation_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[PhysicalLocationTypeName] [varchar](30) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Parent_PhysicalLocation_Type_ID] [int] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_PhysicalLocation_Type] PRIMARY KEY CLUSTERED 
(
	[PhysicalLocation_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[RealTime_Event_Queue]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RealTime_Event_Queue](
	[Event_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Match_Id] [int] NULL,
	[Event_Type] [varchar](50) NULL,
	[Event_Data] [nvarchar](max) NULL,
	[Processed] [bit] NULL,
	[Event_Timestamp] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Event_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Region_Compliance]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Region_Compliance](
	[Compliance_Id] [int] IDENTITY(1,1) NOT NULL,
	[Region_Name] [varchar](100) NULL,
	[Regulation_Name] [varchar](100) NULL,
	[Rule_Description] [nvarchar](max) NULL,
	[Enforcement_Level] [varchar](50) NULL,
	[Applies_To] [varchar](100) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Compliance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Retraining_Feedback]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Retraining_Feedback](
	[Feedback_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Commentary_Segment_Id] [bigint] NULL,
	[Flag_Type] [varchar](50) NULL,
	[Comments] [nvarchar](max) NULL,
	[Annotated_By] [int] NULL,
	[Reviewed] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feedback_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Screen]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Screen](
	[ScreenId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[ScreenName] [varchar](500) NULL,
	[Description] [varchar](1000) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Screens] PRIMARY KEY CLUSTERED 
(
	[ScreenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Settings]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Settings](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](100) NOT NULL,
	[SettingValue] [nvarchar](max) NULL,
	[Description] [nvarchar](500) NULL,
	[Module] [nvarchar](100) NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Sponsor_Message]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sponsor_Message](
	[Message_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sponsor_Name] [varchar](100) NULL,
	[Language_Code] [varchar](10) NULL,
	[Message_Text] [nvarchar](max) NULL,
	[Placement_Context] [varchar](50) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SubCategory]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubCategory](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryName] [nvarchar](500) NULL,
	[Desription] [nvarchar](1000) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Subscription]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subscription](
	[SubscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Supplier]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[SupplierCode] [nvarchar](50) NOT NULL,
	[SupplierName] [varchar](255) NOT NULL,
	[ContactName] [varchar](255) NULL,
	[ContactTitle] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[AddressLine1] [varchar](255) NOT NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](100) NOT NULL,
	[WebsiteURL] [varchar](255) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[System_Health_Log]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[System_Health_Log](
	[Health_Log_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Component_Name] [varchar](100) NULL,
	[Metric_Name] [varchar](100) NULL,
	[Metric_Value] [decimal](10, 2) NULL,
	[Recorded_At] [datetime] NULL,
	[Severity] [varchar](20) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Health_Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Tenant]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[TenantSecret] [nvarchar](255) NOT NULL,
	[TenantName] [nvarchar](255) NOT NULL,
	[ContactEmail] [nvarchar](255) NULL,
	[SubscriptionId] [int] NULL,
	[SubscriptionStartDate] [date] NULL,
	[SubscriptionEndDate] [date] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
 CONSTRAINT [PK__Tenants__2E9B47E10A43481F] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[UserGroupId] [int] NULL,
	[Location_Id] [int] NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](5000) NOT NULL,
	[Email] [varchar](255) NULL,
	[TempPassword] [varchar](5000) NULL,
	[DateRangeFrom] [datetime] NULL,
	[DateRangeTo] [datetime] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User_Activity_Log]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Activity_Log](
	[Log_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Activity_Type] [varchar](100) NULL,
	[Activity_Timestamp] [datetime] NULL,
	[Additional_Data] [nvarchar](max) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User_Group]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Group](
	[UserGroupRelationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[UserGroupId] [int] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_User_Group] PRIMARY KEY CLUSTERED 
(
	[UserGroupRelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User_Screen_Right]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Screen_Right](
	[UserRightsId] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [int] NULL,
	[ScreenId] [int] NULL,
	[ViewRights] [bit] NULL,
	[AddRights] [bit] NULL,
	[EditRights] [bit] NULL,
	[DeleteRights] [bit] NULL,
	[ReportRights] [bit] NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [int] NULL,
	[User_IP] [varchar](50) NOT NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_User_Rights] PRIMARY KEY CLUSTERED 
(
	[UserRightsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User_Session_Tracking]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User_Session_Tracking](
	[Session_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Device_Type] [varchar](50) NULL,
	[OS] [varchar](50) NULL,
	[Browser] [varchar](50) NULL,
	[IP_Address] [varchar](25) NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[Language_Selected] [varchar](10) NULL,
	[Voice_Selected] [varchar](50) NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Session_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Vendor]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendor](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[VendorCode] [nvarchar](50) NOT NULL,
	[VendorName] [varchar](255) NOT NULL,
	[VATRegistrationNo] [varchar](50) NULL,
	[ContactName] [varchar](255) NULL,
	[ContactTitle] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[AddressLine1] [varchar](255) NOT NULL,
	[AddressLine2] [varchar](255) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](100) NOT NULL,
	[WebsiteURL] [varchar](255) NULL,
	[Notes] [text] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Voice]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Voice](
	[Voice_Id] [int] IDENTITY(1,1) NOT NULL,
	[Language_Code] [varchar](10) NULL,
	[Voice_Name] [varchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[Emotion_Support] [bit] NULL,
	[TTS_Engine] [varchar](100) NULL,
	[Is_Beta] [bit] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Voice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Voice_Preference]    Script Date: 4/22/2025 11:26:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Voice_Preference](
	[Preference_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Speed] [decimal](3, 1) NULL,
	[Pitch] [decimal](3, 1) NULL,
	[Emotion_Mode] [varchar](50) NULL,
	[Preferred_Voice] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Audit_Id] [bigint] NULL,
	[User_IP] [varchar](25) NULL,
	[Site_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Preference_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF__Customer__Custom__48CFD27E]  DEFAULT (getdate()) FOR [CustomerSince]
GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF__Customer__Accoun__4AB81AF0]  DEFAULT ((0)) FOR [AccountBalance]
GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF__Customer__Is_Act__4BAC3F29]  DEFAULT ((1)) FOR [Is_Active]
GO

ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF__Departmen__Statu__66603565]  DEFAULT ('A') FOR [Status]
GO

ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF__Departmen__Creat__6754599E]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF__Employee__Is_Act__4F7CD00D]  DEFAULT ((1)) FOR [Is_Active]
GO

ALTER TABLE [dbo].[Manufacturer] ADD  CONSTRAINT [DF__Manufactu__Is_Ac__44FF419A]  DEFAULT ((1)) FOR [Is_Active]
GO

ALTER TABLE [dbo].[RealTime_Event_Queue] ADD  DEFAULT ((0)) FOR [Processed]
GO

ALTER TABLE [dbo].[Subscription] ADD  DEFAULT ('Active') FOR [Status]
GO

ALTER TABLE [dbo].[Subscription] ADD  DEFAULT (getdate()) FOR [Created_Date]
GO

ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF__Supplier__Is_Act__4222D4EF]  DEFAULT ((1)) FOR [Is_Active]
GO

ALTER TABLE [dbo].[Tenant] ADD  CONSTRAINT [DF__Tenants__Created__3B40CD36]  DEFAULT (getdate()) FOR [Created_Date]
GO

ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendo__Is_Ac__44FF419A]  DEFAULT ((1)) FOR [Is_Active]
GO

ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Location]
GO

ALTER TABLE [dbo].[Commentary_Feed]  WITH CHECK ADD FOREIGN KEY([Match_Id])
REFERENCES [dbo].[Live_Match] ([Match_Id])
GO

ALTER TABLE [dbo].[Commentary_Log]  WITH CHECK ADD FOREIGN KEY([Feed_Id])
REFERENCES [dbo].[Commentary_Feed] ([Feed_Id])
GO

ALTER TABLE [dbo].[Commentary_Segment]  WITH CHECK ADD FOREIGN KEY([Feed_Id])
REFERENCES [dbo].[Commentary_Feed] ([Feed_Id])
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Location]
GO

ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Location]
GO

ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Manager] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Manager]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Location]
GO

ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([Match_Id])
REFERENCES [dbo].[Live_Match] ([Match_Id])
GO

ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Location]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Location_Type] FOREIGN KEY([Location_Type_Id])
REFERENCES [dbo].[Location_Type] ([Location_Type_Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Location_Type]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Tenant]
GO

ALTER TABLE [dbo].[Location_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Location_Detail_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Location_Detail] CHECK CONSTRAINT [FK_Location_Detail_Location]
GO

ALTER TABLE [dbo].[Manufacturer]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturer_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Manufacturer] CHECK CONSTRAINT [FK_Manufacturer_Location]
GO

ALTER TABLE [dbo].[Match_Stat]  WITH CHECK ADD FOREIGN KEY([Match_Id])
REFERENCES [dbo].[Live_Match] ([Match_Id])
GO

ALTER TABLE [dbo].[Model_Training_Job]  WITH CHECK ADD FOREIGN KEY([Model_Id])
REFERENCES [dbo].[AI_Model] ([Model_Id])
GO

ALTER TABLE [dbo].[PhysicalLocation]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalLocation_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[PhysicalLocation] CHECK CONSTRAINT [FK_PhysicalLocation_Location]
GO

ALTER TABLE [dbo].[PhysicalLocation]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalLocation_PhysicalLocation_Type] FOREIGN KEY([PhysicalLocation_Type_Id])
REFERENCES [dbo].[PhysicalLocation_Type] ([PhysicalLocation_Type_Id])
GO

ALTER TABLE [dbo].[PhysicalLocation] CHECK CONSTRAINT [FK_PhysicalLocation_PhysicalLocation_Type]
GO

ALTER TABLE [dbo].[PhysicalLocation_Detail]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalLocation_Detail_Location] FOREIGN KEY([PhysicalLocation_ID])
REFERENCES [dbo].[PhysicalLocation] ([PhysicalLocation_ID])
GO

ALTER TABLE [dbo].[PhysicalLocation_Detail] CHECK CONSTRAINT [FK_PhysicalLocation_Detail_Location]
GO

ALTER TABLE [dbo].[Screen]  WITH CHECK ADD  CONSTRAINT [FK_Screens_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Screen] CHECK CONSTRAINT [FK_Screens_Location]
GO

ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO

ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Location]
GO

ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Location]
GO

ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_Tenant_Subscription] FOREIGN KEY([SubscriptionId])
REFERENCES [dbo].[Subscription] ([SubscriptionId])
GO

ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_Tenant_Subscription]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Employee]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Location] FOREIGN KEY([Location_Id])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Location]
GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Group] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[Group] ([UserGroupId])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Group]
GO

ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_User]
GO

ALTER TABLE [dbo].[User_Screen_Right]  WITH CHECK ADD  CONSTRAINT [FK_User_Screen_Rights_Group] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[Group] ([UserGroupId])
GO

ALTER TABLE [dbo].[User_Screen_Right] CHECK CONSTRAINT [FK_User_Screen_Rights_Group]
GO

ALTER TABLE [dbo].[User_Screen_Right]  WITH CHECK ADD  CONSTRAINT [FK_User_Screen_Rights_Screens] FOREIGN KEY([ScreenId])
REFERENCES [dbo].[Screen] ([ScreenId])
GO

ALTER TABLE [dbo].[User_Screen_Right] CHECK CONSTRAINT [FK_User_Screen_Rights_Screens]
GO

ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO

ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Location]
GO

ALTER TABLE [dbo].[Voice]  WITH CHECK ADD FOREIGN KEY([Language_Code])
REFERENCES [dbo].[Language] ([Language_Code])
GO

ALTER TABLE [dbo].[Voice_Preference]  WITH CHECK ADD FOREIGN KEY([Preferred_Voice])
REFERENCES [dbo].[Voice] ([Voice_Id])
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CK__Customer__Accoun__49C3F6B7] CHECK  (([AccountBalance]>=(0)))
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CK__Customer__Accoun__49C3F6B7]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CK__Customer__Gender__47DBAE45] CHECK  (([Gender]='O' OR [Gender]='F' OR [Gender]='M'))
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CK__Customer__Gender__47DBAE45]
GO

ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [CK__Departmen__Statu__656C112C] CHECK  (([Status]='I' OR [Status]='A'))
GO

ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [CK__Departmen__Statu__656C112C]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK__Employee__Gender__4E88ABD4] CHECK  (([Gender]='O' OR [Gender]='F' OR [Gender]='M'))
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK__Employee__Gender__4E88ABD4]
GO

ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Group', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location_Detail', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location_Type', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PhysicalLocation_Type', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 for Active, 2 for Inactive, 3 for Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Is_Active'
GO


