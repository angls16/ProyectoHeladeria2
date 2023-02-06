using Newtonsoft.Json;
using ProyectoHeladeria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
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
        //private readonly HttpClient client = new HttpClient();
        //public ObservableCollection<Usuario> _inicioSesion;
        //consulta selecccionar id donde idUsuario = iUsuario
        private readonly HttpClient venta = new HttpClient();
        public ObservableCollection<Ventas> _post;
        public int idVentas = -1, Usuario_idUsuario, Cliente_idCliente;
        public string numeroVenta, fecha;
        // traer el idvENTA
        public int IdVentas;
        //// Insertar Detalle Venta 
        private const string UrlDetalle = "http://192.168.56.1/heladeria/postDetalles.php";
        // Insertar Venta Final
        public double PrecioFinal;




        public DetalleVentas(int idProducto, string nombreProducto, string adereso, double precio,string sabor,int idUsuario,int idVenta )
        {
            InitializeComponent();
            entIdProducto.Text = idProducto.ToString();
            entNombreProducto.Text = nombreProducto.ToString();
            entAdereso.Text = adereso.ToString();
            entPrecio.Text = precio.ToString(); 
            entSabor.Text = sabor.ToString();
            Usuario_idUsuario = idUsuario;
            IdVentas= idVenta;
            // id venta
            lblNVenta.Text = idVenta.ToString();
           
           
        }

        
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            //calcular costos por producto
            double cantidad = double.Parse(lblCantidad.Text);

            //double precioUnitario = Convert.ToDouble(entPrecio.Text)
            double precioUnitario = double.Parse(entPrecio.Text);
            
            double precioTotal = cantidad * precioUnitario ;
            PrecioFinal = precioTotal+PrecioFinal;
            //Calcular precio por producto

            //Insertar en la base 



            // await Navigation.PushAsync(new ListaProducto(Usuario_idUsuario,IdVentas));
            //////////////////////////////
            WebClient detalle = new WebClient();
            try
            {
                var parameters = new System.Collections.Specialized.NameValueCollection();
                
                parameters.Add("idDetalleVentas", "");
                parameters.Add("Productos_idProductos", entIdProducto.Text);
                parameters.Add("Ventas_idVentas", IdVentas.ToString());
                parameters.Add("cantidad", lblCantidad.Text);
                parameters.Add("precio_venta", PrecioFinal.ToString().Replace(",","."));
                //parameters.Add("precio_venta", precioTotal.ToString().Replace(",","."));


                detalle.UploadValues(UrlDetalle, "POST", parameters);
                //entPrecioFinal.Text=PrecioFinal.ToString();
                //await DisplayAlert("Agregado Correctamente ", precioTotal.ToString().Replace(",", "."), " Ok");
                //await DisplayAlert("Agregado Correctamente ", PrecioFinal.ToString().Replace(",", "."), " Ok");
                // await Navigation.PushAsync(new Login());
                //await DisplayAlert("Sucess", "Registro Ingresado del Usuario: " + entNombres.Text + " " + entApellidos.Text, " Cerrar ");
                // Limpiar();


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta ", ex.Message, " Cancelar ");
                //mostrar errores en consola
                Console.WriteLine(ex.Message, "error");
            }
            ///////////////


        }
        private async void btnCompra_Clicked(object sender, EventArgs e)
        {

            IdVentas = 0;
            await Navigation.PushAsync(new ListaProducto(Usuario_idUsuario, IdVentas));
            /// Insertar venta

        }




    }
}