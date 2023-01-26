using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using System;
using Windows.UI.StartScreen;
using WinRT.Interop;
using static Tiles_Games.MainWindow;

namespace Interfaz
{
    public static class Tiles
    {
        public static void Cargar()
        { 
            ObjetosVentana.tbTilesPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            ObjetosVentana.tbTilesPrecargaImagenMediana.TextChanged += ActualizarImagenMediana;
            ObjetosVentana.tbTilesPrecargaImagenAncha.TextChanged += ActualizarImagenAncha;
            ObjetosVentana.tbTilesPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            ObjetosVentana.imagenTilesPrecargaPequeña.ImageExFailed += ImagenPequeñaFalla;
            ObjetosVentana.imagenTilesPrecargaMediana.ImageExFailed += ImagenMedianaFalla;
            ObjetosVentana.imagenTilesPrecargaAncha.ImageExFailed += ImagenAnchaFalla;
            ObjetosVentana.imagenTilesPrecargaGrande.ImageExFailed += ImagenGrandeFalla;

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
        private static void ActualizarImagenPequeña(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaPequeña.Source = tb.Text;
            }
            catch { }
        }

        private static void ActualizarImagenMediana(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaMediana.Source = tb.Text;
            }
            catch { }
        }

        private static void ActualizarImagenAncha(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaAncha.Source = tb.Text;
            }
            catch { }           
        }

        private static void ActualizarImagenGrande(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                ObjetosVentana.imagenTilesPrecargaGrande.Source = tb.Text;
            }
            catch { }
        }

        private static void ImagenPequeñaFalla(object sender, ImageExFailedEventArgs e) 
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
        }

        private static void ImagenMedianaFalla(object sender, ImageExFailedEventArgs e)
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
        }

        private static void ImagenAnchaFalla(object sender, ImageExFailedEventArgs e)
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
        }

        private static void ImagenGrandeFalla(object sender, ImageExFailedEventArgs e)
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
        }

        private static void EstiramientoPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña);
        }

        private static void EstiramientoMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana);
        }

        private static void EstiramientoAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha);
        }

        private static void EstiramientoGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande);
        }

        private static void EstiramientoImagen(ComboBox2 cb, ImageEx imagen)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen.Stretch = Stretch.None;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen.Stretch = Stretch.Fill;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen.Stretch = Stretch.Uniform;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen.Stretch = Stretch.UniformToFill;
            }
        }

        private static void OrientacionHorizontalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña);
        }

        private static void OrientacionHorizontalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana);
        }

        private static void OrientacionHorizontalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha);
        }

        private static void OrientacionHorizontalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande);
        }

        private static void OrientacionHorizontalImagen(ComboBox2 cb, ImageEx imagen)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
        }

        private static void OrientacionVerticalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaPequeña);
        }

        private static void OrientacionVerticalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaMediana);
        }

        private static void OrientacionVerticalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaAncha);
        }

        private static void OrientacionVerticalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, ObjetosVentana.imagenTilesPrecargaGrande);
        }

        private static void OrientacionVerticalImagen(ComboBox2 cb, ImageEx imagen)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen.VerticalAlignment = VerticalAlignment.Top;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen.VerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen.VerticalAlignment = VerticalAlignment.Stretch;
            }
        }

        public static async void PrecargarJuego(string nombre, string ejecutable, string argumentos, string idSteam, 
                                          string plataforma, string imagenAncha, string imagenGrande)
        {
            ActivarDesactivar(false);

            Pestañas.Visibilidad(ObjetosVentana.gridTilesPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            //-------------------------------------------------

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

            //-------------------------------------------------

            string id = plataforma + "_" + idSteam;
            ObjetosVentana.tbTilesPrecargaTitulo.Tag = id;

            ObjetosVentana.tbTilesPrecargaTitulo.Text = nombre;
            ObjetosVentana.tbTilesPrecargaEjecutable.Text = ejecutable;
            ObjetosVentana.tbTilesPrecargaArgumentos.Text = argumentos;

            ObjetosVentana.tbTilesPrecargaImagenAncha.Text = imagenAncha;
            ObjetosVentana.tbTilesPrecargaImagenGrande.Text = imagenGrande;
            ObjetosVentana.imagenTilesPrecargaAncha.Source = ObjetosVentana.tbTilesPrecargaImagenAncha.Text;
            ObjetosVentana.imagenTilesPrecargaGrande.Source = ObjetosVentana.tbTilesPrecargaImagenGrande.Text;

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

            ObjetosVentana.cbTilesPrecargaMedianaEstiramiento.SelectedIndex = 2;
            ObjetosVentana.imagenTilesPrecargaMediana.Stretch = Stretch.Uniform;

            ObjetosVentana.cbTilesPrecargaAnchaEstiramiento.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.Stretch = Stretch.UniformToFill;

            ObjetosVentana.cbTilesPrecargaGrandeEstiramiento.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.Stretch = Stretch.UniformToFill;

            //-------------------------------------------------

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaPequeña.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaMedianaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaMediana.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaAnchaOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.HorizontalAlignment = HorizontalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaGrandeOrientacionHorizontal.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.HorizontalAlignment = HorizontalAlignment.Stretch;

            //-------------------------------------------------

            ObjetosVentana.cbTilesPrecargaPequeñaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaPequeña.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaMedianaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaMediana.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaAnchaOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaAncha.VerticalAlignment = VerticalAlignment.Stretch;

            ObjetosVentana.cbTilesPrecargaGrandeOrientacionVertical.SelectedIndex = 3;
            ObjetosVentana.imagenTilesPrecargaGrande.VerticalAlignment = VerticalAlignment.Stretch;

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
        }
    }
}
