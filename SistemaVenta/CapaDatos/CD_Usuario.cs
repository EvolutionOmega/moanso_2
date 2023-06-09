﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconecxion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select IdUsuario,Documento,NombreCompleto,Correo,Clave,estado from usuarios";

                    SqlCommand cmd = new SqlCommand(query, oconecxion);
                    cmd.CommandType = CommandType.Text;

                    oconecxion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])


                            });


                        }



                    }






                }catch(Exception)
                {

                    lista = new List<Usuario>();

                }


            }

            return lista;

        }
    }
}
