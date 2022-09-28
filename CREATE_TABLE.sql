
CREATE TABLE [usuario] (
  [id_usuario] varchar(46) primary key,
  [Nombres] varchar(50),
  [Apellidos] Varchar(50),
  [Correo] Varchar(50),
  [Activo] bit,
  [us_Usuario] varchar(20),
  [us_Contraseña] varchar(64),
);


CREATE TABLE [Personal] (
  [ID_Personal] varchar(46) DEFAULT NEWID() primary key,
  [Nombres] varchar(50),
  [Apellidos] Varchar(50),
  [Telefono] Varchar(50),
  [Direccion] varchar(15),
  [Puesto] varchar(30)
);

CREATE TABLE [Firma] (
  [ID_Firma] VARCHAR(36) DEFAULT NEWID() primary key,
  [Tipo] varchar(20),
  [Nombre] varchar(25),
  [Firma]  binary
);

CREATE TABLE [ServicioVario] (
  [id_sv] VARCHAR(36) DEFAULT NEWID()primary key,
  [sv_Estacion] varchar(20),
  [sv_Turno] varchar(20),
  [sv_Fecha] Date,
  [sv_Direccion] varchar(100),
  [sv_Servicio] varchar(100),
  [sv_HoraSalida] time,
  [sv_horaEntrada] time,
  [sv_JefeServicio] varchar(46),
  [sv_TelefonistaTurno] varchar(46),
  [sv_BomberoReporta] varchar(46),
  [sv_Unidad] varchar(50),
  [sv_Piloto] varchar(46),
  [sv_ServicioAutPor] varchar(46),
  [sv_PersonalAsistente] varchar(46),
  [sv_Observacion] varchar(500),
  [sv_KmEntrada] Float,
  [sv_KmSalida] Float,
  [sv_KmRecorrido] Float,
  [sv_FirmaBombero] varchar(36),
  [sv_NoBombero] bigint,
  CONSTRAINT [FK_ServicioVario.sv_BomberoReporta]
    FOREIGN KEY ([sv_BomberoReporta])
      REFERENCES [usuario]([id_usuario]),
  CONSTRAINT [FK_ServicioVario.sv_JefeServicio]
    FOREIGN KEY ([sv_JefeServicio])
      REFERENCES [Personal]([ID_Personal]),
  CONSTRAINT [FK_ServicioVario.sv_TelefonistaTurno]
    FOREIGN KEY ([sv_TelefonistaTurno])
      REFERENCES [Personal]([ID_Personal]),
  CONSTRAINT [FK_ServicioVario.sv_FirmaBombero]
    FOREIGN KEY ([sv_FirmaBombero])
      REFERENCES [Firma]([ID_Firma]),
  CONSTRAINT [FK_ServicioVario.sv_ServicioAutPor]
    FOREIGN KEY ([sv_ServicioAutPor])
      REFERENCES [Personal]([ID_Personal]),
  CONSTRAINT [FK_ServicioVario.sv_Piloto]
    FOREIGN KEY ([sv_Piloto])
      REFERENCES [Personal]([ID_Personal]),
  CONSTRAINT [FK_ServicioVario.sv_PersonalAsistente]
    FOREIGN KEY ([sv_PersonalAsistente])
      REFERENCES [Personal]([ID_Personal])
);
