using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace ABM_TP1
{
    /// <summary>
    /// Lógica de interacción para VentaRegistro.xaml
    /// </summary>
    public partial class VentaRegistro : Window
    {
        List<Clases.Registro> listaregistro = new List<Clases.Registro>();
        public VentaRegistro()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String nu = txtNomUsu.Text;
                Clases.Registro objeto = listaregistro.Where(n => n.Usu == nu).FirstOrDefault();
                if (objeto == null)
                {
                    objeto = new Clases.Registro();
                    objeto.Nom = txtNom.Text;
                    objeto.Ape = txtApe.Text;
                    objeto.Usu = nu;
                    objeto.Correo = txtCorreo.Text;
                    objeto.Pass = txtPass.Password;

                    listaregistro.Add(objeto);
                }
                else
                {
                    objeto.Nom = txtNom.Text;
                    objeto.Ape = txtApe.Text;
                    objeto.Usu = nu;
                    objeto.Correo = txtCorreo.Text;
                    objeto.Pass = txtPass.Password;
                }

                dtgRegistro.ItemsSource = listaregistro;
                dtgRegistro.Items.Refresh();
                Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void Guardar()
        {
            try
            {
                if (txtNom.Text.Trim() == "")
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
                        if(txtNomUsu.Text.Trim() == "")
                        {
                            MessageBox.Show("Falta Nombre de Ususario!");
                            txtNomUsu.Focus();
                        }
                        else
                        {
                            if(txtCorreo.Text.Trim() == "")
                            {
                                MessageBox.Show("Falta Correo!");
                                txtCorreo.Focus();
                            }
                            else
                            {
                                if(txtPass.Password.Trim() == "")
                                {
                                    MessageBox.Show("Falta Contraseña!");
                                    txtPass.Focus();
                                }
                                else
                                {
                                    if (File.Exists("Registro.txt"))
                                    {
                                        File.Delete("Registro.txt");
                                    }
                                    string RC = "";
                                    foreach (Clases.Registro objeto in listaregistro)
                                    {
                                        RC = RC + "\n" + objeto.Nom + ";" + objeto.Ape + ";" + objeto.Usu + ";" + objeto.Correo + ";" + objeto.Pass;
                                    }
                                    File.WriteAllText("Registro.txt", RC);
                                    MessageBox.Show("Almacenado exitosamente!", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                }                
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtNom_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Tab)
                {
                    var TextBox = sender as TextBox;

                    if (TextBox != null)
                    {
                        var textboxes = new TextBox[] { txtNom, txtApe, txtNomUsu, txtCorreo };

                        int CI = Array.IndexOf(textboxes, TextBox);
                        int NI = (CI + 1) % textboxes.Length;

                        textboxes[NI].Focus();
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string nom = txtNom.Text;
                string ape = txtApe.Text;
                string usu = txtNomUsu.Text;
                string correo = txtCorreo.Text;

                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(ape) || string.IsNullOrEmpty(usu) || string.IsNullOrEmpty(correo))
                {
                    MessageBox.Show("Se deben completar todos los campos");
                }
                else
                {
                    if (e.Key == Key.Enter)
                    { 
                        String nu = txtNomUsu.Text;
                        Clases.Registro objeto = listaregistro.Where(n => n.Usu == nu).FirstOrDefault();
                        if (objeto == null)
                        {
                            objeto = new Clases.Registro();
                            objeto.Nom = txtNom.Text;
                            objeto.Ape = txtApe.Text;
                            objeto.Usu = nu;
                            objeto.Correo = txtCorreo.Text;
                            objeto.Pass = txtPass.Password;

                            listaregistro.Add(objeto);
                        }
                        else
                        {
                            objeto.Nom = txtNom.Text;
                            objeto.Ape = txtApe.Text;
                            objeto.Usu = nu;
                            objeto.Correo = txtCorreo.Text;
                            objeto.Pass = txtPass.Password;
                        }

                        dtgRegistro.ItemsSource = listaregistro;
                        dtgRegistro.Items.Refresh();
                        Guardar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
