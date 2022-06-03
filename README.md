# Assessment.Project


USE [master]
GO
/****** Object:  Database [AssesmentProjectDB]    Script Date: 4.06.2022 00:34:56 ******/
CREATE DATABASE [AssesmentProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssesmentProjectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssesmentProjectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssesmentProjectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssesmentProjectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AssesmentProjectDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssesmentProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssesmentProjectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssesmentProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssesmentProjectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AssesmentProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssesmentProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AssesmentProjectDB] SET  MULTI_USER 
GO
ALTER DATABASE [AssesmentProjectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssesmentProjectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssesmentProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssesmentProjectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssesmentProjectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AssesmentProjectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AssesmentProjectDB', N'ON'
GO
ALTER DATABASE [AssesmentProjectDB] SET QUERY_STORE = OFF
GO
USE [AssesmentProjectDB]
GO
/****** Object:  Table [dbo].[Vehicle_Warranty_Records]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle_Warranty_Records](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Vehicle_Warranty_Records_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [nvarchar](20) NULL,
	[ChassisNumber] [nvarchar](17) NULL,
	[Brand] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[ModelYear] [varchar](4) NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_Order_Operations]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Order_Operations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkOrderId] [int] NULL,
	[Explanation] [nvarchar](500) NULL,
	[Status] [smallint] NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Work_Order_Operations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_Orders]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[Date] [datetime] NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Request] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Work_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicle_Warranty_Records] ADD  CONSTRAINT [DF_Vehicle_Warranty_Records_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Vehicle_Warranty_Records] ADD  CONSTRAINT [DF_Vehicle_Warranty_Records_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [DF_Vehicles_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [DF_Vehicles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Work_Order_Operations] ADD  CONSTRAINT [DF_Work_Order_Operations_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Work_Order_Operations] ADD  CONSTRAINT [DF_Work_Order_Operations_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Work_Orders] ADD  CONSTRAINT [DF_Work_Orders_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Work_Orders] ADD  CONSTRAINT [DF_Work_Orders_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Vehicle_Warranty_Records]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Warranty_Records_Vehicles1] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON UPDATE SET NULL
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle_Warranty_Records] CHECK CONSTRAINT [FK_Vehicle_Warranty_Records_Vehicles1]
GO
ALTER TABLE [dbo].[Work_Order_Operations]  WITH CHECK ADD  CONSTRAINT [FK_Work_Order_Operations_Work_Orders] FOREIGN KEY([WorkOrderId])
REFERENCES [dbo].[Work_Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Work_Order_Operations] CHECK CONSTRAINT [FK_Work_Order_Operations_Work_Orders]
GO
ALTER TABLE [dbo].[Work_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Work_Orders_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Work_Orders] CHECK CONSTRAINT [FK_Work_Orders_Vehicles]
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_Vehicles]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Add_Vehicles] (
	@plateNumber AS NVARCHAR(20)
	,@chassisNumber AS NVARCHAR(17)
	,@brand AS NVARCHAR(50)
	,@model AS NVARCHAR(50)
	,@modelYear AS VARCHAR(4)
	)
AS
BEGIN
	INSERT INTO Vehicles (
		PlateNumber
		,ChassisNumber
		,Brand
		,Model
		,ModelYear
		)
	VALUES (
		@plateNumber
		,@chassisNumber
		,@brand
		,@model
		,@modelYear
		)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_VehicleWarrantyRecords]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Add_VehicleWarrantyRecords] (
	 @vehicleId AS INT
	,@startDate AS DATETIME
	,@endDate AS DATETIME
	)
AS
BEGIN
	INSERT INTO dbo.Vehicle_Warranty_Records(
		 VehicleId
		,StartDate
		,EndDate
		)
	VALUES (
		 @vehicleId
		,@startDate
		,@endDate
		)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_WorkOrderOperations]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Add_WorkOrderOperations] (
	 @workOrderId AS INT
	,@explanation AS NVARCHAR(500)
	,@status AS SMALLINT
	)
AS
BEGIN
	INSERT INTO dbo.Work_Order_Operations(
		 WorkOrderId
		,Explanation
		,[Status]
		)
	VALUES (
		 @workOrderId
		,@explanation
		,@status
		)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Add_WorkOrders]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Add_WorkOrders] (
	 @vehicleId AS INT
	,@date AS DATETIME
	,@customerName AS NVARCHAR(50)
	,@request AS NVARCHAR(500)
	)
AS
BEGIN
	INSERT INTO Work_Orders(
		 VehicleId
		,[Date]
		,CustomerName
		,Request
		)
	VALUES (
		@vehicleId
		,@date
		,@customerName
		,@request
		)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Vehicles_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_Vehicles_ById] (
	 @id AS INT
	)
AS
BEGIN
	UPDATE Vehicles 
	SET IsDeleted = 1
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_VehicleWarrantyRecords_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_VehicleWarrantyRecords_ById] (
	 @id AS INT
	)
AS
BEGIN
	UPDATE Vehicle_Warranty_Records 
	SET IsDeleted = 1
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_WorkOrderOperations_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_WorkOrderOperations_ById] (
	 @id AS INT
	)
AS
BEGIN
	UPDATE Work_Order_Operations 
	SET IsDeleted = 1
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_WorkOrders_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Delete_WorkOrders_ById] (
	 @id AS INT
	)
AS
BEGIN
	UPDATE Work_Orders 
	SET IsDeleted = 1
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetList_General_VehicleInformations]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetList_General_VehicleInformations](
	 @plateNumber AS NVARCHAR(20),
	 @chassisNumber AS NVARCHAR(20)
	 )
AS
BEGIN
	DECLARE @vehicleId INT;
	SET @vehicleId = (SELECT  Id FROM Vehicles WHERE PlateNumber = @plateNumber AND ChassisNumber = @chassisNumber and IsDeleted=0);

	SELECT * FROM Vehicles WHERE Id = @vehicleId AND IsDeleted=0;
	SELECT * FROM Vehicle_Warranty_Records WHERE VehicleId = @vehicleId AND IsDeleted=0;
	SELECT * FROM Work_Orders WHERE VehicleId = @vehicleId AND IsDeleted=0;

END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetList_Vehicles]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetList_Vehicles]
AS
BEGIN
	SELECT 
	* 
	FROM Vehicles
	WHERE IsDeleted = 0
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetList_WorkOrderOperations_ByWorkOrderId]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetList_WorkOrderOperations_ByWorkOrderId](
	 @workOrderId AS INT)
AS
BEGIN
	SELECT 
	* 
	FROM Work_Order_Operations
	WHERE WorkOrderId = @workOrderId AND IsDeleted=0
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_Vehicles_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_Vehicles_ById] (
	@id AS INT,
	@plateNumber AS NVARCHAR(20),
	@chassisNumber AS NVARCHAR(17),
	@brand AS NVARCHAR(50),
	@model AS NVARCHAR(50),
	@modelYear AS VARCHAR(4)
	)
AS
BEGIN
	UPDATE Vehicles
	SET PlateNumber = @plateNumber,
		ChassisNumber = @chassisNumber,
		Brand = @brand,
		Model = @model,
		ModelYear = @modelYear
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_VehicleWarrantyRecords_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_VehicleWarrantyRecords_ById] (
	@id AS INT,
	@startDate AS DATETIME,
	@endDate AS DATETIME
	)
AS
BEGIN
	UPDATE Vehicle_Warranty_Records
	SET StartDate = @startDate,
		EndDate = @endDate
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_WorkOrderOperations_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_WorkOrderOperations_ById] (
	@id AS INT,
	@explanation AS NVARCHAR(500),
	@status AS SMALLINT
	)
AS
BEGIN
	UPDATE Work_Order_Operations
	SET Explanation = @explanation,
		[Status] = @status
	WHERE Id = @id
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_WorkOrders_ByChassisNumber]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_WorkOrders_ByChassisNumber] (
	 @currentChassisNumber AS NVARCHAR(17)
	,@targetChassisNumber AS NVARCHAR(17)
	)
AS
BEGIN

DECLARE @currentVehicleId INT;
DECLARE @targetVehicleId INT;

SET @currentVehicleId = (SELECT TOP 1 Id FROM Vehicles WHERE ChassisNumber = @currentChassisNumber AND IsDeleted=0)
SET @targetVehicleId = (SELECT TOP 1 Id FROM Vehicles WHERE ChassisNumber = @targetChassisNumber AND IsDeleted=0)

	 UPDATE Work_Orders 
	 SET VehicleId = @targetVehicleId
	 WHERE VehicleId = @currentVehicleId
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_WorkOrders_ById]    Script Date: 4.06.2022 00:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Update_WorkOrders_ById] (
	@id AS INT,
	@date AS DATETIME,
	@customerName AS NVARCHAR(50),
	@request AS NVARCHAR(500)
	)
AS
BEGIN
	UPDATE Work_OrderS
	SET [Date] = @date,
		CustomerName = @customerName,
		Request = @request
	WHERE Id = @id
END;
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:  Not Completed          1:  Completed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Order_Operations', @level2type=N'COLUMN',@level2name=N'Status'
GO
USE [master]
GO
ALTER DATABASE [AssesmentProjectDB] SET  READ_WRITE 
GO





USE [AssesmentProjectDB]
GO


-- 1st VEHICLE RECORDS
EXEC usp_Add_Vehicles '34 ABC 34','SCA664S5XAUX48670', 'Toyota', 'Corolla', '2022'
DECLARE @currentVehicleId INT;
SET @currentVehicleId = IDENT_CURRENT('Vehicles')

EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-05', '2022-06-01'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-06', '2022-08-07'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-07', '2022-08-08'

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-01', 'Ahmet Yılmaz', 'Araç Bakımı'
DECLARE @currentWorkOrderId INT;
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-02', 'Melek Aygün', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0


EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-03', 'Hasan Kaya', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0



-- 2nd VEHICLE RECORDS
EXEC usp_Add_Vehicles '21 TF 46','WP0CB29906S769518', 'Toyota', 'Yaris', '2016'
SET @currentVehicleId = IDENT_CURRENT('Vehicles')

EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-08', '2022-06-02'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-09', '2022-08-09'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-10', '2022-08-10'

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-07', 'Derya Şenler', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-08', 'Deniz Yalçın', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-09', 'Suna Ünal', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0



-- 3rd VEHICLE RECORDS
EXEC usp_Add_Vehicles '55 KTC 46','2C3CCAFJ2CH801561', 'Toyota', 'Camry', '2020'
SET @currentVehicleId = IDENT_CURRENT('Vehicles')

EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-11', '2022-06-03'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-12', '2022-06-11'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-13', '2022-08-12'


EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-04', 'Bora Demir', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-05', 'Suat Altun', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-06', 'Ayşe Semiz', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0




-- 4th VEHICLE RECORDS
EXEC usp_Add_Vehicles '19 XYZ 46','1GCDC14H5DS161081', 'Toyota', 'Hilux', '2021'
SET @currentVehicleId = IDENT_CURRENT('Vehicles')

EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-14', '2022-06-03'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-15', '2022-08-13'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-16', '2022-08-14'

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-10', 'Cenk Toraman', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-11', 'Emre Keskin', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-12', 'Tuna Tunay', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0




-- 5th VEHICLE RECORDS
EXEC usp_Add_Vehicles '01 TT 46','1J4GZ78Y5PC574443', 'Toyota', 'Corolla HB', '2021'
SET @currentVehicleId = IDENT_CURRENT('Vehicles')

EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-17', '2022-06-03'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-18', '2022-08-15'
EXEC usp_Add_VehicleWarrantyRecords @currentVehicleId,'2021-05-19', '2022-08-16'

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-13', 'Serpil Yılmaz', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-14', 'Arda Şahin', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

EXEC usp_Add_WorkOrders @currentVehicleId,'2022-06-15', 'Aslan Kara', 'Araç Bakımı'
SET @currentWorkOrderId = IDENT_CURRENT('Work_Orders')

EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0
EXEC usp_Add_WorkOrderOperations @currentWorkOrderId, 'Yapılması Gereken İşlemler', 0

GO
