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
    /// Lógica de interacción para MantAcceso.xaml
    /// </summary>
    public partial class MantAcceso : Window
    {
        public MantAcceso()
        {
            InitializeComponent();

            Mostrar();
            Combo();
        }

        private void Combo()
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

        private void Mostrar()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                string query = "SELECT * FROM Acceso";
                using (SqlDataAdapter adt = new SqlDataAdapter(query, conexion))
                {
                    DataTable dtb = new DataTable();
                    adt.Fill(dtb);

                    dtgAcceso.ItemsSource = dtb.DefaultView;
                    dtgAcceso.Items.Refresh();
                }
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

                int id;
                int empleado = cmbEmpleado.SelectedIndex + 1;
                string he = txtHoraEntrada.Text;
                string hs = txtHoraSalida.Text;

                if (int.TryParse(txtCodAcceso.Text, out id))
                {
                    string query = "UPDATE Acceso SET HoraIngreso  = @Value2, HoraSalida = @Value3, Legajo = @Value4 WHERE CodAcceso = @ID";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("Value4", empleado);
                    cmd.Parameters.AddWithValue("@Value2", he);
                    cmd.Parameters.AddWithValue("@Value3", hs);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos Actualizados!");
                    dtgAcceso.Items.Refresh();

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int id;

                if (int.TryParse(txtCodAcceso.Text, out id))
                {
                    string query = "DELETE FROM Acceso WHERE CodAcceso = @Value";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Value", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Eliminado exitosamente!");
                    }
                }
                Mostrar();

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
            SqlConnection conexion = new SqlConnection(con);

            conexion.Open();

            if (dtgAcceso.SelectedItem != null)
            {
                DataRowView dtr = (DataRowView)dtgAcceso.SelectedItem;

                txtCodAcceso.Text = dtr["CodAcceso"].ToString();
                cmbEmpleado.SelectedValue = dtr["Legajo"].ToString();
                txtHoraEntrada.Text = dtr["HoraIngreso"].ToString();
                txtHoraSalida.Text = dtr["HoraSalida"].ToString();
            }
            conexion.Close();
        }
    }
}
