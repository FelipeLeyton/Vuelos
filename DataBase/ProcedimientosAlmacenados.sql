USE [Vuelos]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarAerolineas]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ConsultarAerolineas]  
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		[id]
	   ,[nombre]
	FROM
		[dbo].[Aerolinea]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarCiudades]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ConsultarCiudades]  
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		[id]
	   ,[nombre]
	FROM
		[dbo].[Ciudad]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarEstados]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ConsultarEstados]  
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		[id]
	   ,[nombre]
	FROM
		[dbo].[Estado]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarVuelos]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Andres Felipe Roa Leyton>
-- Create date: <24/09/2022,,>
-- Description:	<Optiene los vuelos,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ConsultarVuelos] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		 GV.[id]
		,CO.[nombre] AS 'ciudadOrigen'
		,CD.[nombre] AS 'ciudadDestino'
		,[fecha]
		,[horaSalida]
		,[horaLLegada]
		,[numeroVuelo]
		,A.[nombre] AS 'aerolinea'
		,E.[nombre] AS 'estado'
	FROM
		[dbo].[GestionVuelos] GV
		INNER JOIN [dbo].[Ciudad] CO ON GV.idCiudadOrigen = CO.id
		INNER JOIN [dbo].[Ciudad] CD ON GV.idCiudadDestino = CD.id
		INNER JOIN [dbo].[Aerolinea] A ON GV.idAerolinea = A.id
		INNER JOIN [dbo].[Estado] E ON GV.idEstado = E.id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarVuelosById]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ConsultarVuelosById]  
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		[idCiudadOrigen]
       ,[idCiudadDestino]
       ,[fecha]
       ,[horaSalida]
       ,[horaLlegada]
       ,[numeroVuelo]
       ,[idAerolinea]
       ,[idEstado]
	FROM
		[dbo].[GestionVuelos]
	WHERE
		id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarVuelos]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_EditarVuelos] 
	@id int,
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@fecha date,
	@horaSalida time(7),
	@horaLLegada time(7),
	@numeroVuelo varchar(50),
	@idAerolinea int,
	@idEstado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[GestionVuelos]
	SET
		[idCiudadOrigen] = @idCiudadOrigen
       ,[idCiudadDestino] = @idCiudadDestino
       ,[fecha] = @fecha
       ,[horaSalida] = @horaSalida
       ,[horaLlegada] = @horaLLegada
       ,[numeroVuelo] = @numeroVuelo
       ,[idAerolinea] = @idAerolinea
       ,[idEstado] = @idEstado
	WHERE
		[id] = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarVuelos]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_EliminarVuelos] 
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[GestionVuelos] WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarVuelos]    Script Date: 28/09/2022 1:36:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_RegistrarVuelos] 
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@fecha date,
	@horaSalida time(7),
	@horaLLegada time(7),
	@numeroVuelo varchar(50),
	@idAerolinea int,
	@idEstado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[GestionVuelos]
	(
       [idCiudadOrigen]
      ,[idCiudadDestino]
      ,[fecha]
      ,[horaSalida]
      ,[horaLlegada]
      ,[numeroVuelo]
      ,[idAerolinea]
      ,[idEstado]
	)
	VALUES
	(
		@idCiudadOrigen,
		@idCiudadDestino,
		@fecha,
		@horaSalida,
		@horaLLegada,
		@numeroVuelo,
		@idAerolinea,
		@idEstado
	)
END
GO
