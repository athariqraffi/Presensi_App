using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AplikasiPresensi.Model
{
    class PenggunaModel
    {
        //declare variable
        public string id_pengguna,
                      nama,
                      jk,
                      no_telp, 
                      password;

        //declare object from ModelTemplate
        private ModelTemplate temp;

        //instance
        public PenggunaModel()
        {
            temp = new ModelTemplate();
        }

        //validasi login
        public bool CekLogin()
        {
            bool result = false;

            DataSet dataSet = new DataSet();
            dataSet = temp.Select("pengguna", "id = '"+id_pengguna+"' AND password = '"+password+"'");

            if (dataSet.Tables[0].Rows.Count > 0) //kondisi jika tables memiliki data atau tidak 
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
