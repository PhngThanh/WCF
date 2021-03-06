CREATE DATABASE [PointOfSaleDB]
GO
/****************************/


USE [PointOfSaleDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [nvarchar](50) NOT NULL,
	[AccountPassword] [nvarchar](max) NULL,
	[StaffName] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NOT NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsDisplayed] [bit] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsExtra] [int] NULL,
	[AdjustmentNote] [nvarchar](250) NULL,
	[ImageFontAwsomeCss] [varchar](50) NOT NULL DEFAULT ('glass'),
	[ParentCateId] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryExtra]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryExtra](
	[CategoryExtraId] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryCategoryCode] [int] NOT NULL,
	[ExtraCategoryCode] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryExtraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Nationality] [int] NULL,
	[Notes] [nvarchar](250) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](50) NULL,
	[CheckInDate] [datetime] NOT NULL,
	[CheckOutDate] [datetime] NULL,
	[ApproveDate] [datetime] NULL,
	[TotalAmount] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[DiscountOrderDetail] [float] NOT NULL,
	[FinalAmount] [float] NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[OrderType] [int] NOT NULL,
	[Notes] [nvarchar](250) NULL,
	[FeeDescription] [nvarchar](250) NULL,
	[CheckInPerson] [nvarchar](50) NULL,
	[CheckOutPerson] [nvarchar](50) NULL,
	[ApprovePerson] [nvarchar](50) NULL,
	[CustomerID] [int] NULL,
	[SourceID] [int] NULL,
	[TableId] [int] NULL,
	[IsFixedPrice] [bit] NOT NULL,
	[LastRecordDate] [datetime] NULL,
	[ServedPerson] [nvarchar](50) NULL,
	[DeliveryAddress] [nvarchar](500) NULL,
	[DeliveryStatus] [int] NOT NULL,
	[DeliveryPhone] [nvarchar](50) NULL,
	[DeliveryCustomer] [nvarchar](50) NULL,
	[TotalInvoicePrint] [int] NOT NULL,
	[VAT] [float] NOT NULL,
	[VATAmount] [float] NOT NULL,
	[NumberOfGuest] [int] NOT NULL,
	[GroupPaymentStatus] [int] NOT NULL DEFAULT ((0)),
	[Att1] [nvarchar](250) NULL,
	[Att2] [nvarchar](250) NULL,
	[Att3] [nvarchar](250) NULL,
	[Att4] [nvarchar](250) NULL,
	[Att5] [nvarchar](250) NULL,
	[PromotionCode] [nvarchar](250) NULL,
	[PasswordWifi] [nvarchar](50) NULL,
	[CustomerType] [int] NULL,
	[LastModifiedPayment] [datetime] NULL,
	[LastModifiedOrderDetail] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[FinalAmount] [float] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Notes] [nvarchar](250) NULL,
	[TaxValue] [float] NULL,
	[UnitPrice] [float] NOT NULL,
	[ProductType] [int] NULL,
	[ParentId] [int] NULL,
	[ProductOrderType] [int] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[OrderGroup] [int] NOT NULL,
	[TmpDetailId] [int] NULL,
	[PromotionCode] [nvarchar](250) NULL,
	[OrderPromotionMappingId] [int] NULL,
	[OrderDetailPromotionMappingId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetailPromotionMapping]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetailPromotionMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDetailId] [int] NOT NULL,
	[PromotionCode] [nvarchar](250) NOT NULL,
	[PromotionDetailCode] [nvarchar](250) NOT NULL,
	[MappingIndex] [int] NOT NULL,
	[DiscountAmount] [money] NULL,
	[DiscountRate] [int] NULL,
	[TmpMappingId] [int] NULL,
 CONSTRAINT [PK_OrderDetailPromotionMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderPromotionMapping]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPromotionMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PromotionCode] [nvarchar](250) NOT NULL,
	[PromotionDetailCode] [nvarchar](250) NOT NULL,
	[MappingIndex] [int] NOT NULL,
	[DiscountAmount] [money] NULL,
	[DiscountRate] [int] NULL,
	[TmpMappingId] [int] NULL,
 CONSTRAINT [PK_OrderPromotionMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[CurrencyCode] [char](5) NULL,
	[FCAmount] [money] NOT NULL,
	[Notes] [nvarchar](250) NULL,
	[PayTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[CardCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](500) NULL,
	[ShortName] [nvarchar](50) NULL,
	[Price] [float] NOT NULL,
	[PicURL] [nvarchar](max) NULL,
	[CatID] [int] NOT NULL,
	[IsAvailable] [bit] NULL,
	[DiscountPercent] [float] NOT NULL,
	[DiscountPrice] [float] NOT NULL,
	[ProductType] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[HasExtra] [bit] NULL,
	[IsFixedPrice] [bit] NOT NULL,
	[PosX] [int] NOT NULL,
	[PosY] [int] NOT NULL,
	[ColorGroup] [int] NULL,
	[Group] [int] NOT NULL,
	[IsMenuDisplay] [bit] NULL,
	[GeneralProductId] [int] NULL,
	[Att1] [nvarchar](50) NULL,
	[Att2] [nvarchar](50) NULL,
	[Att3] [nvarchar](50) NULL,
	[MaxExtra] [int] NULL,
	[IsMostOrder] [bit] NULL,
	[IsUsed] [bit] NOT NULL,
	[ProductParentId] [int] NULL,
	[PrintGroup] [int] NOT NULL,
	[IsDefaultChildProduct] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductExtra]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductExtra](
	[ProductExtraId] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryProductCode] [nvarchar](50) NOT NULL,
	[ExtraProductCode] [nvarchar](50) NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsDisplayed] [bit] NULL,
	[MaxItem] [int] NULL,
	[Price] [float] NULL,
	[TimeStamp] [numeric](18, 0) NULL,
	[IsUsed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductExtraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[PromotionID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionCode] [nvarchar](250) NOT NULL,
	[PromotionName] [nvarchar](250) NOT NULL,
	[PromotionClassName] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[ImageCss] [nvarchar](50) NULL,
	[ApplyLevel] [int] NOT NULL,
	[GiftType] [int] NOT NULL,
	[IsForMember] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[ApplyFromTime] [int] NULL,
	[ApplyToTime] [int] NULL,
	[PromotionType] [int] NULL,
	[IsVoucher] [bit] NULL,
	[IsApplyOnce] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PromotionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PromotionDetail]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionDetail](
	[PromotionDetailID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionCode] [nvarchar](250) NOT NULL,
	[RegExCode] [nvarchar](50) NULL,
	[MinOrderAmount] [float] NULL,
	[MaxOrderAmount] [float] NULL,
	[BuyProductCode] [nvarchar](250) NULL,
	[MinBuyQuantity] [int] NULL,
	[MaxBuyQuantity] [int] NULL,
	[GiftProductCode] [nvarchar](50) NULL,
	[PromotionDetailCode] [nvarchar](250) NOT NULL,
	[GiftQuantity] [int] NULL,
	[DiscountAmount] [money] NULL,
	[DiscountRate] [int] NULL,
 CONSTRAINT [PK__Promotio__FF43FD6429572725] PRIMARY KEY CLUSTERED 
(
	[PromotionDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Source]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[SourceId] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[SourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Store]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoreCode] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Lat] [nvarchar](50) NULL,
	[Lon] [nvarchar](50) NULL,
	[isAvailable] [bit] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Type] [int] NOT NULL,
	[RoomRentMode] [int] NULL,
	[ReportDate] [datetime] NULL,
	[ShortName] [nvarchar](100) NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 07/01/2017 10:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[Text] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsCircle] [bit] NOT NULL,
	[TableRow] [int] NOT NULL,
	[TableColumn] [int] NOT NULL,
	[SpanTableRow] [int] NOT NULL,
	[SpanTableColumn] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[CurrentOrderId] [int] NULL,
	[CurrentOrderDate] [datetime] NULL,
	[ForOrderType] [int] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetailPromotionMapping]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetailPromotionMapping_OrderDetail] FOREIGN KEY([OrderDetailId])
REFERENCES [dbo].[OrderDetail] ([OrderDetailID])
GO
ALTER TABLE [dbo].[OrderDetailPromotionMapping] CHECK CONSTRAINT [FK_OrderDetailPromotionMapping_OrderDetail]
GO
ALTER TABLE [dbo].[OrderPromotionMapping]  WITH CHECK ADD  CONSTRAINT [FK_OrderPromotionMapping_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderPromotionMapping] CHECK CONSTRAINT [FK_OrderPromotionMapping_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO


/******************** Create table *************************/

USE [PointOfSaleDB]
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (1, N'1', N'Table 1', 0, 1, 0, 0, 0, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (2, N'2', N'Table 2', 0, 1, 0, 0, 1, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (3, N'3', N'Table 3', 0, 1, 0, 0, 2, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (4, N'4', N'Table 4', 0, 1, 0, 0, 3, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (5, N'5', N'Table 5', 0, 1, 0, 0, 4, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (6, N'6', N'Table 6', 0, 1, 0, 0, 5, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (7, N'7', N'Table 7', 0, 1, 0, 0, 6, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (8, N'8', N'Table 8', 0, 1, 0, 0, 7, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (9, N'9', N'Table 9', 0, 1, 0, 0, 8, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (10, N'10', N'Table 10', 0, 1, 0, 1, 0, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (11, N'11', N'Table 11', 0, 1, 0, 1, 1, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (12, N'12', N'Table 12', 0, 1, 0, 1, 2, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (13, N'13', N'Table 13', 0, 1, 0, 1, 3, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (14, N'14', N'Table 14', 0, 1, 0, 1, 4, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (15, N'15', N'Table 15', 0, 1, 0, 1, 5, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (16, N'16', N'Table 16', 0, 1, 0, 1, 6, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (17, N'17', N'Table 17', 0, 1, 0, 1, 7, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (18, N'18', N'Table 18', 0, 1, 0, 1, 8, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (19, N'19', N'Table 19', 0, 1, 0, 2, 0, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (20, N'20', N'Table 20', 0, 1, 0, 2, 1, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (21, N'21', N'Table 21', 0, 1, 0, 2, 2, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (22, N'22', N'Table 22', 0, 1, 0, 2, 3, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (23, N'23', N'Table 23', 0, 1, 0, 2, 4, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (24, N'24', N'Table 24', 0, 1, 0, 2, 5, 1, 1, 0, -1, NULL, 4)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (25, N'25', N'Table 25', 0, 1, 0, 2, 6, 1, 1, 0, -1, NULL, 4)



/******************** Create table delivery *************************/
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (101, N'1', N'Table 1', 0, 1, 1, 0, 0, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (102, N'2', N'Table 2', 0, 1, 1, 0, 1, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (103, N'3', N'Table 3', 0, 1, 1, 0, 2, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (104, N'4', N'Table 4', 0, 1, 1, 0, 3, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (105, N'5', N'Table 5', 0, 1, 1, 0, 4, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (106, N'6', N'Table 6', 0, 1, 1, 0, 5, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (107, N'7', N'Table 7', 0, 1, 1, 0, 6, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (108, N'8', N'Table 8', 0, 1, 1, 0, 7, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (109, N'9', N'Table 9', 0, 1, 1, 0, 8, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (110, N'10', N'Table 10', 0, 1, 1, 1, 0, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (111, N'11', N'Table 11', 0, 1, 1, 1, 1, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (112, N'12', N'Table 12', 0, 1, 1, 1, 2, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (113, N'13', N'Table 13', 0, 1, 1, 1, 3, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (114, N'14', N'Table 14', 0, 1, 1, 1, 4, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (115, N'15', N'Table 15', 0, 1, 1, 1, 5, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (116, N'16', N'Table 16', 0, 1, 1, 1, 6, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (117, N'17', N'Table 17', 0, 1, 1, 1, 7, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (118, N'18', N'Table 18', 0, 1, 1, 1, 8, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (119, N'19', N'Table 19', 0, 1, 1, 2, 0, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (120, N'20', N'Table 20', 0, 1, 1, 2, 1, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (121, N'21', N'Table 21', 0, 1, 1, 2, 2, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (122, N'22', N'Table 22', 0, 1, 1, 2, 3, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (123, N'23', N'Table 23', 0, 1, 1, 2, 4, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (124, N'24', N'Table 24', 0, 1, 1, 2, 5, 1, 1, 0, -1, NULL, 5)
INSERT [dbo].[Table] ([Id], [Number], [Text], [Status], [DisplayOrder], [IsCircle], [TableRow], [TableColumn], [SpanTableRow], [SpanTableColumn], [Floor], [CurrentOrderId], [CurrentOrderDate], [ForOrderType]) VALUES (125, N'25', N'Table 25', 0, 1, 1, 2, 6, 1, 1, 0, -1, NULL, 5)
SET IDENTITY_INSERT [dbo].[Table] OFF
