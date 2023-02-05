using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoHeladeria.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleVentas : ContentPage
    {
        
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
        }
    }
}