using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;

namespace CelySabores.Data.Repositories
{
    public class FuncionarioRepository : RepositorioBase
    {
        private const string Colunas =
            "Id, NomeCompleto, Telefone, Email, Endereco, Cargo, DataCadastro, Ativo, Observacoes";

        public FuncionarioRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Funcionario> Listar(bool apenasAtivos)
        {
            var sql = "SELECT " + Colunas + " FROM Funcionarios";
            if (apenasAtivos)
            {
                sql += " WHERE Ativo = 1";
            }
            sql += " ORDER BY NomeCompleto";

            var tabela = Db.ExecuteDataTable(sql);
            var funcionarios = new List<Funcionario>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                funcionarios.Add(Mapear(linha));
            }

            return funcionarios;
        }

        public Funcionario ObterPorId(int id)
        {
            var sql = "SELECT " + Colunas + " FROM Funcionarios WHERE Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            return Mapear(tabela.Rows[0]);
        }

        public int Inserir(Funcionario funcionario)
        {
            const string sql =
                @"INSERT INTO Funcionarios (NomeCompleto, Telefone, Email, Endereco, Cargo, Observacoes, Ativo)
                  VALUES (@NomeCompleto, @Telefone, @Email, @Endereco, @Cargo, @Observacoes, @Ativo);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@NomeCompleto", funcionario.NomeCompleto),
                ObterOuNulo("@Telefone", funcionario.Telefone),
                ObterOuNulo("@Email", funcionario.Email),
                ObterOuNulo("@Endereco", funcionario.Endereco),
                ObterOuNulo("@Cargo", funcionario.Cargo),
                ObterOuNulo("@Observacoes", funcionario.Observacoes),
                new SqlParameter("@Ativo", funcionario.Ativo));

            return System.Convert.ToInt32(id);
        }

        public void Atualizar(Funcionario funcionario)
        {
            const string sql =
                @"UPDATE Funcionarios
                  SET NomeCompleto = @NomeCompleto,
                      Telefone = @Telefone,
                      Email = @Email,
                      Endereco = @Endereco,
                      Cargo = @Cargo,
                      Observacoes = @Observacoes
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@NomeCompleto", funcionario.NomeCompleto),
                ObterOuNulo("@Telefone", funcionario.Telefone),
                ObterOuNulo("@Email", funcionario.Email),
                ObterOuNulo("@Endereco", funcionario.Endereco),
                ObterOuNulo("@Cargo", funcionario.Cargo),
                ObterOuNulo("@Observacoes", funcionario.Observacoes),
                new SqlParameter("@Id", funcionario.Id));
        }

        public void AlterarAtivo(int id, bool ativo)
        {
            Db.ExecuteNonQuery(
                "UPDATE Funcionarios SET Ativo = @Ativo WHERE Id = @Id",
                new SqlParameter("@Ativo", ativo),
                new SqlParameter("@Id", id));
        }

        private static SqlParameter ObterOuNulo(string nome, string valor)
        {
            return new SqlParameter(nome, (object)valor ?? System.DBNull.Value);
        }

        private static Funcionario Mapear(System.Data.DataRow linha)
        {
            return new Funcionario
            {
                Id = Leitor.Int(linha, "Id"),
                NomeCompleto = Leitor.String(linha, "NomeCompleto"),
                Telefone = Leitor.String(linha, "Telefone"),
                Email = Leitor.String(linha, "Email"),
                Endereco = Leitor.String(linha, "Endereco"),
                Cargo = Leitor.String(linha, "Cargo"),
                DataCadastro = Leitor.DateTime(linha, "DataCadastro"),
                Ativo = Leitor.Bool(linha, "Ativo"),
                Observacoes = Leitor.String(linha, "Observacoes")
            };
        }
    }
}