USE [master]
GO
/****** Object:  Database [hotelaria]    Script Date: 08/11/2021 23:08:09 ******/
CREATE DATABASE [hotelaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hotelaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hotelaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hotelaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hotelaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [hotelaria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hotelaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hotelaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hotelaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hotelaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hotelaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hotelaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [hotelaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hotelaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hotelaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hotelaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hotelaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hotelaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hotelaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hotelaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hotelaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hotelaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hotelaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hotelaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hotelaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hotelaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hotelaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hotelaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hotelaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hotelaria] SET RECOVERY FULL 
GO
ALTER DATABASE [hotelaria] SET  MULTI_USER 
GO
ALTER DATABASE [hotelaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hotelaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hotelaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hotelaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hotelaria] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'hotelaria', N'ON'
GO
ALTER DATABASE [hotelaria] SET QUERY_STORE = OFF
GO
USE [hotelaria]
GO
/****** Object:  Table [dbo].[acomodacao]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acomodacao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_categoria_quarto] [int] NULL,
	[numero] [int] NOT NULL,
	[andar] [int] NOT NULL,
	[ocupado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria_quarto]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria_quarto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantidade_camas] [int] NOT NULL,
	[descricao] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[nome] [varchar](100) NOT NULL,
	[rg] [varchar](15) NOT NULL,
	[cpf_cnpj] [varchar](15) NOT NULL,
	[data_nascimento] [date] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefone] [varchar](15) NOT NULL,
 CONSTRAINT [PK__cliente__3213E83F4013AACC] PRIMARY KEY CLUSTERED 
(
	[cpf_cnpj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[endereco]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[endereco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logradouro] [varchar](50) NOT NULL,
	[numero] [int] NULL,
	[bairro] [varchar](50) NULL,
	[cidade] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[complemento] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[funcionario]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[funcionario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_endereco] [int] NULL,
	[nome] [varchar](100) NULL,
	[registro] [varchar](30) NULL,
	[rg] [varchar](9) NULL,
	[cpf] [varchar](11) NULL,
	[data_nascimento] [date] NULL,
	[email] [varchar](100) NULL,
	[cargo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[login] [varchar](100) NOT NULL,
	[senha] [varchar](100) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[meio_pagamento]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meio_pagamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prestadores_servico]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prestadores_servico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_servico] [int] NULL,
	[cnpj_empresa] [varchar](15) NULL,
	[nome_empresa] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservas]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf_cliente] [varchar](15) NOT NULL,
	[id_acomodacao] [int] NOT NULL,
	[forma_pagamento] [varchar](20) NOT NULL,
	[checkin] [datetime] NOT NULL,
	[checkout] [datetime] NOT NULL,
 CONSTRAINT [PK_reservas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servico]    Script Date: 08/11/2021 23:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[custo] [money] NULL,
	[atendido] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_reservas]    Script Date: 08/11/2021 23:08:10 ******/
CREATE NONCLUSTERED INDEX [IX_reservas] ON [dbo].[reservas]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[acomodacao]  WITH CHECK ADD FOREIGN KEY([id_categoria_quarto])
REFERENCES [dbo].[categoria_quarto] ([id])
GO
ALTER TABLE [dbo].[funcionario]  WITH CHECK ADD FOREIGN KEY([id_endereco])
REFERENCES [dbo].[endereco] ([id])
GO
ALTER TABLE [dbo].[prestadores_servico]  WITH CHECK ADD FOREIGN KEY([id_servico])
REFERENCES [dbo].[servico] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD  CONSTRAINT [FK_reservas_acomodacao] FOREIGN KEY([id_acomodacao])
REFERENCES [dbo].[acomodacao] ([id])
GO
ALTER TABLE [dbo].[reservas] CHECK CONSTRAINT [FK_reservas_acomodacao]
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD  CONSTRAINT [FK_reservas_cliente] FOREIGN KEY([cpf_cliente])
REFERENCES [dbo].[cliente] ([cpf_cnpj])
GO
ALTER TABLE [dbo].[reservas] CHECK CONSTRAINT [FK_reservas_cliente]
GO
USE [master]
GO
ALTER DATABASE [hotelaria] SET  READ_WRITE 
GO
