using ABM_TP1.Clases;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para VentanaInicio.xaml
    /// </summary>
    public partial class VentanaInicio : Window
    {
        public VentanaInicio()
        {
            InitializeComponent();

            btnRegistro.FocusVisualStyle = null;
            btnRegistro.Background = Brushes.Transparent;
            btnRegistro.BorderBrush = Brushes.Transparent;
            btnRegistro.Foreground = Brushes.Blue;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            ABM_TP1.VentaRegistro c = new ABM_TP1.VentaRegistro();
            c.Show();

        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show("Falta Usuario");
                }
                else if (txtPass.Password.Trim() == "")
                {
                    MessageBox.Show("Falta Contraseña");
                }
                else 
                { 
                    ClasesPublicas.LeerArchivoRegistro();
                    Registro reg = ClasesPublicas.listaregistro.FirstOrDefault();

                    if ((reg.Nom == txtUsuario.Text || reg.Usu == txtUsuario.Text || reg.Correo == txtUsuario.Text) && reg.Pass == txtPass.Password)
                    {
                        ABM_TP1.Menu c = new ABM_TP1.Menu();
                        c.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos! :'(", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtUsuario.Foreground = Brushes.Black;
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (txtUsuario.Text.Trim() == "" && txtPass.Password.Trim() == "")
                {
                    MessageBox.Show("Uno de los campos esta vacio");
                }
                else
                {
                    ClasesPublicas.LeerArchivoRegistro();
                    Registro reg = ClasesPublicas.listaregistro.FirstOrDefault();

                    if ((reg.Nom == txtUsuario.Text || reg.Usu == txtUsuario.Text || reg.Correo == txtUsuario.Text) && reg.Pass == txtPass.Password)
                    {
                        ABM_TP1.Menu c = new ABM_TP1.Menu();
                        c.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos! :'(", "Aplicación", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPass.Password = string.Empty;
        }
    }
}
