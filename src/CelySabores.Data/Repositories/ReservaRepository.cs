using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    public class ReservaRepository : RepositorioBase
    {
        private const string Colunas =
            @"r.Id, r.ClienteId, r.MesaId, r.DataHora, r.NumeroPessoas, r.Estado,
              r.Observacoes, r.DataCriacao,
              c.NomeCompleto AS ClienteNome, c.Telefone AS ClienteTelefone,
              m.Numero AS MesaNumero";

        private const string From =
            @"FROM Reservas r
              INNER JOIN Clientes c ON c.Id = r.ClienteId
              LEFT JOIN Mesas m ON m.Id = r.MesaId";

        public ReservaRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public IList<Reserva> Listar(DateTime? de, DateTime? ate, EstadoReserva? estado)
        {
            var sql = "SELECT " + Colunas + " " + From + " WHERE 1 = 1";
            var parametros = new List<SqlParameter>();

            if (de.HasValue)
            {
                sql += " AND r.DataHora >= @De";
                parametros.Add(new SqlParameter("@De", de.Value));
            }

            if (ate.HasValue)
            {
                sql += " AND r.DataHora <= @Ate";
                parametros.Add(new SqlParameter("@Ate", ate.Value));
            }

            if (estado.HasValue)
            {
                sql += " AND r.Estado = @Estado";
                parametros.Add(new SqlParameter("@Estado", (int)estado.Value));
            }

            sql += " ORDER BY r.DataHora";

            var tabela = Db.ExecuteDataTable(sql, parametros.ToArray());
            var reservas = new List<Reserva>();

            foreach (System.Data.DataRow linha in tabela.Rows)
            {
                reservas.Add(Mapear(linha));
            }

            return reservas;
        }

        public Reserva ObterPorId(int id)
        {
            var sql = "SELECT " + Colunas + " " + From + " WHERE r.Id = @Id";
            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            return tabela.Rows.Count == 0 ? null : Mapear(tabela.Rows[0]);
        }

        public int Inserir(Reserva reserva)
        {
            const string sql =
                @"INSERT INTO Reservas (ClienteId, MesaId, DataHora, NumeroPessoas, Estado, Observacoes)
                  VALUES (@ClienteId, @MesaId, @DataHora, @NumeroPessoas, @Estado, @Observacoes);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return System.Convert.ToInt32(Db.ExecuteScalar(sql,
                new SqlParameter("@ClienteId", reserva.ClienteId),
                Nulo("@MesaId", reserva.MesaId),
                new SqlParameter("@DataHora", reserva.DataHora),
                new SqlParameter("@NumeroPessoas", reserva.NumeroPessoas),
                new SqlParameter("@Estado", (int)reserva.Estado),
                Nulo("@Observacoes", reserva.Observacoes)));
        }

        public void Atualizar(Reserva reserva)
        {
            const string sql =
                @"UPDATE Reservas
                  SET ClienteId = @ClienteId,
                      MesaId = @MesaId,
                      DataHora = @DataHora,
                      NumeroPessoas = @NumeroPessoas,
                      Observacoes = @Observacoes
                  WHERE Id = @Id";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@ClienteId", reserva.ClienteId),
                Nulo("@MesaId", reserva.MesaId),
                new SqlParameter("@DataHora", reserva.DataHora),
                new SqlParameter("@NumeroPessoas", reserva.NumeroPessoas),
                Nulo("@Observacoes", reserva.Observacoes),
                new SqlParameter("@Id", reserva.Id));
        }

        public void AlterarEstado(int id, EstadoReserva estado)
        {
            Db.ExecuteNonQuery(
                "UPDATE Reservas SET Estado = @Estado WHERE Id = @Id",
                new SqlParameter("@Estado", (int)estado),
                new SqlParameter("@Id", id));
        }

        /// <summary>
        /// Reservas activas (pendentes/confirmadas/em atendimento) da mesma mesa que
        /// contenham o instante informado. Janela de 2 horas para tolerar antecedencia.
        /// </summary>
        public bool MesaOcupadaNoHorario(int mesaId, DateTime dataHora)
        {
            const string sql =
                @"SELECT COUNT(*) FROM Reservas
                  WHERE MesaId = @MesaId
                    AND Estado IN (0, 1, 2)
                    AND DataHora BETWEEN @Inicio AND @Fim";

            var total = System.Convert.ToInt32(Db.ExecuteScalar(sql,
                new SqlParameter("@MesaId", mesaId),
                new SqlParameter("@Inicio", dataHora.AddHours(-2)),
                new SqlParameter("@Fim", dataHora.AddHours(2))));

            return total > 0;
        }

        public int ContarNoDia(DateTime dia)
        {
            var sql =
                @"SELECT COUNT(*) FROM Reservas
                  WHERE DataHora >= @Inicio AND DataHora < @Fim
                    AND Estado IN (0, 1, 2, 3)";

            return System.Convert.ToInt32(Db.ExecuteScalar(sql,
                new SqlParameter("@Inicio", dia.Date),
                new SqlParameter("@Fim", dia.Date.AddDays(1))));
        }

        private static Reserva Mapear(System.Data.DataRow linha)
        {
            return new Reserva
            {
                Id = Leitor.Int(linha, "Id"),
                ClienteId = Leitor.Int(linha, "ClienteId"),
                MesaId = Leitor.IntNulo(linha, "MesaId"),
                DataHora = Leitor.DateTime(linha, "DataHora"),
                NumeroPessoas = Leitor.Int(linha, "NumeroPessoas"),
                Estado = (EstadoReserva)Leitor.Int(linha, "Estado"),
                Observacoes = Leitor.String(linha, "Observacoes"),
                DataCriacao = Leitor.DateTime(linha, "DataCriacao"),
                ClienteNome = Leitor.String(linha, "ClienteNome"),
                ClienteTelefone = Leitor.String(linha, "ClienteTelefone"),
                MesaNumero = Leitor.IntNulo(linha, "MesaNumero")
            };
        }
    }
}
