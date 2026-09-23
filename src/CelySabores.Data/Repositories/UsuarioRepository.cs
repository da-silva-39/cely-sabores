using System;
using System.Data;
using System.Data.SqlClient;
using CelySabores.Data.Database;
using CelySabores.Models.Entities;
using CelySabores.Models.Enums;

namespace CelySabores.Data.Repositories
{
    public class UsuarioRepository : RepositorioBase
    {
        public UsuarioRepository(CommandHelper commandHelper) : base(commandHelper)
        {
        }

        public Usuario ObterPorUsername(string username)
        {
            const string sql =
                @"SELECT u.Id, u.FuncionarioId, u.Username, u.PasswordHash, u.Tipo, u.Ativo,
                         u.DataCriacao, u.UltimoLogin, f.NomeCompleto AS NomeFuncionario, f.Cargo
                  FROM Usuarios u
                  INNER JOIN Funcionarios f ON f.Id = u.FuncionarioId
                  WHERE u.Username = @Username";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Username", username.Trim()));

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            return Mapear(tabela.Rows[0]);
        }

        public Usuario ObterPorId(int id)
        {
            const string sql =
                @"SELECT u.Id, u.FuncionarioId, u.Username, u.PasswordHash, u.Tipo, u.Ativo,
                         u.DataCriacao, u.UltimoLogin, f.NomeCompleto AS NomeFuncionario, f.Cargo
                  FROM Usuarios u
                  INNER JOIN Funcionarios f ON f.Id = u.FuncionarioId
                  WHERE u.Id = @Id";

            var tabela = Db.ExecuteDataTable(sql, new SqlParameter("@Id", id));

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            return Mapear(tabela.Rows[0]);
        }

        public void Inserir(Usuario usuario)
        {
            const string sql =
                @"INSERT INTO Usuarios (FuncionarioId, Username, PasswordHash, Tipo, Ativo)
                  VALUES (@FuncionarioId, @Username, @PasswordHash, @Tipo, @Ativo)";

            Db.ExecuteNonQuery(sql,
                new SqlParameter("@FuncionarioId", usuario.FuncionarioId),
                new SqlParameter("@Username", usuario.Username.Trim()),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Tipo", (int)usuario.Tipo),
                new SqlParameter("@Ativo", usuario.Ativo));
        }

        public void AtualizarSenha(int id, string passwordHash)
        {
            Db.ExecuteNonQuery(
                "UPDATE Usuarios SET PasswordHash = @PasswordHash WHERE Id = @Id",
                new SqlParameter("@PasswordHash", passwordHash),
                new SqlParameter("@Id", id));
        }

        public void AlterarTipo(int id, TipoUsuario tipo)
        {
            Db.ExecuteNonQuery(
                "UPDATE Usuarios SET Tipo = @Tipo WHERE Id = @Id",
                new SqlParameter("@Tipo", (int)tipo),
                new SqlParameter("@Id", id));
        }

        public void AlterarAtivo(int id, bool ativo)
        {
            Db.ExecuteNonQuery(
                "UPDATE Usuarios SET Ativo = @Ativo WHERE Id = @Id",
                new SqlParameter("@Ativo", ativo),
                new SqlParameter("@Id", id));
        }

        public void AlterarUsername(int id, string username)
        {
            Db.ExecuteNonQuery(
                "UPDATE Usuarios SET Username = @Username WHERE Id = @Id",
                new SqlParameter("@Username", username.Trim()),
                new SqlParameter("@Id", id));
        }

        public void AtualizarUltimoLogin(int id)
        {
            Db.ExecuteNonQuery(
                "UPDATE Usuarios SET UltimoLogin = @UltimoLogin WHERE Id = @Id",
                new SqlParameter("@UltimoLogin", DateTime.Now),
                new SqlParameter("@Id", id));
        }

        private static Usuario Mapear(DataRow linha)
        {
            return new Usuario
            {
                Id = Leitor.Int(linha, "Id"),
                FuncionarioId = Leitor.Int(linha, "FuncionarioId"),
                Username = Leitor.String(linha, "Username"),
                PasswordHash = Leitor.String(linha, "PasswordHash"),
                Tipo = (TipoUsuario)Leitor.Int(linha, "Tipo"),
                Ativo = Leitor.Bool(linha, "Ativo"),
                DataCriacao = Leitor.DateTime(linha, "DataCriacao"),
                UltimoLogin = Leitor.DateTimeNulo(linha, "UltimoLogin"),
                NomeFuncionario = Leitor.String(linha, "NomeFuncionario")
            };
        }
    }
}