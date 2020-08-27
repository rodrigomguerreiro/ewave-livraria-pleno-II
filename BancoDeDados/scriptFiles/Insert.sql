USE [ToDo];

DECLARE @AggregateId UNIQUEIDENTIFIER;
 SET @AggregateId = NEWID();

INSERT INTO [dbo].[Endereco]([Logradouro], [Bairro],[Complemento], [Numero]) VALUES
('Av. B' , 'Cristo Rei', 'Anexo 1', 52),
('Av. Beira Rio' , 'JD Unic', 'Anexo 2', 100),
('Av. Feb' , 'Alameda', 'BL A', 172),
('Av. Italia' , 'JD Italia', 'Casa', 50)
GO

INSERT INTO [dbo].[InstituicaoEnsino]([AggregateId], [Nome], [Cnpj], [Telefone], [Ativo], [EnderecoId]) VALUES
(NEWID(), 'Univag', 19702134000182, 30265050, 1 , 1),
(NEWID(), 'UFMT', 19502133307785, 30000000, 1 , 2)
GO

INSERT INTO [dbo].[Usuario]([AggregateId], [Nome], [Cpf], [Telefone], [Email], [Ativo], [EnderecoId], [InstituicaoEnsinoId]) VALUES
(NEWID(), 'Rodrigo', 01701254188, 65984098820, 'rodrigomguerreiro@outlook.com', 1, 3, 1),
(NEWID(), 'Jhon Doe', 02965247855, 65981105563, 'jhondoe@todo.com' , 1, 4, 2)
GO

INSERT INTO [dbo].[Autor]([AggregateId], [Nome], [Ativo]) VALUES
(NEWID(), 'J. R. R. Tolkien', 1),
(NEWID(), 'Terry Brooks', 1),
(NEWID(), 'Dan Brown', 1),
(NEWID(), 'Sun Tzu', 1)
GO

INSERT INTO [dbo].[Genero]([AggregateId], [Descricao], [Ativo]) VALUES
(NEWID(), 'Literatura fantástica', 1),
(NEWID(), 'Ficção científica', 1),
(NEWID(), 'Tratado, Não ficção', 1)
GO

INSERT INTO [dbo].[SituacaoLivro]([AggregateId], [Descricao], [Ativo]) VALUES
(NEWID(), 'Emprestado', 1),
(NEWID(), 'Disponível', 1)
GO

INSERT INTO [dbo].[Livro]([AggregateId], [Titulo], [Sinopse], [Capa], [Ativo], [AutorId], [GeneroId], [SituacaoLivroId]) VALUES
(NEWID(), 'Star Wars Episódio I: A Ameaça Fantasma', 'O livro Star Wars Episódio I: A Ameaça Fantasma é a romantização do filme do mesmo nome.', '', 1, 2, 2, 1),
(NEWID(), 'O Senhor dos Anéis', 'Escrita entre 1937 e 1949, com muitas partes criadas durante a Segunda Guerra Mundial, a saga é uma continuação de O Hobbit.', '', 1, 1, 1, 2),
(NEWID(), 'Fortaleza Digital', 'Fortaleza Digital de Dan Brown é o primeiro livro do escritor estadunidense, anterior aos best-sellers O Código da Vinci e a Anjos e Demônios.', '', 1, 3, 2, 2),
(NEWID(), 'A Arte da Guerra', 'A Arte da Guerra, é um tratado militar escrito durante o século IV a.C. pelo estrategista conhecido como Sun Tzu.', '', 1, 4, 3, 2)
GO

INSERT INTO [dbo].[Emprestimo]([AggregateId], [DataEmprestimo], [DataVencimento], [DataDevolucao], [LivroId], [UsuarioId]) VALUES
(NEWID(), '2020-07-20T22:45:59.727', '2020-08-19T22:45:59.727', NULL, 1, 2)
GO