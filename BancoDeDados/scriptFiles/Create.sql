IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'ToDo')
BEGIN
	CREATE DATABASE ToDo;
END
GO

USE ToDo;
GO

CREATE TABLE [dbo].[Endereco]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Logradouro] VARCHAR(255) NOT NULL,
	[Bairro] VARCHAR(180) NOT NULL ,
	[Complemento] VARCHAR(150) NOT NULL ,
	[Numero] int NOT NULL,
	CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[InstituicaoEnsino]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[AggregateId] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[Nome] VARCHAR(255) NOT NULL,
	[Cnpj] VARCHAR(14) NOT NULL UNIQUE,
	[Telefone] VARCHAR(14) NOT NULL,
	[Ativo] BIT NOT NULL,
	[EnderecoId] int NOT NULL,
	CONSTRAINT [PK_InstituicaoEnsino] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_InstituicaoEnsino_Endereco] FOREIGN KEY (EnderecoId) REFERENCES dbo.Endereco([id])
)
GO

CREATE TABLE [dbo].[Usuario]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[AggregateId] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[Nome] VARCHAR(255) NOT NULL,
	[Cpf] VARCHAR(11) NOT NULL UNIQUE,
	[Telefone] VARCHAR(14) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[Ativo] BIT NOT NULL,
	[EnderecoId] int NULL,
	[InstituicaoEnsinoId] int NOT NULL,
	CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Usuario_Endereco] FOREIGN KEY (EnderecoId) REFERENCES dbo.Endereco(id),
	CONSTRAINT [FK_Usuario_InstituicaoEnsino] FOREIGN KEY (InstituicaoEnsinoId) REFERENCES dbo.InstituicaoEnsino([id])
)
GO

CREATE TABLE [dbo].[Autor] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL,
	[Nome] VARCHAR(180) NOT NULL,
	[Ativo] BIT NOT NULL,
	CONSTRAINT [PK_Autor] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Genero] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL,
	[Descricao] VARCHAR(180) NOT NULL,
	[Ativo] BIT NOT NULL,
	CONSTRAINT [PK_Genero] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[SituacaoLivro] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL,
	[Descricao] VARCHAR(180) NOT NULL,
	[Ativo] BIT NOT NULL,
	CONSTRAINT [PK_SituacaoLivro] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Livro] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[Titulo] VARCHAR(255) NOT NULL,
	[Sinopse] VARCHAR(255) NOT NULL,
	[Capa] VARCHAR(255) NOT NULL,
	[Ativo] BIT NOT NULL,
	[AutorId] INT NOT NULL,
	[GeneroId] INT NOT NULL,
	[SituacaoLivroId] INT NOT NULL,
	CONSTRAINT [PK_Livro] PRIMARY KEY ([Id] ASC),
	CONSTRAINT [FK_Livro_Autor] FOREIGN KEY ([AutorId]) REFERENCES [Autor]([Id]),
	CONSTRAINT [FK_Livro_Genero] FOREIGN KEY ([GeneroId]) REFERENCES [Genero]([Id]),
	CONSTRAINT [FK_Livro_SituacaoLivro] FOREIGN KEY ([SituacaoLivroId]) REFERENCES [SituacaoLivro]([Id])
)
GO

CREATE TABLE [dbo].[Emprestimo] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[DataEmprestimo] DATETIME NOT NULL,
	[DataVencimento] DATETIME NOT NULL,
	[DataDevolucao] DATETIME NULL,
	[LivroId] INT NOT NULL,
	[UsuarioId] INT NOT NULL,
	CONSTRAINT [PK_Emprestimo] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Emprestimo_Livro] FOREIGN KEY ([LivroId]) REFERENCES [Livro]([Id]),
	CONSTRAINT [FK_Emprestimo_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([id])
)
GO

CREATE TABLE [dbo].[Reserva] 
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AggregateId] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[DataReserva] DATETIME NOT NULL,
	[LivroId] INT NOT NULL,
	[UsuarioId] INT NOT NULL,
	CONSTRAINT [PK_Reserva] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Reserva_Livro] FOREIGN KEY ([LivroId]) REFERENCES [Livro]([Id]),
	CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([id])
)
GO