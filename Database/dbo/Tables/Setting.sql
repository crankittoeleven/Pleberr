CREATE TABLE [dbo].[Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User] [int] NOT NULL,
	[PostsPrivacy] [bit] NOT NULL,
	[InfoPrivacy] [bit] NOT NULL,
	[FriendsPrivacy] [bit] NOT NULL,
	[PicturesPrivacy] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]