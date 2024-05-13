using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using ABM_TP2.Ventanas;

namespace ABM_TP2.Mantenimiento
{
    /// <summary>
    /// Lógica de interacción para MantEmpleado.xaml
    /// </summary>
    public partial class MantEmpleado : Window
    {
        public MantEmpleado()
        {
            InitializeComponent();

            MostrarCombo();
            CargarID();
   
        }

        private void CargarID()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string datos = "SELECT MAX(Legajo) FROM Empleados";
                SqlCommand cmd = new SqlCommand(datos, conexion);

                object res = cmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtLegajo.Text = nuevo.ToString();
                }
                else
                {
                    txtLegajo.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void MostrarCombo()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string query = "SELECT CodCargo, Descripcion FROM Cargos";

                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(query, conexion);

                dap.Fill(ds, "Cargos");
                cmbCargoEmpleado.ItemsSource = ds.Tables["Cargos"].DefaultView;
                cmbCargoEmpleado.DisplayMemberPath = ds.Tables["Cargos"].Columns["Descripcion"].ToString();
                cmbCargoEmpleado.SelectedValuePath = ds.Tables["Cargos"].Columns["CodCargo"].ToString();
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

                CargarID();

                string query = "INSERT INTO Empleados (Legajo, Nombre, Apellido, Nacimiento, Alta, CodCargo, Estado) VALUES (@Valor1, @Valor2, @Valor3, @Valor4, @Valor5, @Valor6, @Valor7)";

                int legajo = int.Parse(txtLegajo.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                DateTime nacimiento = dtpNacimiento.SelectedDate.Value;
                DateTime alta = dtpAlta.SelectedDate.Value;
                int cargo = cmbCargoEmpleado.SelectedIndex + 1;
                int est = 0;
                if (chbEstado.IsChecked == true)
                {
                    est = 1;
                }
                int estado = est;

                if (txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show("Falta Nombre");
                    txtNombre.Focus();
                }
                else
                {
                    if (txtApellido.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta Apellido");
                        txtApellido.Focus();
                    }
                    else
                    {
                        if (dtpNacimiento.Text.Trim() == "")
                        {
                            MessageBox.Show("Falta Fecha de Nacimiento");
                            dtpNacimiento.Focus();
                        }
                        else if (dtpNacimiento.SelectedDate.Value > DateTime.Now)
                        {
                            MessageBox.Show("No puede ser Mayor a la Actual " + DateTime.Now);
                            dtpNacimiento.Focus();
                        }
                        else
                        {
                            if (dtpAlta.Text.Trim() == "")
                            {
                                MessageBox.Show("Falta Fecha de Alta");
                                dtpAlta.Focus();
                            }
                            else if (dtpAlta.SelectedDate.Value > DateTime.Now)
                            {
                                MessageBox.Show("No puede ser Mayor a la Actual " + DateTime.Now);
                                dtpAlta.Focus();
                            }
                            else
                            {
                                if (cmbCargoEmpleado.SelectedIndex == -1)
                                {
                                    MessageBox.Show("Falta Seleccionar el Cargo");
                                    cmbCargoEmpleado.Focus();
                                }
                                else
                                {
                                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                                    {
                                        cmd.Parameters.AddWithValue("@Valor1", legajo);
                                        cmd.Parameters.AddWithValue("@Valor2", nombre);
                                        cmd.Parameters.AddWithValue("@Valor3", apellido);
                                        cmd.Parameters.AddWithValue("@Valor4", nacimiento);
                                        cmd.Parameters.AddWithValue("@Valor5", alta);
                                        cmd.Parameters.AddWithValue("@Valor6", cargo);
                                        cmd.Parameters.AddWithValue("@Valor7", estado);

                                        cmd.ExecuteNonQuery();

                                        if (MessageBox.Show("Agregado exitosamente! \n ¿Desea salir de este registro?", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                        {
                                            Empleados empleados = new Empleados();
                                            empleados.Show();
                                            this.Close();
                                        }
                                    }
                                }
                            }
                        }
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
