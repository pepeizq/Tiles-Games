using CommunityToolkit.WinUI.Notifications;
using CommunityToolkit.WinUI.UI.Controls;
using FontAwesome6;
using Herramientas;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.VisualBasic;
using System;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using WinRT.Interop;
using static Tiles_Games.MainWindow;

namespace Interfaz
{
    public static class Tiles
    {
        public static void Cargar()
        {
            int i = 0;
            foreach (Button2 boton in ObjetosVentana.spTilesBotones.Children)
            {
                boton.Tag = i;
                boton.Click += CambiarPestaña;
                boton.PointerEntered += Animaciones.EntraRatonBoton2;
                boton.PointerExited += Animaciones.SaleRatonBoton2;

                i += 1;
            }

            CambiarPestaña(0);

            //---------------------------------

            ObjetosVentana.tbTilesPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            ObjetosVentana.tbTilesPrecargaImagenMediana.TextChanged += ActualizarImagenMediana;
            ObjetosVentana.tbTilesPrecargaImagenAncha.TextChanged += ActualizarImagenAncha;
            ObjetosVentana.tbTilesPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            ObjetosVentana.imagenTilesPrecargaPequeña.ImageOpened += ImagenPequeñaCarga;
            ObjetosVentana.imagenTilesPrecargaPequeña.ImageFailed += ImagenPequeñaFalla;
            ObjetosVentana.imagenTilesPrecargaMediana.ImageOpened += ImagenMedianaCarga;
            ObjetosVentana.imagenTilesPrecargaMediana.ImageFailed += ImagenMedianaFalla;
            ObjetosVentana.imagenTilesPrecargaAncha.ImageOpened += ImagenAnchaCarga;
            ObjetosVentana.imagenTilesPrecargaAncha.ImageFailed += ImagenAnchaFalla;
            ObjetosVentana.imagenTilesPrecargaGrande.ImageOpened += ImagenGrandeCarga;
            ObjetosVentana.imagenTilesPrecargaGrande.ImageFailed += ImagenGrandeFalla;

            ObjetosVentana.cbTilesPrecargaPequeñaEstiramiento.SelectionChanged += EstiramientoPequeñaCambio;
            ObjetosVentana.cbTilesPrecargaPequeñaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaPequeñaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.SelectionChanged += EstiramientoMedianaCambio;
            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.SelectionChanged += EstiramientoAnchaCambio;
            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.SelectionChanged += EstiramientoGrandeCambio;
            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalPequeñaCambio;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalMedianaCambio;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalAnchaCambio;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.SelectionChanged += OrientacionHorizontalGrandeCambio;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.SelectionChanged += OrientacionVerticalPequeñaCambio;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.SelectionChanged += OrientacionVerticalMedianaCambio;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.SelectionChanged += OrientacionVerticalAnchaCambio;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.SelectionChanged += OrientacionVerticalGrandeCambio;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.botonTilesCargarJuego.Click += CargarJuego;
            ObjetosVentana.botonTilesCargarJuego.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonTilesCargarJuego.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void CambiarPestaña(object sender, RoutedEventArgs e)
        {
            Button2 botonPulsado = sender as Button2;
            int pestañaMostrar = (int)botonPulsado.Tag;
            CambiarPestaña(pestañaMostrar);
        }

        private static void CambiarPestaña(int botonPulsado)
        {
            SolidColorBrush colorPulsado = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
            colorPulsado.Opacity = 0.6;

            int i = 0;
            foreach (Button2 boton in ObjetosVentana.spTilesBotones.Children)
            {
                if (i == botonPulsado)
                {
                    boton.Background = colorPulsado;
                }
                else
                {
                    boton.Background = new SolidColorBrush(Colors.Transparent);
                }

                i += 1;
            }

            foreach (StackPanel sp in ObjetosVentana.spTilesPestañas.Children)
            {
                sp.Visibility = Visibility.Collapsed;
            }

            StackPanel spMostrar = ObjetosVentana.spTilesPestañas.Children[botonPulsado] as StackPanel;
            spMostrar.Visibility = Visibility.Visible;
        }
        private static void ActualizarImagenPequeña(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaPequeña.Source = new BitmapImage(new Uri(tb.Text));
                ObjetosVentana.imagenTilesPrecargaPequeña2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ActualizarImagenMediana(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaMediana.Source = new BitmapImage(new Uri(tb.Text));
                ObjetosVentana.imagenTilesPrecargaMediana2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ActualizarImagenAncha(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaAncha.Source = new BitmapImage(new Uri(tb.Text));
                ObjetosVentana.imagenTilesPrecargaAncha2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }           
        }

        private static void ActualizarImagenGrande(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaGrande.Source = new BitmapImage(new Uri(tb.Text));
                ObjetosVentana.imagenTilesPrecargaGrande2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ImagenPequeñaCarga(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenPequeñaFalla(object sender, ExceptionRoutedEventArgs e) 
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                ObjetosVentana.tbTilesPrecargaImagenPequeña.Text = null;
            }
            catch { }

            ObjetosVentana.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenMedianaCarga(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenMedianaFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                ObjetosVentana.tbTilesPrecargaImagenMediana.Text = null;
            }
            catch { }

            ObjetosVentana.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenAnchaCarga(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenAnchaFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                ObjetosVentana.tbTilesPrecargaImagenAncha.Text = null;
            }
            catch { }

            ObjetosVentana.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenGrandeCarga(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenGrandeFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                ObjetosVentana.tbTilesPrecargaImagenGrande.Text = null;
            }
            catch { }

            ObjetosVentana.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void EstiramientoPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña, ObjetosVentana.imagenTilesPrecargaPequeña2);
        }

        private static void EstiramientoMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana, ObjetosVentana.imagenTilesPrecargaMediana2);
        }

        private static void EstiramientoAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha, ObjetosVentana.imagenTilesPrecargaAncha2);
        }

        private static void EstiramientoGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande, ObjetosVentana.imagenTilesPrecargaGrande2);
        }

        private static void EstiramientoImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.Stretch = Stretch.None;
                imagen2.Stretch = Stretch.None;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.Stretch = Stretch.Fill;
                imagen2.Stretch = Stretch.Fill;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.Stretch = Stretch.Uniform;
                imagen2.Stretch = Stretch.Uniform;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.Stretch = Stretch.UniformToFill;
                imagen2.Stretch = Stretch.UniformToFill;
            }
        }

        private static void OrientacionHorizontalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña, ObjetosVentana.imagenTilesPrecargaPequeña2);
        }

        private static void OrientacionHorizontalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana, ObjetosVentana.imagenTilesPrecargaMediana2);
        }

        private static void OrientacionHorizontalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha, ObjetosVentana.imagenTilesPrecargaAncha2);
        }

        private static void OrientacionHorizontalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande, ObjetosVentana.imagenTilesPrecargaGrande2);
        }

        private static void OrientacionHorizontalImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Left;
                imagen2.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Center;
                imagen2.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Right;
                imagen2.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Stretch;
                imagen2.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
        }

        private static void OrientacionVerticalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña, ObjetosVentana.imagenTilesPrecargaPequeña2);
        }

        private static void OrientacionVerticalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana, ObjetosVentana.imagenTilesPrecargaMediana2);
        }

        private static void OrientacionVerticalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha, ObjetosVentana.imagenTilesPrecargaAncha2);
        }

        private static void OrientacionVerticalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande, ObjetosVentana.imagenTilesPrecargaGrande2);
        }

        private static void OrientacionVerticalImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Top;
                imagen2.VerticalAlignment = VerticalAlignment.Top;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Center;
                imagen2.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Bottom;
                imagen2.VerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Stretch;
                imagen2.VerticalAlignment = VerticalAlignment.Stretch;
            }
        }

        public static async void PrecargarJuego(string nombre, string ejecutable, string argumentos, string idSteam, 
                                          string plataforma, string imagenAncha, string imagenGrande)
        {
            ActivarDesactivar(false);

            Pestañas.Visibilidad(ObjetosVentana.gridTilesPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            //-------------------------------------------------

            ObjetosVentana.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Xmark;
            ObjetosVentana.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Xmark;
            ObjetosVentana.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Xmark;
            ObjetosVentana.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Xmark;

            ObjetosVentana.tbTilesPrecargaTitulo.Text = null;
            ObjetosVentana.tbTilesPrecargaEjecutable.Text = null;
            ObjetosVentana.tbTilesPrecargaArgumentos.Text = null;
            ObjetosVentana.tbTilesPrecargaImagenPequeña.Text = null; 
            ObjetosVentana.tbTilesPrecargaImagenMediana.Text = null;
            ObjetosVentana.tbTilesPrecargaImagenAncha.Text = null;
            ObjetosVentana.tbTilesPrecargaImagenGrande.Text = null;
            ObjetosVentana.imagenTilesPrecargaPequeña.Source = null;
            ObjetosVentana.imagenTilesPrecargaMediana.Source = null;
            ObjetosVentana.imagenTilesPrecargaAncha.Source = null;
            ObjetosVentana.imagenTilesPrecargaGrande.Source = null;
            ObjetosVentana.imagenTilesPrecargaPequeña2.Source = null;
            ObjetosVentana.imagenTilesPrecargaMediana2.Source = null;
            ObjetosVentana.imagenTilesPrecargaAncha2.Source = null;
            ObjetosVentana.imagenTilesPrecargaGrande2.Source = null;

            //-------------------------------------------------

            string id = plataforma + "_" + idSteam;
            ObjetosVentana.tbTilesPrecargaTitulo.Tag = id;

            ObjetosVentana.tbTilesPrecargaTitulo.Text = nombre;
            ObjetosVentana.tbTilesPrecargaEjecutable.Text = ejecutable;
            ObjetosVentana.tbTilesPrecargaArgumentos.Text = argumentos;

            ObjetosVentana.tbTilesPrecargaImagenAncha.Text = imagenAncha;
            ObjetosVentana.tbTilesPrecargaImagenGrande.Text = imagenGrande;
            ObjetosVentana.imagenTilesPrecargaAncha.Source = new BitmapImage(new Uri(ObjetosVentana.tbTilesPrecargaImagenAncha.Text)); 
            ObjetosVentana.imagenTilesPrecargaGrande.Source = new BitmapImage(new Uri(ObjetosVentana.tbTilesPrecargaImagenGrande.Text));
            ObjetosVentana.imagenTilesPrecargaAncha2.Source = new BitmapImage(new Uri(ObjetosVentana.tbTilesPrecargaImagenAncha.Text));
            ObjetosVentana.imagenTilesPrecargaGrande2.Source = new BitmapImage(new Uri(ObjetosVentana.tbTilesPrecargaImagenGrande.Text));

            if (idSteam != null)
            {
                if (idSteam.Trim().Length > 0)
                {
                    string html = await Decompiladores.CogerHtml("https://store.steampowered.com/app/" + idSteam + "/");

                    if (html != null)
                    {
                        if (html.Contains("<div class=" + Strings.ChrW(34) + "apphub_AppIcon") == true)
                        {
                            int int1 = html.IndexOf("<div class=" + Strings.ChrW(34) + "apphub_AppIcon");
                            string temp1 = html.Remove(0, int1);

                            int1 = temp1.IndexOf("<img src=");
                            temp1 = temp1.Remove(0, int1 + 10);

                            int int2 = temp1.IndexOf(Strings.ChrW(34));
                            string temp2 = temp1.Remove(int2, temp1.Length - int2);

                            temp2 = temp2.Replace("%CDN_HOST_MEDIA_SSL%", "steamcdn-a.akamaihd.net");

                            ObjetosVentana.tbTilesPrecargaImagenPequeña.Text = temp2.Trim();
                        }
                    }

                    ObjetosVentana.tbTilesPrecargaImagenMediana.Text = "https://cdn.cloudflare.steamstatic.com/steam/apps/" + idSteam + "/logo.png";
                }
            }

            //-------------------------------------------------

            ObjetosVentana.cbTilesPrecargaPequeñaEstiramiento.SelectedIndex = 2;
            ObjetosVentana.imagenTilesPrecargaPequeña.Stretch = Stretch.Uniform;
            ObjetosVentana.imagenTilesPrecargaPequeña2.Stretch = Stretch.Uniform;

            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.SelectedIndex = 2;
            ObjetosVentana.imagenTilesPrecargaMediana.Stretch = Stretch.Uniform;
            ObjetosVentana.imagenTilesPrecargaMediana2.Stretch = Stretch.Uniform;

            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.Stretch = Stretch.UniformToFill;
            ObjetosVentana.imagenTilesPrecargaAncha2.Stretch = Stretch.UniformToFill;

            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.Stretch = Stretch.UniformToFill;
            ObjetosVentana.imagenTilesPrecargaGrande2.Stretch = Stretch.UniformToFill;

            //-------------------------------------------------

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaPequeña.HorizontalAlignment = HorizontalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaPequeña2.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaMediana.HorizontalAlignment = HorizontalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaMediana2.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.HorizontalAlignment = HorizontalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaAncha2.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.HorizontalAlignment = HorizontalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaGrande2.HorizontalAlignment = HorizontalAlignment.Stretch;

            //-------------------------------------------------

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaPequeña.VerticalAlignment = VerticalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaPequeña2.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaMediana.VerticalAlignment = VerticalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaMediana2.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.VerticalAlignment = VerticalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaAncha2.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.VerticalAlignment = VerticalAlignment.Stretch;
            ObjetosVentana.imagenTilesPrecargaGrande2.VerticalAlignment = VerticalAlignment.Stretch;

            ActivarDesactivar(true);
        }

        public static async void CargarJuego(object sender, RoutedEventArgs e)
        {
            ActivarDesactivar(false);

            string id = ObjetosVentana.tbTilesPrecargaTitulo.Tag as string;

            await Imagen.Generar(ObjetosVentana.gridTilesPrecargaImagenPequeña, id + "pequena.png", 44, 44);
            await Imagen.Generar(ObjetosVentana.gridTilesPrecargaImagenMediana, id + "mediana.png", 150, 150);
            await Imagen.Generar(ObjetosVentana.gridTilesPrecargaImagenAncha, id + "ancha.png", 310, 150);
            await Imagen.Generar(ObjetosVentana.gridTilesPrecargaImagenGrande, id + "grande.png", 310, 310);

            string titulo = ObjetosVentana.tbTilesPrecargaTitulo.Text;
            string enlace = ObjetosVentana.tbTilesPrecargaEjecutable.Text;

            if (ObjetosVentana.tbTilesPrecargaArgumentos.Text.Trim().Length > 0)
            {
                enlace = enlace + " " + ObjetosVentana.tbTilesPrecargaArgumentos.Text;
            }

            SecondaryTile nuevaTile = new SecondaryTile(id, titulo, enlace, new Uri("ms-appdata:///local/" + id + "ancha.png"), Windows.UI.StartScreen.TileSize.Wide310x150);
            nuevaTile.VisualElements.Square44x44Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square30x30Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square70x70Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square71x71Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square150x150Logo = new Uri("ms-appdata:///local/" + id + "mediana.png");
            nuevaTile.VisualElements.Wide310x150Logo = new Uri("ms-appdata:///local/" + id + "ancha.png");
            nuevaTile.VisualElements.Square310x310Logo = new Uri("ms-appdata:///local/" + id + "grande.png");
  
            InitializeWithWindow.Initialize(nuevaTile, WindowNative.GetWindowHandle(ObjetosVentana.ventana));

            await nuevaTile.RequestCreateAsync();

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoMediano = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenMediano = new TileBackgroundImage
            {
                Source = "ms-appdata:///local/" + id + "mediana.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoMediano = new TileBindingContentAdaptive
            {
                BackgroundImage = fondoImagenMediano
            };

            TileBinding tileMediano = new TileBinding {
                Content = contenidoMediano
            };

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoAncho = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenAncha = new TileBackgroundImage 
            {
                Source = "ms-appdata:///local/" + id + "ancha.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoAncho = new TileBindingContentAdaptive 
            {
                BackgroundImage = fondoImagenAncha
            };

            TileBinding tileAncha = new TileBinding 
            {
                Content = contenidoAncho
            };

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoGrande = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenGrande = new TileBackgroundImage 
            {
                Source = "ms-appdata:///local/" + id + "grande.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoGrande = new TileBindingContentAdaptive 
            {
                BackgroundImage = fondoImagenGrande
            };

            TileBinding tileGrande = new TileBinding 
            {
                Content = contenidoGrande
            };

            //-----------------------------------------------

            TileVisual visual = new TileVisual
            {
                TileMedium = tileMediano,
                TileWide = tileAncha,
                TileLarge = tileGrande
            };

            TileContent contenido = new TileContent
            {
                Visual = visual
            };

            TileNotification notificacion = new TileNotification(contenido.GetXml());

            try
            {
                TileUpdateManager.CreateTileUpdaterForSecondaryTile(id).Update(notificacion);
            }
            catch { }

            ActivarDesactivar(true);
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.tbTilesPrecargaTitulo.IsEnabled = estado;
            ObjetosVentana.tbTilesPrecargaEjecutable.IsEnabled = estado;
            ObjetosVentana.tbTilesPrecargaArgumentos.IsEnabled = estado;

            ObjetosVentana.tbTilesPrecargaImagenPequeña.IsEnabled = estado;
            ObjetosVentana.tbTilesPrecargaImagenMediana.IsEnabled = estado;
            ObjetosVentana.tbTilesPrecargaImagenAncha.IsEnabled = estado;
            ObjetosVentana.tbTilesPrecargaImagenGrande.IsEnabled = estado;

            ObjetosVentana.cbTilesPrecargaPequeñaEstiramiento.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.IsEnabled = estado;
            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.IsEnabled = estado;

            ObjetosVentana.botonTilesCargarJuego.IsEnabled = estado;
        }
    }
}
