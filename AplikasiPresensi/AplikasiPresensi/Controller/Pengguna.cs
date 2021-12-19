using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AplikasiPresensi.Controller
{
    class Pengguna
    {
        //declare object from model & view
        Model.PenggunaModel pengguna;
        View.LoginWindow login;

        //isntance
        public Pengguna(View.LoginWindow login)
        {
            pengguna = new Model.PenggunaModel();
            this.login = login;
        }

        //request & response
        public void Login()
        {
            pengguna.id_pengguna = login.txtUsername.Text; //get text from txt username
            pengguna.password = login.txtPassword.Password; //get password from txt password

            bool result = pengguna.CekLogin();

            if (result)
            {
                View.MainWindow window= new View.MainWindow();
                window.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah !!");
                login.txtUsername.Text      = "";
                login.txtPassword.Password  = "";
                login.txtUsername.Focus();
            }
        }
    }
}
