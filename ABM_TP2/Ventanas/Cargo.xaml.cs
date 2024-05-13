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

namespace ABM_TP2.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Cargo.xaml
    /// </summary>
    public partial class Cargo : Window
    {
        public Cargo()
        {
            InitializeComponent();

            CargaID();
            txtDescripcion.Focus();
        }

        private void CargaID()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string datos = "SELECT MAX(CodCargo) FROM Cargos";
                SqlCommand cmd = new SqlCommand(datos, conexion);

                object res = cmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtCodCargo.Text = nuevo.ToString();
                }
                else
                {
                    txtCodCargo.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }
        private void Agregar()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                CargaID();

                int codcargo = int.Parse(txtCodCargo.Text);
                string desc = txtDescripcion.Text;
                int est = 0;
                if(chbEstado.IsChecked != false)
                {
                    est = 1;
                }
                int estado = est;

                if (txtDescripcion.Text.Trim() == "")
                {
                    MessageBox.Show("Falta Descripción");
                    txtDescripcion.Focus();
                }
                else
                {
                    string query = "INSERT INTO Cargos (CodCargo, Descripcion, Estado) VALUES (@Value1, @Value2, @Value3)";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Value1", codcargo);
                    cmd.Parameters.AddWithValue("@Value2", desc);
                    cmd.Parameters.AddWithValue("@Value3", estado);

                    cmd.ExecuteNonQuery();

                    if (MessageBox.Show("Agregado exitosamente! \n ¿Desea salir del registro?", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        conexion.Close();
                        Empleados empleados = new Empleados();
                        empleados.Show();
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
            Agregar();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
            this.Close();
        }
    }
}
