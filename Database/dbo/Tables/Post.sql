CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Owner] [int] NOT NULL,
	[Author] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Likes] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Liked] [nvarchar](max) NOT NULL,
	[Privacy] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]