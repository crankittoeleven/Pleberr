CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1000000001,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[School] [nvarchar](50) NULL,
	[Work] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Relationship] [nvarchar](50) NULL,
	[Birthdate] [datetime] NULL,
	[Weight] [int] NULL,
	[Height] [float] NULL,
	[Friends] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Online] [bit] NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[Email2] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]