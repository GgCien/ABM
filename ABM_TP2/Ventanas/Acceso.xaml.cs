using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para Acceso.xaml
    /// </summary>
    public partial class Acceso : Window
    {
        public Acceso()
        {
            InitializeComponent();

            CargaID();
            MostrarCombo();

            txtHoraEntrada.Focus();
        }

        private void MostrarCombo()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string query = "SELECT Legajo, Nombre FROM Empleados";

                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(query, conexion);

                dap.Fill(ds, "Empleados");
                cmbEmpleado.ItemsSource = ds.Tables["Empleados"].DefaultView;
                cmbEmpleado.DisplayMemberPath = ds.Tables["Empleados"].Columns["Nombre"].ToString();
                cmbEmpleado.SelectedValuePath = ds.Tables["Empleados"].Columns["Legajo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void CargaID()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string datos = "SELECT MAX(CodAcceso) FROM Acceso";
                SqlCommand cmd = new SqlCommand(datos, conexion);

                object res = cmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtCodAcceso.Text = nuevo.ToString();
                }
                else
                {
                    txtCodAcceso.Text = "1";
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

                CargaID();

                int codacceso = int.Parse(txtCodAcceso.Text);
                string he = txtHoraEntrada.Text;
                string hs = txtHoraSalida.Text;
                int empleado = cmbEmpleado.SelectedIndex + 1;

                if (cmbEmpleado.SelectedIndex == -1)
                {
                    MessageBox.Show("Falta Seleccionar Empleado");
                    cmbEmpleado.Focus();
                }
                else
                {
                    if (txtHoraEntrada.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta la Hora de Entrada");
                        txtHoraEntrada.Focus();
                    }
                    else
                    {
                        if (txtHoraSalida.Text.Trim() == "")
                        {
                            MessageBox.Show("Falta la Hora de Salida");
                            txtHoraSalida.Focus();
                        }
                        else
                        {
                            string query = "INSERT INTO Acceso (CodAcceso, HoraIngreso, HoraSalida, Legajo) VALUES (@CodAcceso, @HoraIngreso, @HoraSalida, @Legajo)";
                            SqlCommand cmd = new SqlCommand(query, conexion);

                            cmd.Parameters.AddWithValue("@CodAcceso", codacceso);
                            cmd.Parameters.AddWithValue("@HoraIngreso", he);
                            cmd.Parameters.AddWithValue("@HoraSalida", hs);
                            cmd.Parameters.AddWithValue("@Legajo", empleado);

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
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " +  ex.Message);
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
