using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ExpressDelivery.Repository
{
    class BairroRepository
    {
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;

        public List<Bairro> LoadAll()
        {
            List<Bairro> bairros = new List<Bairro>();

            _cmd.CommandText = $"SELECT * FROM TB_DELIVERY_BAIRRO;";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var bairro = new Bairro
                    {
                        Id = Convert.ToInt16(_dr["ID_BAIRRO"]),
                        Status = Convert.ToInt16(_dr["STATUS_BAIRRO"]),
                        Nome = _dr["NOME"].ToString(),
                        VrTaxa = Convert.ToDouble(_dr["VR_TAXA"]),
                    };

                    bairros.Add(bairro);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            finally
            {
                _con.Disconnect();
            }

            return bairros;
        }

        public int Save(Bairro bairro, string type)
        {
            if (type == "new")
            {
                _cmd.CommandText =
                    $"INSERT INTO TB_DELIVERY_BAIRRO (NOME, VR_TAXA) VALUES ('{bairro.Nome}', {bairro.VrTaxa});";
            }
            else
            {
                _cmd.CommandText =
                    $"UPDATE TB_DELIVERY_BAIRRO SET NOME='{bairro.Nome}', VR_TAXA={bairro.VrTaxa} WHERE ID_BAIRRO={bairro.Id};";
            }

            try
            {
                _cmd.Connection = _con.Connect();
                return _cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return -1;
            }
            finally
            {
                _con.Disconnect();
            }
        }
    }
}
