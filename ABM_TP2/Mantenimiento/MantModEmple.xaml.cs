using ABM_TP2.Ventanas;
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

namespace ABM_TP2.Mantenimiento
{
    /// <summary>
    /// Lógica de interacción para MantModEmple.xaml
    /// </summary>
    public partial class MantModEmple : Window
    {
        public static Action<object, EventArgs> WindowClosed { get; internal set; }

        public event EventHandler DataUpdate;
        public MantModEmple(string d1, string d2, string d3, string d4, string d5)
        {
            InitializeComponent();
            MostrarCombo();

            txtNombre.Focus();

            txtLegajo.Text = d1;
            txtNombre.Text = d2;
            txtApellido.Text = d3;
            dtpNacimiento.Text = d4;
            dtpAlta.Text = d5;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int id = int.Parse(txtLegajo.Text);
                string nom = txtNombre.Text;
                string ape = txtApellido.Text;
                DateTime fn = dtpNacimiento.SelectedDate.Value;
                DateTime fa = dtpAlta.SelectedDate.Value;
                int carr = cmbCargoEmpleado.SelectedIndex + 1;
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
                                    string query = "UPDATE Empleados SET Nombre = @value2, Apellido = @value3, Nacimiento = @Value4, Alta = @Value5, CodCargo = @Value6, Estado = @Value7 WHERE Legajo = @value1";
                                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                                    {
                                        cmd.Parameters.AddWithValue("@Value1", id);
                                        cmd.Parameters.AddWithValue("@Value2", nom);
                                        cmd.Parameters.AddWithValue("@Value3", ape);
                                        cmd.Parameters.AddWithValue("@Value4", fn);
                                        cmd.Parameters.AddWithValue("@Value5", fa);
                                        cmd.Parameters.AddWithValue("@Value6", carr);
                                        cmd.Parameters.AddWithValue("@Value7", estado);

                                        cmd.ExecuteNonQuery();

                                        conexion.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
            DataUpdate?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
