CREATE TABLE [dbo].[MenuItem](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[ParentMenuId] [int] NULL,
	[MenuTitle] [nvarchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[MenuAction] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__MenuItem__C99ED23053BF3C6D] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/*
1	0	Home	10	/Home/Home
2	0	Woman	20	
4	0	Man	30	
5	0	Accessories	40	/Accessories/Accessories
6	0	Beauty	50	/Beauty/Beauty
7	0	Food & Wine	60	/FoodWine/FoodWine
8	0	Gifts	70	/Gifts/Gifts
9	0	Brands	80	/Brands/Brands
10	2	All Clothing	10	/Woman/AllClothes
11	2	All Shoes	20	/Woman/AllShoes
12	2	All Accessories	30	/Woman/AllAccessories
13	4	All Clothing	10	/Man/AllClothes
14	4	All Shoes	20	/Man/AllShoes
15	4	All Accessories	30	/Man/AllAccessories

*/