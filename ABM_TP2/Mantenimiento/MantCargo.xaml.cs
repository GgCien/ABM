using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ABM_TP2.Ventanas;

namespace ABM_TP2.Mantenimiento
{
    /// <summary>
    /// Lógica de interacción para MantCargo.xaml
    /// </summary>
    public partial class MantCargo : Window
    {
        public event EventHandler Cerrar;
        public MantCargo()
        {
            InitializeComponent();

            Mostrar();
        }

        private void Eliminar()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int id;

                if (int.TryParse(txtCodCargo.Text, out id))
                {
                    string query = "DELETE FROM Cargos WHERE CodCargo = @Value";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Value", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Eliminado exitosamente!");
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Actualizar()
        {
            try
            {
                string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(con);

                conexion.Open();

                int id;

                if (int.TryParse(txtCodCargo.Text, out id))
                {
                    string query = "UPDATE Empleados SET CodCargo = 0 WHERE CodCargo = @Value1";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Value1", id);
                        cmd.ExecuteNonQuery();
                    }
                }  
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

                string query = "SELECT * FROM Cargos";
                using (SqlDataAdapter adt = new SqlDataAdapter(query, conexion))
                {
                    DataTable dtb = new DataTable();
                    adt.Fill(dtb);

                    dtgCargo.ItemsSource = dtb.DefaultView;
                    dtgCargo.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
            SqlConnection conexion = new SqlConnection(con);

            conexion.Open();

            int id;
            string desc = txtDescripcion.Text;
            int est = 0;
            if (chbEstado.IsChecked != false)
            {
                est = 1;
            }
            int estado = est;

            if (int.TryParse(txtCodCargo.Text, out id))
            {
                string query = "UPDATE Cargos SET Descripcion = @Value2, Estado = @Value3 WHERE CodCargo = @ID";
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Value2", desc);
                cmd.Parameters.AddWithValue("@Value3",estado);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Actualizados!");
                dtgCargo.Items.Refresh();

                conexion.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Eliminar();
                Actualizar();
                Mostrar();
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Cerrar?.Invoke(this, EventArgs.Empty);
        }

        private void dtgCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string con = "Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP2; Integrated Security = True";
            SqlConnection conexion = new SqlConnection(con);

            conexion.Open();

            if (dtgCargo.SelectedItem != null)
            {
                DataRowView dtr = (DataRowView)dtgCargo.SelectedItem;

                txtCodCargo.Text = dtr["CodCargo"].ToString();
                txtDescripcion.Text = dtr["Descripcion"].ToString();
            }
            conexion.Close();
        }
    }
}
