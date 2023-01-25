using CommunityToolkit.WinUI.Notifications;
using Herramientas;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
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

        public static async void PrecargarJuego(string nombre, string ejecutable, string argumentos, string idSteam, 
                                          string plataforma, string imagenAncha, string imagenGrande)
        {
            Pestañas.Visibilidad(ObjetosVentana.gridTilesPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

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
                }
            }
            
        }

        public static async void CargarJuego(object sender, RoutedEventArgs e)
        {
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
            nuevaTile.VisualElements.Square150x150Logo = new Uri("ms-appdata:///local/" + id + "mediana.png");
            nuevaTile.VisualElements.Wide310x150Logo = new Uri("ms-appdata:///local/" + id + "ancha.png");
            nuevaTile.VisualElements.Square310x310Logo = new Uri("ms-appdata:///local/" + id + "grande.png");

            InitializeWithWindow.Initialize(nuevaTile, WindowNative.GetWindowHandle(ObjetosVentana.ventana));

            await nuevaTile.RequestCreateAsync();
        }
    }
}
