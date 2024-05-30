using ABM_TP1.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABM_TP1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Alumnos> listalumnos = new List<Alumnos>();
        SqlConnection bdconexion = new SqlConnection("Data Source = LAPTOP-K7DIJNJ8\\SQLEXPRESS; Initial Catalog = ABMTP1; Integrated Security = True");

        private string nomusu;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                bdconexion.Open();
                Console.WriteLine("Conectado");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            nomusu = usu();
            lblUsu.Content = "Usuario: " + nomusu;
            lblUsuBuscador.Content = "Usuario: " + nomusu;

            bdTodoBuscador();
            cmbCarreras();
            cmbBuscar();
            bdTodo();

            cmbBuscador.SelectedIndex = 0;
            cmbBuscador.IsEnabled = false;
            cmbCarrera.SelectedIndex = 0;
            btnGuardar.IsEnabled = false;
            btnLimpiar.IsEnabled = false;

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

        void cmbCarreras()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CodClas, Descripcion FROM CarreraABM", bdconexion);

                da.Fill(ds, "CarreraABM");
                cmbCarrera.ItemsSource = ds.Tables["CarreraABM"].DefaultView;
                cmbCarrera.DisplayMemberPath = ds.Tables["CarreraABM"].Columns["Descripcion"].ToString();
                cmbCarrera.SelectedValuePath = ds.Tables["CarreraABM"].Columns["CodClas"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void cmbBuscar()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CodClas, Descripcion FROM CarreraABM", bdconexion);

                da.Fill(ds, "CarreraABM");
                cmbBuscador.ItemsSource = ds.Tables["CarreraABM"].DefaultView;
                cmbBuscador.DisplayMemberPath = ds.Tables["CarreraABM"].Columns["Descripcion"].ToString();
                cmbBuscador.SelectedValuePath = ds.Tables["CarreraABM"].Columns["CodClas"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void Agregar()
        {
            try
            {
                Int32 id = int.Parse(txtID.Text);
                Alumnos objeto = listalumnos.Where(n => n.ID == id).FirstOrDefault();
                if (objeto == null)
                {
                    objeto = new Alumnos();
                    objeto.ID = id;
                    objeto.DNI = int.Parse(txtDNI.Text);
                    objeto.Nom = txtNom.Text;
                    objeto.Ape = txtApe.Text;
                    objeto.FA = dtpFA.SelectedDate.Value;
                    objeto.FN = dtpFN.SelectedDate.Value;
                    objeto.Carrera = cmbCarrera.SelectedIndex + 1;
                    int estado = 0;
                    if (chbEstado.IsChecked == true)
                    {
                        estado = 1;
                    }
                    objeto.Estado = estado;

                    listalumnos.Add(objeto);
                    dtgDatos.ItemsSource = listalumnos;
                    dtgDatos.Items.Refresh();
                }
                else
                {
                    objeto.ID = id;
                    objeto.DNI = int.Parse(txtDNI.Text);
                    objeto.Nom = txtNom.Text;
                    objeto.Ape = txtApe.Text;
                    objeto.FA = dtpFA.SelectedDate.Value;
                    objeto.FN = dtpFN.SelectedDate.Value;
                    objeto.Carrera = cmbCarrera.SelectedIndex + 1;
                    int estado = 0;
                    if (chbEstado.IsChecked == true)
                    {
                        estado = 1;
                    }
                    objeto.Estado = estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CargaID();

                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                btnLimpiar.IsEnabled = true;
                btnGuardar.IsEnabled = true;

                gpbRegistro.Visibility = Visibility.Visible;
                uno.Visibility = Visibility.Visible;
                txtID.Visibility = Visibility.Visible;
                dos.Visibility = Visibility.Visible;
                txtDNI.Visibility = Visibility.Visible;
                tres.Visibility = Visibility.Visible;
                txtNom.Visibility = Visibility.Visible;
                cuatro.Visibility = Visibility.Visible;
                txtApe.Visibility = Visibility.Visible;
                cinco.Visibility = Visibility.Visible;
                dtpFA.Visibility = Visibility.Visible;
                seis.Visibility = Visibility.Visible;
                dtpFN.Visibility = Visibility.Visible;
                siete.Visibility = Visibility.Visible;
                cmbCarrera.Visibility = Visibility.Visible;
                chbEstado.Visibility = Visibility.Visible;
                opciones.Visibility = Visibility.Visible;
                btnGuardar.Visibility = Visibility.Visible;
                btnLimpiar.Visibility = Visibility.Visible;
                dtgMostrar.Visibility = Visibility.Collapsed;

                chbEstado.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtDNI.Text.Trim() == "")
                {
                    MessageBox.Show("Falta DNI!");
                    txtDNI.Focus();
                }
                else if(txtDNI.Text.Trim().Length > 8)
                {
                    MessageBox.Show("No puede ser mayor a 8 digitos!");
                }
                else
                {
                    if(txtNom.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta Nombre!");
                        txtNom.Focus();
                    }
                    else
                    {
                        if(txtApe.Text.Trim() == "")
                        {
                            MessageBox.Show("Falta Apellido!");
                            txtApe.Focus();
                        }
                        else
                        {
                            if (dtpFN.Text.Trim() == "")
                            {
                                MessageBox.Show("Falta Fecha de Nacimiento!");
                                dtpFN.Focus();
                            }
                            else
                            {
                                if (dtpFA.Text.Trim() == "")
                                {
                                    MessageBox.Show("Falta Fecha de Alta");
                                    dtpFA.Focus();
                                }
                                else if (dtpFA.SelectedDate > DateTime.Now)
                                {
                                    MessageBox.Show("No puede ser Mayor a la actual " + DateTime.Now);
                                    dtpFA.Focus();
                                }
                                else
                                {
                                    int id = int.Parse(txtID.Text);
                                    int dni = int.Parse(txtDNI.Text);
                                    string nom = txtNom.Text;
                                    string ape = txtApe.Text;
                                    DateTime fa = dtpFA.SelectedDate.Value;
                                    DateTime fn = dtpFN.SelectedDate.Value;
                                    int carrera = cmbCarrera.SelectedIndex + 1;
                                    int estado = 0;
                                    if (chbEstado.IsChecked == true)
                                    {
                                        estado = 1;
                                    }
                                    int Estado = estado;

                                    string datos = "INSERT INTO AlumnosABM (ID, DNI, Nombre, Apellido, FechaAlta, FechaNac, CodClas, Estado) VALUES (@ID, @DNI, @Nombre, @Apellido, @FechaAlta, @FechaNac, @CodClas, @Estado)";
                                    SqlCommand cmd = new SqlCommand(datos, bdconexion);

                                    cmd.Parameters.AddWithValue("@ID", id);
                                    cmd.Parameters.AddWithValue("@DNI", dni);
                                    cmd.Parameters.AddWithValue("@Nombre", nom);
                                    cmd.Parameters.AddWithValue("@Apellido", ape);
                                    cmd.Parameters.AddWithValue("@FechaAlta", fa);
                                    cmd.Parameters.AddWithValue("@FechaNac", fn);
                                    cmd.Parameters.AddWithValue("@CodClas", carrera);
                                    cmd.Parameters.AddWithValue("@Estado", Estado);

                                    Agregar();

                                    int FA = cmd.ExecuteNonQuery();
                                    Console.WriteLine(FA);
                                    MessageBox.Show("Almacenado exitosamente!");

                                    cancelar();
                                }
                            }
                        }
                    }
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " +  ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void Mostrar()
        {
            try
            {
                if(dtgDatos.Visibility == Visibility.Collapsed)
                {
                    dtgDatos.Visibility = Visibility.Visible;
                }
                else
                {
                    dtgDatos.Visibility = Visibility.Collapsed;
                }

                string datos = "SELECT * FROM AlumnosABM";
                SqlDataAdapter adp = new SqlDataAdapter(datos, bdconexion);
                DataSet ds = new DataSet();
                adp.Fill(ds, "AlumnosABM");
                dtgDatos.ItemsSource = ds.Tables["AlumnosABM"].DefaultView;
                dtgDatos.Items.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnNuevo.IsEnabled = false;
                btnLimpiar.IsEnabled = true;
                btnGuardar.IsEnabled = !true;

                gpbRegistro.Visibility = Visibility.Visible;
                uno.Visibility = Visibility.Visible;
                txtID.Visibility = Visibility.Visible;
                dos.Visibility = Visibility.Visible;
                txtDNI.Visibility = Visibility.Visible;
                tres.Visibility = Visibility.Visible;
                txtNom.Visibility = Visibility.Visible;
                cuatro.Visibility = Visibility.Visible;
                txtApe.Visibility = Visibility.Visible;
                cinco.Visibility = Visibility.Visible;
                dtpFA.Visibility = Visibility.Visible;
                seis.Visibility = Visibility.Visible;
                dtpFN.Visibility = Visibility.Visible;
                siete.Visibility = Visibility.Visible;
                cmbCarrera.Visibility = Visibility.Visible;
                chbEstado.Visibility = Visibility.Visible;
                dtgMostrar.Visibility = Visibility.Collapsed;

                Mostrar();
                btnModificar.Visibility = Visibility.Collapsed;
                btnActualizar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(dtgDatos.SelectedItem != null)
                {
                    DataRowView dtr = (DataRowView)dtgDatos.SelectedItem;

                    txtID.Text = dtr["ID"].ToString();
                    txtDNI.Text = dtr["DNI"].ToString();
                    txtNom.Text = dtr["Nombre"].ToString();
                    txtApe.Text = dtr["Apellido"].ToString();
                    dtpFA.Text = dtr["FechaAlta"].ToString();
                    dtpFN.Text = dtr["FechaNac"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;

                if(int.TryParse(txtID.Text, out id))
                {
                    string datos = "DELETE FROM AlumnosABM WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(datos, bdconexion);
                    cmd.Parameters.AddWithValue("@ID", id);

                    int FA = cmd.ExecuteNonQuery();
                    if(FA > 0)
                    {
                        MessageBox.Show("Eliminado");
                    }
                    else
                    {
                        MessageBox.Show("Error al Eliminar");
                    }
                }
                bdTodo();
            }
            catch( Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            //txtID.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtApe.Text = string.Empty;
            dtpFA.Text = string.Empty;
            dtpFA.SelectedDate = DateTime.Now;
            dtpFN.Text = string.Empty;
            dtpFN.SelectedDate = DateTime.Now;
            chbEstado.IsChecked = false;
            cmbCarrera.SelectedIndex = 1;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdTodoBuscador();

                if(chbBuscador.IsChecked == true)
                {

                    int desde = int.Parse(txtDesde.Text);
                    int hasta = int.Parse(txtHasta.Text);

                    string consulta = "SELECT * FROM AlumnosABM WHERE ID BETWEEN @desde AND @hasta";

                    SqlCommand cmd = new SqlCommand(consulta, bdconexion);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);

                    dtgBuscador.ItemsSource = dt.DefaultView;
                }

                if(chbBuscador2.IsChecked == true)
                {
                    int sidb = Convert.ToInt32(cmbBuscador.SelectedValue);
                    string consulta = "SELECT * FROM AlumnosABM WHERE CodClas = @CodClas";

                    using (SqlCommand cmd = new SqlCommand(consulta, bdconexion))
                    {
                        cmd.Parameters.AddWithValue("@CodClas", sidb);

                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataTable datatable = new DataTable();
                            adp.Fill(datatable);
                            dtgBuscador.ItemsSource = datatable.DefaultView;
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Error al buscar! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDesde_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDesde.Text = string.Empty;
        }

        private void txtHasta_GotFocus(object sender, RoutedEventArgs e)
        {
            txtHasta.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            bdconexion.Close();
            Console.WriteLine("Desconecctado");
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnNuevo.IsEnabled = true;
            btnLimpiar.IsEnabled = !true;
            btnGuardar.IsEnabled = !true;
            dtgDatos.Visibility = Visibility.Collapsed;

            //txtID.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtApe.Text = string.Empty;
            dtpFA.SelectedDate = DateTime.Now;
            dtpFN.Text = string.Empty;
            dtpFN.SelectedDate = DateTime.Now;
            chbEstado.IsChecked = false;
            cmbCarrera.SelectedIndex = 1;

            gpbRegistro.Visibility = Visibility.Collapsed;
            uno.Visibility = Visibility.Collapsed;
            txtID.Visibility = Visibility.Collapsed;
            dos.Visibility = Visibility.Collapsed;
            txtDNI.Visibility = Visibility.Collapsed;
            tres.Visibility = Visibility.Collapsed;
            txtNom.Visibility = Visibility.Collapsed;
            cuatro.Visibility = Visibility.Collapsed;
            txtApe.Visibility = Visibility.Collapsed;
            cinco.Visibility = Visibility.Collapsed;
            dtpFA.Visibility = Visibility.Collapsed;
            seis.Visibility = Visibility.Collapsed;
            dtpFN.Visibility = Visibility.Collapsed;
            siete.Visibility = Visibility.Collapsed;
            cmbCarrera.Visibility = Visibility.Collapsed;
            chbEstado.Visibility = Visibility.Collapsed;

            opciones.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnLimpiar.Visibility = Visibility.Collapsed;

            btnModificar.Visibility = Visibility.Visible;
            btnActualizar.Visibility = Visibility.Collapsed;

            dtgMostrar.Visibility = Visibility.Visible;
            bdTodo();
            
        }

        private void txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Tab)
            {
                var TextBox = sender as TextBox;

                if(TextBox != null )
                {
                    var textboxes = new TextBox[] { txtDNI, txtNom, txtApe };

                    int CI = Array.IndexOf(textboxes, TextBox);
                    int NI = (CI + 1) % textboxes.Length;

                    textboxes[NI].Focus();
                }
                e.Handled = true;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.Modifiers == ModifierKeys.Control)
            {
                if(e.Key == Key.B)
                {
                    int selectedIndex = tbc.SelectedIndex;
                    int tabCount = tbc.Items.Count;
                    selectedIndex = (selectedIndex + 1) % tabCount;
                    tbc.SelectedIndex = selectedIndex;
                }
                else if(e.Key == Key.B && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
                {
                    int selectedIndex = tbc.SelectedIndex;
                    int tabCount = tbc.Items.Count;
                    selectedIndex = (selectedIndex - 1 + tabCount) % tabCount;
                    tbc.SelectedIndex = selectedIndex;
                }
            }
        }

        private void chbBuscador2_Checked(object sender, RoutedEventArgs e)
        {
            cmbBuscador.IsEnabled = true;
        }
        private void chbBuscador2_Unchecked(object sender, RoutedEventArgs e)
        {
            cmbBuscador.IsEnabled = false;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDNI.Text.Trim() == "")
                {
                    MessageBox.Show("Falta DNI y no puede ser Mayor a 8 Digitos!");
                    txtDNI.Focus();
                }
                else if(txtDNI.Text.Trim().Length > 8)
                {
                    MessageBox.Show("Nno puede ser Mayor a 8 Digitos!");
                    txtDNI.Focus();
                }
                else
                {
                    if (txtNom.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta Nombre!");
                        txtNom.Focus();
                    }
                    else
                    {
                        if (txtApe.Text.Trim() == "")
                        {
                            MessageBox.Show("Falta Apellido!");
                            txtApe.Focus();
                        }
                        else
                        {
                            if (dtpFN.Text.Trim() == "")
                            {
                                MessageBox.Show("Falta Fecha de Nacimiento!");
                                dtpFN.Focus();
                            }
                            else
                            {
                                if (dtpFA.Text.Trim() == "")
                                {
                                    MessageBox.Show("Falta Fecha de Alta");
                                    dtpFA.Focus();
                                }
                                else if (dtpFA.SelectedDate > DateTime.Now)
                                {
                                    MessageBox.Show("La Fecha no puede ser mayor a la actual!" + DateTime.Now);
                                    dtpFN.Focus();
                                }
                                else
                                {

                                    int id;
                                    int dni = int.Parse(txtDNI.Text);
                                    string nom = txtNom.Text;
                                    string ape = txtApe.Text;
                                    DateTime fa = dtpFA.SelectedDate.Value;
                                    DateTime fn = dtpFA.SelectedDate.Value;
                                    int carrera = cmbCarrera.SelectedIndex + 1;
                                    int estado = 0;
                                    if (chbEstado.IsChecked == true)
                                    {
                                        estado = 1;
                                    }
                                    int Estado = estado;

                                    if (int.TryParse(txtID.Text, out id))
                                    {
                                        string datos = "UPDATE AlumnosABM SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, FechaAlta = @FechaAlta, FechaNac = @FechaNac, CodClas = @CodClas, Estado = @Estado WHERE ID = @ID";
                                        SqlCommand cmd = new SqlCommand(datos, bdconexion);

                                        cmd.Parameters.AddWithValue("@DNI", dni);
                                        cmd.Parameters.AddWithValue("id", id);
                                        cmd.Parameters.AddWithValue("@Nombre", nom);
                                        cmd.Parameters.AddWithValue("@Apellido", ape);
                                        cmd.Parameters.AddWithValue("@FechaAlta", fa);
                                        cmd.Parameters.AddWithValue("@FechaNac", fn);
                                        cmd.Parameters.AddWithValue("@CodClas", carrera);
                                        cmd.Parameters.AddWithValue("@Estado", Estado);

                                        int fla = cmd.ExecuteNonQuery();
                                        Console.WriteLine(fla);

                                        MessageBox.Show("Modificado correctamente!");
                                        dtgDatos.Items.Refresh();

                                        cancelar();
                                    }
                                }
                            }
                        }
                    }
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
                string datos = "SELECT * FROM AlumnosABM";
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
        void bdTodoBuscador()
        {
            string datos = "SELECT * FROM AlumnosABM";
            SqlDataAdapter adt = new SqlDataAdapter(datos, bdconexion);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            dtgBuscador.ItemsSource = dt.DefaultView;
            dtgBuscador.Items.Refresh();
        }

        private void dtgMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgMostrar.SelectedItem != null)
                {
                    DataRowView dtr = (DataRowView)dtgMostrar.SelectedItem;

                    txtID.Text = dtr["ID"].ToString();
                    txtDNI.Text = dtr["DNI"].ToString();
                    txtNom.Text = dtr["Nombre"].ToString();
                    txtApe.Text = dtr["Apellido"].ToString();
                    dtpFA.Text = dtr["FechaAlta"].ToString();
                    dtpFN.Text = dtr["FechaNac"].ToString();
                    cmbCarrera.SelectedItem = dtr["CodClas"].ToString();
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void CargaID()
        {
            try
            {
                string datos = "SELECT MAX(ID) FROM AlumnosABM";
                SqlCommand cmd = new SqlCommand(datos, bdconexion);

                object res = cmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int ui = Convert.ToInt32(res);
                    int nuevo = ui + 1;

                    txtID.Text = nuevo.ToString();
                }
                else
                {
                    txtID.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void cancelar()
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnNuevo.IsEnabled = true;
            btnLimpiar.IsEnabled = !true;
            btnGuardar.IsEnabled = !true;
            dtgDatos.Visibility = Visibility.Collapsed;

            //txtID.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtApe.Text = string.Empty;
            dtpFA.SelectedDate = DateTime.Now;
            dtpFN.Text = string.Empty;
            dtpFN.SelectedDate = DateTime.Now;
            chbEstado.IsChecked = false;
            cmbCarrera.SelectedIndex = 1;

            gpbRegistro.Visibility = Visibility.Collapsed;
            uno.Visibility = Visibility.Collapsed;
            txtID.Visibility = Visibility.Collapsed;
            dos.Visibility = Visibility.Collapsed;
            txtDNI.Visibility = Visibility.Collapsed;
            tres.Visibility = Visibility.Collapsed;
            txtNom.Visibility = Visibility.Collapsed;
            cuatro.Visibility = Visibility.Collapsed;
            txtApe.Visibility = Visibility.Collapsed;
            cinco.Visibility = Visibility.Collapsed;
            dtpFA.Visibility = Visibility.Collapsed;
            seis.Visibility = Visibility.Collapsed;
            dtpFN.Visibility = Visibility.Collapsed;
            siete.Visibility = Visibility.Collapsed;
            cmbCarrera.Visibility = Visibility.Collapsed;
            chbEstado.Visibility = Visibility.Collapsed;

            opciones.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnLimpiar.Visibility = Visibility.Collapsed;

            btnModificar.Visibility = Visibility.Visible;
            btnActualizar.Visibility = Visibility.Collapsed;

            dtgMostrar.Visibility = Visibility.Visible;
            bdTodo();
        }
    }
}
