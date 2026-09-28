using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;

namespace CelySabores.Data.Repositories
{
    public class CardapioRepository : RepositorioBase
    {
        private const string ColunasPrato =
            "Id, CategoriaId, Nome, Descricao, Preco, Imagem, Disponivel, Ativo";

        public CardapioRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Categoria> ListarCategorias(bool apenasAtivas)
        {
            var sql = "SELECT Id, Nome, Ativo, Ordem FROM Categorias";
            if (apenasAtivas)
            {
                sql += " WHERE Ativo = 1";
            }
            sql += " ORDER BY Ordem, Nome";

            var tabela = Db.ExecuteDataTable(sql);
            var categorias = new List<Categoria>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                categorias.Add(new Categoria
                {
                    Id = Leitor.Int(linha, "Id"),
                    Nome = Leitor.String(linha, "Nome"),
                    Ativo = Leitor.Bool(linha, "Ativo"),
                    Ordem = Leitor.Int(linha, "Ordem")
                });
            }

            return categorias;
        }

        public IList<Prato> ListarPratos(int? categoriaId, bool apenasDisponiveis, bool apenasAtivos)
        {
            var sql =
                @"SELECT p.Id, p.CategoriaId, p.Nome, p.Descricao, p.Preco, p.Imagem,
                         p.Disponivel, p.Ativo, c.Nome AS CategoriaNome
                  FROM Pratos p
                  INNER JOIN Categorias c ON c.Id = p.CategoriaId
                  WHERE 1 = 1";

            if (categoriaId.HasValue)
            {
                sql += " AND p.CategoriaId = @CategoriaId";
            }
            if (apenasDisponiveis)
            {
                sql += " AND p.Disponivel = 1";
            }
            if (apenasAtivos)
            {
                sql += " AND p.Ativo = 1";
            }
            sql += " ORDER BY c.Ordem, p.Nome";

            var parametros = new List<SqlParameter>();
            if (categoriaId.HasValue)
            {
                parametros.Add(new SqlParameter("@CategoriaId", categoriaId.Value));
            }

            var tabela = Db.ExecuteDataTable(sql, parametros.ToArray());
            var pratos = new List<Prato>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                pratos.Add(new Prato
                {
                    Id = Leitor.Int(linha, "Id"),
                    CategoriaId = Leitor.Int(linha, "CategoriaId"),
                    Nome = Leitor.String(linha, "Nome"),
                    Descricao = Leitor.String(linha, "Descricao"),
                    Preco = Leitor.Decimal(linha, "Preco"),
                    Imagem = Leitor.String(linha, "Imagem"),
                    Disponivel = Leitor.Bool(linha, "Disponivel"),
                    Ativo = Leitor.Bool(linha, "Ativo"),
                    CategoriaNome = Leitor.String(linha, "CategoriaNome")
                });
            }

            return pratos;
        }

        public Prato ObterPrato(int id)
        {
            var sql =
                @"SELECT p.Id, p.CategoriaId, p.Nome, p.Descricao, p.Preco, p.Imagem,
                         p.Disponivel, p.Ativo, c.Nome AS CategoriaNome
                  FROM Pratos p
                  INNER JOIN Categorias c ON c.Id = p.CategoriaId
                  WHERE p.Id = @Id";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            var linha = tabela.Rows[0];
            return new Prato
            {
                Id = Leitor.Int(linha, "Id"),
                CategoriaId = Leitor.Int(linha, "CategoriaId"),
                Nome = Leitor.String(linha, "Nome"),
                Descricao = Leitor.String(linha, "Descricao"),
                Preco = Leitor.Decimal(linha, "Preco"),
                Imagem = Leitor.String(linha, "Imagem"),
                Disponivel = Leitor.Bool(linha, "Disponivel"),
                Ativo = Leitor.Bool(linha, "Ativo"),
                CategoriaNome = Leitor.String(linha, "CategoriaNome")
            };
        }

        public int InserirPrato(Prato prato)
        {
            const string sql =
                @"INSERT INTO Pratos (CategoriaId, Nome, Descricao, Preco, Imagem, Disponivel, Ativo)
                  VALUES (@CategoriaId, @Nome, @Descricao, @Preco, @Imagem, @Disponivel, @Ativo);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@CategoriaId", prato.CategoriaId),
                new SqlParameter("@Nome", prato.Nome),
                Nulo("@Descricao", prato.Descricao),
                new SqlParameter("@Preco", prato.Preco),
                Nulo("@Imagem", prato.Imagem),
                new SqlParameter("@Disponivel", prato.Disponivel),
                new SqlParameter("@Ativo", prato.Ativo));

            return System.Convert.ToInt32(id);
        }

        public void AtualizarPrato(Prato prato)
        {
            const string sql =
                @"UPDATE Pratos
                  SET CategoriaId = @CategoriaId,
                      Nome = @Nome,
                      Descricao = @Descricao,
                      Preco = @Preco,
                      Disponivel = @Disponivel
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@CategoriaId", prato.CategoriaId),
                new SqlParameter("@Nome", prato.Nome),
                Nulo("@Descricao", prato.Descricao),
                new SqlParameter("@Preco", prato.Preco),
                new SqlParameter("@Disponivel", prato.Disponivel),
                new SqlParameter("@Id", prato.Id));
        }

        public void AlterarDisponibilidade(int id, bool disponivel)
        {
            Db.ExecuteNonQuery(
                "UPDATE Pratos SET Disponivel = @Disponivel WHERE Id = @Id",
                new SqlParameter("@Disponivel", disponivel),
                new SqlParameter("@Id", id));
        }

        public void AlterarAtivoPrato(int id, bool ativo)
        {
            Db.ExecuteNonQuery(
                "UPDATE Pratos SET Ativo = @Ativo WHERE Id = @Id",
                new SqlParameter("@Ativo", ativo),
                new SqlParameter("@Id", id));
        }

        public int InserirCategoria(Categoria categoria)
        {
            const string sql =
                @"INSERT INTO Categorias (Nome, Ativo, Ordem)
                  VALUES (@Nome, @Ativo, @Ordem);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@Nome", categoria.Nome),
                new SqlParameter("@Ativo", categoria.Ativo),
                new SqlParameter("@Ordem", categoria.Ordem));

            return System.Convert.ToInt32(id);
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            const string sql =
                @"UPDATE Categorias SET Nome = @Nome, Ativo = @Ativo, Ordem = @Ordem WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@Nome", categoria.Nome),
                new SqlParameter("@Ativo", categoria.Ativo),
                new SqlParameter("@Ordem", categoria.Ordem),
                new SqlParameter("@Id", categoria.Id));
        }

        public bool CategoriaEmUso(int categoriaId)
        {
            var sql = "SELECT COUNT(*) FROM Pratos WHERE CategoriaId = @CategoriaId";
            return System.Convert.ToInt32(
                Db.ExecuteScalar(sql, new SqlParameter("@CategoriaId", categoriaId))) > 0;
        }

        public bool NomePratoJaExiste(string nome, int ignorarId)
        {
            var sql = "SELECT COUNT(*) FROM Pratos WHERE Nome = @Nome AND Id <> @IgnorarId";
            var total = System.Convert.ToInt32(Db.ExecuteScalar(sql,
                new SqlParameter("@Nome", nome),
                new SqlParameter("@IgnorarId", ignorarId)));

            return total > 0;
        }

        public string NomeCategoriaEmUso(string nome, int ignorarId)
        {
            var sql =
                "SELECT TOP 1 p.Nome FROM Pratos p WHERE p.CategoriaId IN " +
                "(SELECT Id FROM Categorias WHERE Nome = @Nome AND Id <> @IgnorarId)";
            var prato = Db.ExecuteScalar(sql,
                new SqlParameter("@Nome", nome),
                new SqlParameter("@IgnorarId", ignorarId));

            return prato == null ? null : System.Convert.ToString(prato);
        }
    }
}
