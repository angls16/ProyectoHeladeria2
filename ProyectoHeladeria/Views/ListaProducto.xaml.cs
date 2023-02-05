using Newtonsoft.Json;
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
    public partial class ListaProducto : ContentPage
    {
        private const string Url = "http://192.168.1.12/heladeria/postProductos.php";

        private readonly HttpClient client = new HttpClient();
        public ObservableCollection<Productos> _post;
        public int idProductos = -1;
        public string nombreProducto, adereso,sabor,imagen;

        public double precio;

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (idProductos > 0)
            {
                await Navigation.PushAsync(new DetalleVentas(idProductos, nombreProducto,adereso,precio,sabor));
            }
            else {
                await DisplayAlert("Alerta", "No se ha seleccionado ", "OK");
            }
            
        }

        private void lstProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemSelected = e.CurrentSelection[0] as Productos;
            idProductos = itemSelected.idProductos;
            nombreProducto= itemSelected.nombreProducto;
            adereso= itemSelected.adereso;
            sabor= itemSelected.sabor;
            precio = itemSelected.costo;
            //imagen= itemSelected.imagen;
        }

        
        public ListaProducto()
        {
            InitializeComponent();
            Get();
        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Productos> post =
                    JsonConvert.DeserializeObject<List<Productos>>(content);
                _post = new ObservableCollection<Productos>(post);
                lstProductos.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}