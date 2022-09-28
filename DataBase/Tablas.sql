USE [Vuelos]
GO
/****** Object:  Table [dbo].[Aerolinea]    Script Date: 28/09/2022 1:36:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerolinea](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 28/09/2022 1:36:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 28/09/2022 1:36:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GestionVuelos]    Script Date: 28/09/2022 1:36:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GestionVuelos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCiudadOrigen] [int] NULL,
	[idCiudadDestino] [int] NULL,
	[fecha] [date] NULL,
	[horaSalida] [time](7) NULL,
	[horaLlegada] [time](7) NULL,
	[numeroVuelo] [varchar](50) NULL,
	[idAerolinea] [int] NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aerolinea] ON 
GO
INSERT [dbo].[Aerolinea] ([id], [nombre]) VALUES (1, N'Avianca')
GO
INSERT [dbo].[Aerolinea] ([id], [nombre]) VALUES (2, N'Despegar')
GO
SET IDENTITY_INSERT [dbo].[Aerolinea] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudad] ON 
GO
INSERT [dbo].[Ciudad] ([id], [nombre]) VALUES (1, N'Bogota')
GO
INSERT [dbo].[Ciudad] ([id], [nombre]) VALUES (2, N'Medellin')
GO
INSERT [dbo].[Ciudad] ([id], [nombre]) VALUES (3, N'Cali')
GO
SET IDENTITY_INSERT [dbo].[Ciudad] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 
GO
INSERT [dbo].[Estado] ([id], [nombre]) VALUES (1, N'Aterrizo')
GO
INSERT [dbo].[Estado] ([id], [nombre]) VALUES (2, N'Despego')
GO
INSERT [dbo].[Estado] ([id], [nombre]) VALUES (3, N'Confirmado')
GO
INSERT [dbo].[Estado] ([id], [nombre]) VALUES (4, N'Programado')
GO
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
SET IDENTITY_INSERT [dbo].[GestionVuelos] ON 
GO
INSERT [dbo].[GestionVuelos] ([id], [idCiudadOrigen], [idCiudadDestino], [fecha], [horaSalida], [horaLlegada], [numeroVuelo], [idAerolinea], [idEstado]) VALUES (5, 0, 0, CAST(N'2022-09-27' AS Date), CAST(N'10:30:00' AS Time), CAST(N'13:45:00' AS Time), N'string', 0, 0)
GO
INSERT [dbo].[GestionVuelos] ([id], [idCiudadOrigen], [idCiudadDestino], [fecha], [horaSalida], [horaLlegada], [numeroVuelo], [idAerolinea], [idEstado]) VALUES (6, 0, 0, CAST(N'2022-09-27' AS Date), CAST(N'10:30:00' AS Time), CAST(N'13:45:00' AS Time), N'string', 0, 0)
GO
INSERT [dbo].[GestionVuelos] ([id], [idCiudadOrigen], [idCiudadDestino], [fecha], [horaSalida], [horaLlegada], [numeroVuelo], [idAerolinea], [idEstado]) VALUES (7, 0, 0, CAST(N'2022-09-27' AS Date), CAST(N'12:30:00' AS Time), CAST(N'01:30:00' AS Time), N'string', 0, 0)
GO
INSERT [dbo].[GestionVuelos] ([id], [idCiudadOrigen], [idCiudadDestino], [fecha], [horaSalida], [horaLlegada], [numeroVuelo], [idAerolinea], [idEstado]) VALUES (8, 0, 0, CAST(N'2022-09-27' AS Date), CAST(N'12:30:00' AS Time), CAST(N'01:30:00' AS Time), N'string', 0, 0)
GO
INSERT [dbo].[GestionVuelos] ([id], [idCiudadOrigen], [idCiudadDestino], [fecha], [horaSalida], [horaLlegada], [numeroVuelo], [idAerolinea], [idEstado]) VALUES (10, 1, 3, CAST(N'2022-09-28' AS Date), CAST(N'23:53:00' AS Time), CAST(N'13:55:00' AS Time), N'ASE35', 2, 3)
GO
SET IDENTITY_INSERT [dbo].[GestionVuelos] OFF
GO
