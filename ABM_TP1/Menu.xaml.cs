using ABM_TP1.Clases;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string nomusu;
        public Menu()
        {
            InitializeComponent();

            nomusu = usu();
            lblUsu.Content = "Usuario: " + nomusu;

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

        private void btnCarreras_Click(object sender, RoutedEventArgs e)
        {
            ABM_TP1.Carreras c = new ABM_TP1.Carreras();
            c.Show();
        }

        private void btnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            ABM_TP1.MainWindow c = new ABM_TP1.MainWindow();
            c.Show();
        }

        private void btnSalirMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
