using ProyectoHeladeria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoHeladeria.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleVentas : ContentPage
    {

        private const string Url = "http://192.168.56.1/heladeria/postVentas.php";
        //consulta selecccionar id donde idUsuario = iUsuario
        private readonly HttpClient venta = new HttpClient();
        public ObservableCollection<Ventas> _post;
        public int idVentas = -1, Usuario_idUsuario, Cliente_idCliente;
        public string numeroVenta, fecha;
        public double precioTotal;

        public DetalleVentas(int idProducto, string nombreProducto, string adereso, double precio,string sabor )
        {
            InitializeComponent();
            entIdProducto.Text = idProducto.ToString();
            entNombreProducto.Text = nombreProducto.ToString();
            entAdereso.Text = adereso.ToString();
            entPrecio.Text = precio.ToString(); 
            entSabor.Text = sabor.ToString();   

           
           
        }

        
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaProducto());
            //agrgar a DetalleVenta
            //id venta
            // id Detalle Venta
            //id producto -------
            //cantidad 
            //precio venta
        }

        private void btnCompra_Clicked(object sender, EventArgs e)
        {

        }
    }
}