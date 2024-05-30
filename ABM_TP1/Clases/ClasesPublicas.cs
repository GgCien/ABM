using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ABM_TP1.Clases
{
    internal class ClasesPublicas
    {
        public static List<Clases.Registro> listaregistro = new List<Clases.Registro>();

        public static void LeerArchivoRegistro()
        {
            try
            {
                if (File.Exists("Registro.txt"))
                {
                    listaregistro = new List<Clases.Registro>();
                    Clases.Registro objeto;
                    string TxtCompleto = File.ReadAllText("Registro.txt");
                    char[] delims = new[] { '\n' };
                    string[] lineas = TxtCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                    foreach(string fila in lineas)
                    {
                        objeto = new Clases.Registro();
                        string[] valores = fila.Split(';');
                        int i = 0;

                        foreach (string val in valores)
                        {
                            if (i == 0)
                            {
                                objeto.Nom = val;
                            }
                            else if (i == 1)
                            {
                                objeto.Ape = val;
                            }
                            else if (i == 2)
                            {
                                objeto.Usu = val;
                            }
                            else if (i == 3)
                            {
                                objeto.Correo = val;
                            }
                            else if (i == 4)
                            {
                                objeto.Pass = val;
                            }
                            i++;
                        }
                        listaregistro.Add(objeto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message, "Aplicación ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
