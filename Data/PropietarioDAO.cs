using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster.Data
{
    public class PropietarioDAO
    {
        public List<Propietario> Listar()
        {
            var lista = new List<Propietario>();

            string sql = "SELECT * FROM VT_PROPIETARIOS";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Propietario
                        {
                            ProId = (int)dr["PRO_ID"],
                            NumeroIdentificacion = dr["PRO_IDENTIFICACION"].ToString(),
                            PrimerNombre = dr["PRO_PRIMER_NOMBRE"].ToString(),
                            SegundoNombre = dr["PRO_SEGUNDO_NOMBRE"].ToString(),
                            PrimerApellido = dr["PRO_PRIMER_APELLIDO"].ToString(),
                            SegundoApellido = dr["PRO_SEGUNDO_APELLIDO"].ToString(),
                            TelefonoCelular = dr["PRO_TELEFONO"].ToString(),
                            CorreoElectronico = dr["PRO_CORREO"].ToString(),
                            AdicionadoPor = dr["PRO_ADICIONADO_POR"].ToString(),
                            FechaAdicion = (DateTime)dr["PRO_FECHA_ADICION"],
                            ModificadoPor = dr["PRO_MODIFICADO_POR"] == DBNull.Value ? null : dr["PRO_MODIFICADO_POR"].ToString(),
                            FechaModificacion = dr["PRO_FECHA_MODIFICACION"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["PRO_FECHA_MODIFICACION"]
                        });
                    }
                }
            }

            return lista;
        }

        public Propietario ObtenerPorId(int id)
        {
            Propietario p = null;

            string sql = "SELECT * FROM VT_PROPIETARIOS WHERE PRO_ID = @Id";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        p = new Propietario
                        {
                            ProId = (int)dr["PRO_ID"],
                            NumeroIdentificacion = dr["PRO_IDENTIFICACION"].ToString(),
                            PrimerNombre = dr["PRO_PRIMER_NOMBRE"].ToString(),
                            SegundoNombre = dr["PRO_SEGUNDO_NOMBRE"].ToString(),
                            PrimerApellido = dr["PRO_PRIMER_APELLIDO"].ToString(),
                            SegundoApellido = dr["PRO_SEGUNDO_APELLIDO"].ToString(),
                            TelefonoCelular = dr["PRO_TELEFONO"].ToString(),
                            CorreoElectronico = dr["PRO_CORREO"].ToString(),
                            AdicionadoPor = dr["PRO_ADICIONADO_POR"].ToString(),
                            FechaAdicion = (DateTime)dr["PRO_FECHA_ADICION"],
                            ModificadoPor = dr["PRO_MODIFICADO_POR"] == DBNull.Value ? null : dr["PRO_MODIFICADO_POR"].ToString(),
                            FechaModificacion = dr["PRO_FECHA_MODIFICACION"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["PRO_FECHA_MODIFICACION"]
                        };
                    }
                }
            }

            return p;
        }

        public Propietario ObtenerPorIdentificacion(string identificacion)
        {
            Propietario resultado = null;

            string sql = @"
                SELECT * 
                FROM VT_PROPIETARIOS
                WHERE PRO_IDENTIFICACION = @Identificacion";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        resultado = new Propietario
                        {
                            ProId = (int)dr["PRO_ID"],
                            NumeroIdentificacion = dr["PRO_IDENTIFICACION"].ToString(),
                            PrimerNombre = dr["PRO_PRIMER_NOMBRE"].ToString(),
                            SegundoNombre = dr["PRO_SEGUNDO_NOMBRE"].ToString(),
                            PrimerApellido = dr["PRO_PRIMER_APELLIDO"].ToString(),
                            SegundoApellido = dr["PRO_SEGUNDO_APELLIDO"].ToString(),
                            TelefonoCelular = dr["PRO_TELEFONO"].ToString(),
                            CorreoElectronico = dr["PRO_CORREO"].ToString(),
                            AdicionadoPor = dr["PRO_ADICIONADO_POR"].ToString(),
                            FechaAdicion = (DateTime)dr["PRO_FECHA_ADICION"],
                            ModificadoPor = dr["PRO_MODIFICADO_POR"] == DBNull.Value ? null : dr["PRO_MODIFICADO_POR"].ToString(),
                            FechaModificacion = dr["PRO_FECHA_MODIFICACION"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["PRO_FECHA_MODIFICACION"]
                        };
                    }
                }
            }

            return resultado;
        }

        public void Insertar(Propietario p)
        {
            string sql = @"
                INSERT INTO VT_PROPIETARIOS
                (PRO_IDENTIFICACION, PRO_PRIMER_NOMBRE, PRO_SEGUNDO_NOMBRE,
                 PRO_PRIMER_APELLIDO, PRO_SEGUNDO_APELLIDO, PRO_TELEFONO,
                 PRO_CORREO, PRO_ADICIONADO_POR, PRO_FECHA_ADICION)
                VALUES
                (@Identificacion, @PNombre, @SNombre, @PApellido, @SApellido,
                 @Telefono, @Correo, @AdicionadoPor, @FechaAdicion)";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Identificacion", p.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("@PNombre", p.PrimerNombre);
                cmd.Parameters.AddWithValue("@SNombre", p.SegundoNombre ?? "");
                cmd.Parameters.AddWithValue("@PApellido", p.PrimerApellido);
                cmd.Parameters.AddWithValue("@SApellido", p.SegundoApellido ?? "");
                cmd.Parameters.AddWithValue("@Telefono", p.TelefonoCelular);
                cmd.Parameters.AddWithValue("@Correo", p.CorreoElectronico);
                cmd.Parameters.AddWithValue("@AdicionadoPor", p.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", p.FechaAdicion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Propietario p)
        {
            string sql = @"
                UPDATE VT_PROPIETARIOS
                SET PRO_IDENTIFICACION = @Identificacion,
                    PRO_PRIMER_NOMBRE = @PNombre,
                    PRO_SEGUNDO_NOMBRE = @SNombre,
                    PRO_PRIMER_APELLIDO = @PApellido,
                    PRO_SEGUNDO_APELLIDO = @SApellido,
                    PRO_TELEFONO = @Telefono,
                    PRO_CORREO = @Correo,
                    PRO_MODIFICADO_POR = @ModificadoPor,
                    PRO_FECHA_MODIFICACION = @FechaModificacion
                WHERE PRO_ID = @Id";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", p.ProId);
                cmd.Parameters.AddWithValue("@Identificacion", p.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("@PNombre", p.PrimerNombre);
                cmd.Parameters.AddWithValue("@SNombre", p.SegundoNombre ?? "");
                cmd.Parameters.AddWithValue("@PApellido", p.PrimerApellido);
                cmd.Parameters.AddWithValue("@SApellido", p.SegundoApellido ?? "");
                cmd.Parameters.AddWithValue("@Telefono", p.TelefonoCelular);
                cmd.Parameters.AddWithValue("@Correo", p.CorreoElectronico);
                cmd.Parameters.AddWithValue("@ModificadoPor", (object)p.ModificadoPor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaModificacion", (object)p.FechaModificacion ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM VT_PROPIETARIOS WHERE PRO_ID = @Id";

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
