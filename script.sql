USE [PortalNoticias]
GO
/****** Object:  Table [dbo].[Archivo]    Script Date: 8/25/2020 9:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Archivo](
	[IdArchivo] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNoticia] [bigint] NOT NULL,
	[Ruta] [varchar](250) NOT NULL,
	[Tipo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 8/25/2020 9:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[IdComentario] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdNoticia] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Texto] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticia]    Script Date: 8/25/2020 9:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticia](
	[IdNoticia] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[Titulo] [varchar](250) NOT NULL,
	[Texto] [varchar](8000) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoNoticia] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNoticia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/25/2020 9:20:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](15) NOT NULL,
	[TipoUsuario] [tinyint] NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellido1] [varchar](30) NOT NULL,
	[Apellido2] [varchar](30) NULL,
	[Clave] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Archivo] ON 

INSERT [dbo].[Archivo] ([IdArchivo], [IdNoticia], [Ruta], [Tipo]) VALUES (17, 26, N'https://www.youtube.com/embed/2ilaanEphFs?autoplay=0&fs=0&iv_load_policy=3&showinfo=0&rel=0&cc_load_policy=0&start=0&end=0&origin=https://youtubeembedcode.com', 1)
INSERT [dbo].[Archivo] ([IdArchivo], [IdNoticia], [Ruta], [Tipo]) VALUES (18, 27, N'../Archivos/coronavirus_images_stories_ECEN_thumb_medium250_0.jpeg', 0)
INSERT [dbo].[Archivo] ([IdArchivo], [IdNoticia], [Ruta], [Tipo]) VALUES (19, 28, N'../Archivos/Productor-de-cacao-en-Limón.-660x330.jpeg', 0)
INSERT [dbo].[Archivo] ([IdArchivo], [IdNoticia], [Ruta], [Tipo]) VALUES (20, 29, N'../Archivos/Bill-Ted-PPAL.jpg', 0)
INSERT [dbo].[Archivo] ([IdArchivo], [IdNoticia], [Ruta], [Tipo]) VALUES (21, 30, N'https://www.youtube.com/embed/EMoo85EoeC0?autoplay=0&fs=0&iv_load_policy=3&showinfo=0&rel=0&cc_load_policy=0&start=0&end=0&origin=https://youtubeembedcode.com', 1)
SET IDENTITY_INSERT [dbo].[Archivo] OFF
GO
SET IDENTITY_INSERT [dbo].[Noticia] ON 

INSERT [dbo].[Noticia] ([IdNoticia], [IdUsuario], [Titulo], [Texto], [Fecha], [TipoNoticia]) VALUES (26, 1, N'Messi se va del barcelona', N'La "bomba" ha estallado en Barcelona, Lionel Messi comunicó al club que no quiere seguir en la entidad blaugrana de cara a la siguiente temporada, lo que deja al equipo y a la directiva en shock.Tras su conversación con Ronald Koeman del pasado viernes, en la que el argentino ya advirtió al entrenador que se veía más fuera que dentro, Messi no tardó en acabar de tomar una decisión que supone un terremoto en el planeta fútbol


Por ello, en MARCA Claro te dejamos las opciones del jugador argentino para fichar de cara a la próxima temporada.¿Qué equipos podrían fichar a Messi?Tres equipos por Messi. Ni los 33 años del futbolista argentino desaniman al Inter de Milán, Manchester City y Paris Saint-Germain, escuadras que, después de haber hecho cuentas, se colocan en la línea de salida de la carrera por Lionel Messi.Para que el fichaje de Messi pudiera realizarse es indispensable que Bartomeuhiciera con el argentino lo mismo que hizo Florentino con Cristiano en 2018: abrirle la puerta por un módico precio. Los 700 millones que ha deslizado el presidente que habría que ganar por el argentino son una quimera, así que lo primero que se debe dar es un gesto de buena voluntad por parte del Barça. Se entiende, o al menos así lo cree el entorno del jugador, que se daría. ¿100 millones? ¿150? Por ahí debería andar el traspaso del argentino, que tiene alicientes para ir a cualquiera de estos tres equipos.', CAST(N'2020-08-25T00:00:00.000' AS DateTime), N'Deportes')
INSERT [dbo].[Noticia] ([IdNoticia], [IdUsuario], [Titulo], [Texto], [Fecha], [TipoNoticia]) VALUES (27, 1, N'Los casos se disparan en Francia con más de 3.000 nuevos contagios en 24 horas y 1.184 en Reino Unido', N'Sánchez ha asegurado en rueda de prensa que "la evolución global de la curva es preocupante", aunque ha especificado que la situación no es homogénea y hay territorios más afectados que otros.

España supera los 400.000 contagios de coronavirus, y el número de muertos por Covid desde que comenzó la pandemia de Covid es de 28.872. Ante la subida de casos producida durante el verano y el temor a enfrentarse a una situación como la de marzo, el presidente del Gobierno, Pedro Sánchez, apuesta este martes por un plan de "cogobernanza" con las Comunidades Autónomas. Además, la vuelta al colegio sigue centrando la preocupación general y las comunidades van anunciando sus normas. Cantabria recomienda una medida controvertida: el uso de mascarilla por parte de los alumnos de 3 a 6 años.

Los casos de COVID-19 en México llegaron este martes a 568.621 y las defunciones a 61.450 al añadirse las 4.916 infecciones y los 650 muertos notificados en las últimas 24 horas a las autoridades sanitarias del país.

Con el reporte técnico presentado en Palacio Nacional de Ciudad de México, se confirmó un aumento porcentual de 0,87 % en los casos confirmados comparados con los 563.705 de ayer y muertes tuvieron un crecimiento de 1,06 % respecto a los 60.800 del informe previo.', CAST(N'2020-08-25T00:00:00.000' AS DateTime), N'Tecnologia')
INSERT [dbo].[Noticia] ([IdNoticia], [IdUsuario], [Titulo], [Texto], [Fecha], [TipoNoticia]) VALUES (28, 1, N'Sector agro anuncia 13 proyectos para activar producción y generar empleo en el Caribe', N'Con el desarrollo de 13 proyectos agroproductivos que impulsa el Ministerio de Agricultura y Ganadería (MAG), de manera articulada con otras entidades del sector e instituciones del Estado, academia y empresas privadas, se pretende mejorar las condiciones en que producen los agricultores y agricultoras de la región Caribe del país.

Se trata de una serie de iniciativas que buscan potenciar a productores dedicados a actividades como la producción de cacao, ganadería, lácteos, avicultura, hortalizas, papaya, musáceas, entre otras, con el objetivo de reducir los niveles de intermediación, mejorar los procesos de agregación de valor y el nivel de vida de las familias que dependen de este tipo de cultivos.

El ministro de Agricultura y Ganadería, Renato Alvarado, indicó que la mayoría de los proyectos se han ejecutado o están pronto a desarrollar, con una inversión que supera los ¢3.500 millones, beneficiando de manera directa a más de 1.350 personas productoras y sus familias, en las comunidades de Matina, Batán, Carrandy, Guácimo, Limón, Matama, Valle la Estrella, Pococí, Cariari, Jiménez, Siquirres, Germania, Florida, Cairo, La Alegría, Talamanca y Telire.

“Estas iniciativas son parte del compromiso de la actual Administración para impulsar al sector, generar riqueza y mayor empleo, con el fin de que las familias que viven del agro tengan mejores condiciones de vida. Todos los proyectos tienen dentro de sus componentes la agregación de valor a la producción primaria, el fortalecimiento de la comercialización y de la exportación, la inclusión de grupos vulnerables, como los indígenas, y la sostenibilidad”, precisó el ministro Alvarado.

Por su parte, el vicepresidente de la República y coordinador de la Mesa Caribe, Marvin Rodríguez, celebró y agradeció el trabajo de las instancias gubernamentales que, bajo un principio de articulación interinstitucional, han otorgado el financiamiento respectivo a los proyectos presentados, brindándole oportunidades a cientos de familias agrícolas de la provincia.

“Desde la Mesa Caribe impulsamos la Zona Económica Caribe y dentro de ella el Clúster de Agroindustria, bajo un concepto de triple hélice con participación activa de la Academia, los productores, las instituciones de Gobierno y con el apoyo de los Gobiernos locales. Avanzamos en la consolidación de este clúster para generar empleos decentes y más y mejores oportunidades al sector”, precisó.

Para la ejecución de estos proyectos, el MAG ha sumado esfuerzos de entidades del Sector Agropecuario, entre ellas, el Instituto de Desarrollo Rural (INDER), el Consejo Nacional de Producción (CNP), el Servicio Nacional de Salud Animal (SENASA), la Fundación para la Investigación y Transferencia de Tecnología Agropecuaria (FITTACORI) y el Consejo Nacional de Clubes 4S.

Además, se ha articulado con otras entidades como la Junta para el Desarrollo Portuario de la Vertiente Atlántica (JAPDEVA), los institutos Costarricense de Electricidad (ICE), Mixto de Ayuda Social (IMAS), la Promotora de Comercio Exterior, (PROCOMER), la Comisión para el Ordenamiento y Manejo de la Cuenca del Río Reventazón (COMCURE).

Así como organismos como el Centro Agronómico Tropical de Investigación y Enseñanza (CATIE) y con las universidades Nacional (UNA) y de Costa Rica (UCR). “Los logros no serían posibles sin la voluntad de cámaras y organizaciones de productores y empresas privadas como los Centros Agrícolas Cantonales, la Cámara de Ganaderos Unidos del Caribe, Wild tropics, Green Life, y Frutas Tropicales”, agregó el ministro rector del sector agropecuario.', CAST(N'2020-08-25T00:00:00.000' AS DateTime), N'Sucesos')
INSERT [dbo].[Noticia] ([IdNoticia], [IdUsuario], [Titulo], [Texto], [Fecha], [TipoNoticia]) VALUES (29, 1, N'La música salva a la humanidad de su extinción en «Bill and Ted Face the Music» con Keanu Reeves y Alex Winter', N'En efecto, están de regreso. Bill (Keanu Reeves) y Ted (Alex Winter) han vuelto en una tercera parte de la cinta original que se estrenó en 1989 —»Bill & Ted’s Excellent Adventure— y que tras una segunda parte titulada «Bill & Ted’s Bogus Journey», estos mejores amigos estaban en el escenario cargando a sus bebés «Little Bill & Little Ted» y su amiga, la Muerte (William Sadler). El mundo estaba a sus pies y su banda Wyld Stallyns salvaba al mundo en ese momento.

Hoy, 29 años después, regresan estos mejores amigos quienes no han escrito la canción que cumpliría su destino y aseguraría la supervivencia de la humanidad. El tiempo se acaba. Aún viven en San Dimas, California; sus bebés ahora se han convertido en los igualmente obsesionados con la música Billie y Thea; Wyld Stallyns se desintegró y la Muerte se encuentra molesta.

«Me divertí tanto con esta tercera cinta. Pasaron 29 años para hacerse, pero fue lo más divertido en hacer a este personaje. Vi la segunda parte un par de veces. Llevo cargando este personaje por varios años. Cuando lo desempolvé, salió muy fácil. Quise ver la segunda cinta para recordar cuál era la relación que tenía con Bill y Ted. Había olvidado tantos detalles que me sirvió para recordarlos. La muerte tuvo un mal camino en la industria musical, así que está algo amargado y enojado. Porque siente que nada salió bien y que fue la culpa de Billy Ted y porque lo sacaron de la banda. No está en un lugar bueno», asegura el actor William Sandler quien habló vía telefónica con Zona Pop CNN.

Zona Pop
¿Por qué tardó 29 años en filmarse la tercera parte?

William Sadler
«Todos estábamos muy ocupados, Keanu hizo «Speed» y «Matrix» y otros proyectos, Alex hizo sus documentales y yo hice otras cintas. Todos estábamos ocupados hasta que hace 5 años, los escritores Ed Solomon y Chris Matheson comenzaron a escribir la tercera parte y se acercaron a preguntarme si estaría interesado en revivir a la muerte. Honestamente no pensé que llevarían a cabo el guión».', CAST(N'2020-08-25T00:00:00.000' AS DateTime), N'Entretenimiento')
INSERT [dbo].[Noticia] ([IdNoticia], [IdUsuario], [Titulo], [Texto], [Fecha], [TipoNoticia]) VALUES (30, 1, N'Tercera noche de protestas en Wisconsin por disparar la policía a un hombre negro por la espalda', N'El incidente tiene significación electoral porque Wisconsin es el estado que puede decidir las elecciones del 3 de noviembre, ya que tiene una considerable población blanca de clase obrera, pero también cuenta con una minoría negra importante.

La tensión racial sigue imparable en EEUU. Por tercera noche consecutiva, la ciudad de Kenosha, en el estado de Wisconsin, se ha visto asolada por manifestaciones, disturbios y saqueos después de que la policía pegara cuatro tiros a muy corta distancia a un afroamericano, Jacob S. Blake, al que estaba introduciendo en un coche policial.

Blake había sido arrestado cuando estaba tratando de robar en una tienda abierta 24 horas en una gasolinera, y, al entrar esposado en el vehículo de los policías, éstos le pegaron cuatro tiros a una distancia de pocos centímetros lo que, según su padre, le dejará paralítico. Todo el incidente, que fue grabado con un teléfono, ha vuelto a encender la llama de las tensiones raciales. En todo el país están apareciendo pintadas con las letras ''ACAB'' (el acrónimo ''Todos los Policías son unos Bastardos'', en inglés), en ocasiones en monumentos.

El incidente tiene además significación electoral porque Wisconsin es el estado que puede decidir las elecciones del 3 de noviembre, ya que tiene una considerable población blanca de clase obrera que en 2016 cambió sus preferencias políticas y votó por el candidato republicanos, Donald Trump, pero también cuenta con una minoría negra importante que Barack Obama supo movilizar muy bien para ganar la reelección en 2012. Desde el punto de vista sociológico, además, Wisconsin es el estado que representa la media perfecta de la política estadounidense, según la web de estadísticas FiveThirtyEight.

De hecho, según narra en sus memorias el ex jefe de campaña de Obama, David Axelrod, cuando el presidente colgó el teléfono después de que le llamara por teléfono el candidato republicano, Mitt Romney, para felicitarle por su victoria, se dirigió a su asesor y le dijo, con el gesto serio: "Usted hizo un trabajo muy bueno con el voto negro en Cleveland y en Milwaukee", en otras palabras, el voto de los negros. "Para él, eso es de lo que se trata", relata Axelrod.', CAST(N'2020-08-25T00:00:00.000' AS DateTime), N'Internacionales')
SET IDENTITY_INSERT [dbo].[Noticia] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [NombreUsuario], [TipoUsuario], [Nombre], [Apellido1], [Apellido2], [Clave]) VALUES (1, N'Administrador', 1, N'Guillermo', N'Sotomayor', N'Blanco', N'12345')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Archivo__D885EF9999BBFE6E]    Script Date: 8/25/2020 9:20:54 PM ******/
ALTER TABLE [dbo].[Archivo] ADD UNIQUE NONCLUSTERED 
(
	[Ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__6B0F5AE0A60484C3]    Script Date: 8/25/2020 9:20:54 PM ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Archivo] ADD  DEFAULT ((0)) FOR [Tipo]
GO
ALTER TABLE [dbo].[Archivo]  WITH CHECK ADD  CONSTRAINT [fk_Noticia_Archivo] FOREIGN KEY([IdNoticia])
REFERENCES [dbo].[Noticia] ([IdNoticia])
GO
ALTER TABLE [dbo].[Archivo] CHECK CONSTRAINT [fk_Noticia_Archivo]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [fk_Noticia_Comentario] FOREIGN KEY([IdNoticia])
REFERENCES [dbo].[Noticia] ([IdNoticia])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [fk_Noticia_Comentario]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Comentario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [fk_Usuario_Comentario]
GO
ALTER TABLE [dbo].[Noticia]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Noticia] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Noticia] CHECK CONSTRAINT [fk_Usuario_Noticia]
GO
