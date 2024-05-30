using ABM_TP1.Clases;
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

namespace ABM_TP1
{
    /// <summary>
    /// Lógica de interacción para Carreras.xaml
    /// </summary>
    public partial class Carreras : Window
    {
        List<Clases.Carreras> listacarreras = new List<Clases.Carreras>();

        SqlConnection bdconexion = new SqlConnection("Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP1; Integrated Security = True");

        private string nomusu;
        public Carreras()
        {
            InitializeComponent();

            try
            {
                bdconexion.Open();
                Console.WriteLine("Conectado");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

            nomusu = usu();
            lblUsu.Content = "Usuario: " + nomusu;

            bdTodo();

            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private string usu()
        {
            ClasesPublicas.LeerArchivoRegistro();
            Registro reg = ClasesPublicas.listaregistro.FirstOrDefault();

            string a = reg.Usu;
            return a;
        }

        void Agregar()
        {
            try
            {
                Int32 id = Convert.ToInt32(txtIDc.Text);
                Clases.Carreras objeto = listacarreras.Where(n => n.ID == id).FirstOrDefault();
                if (objeto == null)
                {
                    objeto = new Clases.Carreras();
                    objeto.ID = Convert.ToInt32(txtIDc.Text);
                    objeto.Descripcion = txtDescripcion.Text;

                    listacarreras.Add(objeto);
                }
                else
                {
                    objeto.ID = Convert.ToInt32(txtIDc.Text);
                    objeto.Descripcion = txtDescripcion.Text;
                }
                dtgCarreras.ItemsSource = listacarreras;
                dtgCarreras.Items.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Agregar! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtIDc.Text);
                string desc = txtDescripcion.Text;

                string datos = "INSERT INTO CarreraABM (CodClas, Descripcion) VALUES (@CodClas, @Descripcion)";
                SqlCommand cmd = new SqlCommand(datos, bdconexion);

                cmd.Parameters.AddWithValue("@CodClas", id);
                cmd.Parameters.AddWithValue("@Descripcion", desc);

                int FA = cmd.ExecuteNonQuery();
                Console.WriteLine(FA);

                Agregar();
                MessageBox.Show("Almacenado exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                opciones.Visibility = Visibility.Collapsed;
                btnLimpiar.Visibility = Visibility.Collapsed;
                btnGuardar.Visibility = Visibility.Collapsed;
                btnNuevo.IsEnabled = false;
                mantenimiento.Visibility = Visibility.Visible;
                uno.Visibility = Visibility.Visible;
                txtIDc.Visibility = Visibility.Visible;
                dos.Visibility = Visibility.Visible;
                txtDescripcion.Visibility = Visibility.Visible;
                dtgMostrar.Visibility = Visibility.Collapsed;

                //if (txtIDc.Text.Trim() == "")
                //{
                Mostrar();
                btnModificar.Visibility = Visibility.Collapsed;
                btnActualizar.Visibility = Visibility.Visible;
                //}
                /*else
                {
                    int idc;
                    string desc = txtDescripcion.Text;

                    if (int.TryParse(txtIDc.Text, out idc))
                    {
                        string datos = "UPDATE CarreraABM SET Descripcion = @Descripcion WHERE CodClas = @CodClas";
                        SqlCommand cmd = new SqlCommand(datos, bdconexion);

                        cmd.Parameters.AddWithValue("@Descripcion", desc);
                        cmd.Parameters.AddWithValue("id", idc);

                        int fa = cmd.ExecuteNonQuery();
                        Console.WriteLine(fa);
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;

                if (int.TryParse(txtIDc.Text, out id))
                {
                    string datos = "DELETE FROM CarreraABM WHERE CodClas = @CodClas";
                    SqlCommand cmd = new SqlCommand(datos, bdconexion);
                    cmd.Parameters.AddWithValue("@CodClas", id);

                    int FA = cmd.ExecuteNonQuery();
                    if (FA > 0)
                    {
                        MessageBox.Show("Eliminado");
                    }
                }
                bdTodo();
            }
            catch
            {
                MessageBox.Show("No se puede eliminar porque uno o más usuarios estan registradas a esta carrera!");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnNuevo.IsEnabled = true;

                uno.Visibility = Visibility.Collapsed;
                txtIDc.Visibility = Visibility.Collapsed;
                dos.Visibility = Visibility.Collapsed;
                txtDescripcion.Visibility = Visibility.Collapsed;
                mantenimiento.Visibility = Visibility.Collapsed;
                opciones.Visibility = Visibility.Collapsed;
                btnGuardar.Visibility = Visibility.Collapsed;
                btnLimpiar.Visibility = Visibility.Collapsed;
                dtgCarreras.Visibility = Visibility.Collapsed;

                btnModificar.Visibility = Visibility.Visible;
                btnActualizar.Visibility = Visibility.Collapsed;
                dtgMostrar.Visibility = Visibility.Visible;

                //txtIDc.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                bdTodo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void Mostrar()
        {
            try
            {
                if(dtgCarreras.Visibility == Visibility.Collapsed)
                {
                    dtgCarreras.Visibility = Visibility.Visible;
                }
                else
                {
                    dtgCarreras.Visibility = Visibility.Collapsed;
                }

                string datos = "SELECT * FROM CarreraABM";
                SqlDataAdapter adp = new SqlDataAdapter(datos, bdconexion);
                DataSet ds = new DataSet();
                adp.Fill(ds, "CarreraABM");
                dtgCarreras.ItemsSource = ds.Tables["CarreraABM"].DefaultView;
                dtgMostrar.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgCarreras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgCarreras.SelectedItem != null)
                {
                    DataRowView dtr = (DataRowView)dtgCarreras.SelectedItem;

                    txtIDc.Text = dtr["CodClas"].ToString();
                    txtDescripcion.Text = dtr["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            bdconexion.Close();
            Console.WriteLine("Desconectado");
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgMostrar.Visibility = Visibility.Collapsed;
                Habilitar();
                CargaID();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void Habilitar()
        {
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnGuardar.IsEnabled = true;

            uno.Visibility = Visibility.Visible;
            txtIDc.Visibility = Visibility.Visible;
            dos.Visibility = Visibility.Visible;
            txtDescripcion.Visibility = Visibility.Visible;

            mantenimiento.Visibility = Visibility.Visible;
            opciones.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
            btnLimpiar.Visibility = Visibility.Visible;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //txtIDc.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtIDc_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                var TextBox = sender as TextBox;

                if (TextBox != null)
                {
                    var textboxes = new TextBox[] { txtIDc, txtDescripcion };

                    int CI = Array.IndexOf(textboxes, TextBox);
                    int NI = (CI + 1) % textboxes.Length;

                    textboxes[NI].Focus();
                }
                e.Handled = true;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idc;
                string desc = txtDescripcion.Text;

                if (int.TryParse(txtIDc.Text, out idc))
                {
                    string datos = "UPDATE CarreraABM SET Descripcion = @Descripcion WHERE CodClas = @CodClas";
                    SqlCommand cmd = new SqlCommand(datos, bdconexion);

                    cmd.Parameters.AddWithValue("@Descripcion", desc);
                    cmd.Parameters.AddWithValue("@CodClas", idc);

                    int fa = cmd.ExecuteNonQuery();
                    Console.WriteLine(fa);

                    MessageBox.Show("Modificado exitosamente!");
                    dtgCarreras.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Actualizar! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void bdTodo()
        {
            try
            {
                string datos = "SELECT * FROM CarreraABM";
                SqlDataAdapter adt = new SqlDataAdapter(datos, bdconexion);
                DataTable dt = new DataTable();
                adt.Fill(dt);

                dtgMostrar.ItemsSource = dt.DefaultView;
                dtgMostrar.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDescripcion_GotFocus(object sender, RoutedEventArgs e)
        {
            //txtDescripcion.Text = string.Empty;
        }

        private void txtIDc_GotFocus(object sender, RoutedEventArgs e)
        {
            //txtIDc.Text = string.Empty;
        }

        private void dtgMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgMostrar.SelectedItem != null)
                {
                    DataRowView dtr = (DataRowView)dtgMostrar.SelectedItem;

                    txtIDc.Text = dtr["CodClas"].ToString();
                    txtDescripcion.Text = dtr["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void CargaID()
        {
            try
            {
                string datos = "SELECT MAX(CodClas) FROM CarreraABM";
                SqlCommand cmd = new SqlCommand(datos, bdconexion);

                object res = cmd.ExecuteScalar();
                if(res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtIDc.Text = nuevo.ToString();
                }
                else
                {
                    txtIDc.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
