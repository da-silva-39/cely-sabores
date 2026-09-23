-- =====================================================================
-- Cely Sabores - Script de criação do banco de dados (desenvolvimento)
-- Ambiente: SQL Server (desenvolvimento local)
-- Executar uma única vez: sqlcmd -S localhost -i CelySabores_Database.sql
-- =====================================================================

IF DB_ID(N'CelySabores') IS NULL
BEGIN
    CREATE DATABASE [CelySabores];
END
GO

USE [CelySabores];
GO

-- ---------------------------------------------------------------------
-- Funcionarios
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Funcionarios') IS NULL
BEGIN
    CREATE TABLE dbo.Funcionarios
    (
        Id           INT IDENTITY(1,1) NOT NULL,
        NomeCompleto NVARCHAR(120)     NOT NULL,
        Telefone     NVARCHAR(30)      NULL,
        Email        NVARCHAR(120)     NULL,
        Endereco     NVARCHAR(200)     NULL,
        Cargo        NVARCHAR(60)      NULL,
        DataCadastro DATETIME          NOT NULL CONSTRAINT DF_Funcionarios_DataCadastro DEFAULT (GETDATE()),
        Ativo        BIT               NOT NULL CONSTRAINT DF_Funcionarios_Ativo DEFAULT (1),
        Observacoes  NVARCHAR(300)     NULL,
        CONSTRAINT PK_Funcionarios PRIMARY KEY (Id)
    );
END
GO

-- ---------------------------------------------------------------------
-- Usuarios (conta de acesso / credenciais)
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Usuarios') IS NULL
BEGIN
    CREATE TABLE dbo.Usuarios
    (
        Id             INT IDENTITY(1,1) NOT NULL,
        FuncionarioId  INT               NOT NULL,
        Username       NVARCHAR(50)      NOT NULL,
        PasswordHash   NVARCHAR(300)     NOT NULL,
        Tipo           TINYINT           NOT NULL,
        Ativo          BIT               NOT NULL CONSTRAINT DF_Usuarios_Ativo DEFAULT (1),
        DataCriacao    DATETIME          NOT NULL CONSTRAINT DF_Usuarios_DataCriacao DEFAULT (GETDATE()),
        UltimoLogin    DATETIME          NULL,
        CONSTRAINT PK_Usuarios PRIMARY KEY (Id),
        CONSTRAINT UQ_Usuarios_Username UNIQUE (Username),
        CONSTRAINT UQ_Usuarios_Funcionario UNIQUE (FuncionarioId),
        CONSTRAINT FK_Usuarios_Funcionarios FOREIGN KEY (FuncionarioId)
            REFERENCES dbo.Funcionarios (Id),
        CONSTRAINT CK_Usuarios_Tipo CHECK (Tipo IN (1, 2))
    );
END
GO

-- ---------------------------------------------------------------------
-- Mesas
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Mesas') IS NULL
BEGIN
    CREATE TABLE dbo.Mesas
    (
        Id          INT IDENTITY(1,1) NOT NULL,
        Numero      INT            NOT NULL,
        Capacidade  INT            NOT NULL,
        Estado      TINYINT        NOT NULL CONSTRAINT DF_Mesas_Estado DEFAULT (0),
        Ativo       BIT            NOT NULL CONSTRAINT DF_Mesas_Ativo DEFAULT (1),
        Observacoes NVARCHAR(200)  NULL,
        CONSTRAINT PK_Mesas PRIMARY KEY (Id),
        CONSTRAINT UQ_Mesas_Numero UNIQUE (Numero),
        CONSTRAINT CK_Mesas_Capacidade CHECK (Capacidade > 0),
        CONSTRAINT CK_Mesas_Estado CHECK (Estado IN (0, 1, 2, 3, 4))
    );
END
GO

-- ---------------------------------------------------------------------
-- Categorias
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Categorias') IS NULL
BEGIN
    CREATE TABLE dbo.Categorias
    (
        Id    INT IDENTITY(1,1) NOT NULL,
        Nome  NVARCHAR(80)      NOT NULL,
        Ativo BIT               NOT NULL CONSTRAINT DF_Categorias_Ativo DEFAULT (1),
        Ordem INT               NOT NULL CONSTRAINT DF_Categorias_Ordem DEFAULT (0),
        CONSTRAINT PK_Categorias PRIMARY KEY (Id),
        CONSTRAINT UQ_Categorias_Nome UNIQUE (Nome)
    );
END
GO

-- ---------------------------------------------------------------------
-- Pratos
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Pratos') IS NULL
BEGIN
    CREATE TABLE dbo.Pratos
    (
        Id          INT IDENTITY(1,1) NOT NULL,
        CategoriaId INT               NOT NULL,
        Nome        NVARCHAR(120)     NOT NULL,
        Descricao   NVARCHAR(400)     NULL,
        Preco       DECIMAL(10,2)     NOT NULL,
        Imagem      NVARCHAR(260)     NULL,
        Disponivel  BIT               NOT NULL CONSTRAINT DF_Pratos_Disponivel DEFAULT (1),
        Ativo       BIT               NOT NULL CONSTRAINT DF_Pratos_Ativo DEFAULT (1),
        CONSTRAINT PK_Pratos PRIMARY KEY (Id),
        CONSTRAINT FK_Pratos_Categorias FOREIGN KEY (CategoriaId)
            REFERENCES dbo.Categorias (Id),
        CONSTRAINT CK_Pratos_Preco CHECK (Preco >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- Clientes
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Clientes') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes
    (
        Id          INT IDENTITY(1,1) NOT NULL,
        NomeCompleto NVARCHAR(120)    NOT NULL,
        Telefone    NVARCHAR(30)      NULL,
        Email       NVARCHAR(120)     NULL,
        Endereco    NVARCHAR(200)     NULL,
        Observacoes NVARCHAR(300)     NULL,
        DataCadastro DATETIME         NOT NULL CONSTRAINT DF_Clientes_DataCadastro DEFAULT (GETDATE()),
        CONSTRAINT PK_Clientes PRIMARY KEY (Id)
    );
END
GO

-- ---------------------------------------------------------------------
-- Reservas
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Reservas') IS NULL
BEGIN
    CREATE TABLE dbo.Reservas
    (
        Id             INT IDENTITY(1,1) NOT NULL,
        ClienteId      INT               NOT NULL,
        MesaId         INT               NULL,
        DataHora       DATETIME          NOT NULL,
        NumeroPessoas  INT               NOT NULL,
        Estado         TINYINT           NOT NULL CONSTRAINT DF_Reservas_Estado DEFAULT (0),
        Observacoes    NVARCHAR(300)     NULL,
        DataCriacao    DATETIME          NOT NULL CONSTRAINT DF_Reservas_DataCriacao DEFAULT (GETDATE()),
        CONSTRAINT PK_Reservas PRIMARY KEY (Id),
        CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (ClienteId)
            REFERENCES dbo.Clientes (Id),
        CONSTRAINT FK_Reservas_Mesas FOREIGN KEY (MesaId)
            REFERENCES dbo.Mesas (Id),
        CONSTRAINT CK_Reservas_Pessoas CHECK (NumeroPessoas > 0),
        CONSTRAINT CK_Reservas_Estado CHECK (Estado IN (0, 1, 2, 3, 4))
    );
END
GO

-- ---------------------------------------------------------------------
-- Pedidos
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Pedidos') IS NULL
BEGIN
    CREATE TABLE dbo.Pedidos
    (
        Id                       INT IDENTITY(1,1) NOT NULL,
        MesaId                   INT               NOT NULL,
        ClienteId                INT               NULL,
        FuncionarioAberturaId    INT               NOT NULL,
        DataAbertura             DATETIME          NOT NULL CONSTRAINT DF_Pedidos_DataAbertura DEFAULT (GETDATE()),
        Estado                   TINYINT           NOT NULL CONSTRAINT DF_Pedidos_Estado DEFAULT (1),
        ValorTotal               DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pedidos_ValorTotal DEFAULT (0),
        Observacao               NVARCHAR(400)     NULL,
        DataFechamento           DATETIME          NULL,
        FuncionarioFechamentoId  INT               NULL,
        CONSTRAINT PK_Pedidos PRIMARY KEY (Id),
        CONSTRAINT FK_Pedidos_Mesas FOREIGN KEY (MesaId)
            REFERENCES dbo.Mesas (Id),
        CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (ClienteId)
            REFERENCES dbo.Clientes (Id),
        CONSTRAINT FK_Pedidos_Funcionarios_Abertura FOREIGN KEY (FuncionarioAberturaId)
            REFERENCES dbo.Funcionarios (Id),
        CONSTRAINT FK_Pedidos_Funcionarios_Fechamento FOREIGN KEY (FuncionarioFechamentoId)
            REFERENCES dbo.Funcionarios (Id),
        CONSTRAINT CK_Pedidos_Estado CHECK (Estado IN (1, 2, 3)),
        CONSTRAINT CK_Pedidos_ValorTotal CHECK (ValorTotal >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- ItensPedido
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ItensPedido') IS NULL
BEGIN
    CREATE TABLE dbo.ItensPedido
    (
        Id            INT IDENTITY(1,1) NOT NULL,
        PedidoId      INT               NOT NULL,
        PratoId       INT               NOT NULL,
        Quantidade    INT               NOT NULL,
        PrecoUnitario DECIMAL(10,2)     NOT NULL,
        Subtotal      DECIMAL(10,2)     NOT NULL,
        Observacao    NVARCHAR(300)     NULL,
        CONSTRAINT PK_ItensPedido PRIMARY KEY (Id),
        CONSTRAINT FK_ItensPedido_Pedidos FOREIGN KEY (PedidoId)
            REFERENCES dbo.Pedidos (Id),
        CONSTRAINT FK_ItensPedido_Pratos FOREIGN KEY (PratoId)
            REFERENCES dbo.Pratos (Id),
        CONSTRAINT CK_ItensPedido_Quantidade CHECK (Quantidade > 0),
        CONSTRAINT CK_ItensPedido_PrecoUnitario CHECK (PrecoUnitario >= 0),
        CONSTRAINT CK_ItensPedido_Subtotal CHECK (Subtotal >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- Pagamentos (sem método de pagamento — apenas valores)
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Pagamentos') IS NULL
BEGIN
    CREATE TABLE dbo.Pagamentos
    (
        Id            INT IDENTITY(1,1) NOT NULL,
        PedidoId      INT               NOT NULL,
        ValorRecebido DECIMAL(10,2)     NOT NULL,
        Troco         DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pagamentos_Troco DEFAULT (0),
        DataPagamento DATETIME          NOT NULL CONSTRAINT DF_Pagamentos_DataPagamento DEFAULT (GETDATE()),
        FuncionarioId INT               NOT NULL,
        CONSTRAINT PK_Pagamentos PRIMARY KEY (Id),
        CONSTRAINT UQ_Pagamentos_Pedido UNIQUE (PedidoId),
        CONSTRAINT FK_Pagamentos_Pedidos FOREIGN KEY (PedidoId)
            REFERENCES dbo.Pedidos (Id),
        CONSTRAINT FK_Pagamentos_Funcionarios FOREIGN KEY (FuncionarioId)
            REFERENCES dbo.Funcionarios (Id),
        CONSTRAINT CK_Pagamentos_ValorRecebido CHECK (ValorRecebido >= 0),
        CONSTRAINT CK_Pagamentos_Troco CHECK (Troco >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- Ingredientes (produtos / matéria-prima)
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Ingredientes') IS NULL
BEGIN
    CREATE TABLE dbo.Ingredientes
    (
        Id                   INT IDENTITY(1,1) NOT NULL,
        Nome                 NVARCHAR(120)     NOT NULL,
        Unidade              NVARCHAR(20)      NOT NULL,
        QuantidadeDisponivel DECIMAL(12,3)     NOT NULL CONSTRAINT DF_Ingredientes_QuantidadeDisponivel DEFAULT (0),
        QuantidadeMinima     DECIMAL(12,3)     NOT NULL CONSTRAINT DF_Ingredientes_QuantidadeMinima DEFAULT (0),
        PrecoCusto           DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Ingredientes_PrecoCusto DEFAULT (0),
        Ativo                BIT               NOT NULL CONSTRAINT DF_Ingredientes_Ativo DEFAULT (1),
        CONSTRAINT PK_Ingredientes PRIMARY KEY (Id),
        CONSTRAINT UQ_Ingredientes_Nome UNIQUE (Nome),
        CONSTRAINT CK_Ingredientes_Quantidade CHECK (QuantidadeDisponivel >= 0),
        CONSTRAINT CK_Ingredientes_PrecoCusto CHECK (PrecoCusto >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- ReceitaPrato (relação prato <-> ingredientes)
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ReceitaPrato') IS NULL
BEGIN
    CREATE TABLE dbo.ReceitaPrato
    (
        Id            INT IDENTITY(1,1) NOT NULL,
        PratoId       INT               NOT NULL,
        IngredienteId INT               NOT NULL,
        Quantidade    DECIMAL(12,3)     NOT NULL,
        CONSTRAINT PK_ReceitaPrato PRIMARY KEY (Id),
        CONSTRAINT UQ_ReceitaPrato_PratoIngrediente UNIQUE (PratoId, IngredienteId),
        CONSTRAINT FK_ReceitaPrato_Pratos FOREIGN KEY (PratoId)
            REFERENCES dbo.Pratos (Id),
        CONSTRAINT FK_ReceitaPrato_Ingredientes FOREIGN KEY (IngredienteId)
            REFERENCES dbo.Ingredientes (Id),
        CONSTRAINT CK_ReceitaPrato_Quantidade CHECK (Quantidade > 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- MovimentosEstoque
-- ---------------------------------------------------------------------
IF OBJECT_ID(N'dbo.MovimentosEstoque') IS NULL
BEGIN
    CREATE TABLE dbo.MovimentosEstoque
    (
        Id            INT IDENTITY(1,1) NOT NULL,
        IngredienteId INT               NOT NULL,
        Tipo          TINYINT           NOT NULL,
        Quantidade    DECIMAL(12,3)     NOT NULL,
        Data          DATETIME          NOT NULL CONSTRAINT DF_MovimentosEstoque_Data DEFAULT (GETDATE()),
        Observacao    NVARCHAR(200)     NULL,
        PedidoId      INT               NULL,
        FuncionarioId INT               NULL,
        CONSTRAINT PK_MovimentosEstoque PRIMARY KEY (Id),
        CONSTRAINT FK_MovimentosEstoque_Ingredientes FOREIGN KEY (IngredienteId)
            REFERENCES dbo.Ingredientes (Id),
        CONSTRAINT FK_MovimentosEstoque_Pedidos FOREIGN KEY (PedidoId)
            REFERENCES dbo.Pedidos (Id),
        CONSTRAINT FK_MovimentosEstoque_Funcionarios FOREIGN KEY (FuncionarioId)
            REFERENCES dbo.Funcionarios (Id),
        CONSTRAINT CK_MovimentosEstoque_Tipo CHECK (Tipo IN (1, 2, 3)),
        CONSTRAINT CK_MovimentosEstoque_Quantidade CHECK (Quantidade >= 0)
    );
END
GO

-- ---------------------------------------------------------------------
-- Índices de apoio às consultas frequentes
-- ---------------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Funcionarios_Nome' AND object_id = OBJECT_ID(N'dbo.Funcionarios'))
    CREATE INDEX IX_Funcionarios_Nome ON dbo.Funcionarios (NomeCompleto);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Pratos_CategoriaId' AND object_id = OBJECT_ID(N'dbo.Pratos'))
    CREATE INDEX IX_Pratos_CategoriaId ON dbo.Pratos (CategoriaId);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Clientes_Nome' AND object_id = OBJECT_ID(N'dbo.Clientes'))
    CREATE INDEX IX_Clientes_Nome ON dbo.Clientes (NomeCompleto);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Reservas_DataHora_Estado' AND object_id = OBJECT_ID(N'dbo.Reservas'))
    CREATE INDEX IX_Reservas_DataHora_Estado ON dbo.Reservas (DataHora, Estado);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Reservas_MesaId_DataHora' AND object_id = OBJECT_ID(N'dbo.Reservas'))
    CREATE INDEX IX_Reservas_MesaId_DataHora ON dbo.Reservas (MesaId, DataHora);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Pedidos_DataAbertura' AND object_id = OBJECT_ID(N'dbo.Pedidos'))
    CREATE INDEX IX_Pedidos_DataAbertura ON dbo.Pedidos (DataAbertura);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Pedidos_MesaId_Estado' AND object_id = OBJECT_ID(N'dbo.Pedidos'))
    CREATE INDEX IX_Pedidos_MesaId_Estado ON dbo.Pedidos (MesaId, Estado);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_ItensPedido_PedidoId' AND object_id = OBJECT_ID(N'dbo.ItensPedido'))
    CREATE INDEX IX_ItensPedido_PedidoId ON dbo.ItensPedido (PedidoId);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Pagamentos_DataPagamento' AND object_id = OBJECT_ID(N'dbo.Pagamentos'))
    CREATE INDEX IX_Pagamentos_DataPagamento ON dbo.Pagamentos (DataPagamento);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_ReceitaPrato_PratoId' AND object_id = OBJECT_ID(N'dbo.ReceitaPrato'))
    CREATE INDEX IX_ReceitaPrato_PratoId ON dbo.ReceitaPrato (PratoId);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_MovimentosEstoque_IngredienteId_Data' AND object_id = OBJECT_ID(N'dbo.MovimentosEstoque'))
    CREATE INDEX IX_MovimentosEstoque_IngredienteId_Data ON dbo.MovimentosEstoque (IngredienteId, Data);

-- =====================================================================
-- DADOS INICIAIS (desenvolvimento)
-- =====================================================================

-- Mesas 1 a 20 ---------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Mesas)
BEGIN
    DECLARE @numero INT = 1;
    WHILE @numero <= 20
    BEGIN
        DECLARE @capacidade INT = CASE
                                      WHEN @numero % 4 = 0 THEN 8
                                      WHEN @numero % 2 = 0 THEN 6
                                      ELSE 4
                                  END;
        INSERT INTO dbo.Mesas (Numero, Capacidade) VALUES (@numero, @capacidade);
        SET @numero = @numero + 1;
    END
END
GO

-- Categorias -----------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Categorias)
BEGIN
    INSERT INTO dbo.Categorias (Nome, Ativo, Ordem) VALUES
        (N'Entradas', 1, 1),
        (N'Pratos principais', 1, 2),
        (N'Grelhados', 1, 3),
        (N'Massas', 1, 4),
        (N'Saladas', 1, 5),
        (N'Sobremesas', 1, 6),
        (N'Bebidas', 1, 7);
END
GO

-- Pratos de exemplo ----------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Pratos)
BEGIN
    INSERT INTO dbo.Pratos (CategoriaId, Nome, Descricao, Preco, Disponivel, Ativo)
    SELECT c.Id, p.Nome, p.Descricao, p.Preco, 1, 1
    FROM (VALUES
        (N'Entradas',          N'Camarão Grelhado', N'Camarão temperado na brasa', 250.00),
        (N'Entradas',          N'Rissóis',           N'Rissóis de camarão fritos', 150.00),
        (N'Pratos principais', N'Frango Grelhado',   N'Frango grelhado com arroz e salada', 350.00),
        (N'Pratos principais', N'Matapa com Caranguejo', N'Matapa de amendoim com caranguejo', 400.00),
        (N'Pratos principais', N'Arroz de Marisco',  N'Arroz com marisco e mexilhão', 450.00),
        (N'Pratos principais', N'Chanfana',          N'Chanfana de cabrito cozinhada ao vinho', 320.00),
        (N'Grelhados',         N'Espetada Mista',    N'Espetada de carne e frango na brasa', 380.00),
        (N'Grelhados',         N'Churrasco Misto',   N'Churrasco misto acompanhado de batata', 500.00),
        (N'Massas',            N'Esparguete à Bolonhesa', N'Esparguete com molho de carne', 280.00),
        (N'Massas',            N'Lasanha de Carne',  N'Lasanha de carne gratinada', 340.00),
        (N'Saladas',           N'Salada César',      N'Salada César com frango grelhado', 220.00),
        (N'Sobremesas',        N'Pudim',             N'Pudim de leite caseiro', 110.00),
        (N'Sobremesas',        N'Salada de Frutas',  N'Frutas frescas da época', 90.00),
        (N'Bebidas',           N'Coca-Cola',         N'Lata 33cl', 80.00),
        (N'Bebidas',           N'Água Mineral',      N'Garrafa 50cl', 60.00),
        (N'Bebidas',           N'Sumo Natural',      N'Sumo de fruta natural 33cl', 120.00)
    ) AS p(Categoria, Nome, Descricao, Preco)
    INNER JOIN dbo.Categorias c ON c.Nome = p.Categoria;
END
GO

-- Ingredientes e receitas ----------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Ingredientes)
BEGIN
    INSERT INTO dbo.Ingredientes (Nome, Unidade, QuantidadeDisponivel, QuantidadeMinima, PrecoCusto, Ativo) VALUES
        (N'Frango',      N'kg', 20.000, 5.000, 120.00, 1),
        (N'Arroz',       N'kg', 50.000, 10.000, 60.00, 1),
        (N'Salada',      N'un', 40.000, 10.000, 25.00, 1),
        (N'Tomate',      N'kg', 30.000, 5.000, 45.00, 1),
        (N'Cebola',      N'kg', 30.000, 5.000, 30.00, 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.ReceitaPrato)
BEGIN
    INSERT INTO dbo.ReceitaPrato (PratoId, IngredienteId, Quantidade)
    SELECT pr.Id, i.Id, r.Quantidade
    FROM (VALUES
        (N'Frango Grelhado', N'Frango', 0.250),
        (N'Frango Grelhado', N'Arroz', 0.200),
        (N'Frango Grelhado', N'Salada', 1.000),
        (N'Frango Grelhado', N'Tomate', 0.050),
        (N'Frango Grelhado', N'Cebola', 0.030)
    ) AS r(Prato, Ingrediente, Quantidade)
    INNER JOIN dbo.Pratos pr ON pr.Nome = r.Prato
    INNER JOIN dbo.Ingredientes i ON i.Nome = r.Ingrediente;
END
GO

-- Movimentos de entrada do estoque inicial ------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.MovimentosEstoque)
BEGIN
    INSERT INTO dbo.MovimentosEstoque (IngredienteId, Tipo, Quantidade, Observacao)
    SELECT i.Id, 1, i.QuantidadeDisponivel, N'Stock inicial (seed)'
    FROM dbo.Ingredientes i;
END
GO

-- Funcionários e utilizadores de acesso --------------------------------
-- Senha padrão: 123456 (trocar no primeiro uso, em produção)
IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios)
BEGIN
    DECLARE @idGerente INT, @idFuncionario INT;

    INSERT INTO dbo.Funcionarios (NomeCompleto, Telefone, Email, Cargo, Observacoes)
    VALUES (N'Administrador Cely Sabores', N'+258 82 000 0000', N'gerente@celysabores.com', N'Gerente geral', N'Conta administradora criada no seed de desenvolvimento');

    SET @idGerente = SCOPE_IDENTITY();

    INSERT INTO dbo.Funcionarios (NomeCompleto, Telefone, Email, Cargo, Observacoes)
    VALUES (N'Funcionário Teste', N'+258 82 000 0001', N'func@celysabores.com', N'Atendente', N'Conta de teste para desenvolvimento');

    SET @idFuncionario = SCOPE_IDENTITY();

    INSERT INTO dbo.Usuarios (FuncionarioId, Username, PasswordHash, Tipo, Ativo) VALUES
        (@idGerente, N'gerente', N'100000:Q2VseVNhYm9yZXNTM2VkMTU=:vyJbMewQhBhx92Iq3vNe4o0ZAUBfdA0l0XsygQdaTuU=', 1, 1),
        (@idFuncionario, N'func', N'100000:Q2VseVNhYm9yZXNTM2VkMjE=:B5W0QWKExTHkK9aXMcKSrQmnoJs/Frfx31wytextl6I=', 2, 1);
END
GO

-- Cliente(s) de exemplo -------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes)
BEGIN
    INSERT INTO dbo.Clientes (NomeCompleto, Telefone, Email, Endereco, Observacoes) VALUES
        (N'Cliente Exemplo', N'+258 84 000 0000', N'cliente@exemplo.com', N'Maputo', NULL);
END
GO

PRINT N'Banco CelySabores criado/atualizado com sucesso.';
GO