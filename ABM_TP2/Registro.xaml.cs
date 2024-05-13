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
using System.Windows.Shapes;

namespace ABM_TP2
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();

            CargarID();
        }

        private void CargarID()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string datos = "SELECT MAX(CodUsuario) FROM Usuario";
                SqlCommand cmd = new SqlCommand(datos, conexion);

                object res = cmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtCodUsuario.Text = nuevo.ToString();
                }
                else
                {
                    txtCodUsuario.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " +  ex.Message);
            }
        }

        private void Agregar()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int cod = int.Parse(txtCodUsuario.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string usuario = txtUsuario.Text;
                string correo = txtCorreo.Text;
                string pass = txtPass.Password;

                string query = "INSERT INTO Usuario (CodUsuario, Nombre, Apellido, Usuario, Correo, Contraseña) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Value1", cod);
                cmd.Parameters.AddWithValue("@Value2", nombre);
                cmd.Parameters.AddWithValue("@Value3", apellido);
                cmd.Parameters.AddWithValue("@Value4", usuario);
                cmd.Parameters.AddWithValue("@Value5", correo);
                cmd.Parameters.AddWithValue("@Value6", pass);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Almacenado exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Agregar();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
