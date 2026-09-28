using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;

namespace CelySabores.Data.Repositories
{
    public class ClienteRepository : RepositorioBase
    {
        private const string Colunas =
            "Id, NomeCompleto, Telefone, Email, Endereco, Observacoes, DataCadastro";

        public ClienteRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Cliente> Listar(string pesquisa)
        {
            var sql = "SELECT " + Colunas + " FROM Clientes";
            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                sql += " WHERE NomeCompleto LIKE @Pesquisa OR ISNULL(Telefone, '') LIKE @Pesquisa"
                       + " OR ISNULL(Email, '') LIKE @Pesquisa";
            }
            sql += " ORDER BY NomeCompleto";

            var parametros = string.IsNullOrWhiteSpace(pesquisa)
                ? new SqlParameter[0]
                : new[] { new SqlParameter("@Pesquisa", "%" + pesquisa.Trim() + "%") };

            var tabela = Db.ExecuteDataTable(sql, parametros);
            var clientes = new List<Cliente>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                clientes.Add(Mapear(linha));
            }

            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            var sql = "SELECT " + Colunas + " FROM Clientes WHERE Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            return tabela.Rows.Count == 0 ? null : Mapear(tabela.Rows[0]);
        }

        public int Inserir(Cliente cliente)
        {
            const string sql =
                @"INSERT INTO Clientes (NomeCompleto, Telefone, Email, Endereco, Observacoes)
                  VALUES (@NomeCompleto, @Telefone, @Email, @Endereco, @Observacoes);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@NomeCompleto", cliente.NomeCompleto),
                Nulo("@Telefone", cliente.Telefone),
                Nulo("@Email", cliente.Email),
                Nulo("@Endereco", cliente.Endereco),
                Nulo("@Observacoes", cliente.Observacoes));

            return System.Convert.ToInt32(id);
        }

        public void Atualizar(Cliente cliente)
        {
            const string sql =
                @"UPDATE Clientes
                  SET NomeCompleto = @NomeCompleto,
                      Telefone = @Telefone,
                      Email = @Email,
                      Endereco = @Endereco,
                      Observacoes = @Observacoes
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@NomeCompleto", cliente.NomeCompleto),
                Nulo("@Telefone", cliente.Telefone),
                Nulo("@Email", cliente.Email),
                Nulo("@Endereco", cliente.Endereco),
                Nulo("@Observacoes", cliente.Observacoes),
                new SqlParameter("@Id", cliente.Id));
        }

        public int ContarPedidos(int clienteId)
        {
            var sql = "SELECT COUNT(*) FROM Pedidos WHERE ClienteId = @ClienteId";
            return System.Convert.ToInt32(
                Db.ExecuteScalar(sql, new SqlParameter("@ClienteId", clienteId)));
        }

        private static Cliente Mapear(System.Data.DataRow linha)
        {
            return new Cliente
            {
                Id = Leitor.Int(linha, "Id"),
                NomeCompleto = Leitor.String(linha, "NomeCompleto"),
                Telefone = Leitor.String(linha, "Telefone"),
                Email = Leitor.String(linha, "Email"),
                Endereco = Leitor.String(linha, "Endereco"),
                Observacoes = Leitor.String(linha, "Observacoes"),
                DataCadastro = Leitor.DateTime(linha, "DataCadastro")
            };
        }
    }
}
