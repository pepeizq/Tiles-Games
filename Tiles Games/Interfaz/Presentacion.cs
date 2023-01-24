using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace Interfaz
{
    public static class Presentacion
    {
        public static GridViewItem CreadorBotones(string imagenEnlace, string nombre, bool mostrarNombre)
        {
            Button2 boton = new Button2
            {
                Height = 80,
                Width = 250,
                Padding = new Thickness(20),
                Background = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                Margin = new Thickness(0)
            };

            StackPanel sp = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            ImageEx imagen = new ImageEx
            {
                Source = imagenEnlace,
                IsCacheEnabled = true,
                EnableLazyLoading = true
            };

            sp.Children.Add(imagen);

            if (mostrarNombre == true)
            {
                TextBlock tb = new TextBlock
                {
                    Text = nombre,
                    Margin = new Thickness(20, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap
                };

                sp.Children.Add(tb);
            }

            boton.Content = sp;

            boton.PointerEntered += Animaciones.EntraRatonBoton2;
            boton.PointerExited += Animaciones.SaleRatonBoton2;

            if (nombre != null)
            {
                TextBlock tbTt = new TextBlock
                {
                    Text = nombre
                };

                ToolTipService.SetToolTip(boton, tbTt);
                ToolTipService.SetPlacement(boton, PlacementMode.Bottom);
            }

            GridViewItem item = new GridViewItem
            {
                Content = boton,
                Margin = new Thickness(10)
            };

            return item;
        }
    }
}
