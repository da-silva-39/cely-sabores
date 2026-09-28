using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    public class MesaRepository : RepositorioBase
    {
        private const string Colunas =
            "Id, Numero, Capacidade, Estado, Ativo, Observacoes";

        public MesaRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Mesa> Listar(bool apenasAtivas)
        {
            var sql = "SELECT " + Colunas + " FROM Mesas";
            if (apenasAtivas)
            {
                sql += " WHERE Ativo = 1";
            }
            sql += " ORDER BY Numero";

            var tabela = Db.ExecuteDataTable(sql);
            var mesas = new List<Mesa>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                mesas.Add(Mapear(linha));
            }

            return mesas;
        }

        public Mesa ObterPorId(int id)
        {
            var sql = "SELECT " + Colunas + " FROM Mesas WHERE Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            return tabela.Rows.Count == 0 ? null : Mapear(tabela.Rows[0]);
        }

        public IList<Mesa> ListarPorEstado(EstadoMesa estado, bool apenasAtivas)
        {
            var sql = "SELECT " + Colunas + " FROM Mesas WHERE Estado = @Estado";
            if (apenasAtivas)
            {
                sql += " AND Ativo = 1";
            }

            sql += " ORDER BY Numero";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Estado", (int)estado));
            var mesas = new List<Mesa>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                mesas.Add(Mapear(linha));
            }

            return mesas;
        }

        public int Inserir(Mesa mesa)
        {
            const string sql =
                @"INSERT INTO Mesas (Numero, Capacidade, Estado, Ativo, Observacoes)
                  VALUES (@Numero, @Capacidade, @Estado, @Ativo, @Observacoes);
                  SELECT SCOPE_IDENTITY();";

            var id = Db.ExecuteScalar(sql,
                new SqlParameter("@Numero", mesa.Numero),
                new SqlParameter("@Capacidade", mesa.Capacidade),
                new SqlParameter("@Estado", (int)mesa.Estado),
                new SqlParameter("@Ativo", mesa.Ativo),
                Nulo("@Observacoes", mesa.Observacoes));

            return System.Convert.ToInt32(id);
        }

        public void Atualizar(Mesa mesa)
        {
            const string sql =
                @"UPDATE Mesas
                  SET Numero = @Numero,
                      Capacidade = @Capacidade,
                      Estado = @Estado,
                      Observacoes = @Observacoes
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@Numero", mesa.Numero),
                new SqlParameter("@Capacidade", mesa.Capacidade),
                new SqlParameter("@Estado", (int)mesa.Estado),
                Nulo("@Observacoes", mesa.Observacoes),
                new SqlParameter("@Id", mesa.Id));
        }

        public void AlterarEstado(int id, EstadoMesa estado)
        {
            Db.ExecuteNonQuery(
                "UPDATE Mesas SET Estado = @Estado WHERE Id = @Id",
                new SqlParameter("@Estado", (int)estado),
                new SqlParameter("@Id", id));
        }

        public void AlterarAtivo(int id, bool ativo)
        {
            Db.ExecuteNonQuery(
                "UPDATE Mesas SET Ativo = @Ativo WHERE Id = @Id",
                new SqlParameter("@Ativo", ativo),
                new SqlParameter("@Id", id));
        }

        public bool NumeroJaExiste(int numero, int ignorarId)
        {
            var sql =
                "SELECT COUNT(*) FROM Mesas WHERE Numero = @Numero AND Id <> @IgnorarId";
            var total = System.Convert.ToInt32(Db.ExecuteScalar(sql,
                new SqlParameter("@Numero", numero),
                new SqlParameter("@IgnorarId", ignorarId)));

            return total > 0;
        }

        public bool TemPedidoAberto(int mesaId)
        {
            var sql = "SELECT COUNT(*) FROM Pedidos WHERE MesaId = @MesaId AND Estado = 1";
            var total = System.Convert.ToInt32(Db.ExecuteScalar(sql, new SqlParameter("@MesaId", mesaId)));

            return total > 0;
        }

        private static Mesa Mapear(System.Data.DataRow linha)
        {
            return new Mesa
            {
                Id = Leitor.Int(linha, "Id"),
                Numero = Leitor.Int(linha, "Numero"),
                Capacidade = Leitor.Int(linha, "Capacidade"),
                Estado = (EstadoMesa)Leitor.Int(linha, "Estado"),
                Ativo = Leitor.Bool(linha, "Ativo"),
                Observacoes = Leitor.String(linha, "Observacoes")
            };
        }
    }
}
