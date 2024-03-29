USE [EFBienestarBD2]
GO
SET IDENTITY_INSERT [dbo].[TL_Usuarios] ON 

INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (1, 123456, N'Maria', N'Arias', CAST(N'1988-06-06' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (2, 123457, N'Fernando', N'Perea', CAST(N'1979-01-25' AS Date), N'M')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (3, 123458, N'Fernanda', N'Perea Arias', CAST(N'2018-02-02' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (5, 123459, N'Maria', N'Perea Arias', CAST(N'2019-03-01' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (6, 123147, N'Camila', N'Ayala', CAST(N'1991-06-26' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (7, 123148, N'Elkin', N'Peñuela', CAST(N'1988-02-24' AS Date), N'M')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (8, 123149, N'Karen', N'Peñuela Ayala', CAST(N'2020-09-01' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (9, 123781, N'Karla', N'Rangel', CAST(N'1983-05-05' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (10, 123782, N'Camilo Jr', N'Rangel ', CAST(N'2021-08-21' AS Date), N'M')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (11, 123369, N'Piedad', N'Peña', CAST(N'1973-12-12' AS Date), N'F')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (12, 123368, N'Jorge', N'Gonzalez', CAST(N'1975-11-26' AS Date), N'M')
INSERT [dbo].[TL_Usuarios] ([Id], [NumeroIdentificacion], [Nombres], [Apellidos], [FechaNacimiento], [Genero]) VALUES (15, 123367, N'Maria Mauricia', N'Gonzalez Peña', CAST(N'2015-12-13' AS Date), N'F')
SET IDENTITY_INSERT [dbo].[TL_Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[TL_Hijos] ON 

INSERT [dbo].[TL_Hijos] ([Id], [UsuarioId], [Estudia], [EstaturaCms], [DescripcionFisica]) VALUES (1, 3, N'S', CAST(100.00 AS Decimal(5, 2)), N'Pequeña')
INSERT [dbo].[TL_Hijos] ([Id], [UsuarioId], [Estudia], [EstaturaCms], [DescripcionFisica]) VALUES (2, 5, N'S', CAST(110.00 AS Decimal(5, 2)), N'Cabello Negro')
INSERT [dbo].[TL_Hijos] ([Id], [UsuarioId], [Estudia], [EstaturaCms], [DescripcionFisica]) VALUES (3, 8, N'S', CAST(90.00 AS Decimal(5, 2)), N'Ojos Verdes')
INSERT [dbo].[TL_Hijos] ([Id], [UsuarioId], [Estudia], [EstaturaCms], [DescripcionFisica]) VALUES (4, 10, N'N', CAST(60.00 AS Decimal(5, 2)), N'Piel Morena, gordito')
INSERT [dbo].[TL_Hijos] ([Id], [UsuarioId], [Estudia], [EstaturaCms], [DescripcionFisica]) VALUES (8, 15, N'S', CAST(120.00 AS Decimal(5, 2)), N'Pelo Corto')
SET IDENTITY_INSERT [dbo].[TL_Hijos] OFF
GO
SET IDENTITY_INSERT [dbo].[TL_Padres] ON 

INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (1, 1, N'I', 10, N'Ninguna')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (2, 2, N'E', 1, N'Ninguna')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (3, 6, N'E', 5, N'Ninguna')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (4, 7, N'E', 2, N'Ninguna')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (5, 9, N'E', 5, N'Ninguna')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (6, 11, N'E', 12, N'Problemas de Salud')
INSERT [dbo].[TL_Padres] ([Id], [UsuarioId], [TipoEmpleo], [ExperienciaLaboral], [Observaciones]) VALUES (7, 12, N'E', 10, N'Problema con el Trago')
SET IDENTITY_INSERT [dbo].[TL_Padres] OFF
GO
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (1, 1)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (2, 1)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (1, 2)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (2, 2)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (3, 3)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (4, 3)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (5, 4)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (6, 8)
INSERT [dbo].[TL_RelacionPadresHijos] ([PadreId], [HijoId]) VALUES (7, 8)
GO
