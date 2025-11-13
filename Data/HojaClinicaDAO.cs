using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster.Data
{
    public class HojaClinicaDAO
    {
        public void Insertar(HojaClinica hoja)
        {
            string sql = @"
                INSERT INTO VT_HOJA
                (HOJ_FECHA_ATENCION, HOJ_SINTOMAS, HOJ_DIAGNOSTICO, HOJ_TRATAMIENTO,
                 HOJ_MAS_ID, HOJ_ADICIONADO_POR, HOJ_FECHA_ADICION)
                VALUES
                (@FechaAtencion, @Sintomas, @Diagnostico, @Tratamiento,
                 @MasId, @AdicionadoPor, @FechaAdicion)";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FechaAtencion", hoja.FechaAtencion);
                cmd.Parameters.AddWithValue("@Sintomas", hoja.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnostico", hoja.Diagnostico);
                cmd.Parameters.AddWithValue("@Tratamiento", hoja.Tratamiento);
                cmd.Parameters.AddWithValue("@MasId", hoja.MasId);
                cmd.Parameters.AddWithValue("@AdicionadoPor", hoja.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", hoja.FechaAdicion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<HojaClinica> ListarPorMascota(int masId)
        {
            var lista = new List<HojaClinica>();

            string sql = @"
                SELECT * 
                FROM VT_HOJA
                WHERE HOJ_MAS_ID = @MasId";

            using (SqlConnection conn = DbHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MasId", masId);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new HojaClinica
                        {
                            HojId = (int)dr["HOJ_ID"],
                            FechaAtencion = (DateTime)dr["HOJ_FECHA_ATENCION"],
                            Sintomas = dr["HOJ_SINTOMAS"].ToString(),
                            Diagnostico = dr["HOJ_DIAGNOSTICO"].ToString(),
                            Tratamiento = dr["HOJ_TRATAMIENTO"].ToString(),
                            MasId = (int)dr["HOJ_MAS_ID"],
                            AdicionadoPor = dr["HOJ_ADICIONADO_POR"].ToString(),
                            FechaAdicion = (DateTime)dr["HOJ_FECHA_ADICION"],
                            ModificadoPor = dr["HOJ_MODIFICADO_POR"] == DBNull.Value ? null : dr["HOJ_MODIFICADO_POR"].ToString(),
                            FechaModificacion = dr["HOJ_FECHA_MODIFICACION"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["HOJ_FECHA_MODIFICACION"]
                        });
                    }
                }
            }

            return lista;
        }
    }
}
