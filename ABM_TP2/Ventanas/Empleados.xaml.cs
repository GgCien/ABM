using ABM_TP2.Clases;
using ABM_TP2.Mantenimiento;
using Microsoft.SqlServer.Server;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ABM_TP2.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        public Empleados()
        {
            InitializeComponent();

            MostrarCombo();
            MostrarBD();

            dtgEmpleados.Items.Refresh();
            cmbCargoBuscar.Items.Refresh();

            lblFecha.Content = "Fecha: " + DateTime.Now;
        }

        public void Usuario()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string query = "SELECT SUSER_NAME() AS Usuario";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string usuario = dr["Usuario"].ToString();
                        lblUsuario.Content = $"Usuario: " + usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void MostrarBD()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string query = "SELECT Legajo, Nombre, Apellido, Nacimiento, Alta, Descripcion, Empleados.Estado FROM Empleados INNER JOIN Cargos ON Empleados.CodCargo = Cargos.CodCargo";
                using (SqlDataAdapter adt = new SqlDataAdapter(query, conexion))
                {
                    DataTable dtb = new DataTable();
                    adt.Fill(dtb);

                    dtgEmpleados.ItemsSource = dtb.DefaultView;
                    dtgEmpleados.Items.Refresh();
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
                cmbCargoBuscar.ItemsSource = ds.Tables["Cargos"].DefaultView;
                cmbCargoBuscar.DisplayMemberPath = ds.Tables["Cargos"].Columns["Descripcion"].ToString();
                cmbCargoBuscar.SelectedValuePath = ds.Tables["Cargos"].Columns["CodCargo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Cargo_Click(object sender, RoutedEventArgs e)
        {
            Ventanas.Cargo vc = new Ventanas.Cargo();
            vc.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Ventanas.Acceso va = new Ventanas.Acceso();
            va.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MantEmpleado me = new MantEmpleado();
            me.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void vme_DataUpdate(object sender, EventArgs e)
        {
            MostrarBD();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int id;

                if (int.TryParse(txtEliminar.Text, out id)) {
                    string query = "DELETE FROM Empleados WHERE Legajo = @Legajo"; //UPDATE Empleados SET Estado = 0 DELETE FROM Empleados WHERE Legajo = @Legajo

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Legajo", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Eliminado exitosamente!");
                    }
                }
                MostrarBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtBuscarLegajo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                btnCancelar.Visibility = Visibility.Visible;

                if(e.Key == Key.Enter)
                {
                    string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                    SqlConnection conexion = new SqlConnection(con);

                    conexion.Open();

                    int buscar = int.Parse(txtBuscarLegajo.Text);

                    string query = "SELECT Legajo, Nombre, Apellido, Nacimiento, Alta, Descripcion, Empleados.Estado FROM Empleados INNER JOIN Cargos ON Empleados.CodCargo = Cargos.CodCargo WHERE Legajo = @Legajo";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Legajo", buscar);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dtgEmpleados.ItemsSource = dataTable.DefaultView;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void cmbCargoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                btnCancelar.Visibility = Visibility.Visible;

                if(e.Key == Key.Enter)
                {
                    string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                    SqlConnection conexion = new SqlConnection(con);

                    conexion.Open();

                    int buscar = (int)cmbCargoBuscar.SelectedValue;

                    string query = "SELECT Legajo, Nombre, Apellido, Nacimiento, Alta, Descripcion, Empleados.Estado FROM Empleados INNER JOIN Cargos ON Empleados.CodCargo = Cargos.CodCargo WHERE Empleados.CodCargo = @ID";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@ID", buscar);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dtgEmpleados.ItemsSource = datatable.DefaultView;
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void dtgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                if (dtgEmpleados.SelectedItem != null)
                {
                    DataRowView dtr = (DataRowView)dtgEmpleados.SelectedItem;

                    txtEliminar.Text = dtr["Legajo"].ToString();
                    string col1 = dtr["Legajo"].ToString();
                    string col2 = dtr["Nombre"].ToString();
                    string col3 = dtr["Apellido"].ToString();
                    string col4 = dtr["Nacimiento"].ToString();
                    string col5 = dtr["Alta"].ToString();

                    if (MessageBox.Show("¿Desea modificar este registro?", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        MantModEmple vm = new MantModEmple(col1, col2, col3, col4, col5);
                        MantModEmple.WindowClosed += MantModEmple_WindowClosed;
                        vm.ShowDialog();
                        this.Close();
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void MantModEmple_WindowClosed(object sender, EventArgs e)
        {
            dtgEmpleados.Items.Refresh();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            btnCancelar.Visibility = Visibility.Collapsed;
            txtBuscarLegajo.Text = string.Empty;
            cmbCargoBuscar.SelectedIndex = -1;
            MostrarBD();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Mantenimiento.MantCargo vmc = new Mantenimiento.MantCargo();
            vmc.Show();
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Mantenimiento.MantAcceso vma = new Mantenimiento.MantAcceso();
            vma.Show();
            this.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ABM_TP2.MainWindow login = new ABM_TP2.MainWindow();
            login.Show();
            this.Close();
        }
    }
}
