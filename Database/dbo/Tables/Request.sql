CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[From] [int] NOT NULL,
	[To] [int] NOT NULL,
	[Accepted] [bit] NOT NULL,
	[Read] [bit] NOT NULL,
	[Pending] [bit] NOT NULL,
	[FromName] [nvarchar](50) NOT NULL,
	[ToName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]