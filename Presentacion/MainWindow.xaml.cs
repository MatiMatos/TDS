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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Negocio;
using Datos;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Categoria
        CategoriaBLL catBLL = new CategoriaBLL();
        //Tarea
        TareaBLL taBLL = new TareaBLL();
        public MainWindow()
        {
            InitializeComponent();
            CargarCategoria();
            CargarTarea();
            cmbEstado.ItemsSource = Enum.GetValues(typeof(Estado));
        }

        private void CargarCategoria()
        {
            lstCategorias.ItemsSource = null;
            lstCategorias.ItemsSource = catBLL.GetAll();
        }

        private void CargarTarea()
        {
            lstTareas.ItemsSource = null;
            lstTareas.ItemsSource = taBLL.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string categoria = txtNuevaCategoria.Text;
            //validar
            catBLL.Add(categoria);
            //Mensaje

            txtNuevaCategoria.Text = String.Empty;
            CargarCategoria();
        }

        private void BtnAgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string cuerpo = txtCuerpo.Text;
            DateTime fechaCreacion = (DateTime)dpFechaCreacion.SelectedDate;
            int estado = (int)cmbEstado.SelectedValue;

            taBLL.Add(titulo, cuerpo, fechaCreacion, estado);

            CargarTarea();
        }
    }
}
