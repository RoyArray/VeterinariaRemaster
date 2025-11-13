using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster.Data
{
    public class MascotaDAO
    {
        public List<Mascota> Listar()
        {
            var lista = new List<Mascota>();
            string sql = "SELECT * FROM VT_MASCOTAS";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Mapear(dr));
                    }
                }
            }

            return lista;
        }

        private Mascota Mapear(SqlDataReader dr)
        {
            return new Mascota
            {
                MasId = (int)dr["MAS_ID"],
                Nombre = dr["MAS_NOMBRE"].ToString(),
                FechaNacimiento = (DateTime)dr["MAS_FECHA_NACIMIENTO"],
                Sexo = dr["MAS_SEXO"].ToString(),
                Peso = (decimal)dr["MAS_PESO"],
                Alergias = dr["MAS_ALERGIAS"] == DBNull.Value ? null : dr["MAS_ALERGIAS"].ToString(),
                ProId = (int)dr["MAS_PRO_ID"]
            };
        }

        public Mascota ObtenerPorId(int id)
        {
            Mascota resultado = null;
            string sql = "SELECT * FROM VT_MASCOTAS WHERE MAS_ID = @Id";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        resultado = Mapear(dr);
                    }
                }
            }

            return resultado;
        }

        public int? BuscarMascotaIdPorPropietarioYNombre(int idPro, string nombre)
        {
            string sql = @"
                SELECT MAS_ID
                FROM VT_MASCOTAS
                WHERE MAS_PRO_ID = @ProId
                  AND MAS_NOMBRE = @Nombre";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProId", idPro);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }

            return null;
        }

        public void Insertar(Mascota mascota)
        {
            string sql = @"
                INSERT INTO VT_MASCOTAS
                (MAS_NOMBRE, MAS_FECHA_NACIMIENTO, MAS_SEXO, MAS_PESO, MAS_ALERGIAS,
                 MAS_PRO_ID, MAS_ADICIONADO_POR, MAS_FECHA_ADICION)
                VALUES
                (@Nombre, @FechaNacimiento, @Sexo, @Peso, @Alergias,
                 @ProId, @AdicionadoPor, @FechaAdicion)";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", mascota.Sexo);
                cmd.Parameters.AddWithValue("@Peso", mascota.Peso);
                cmd.Parameters.AddWithValue("@Alergias", (object)mascota.Alergias ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ProId", mascota.ProId);
                cmd.Parameters.AddWithValue("@AdicionadoPor", mascota.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", mascota.FechaAdicion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Mascota mascota)
        {
            string sql = @"
                UPDATE VT_MASCOTAS
                SET MAS_NOMBRE = @Nombre,
                    MAS_FECHA_NACIMIENTO = @FechaNacimiento,
                    MAS_SEXO = @Sexo,
                    MAS_PESO = @Peso,
                    MAS_ALERGIAS = @Alergias,
                    MAS_MODIFICADO_POR = @ModificadoPor,
                    MAS_FECHA_MODIFICACION = @FechaModificacion
                WHERE MAS_ID = @Id";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", mascota.MasId);
                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", mascota.Sexo);
                cmd.Parameters.AddWithValue("@Peso", mascota.Peso);
                cmd.Parameters.AddWithValue("@Alergias", (object)mascota.Alergias ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ModificadoPor", (object)mascota.ModificadoPor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaModificacion", (object)mascota.FechaModificacion ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM VT_MASCOTAS WHERE MAS_ID = @Id";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
