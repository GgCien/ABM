using ABM_TP2.Clases;
using ABM_TP2.Ventanas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABM_TP2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        public void Inicio()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show("Falta Usuario");
                    txtUsuario.Focus();
                }
                else
                {
                    if (txtPass.Password.Trim() == "")
                    {
                        MessageBox.Show("Falta Contraseña");
                        txtPass.Focus();
                    }
                    else
                    {
                        string usuario = txtUsuario.Text;
                        string pass = txtPass.Password;

                        string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Value1 AND Contraseña = @Value2";
                        SqlCommand cmd = new SqlCommand(query, conexion);

                        cmd.Parameters.AddWithValue("@Value1", usuario);
                        cmd.Parameters.AddWithValue("@Value2", pass);

                        int user = (int)cmd.ExecuteScalar();

                        if (user > 0)
                        {
                            //MessageBox.Show("Inicio de sesion exitoso!");
                            Ventanas.Empleados ve = new Ventanas.Empleados();
                            ve.Show();
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorretas. Por favor, intente nuevamente");
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio();
        }

        private void txtResgistro_Click(object sender, RoutedEventArgs e)
        {
            Registro vr = new Registro();
            vr.Show();
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPass.Password = string.Empty;
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Inicio();
                this.Close();
            }
        }
    }
}
