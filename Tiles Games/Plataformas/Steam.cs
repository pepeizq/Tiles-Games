using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using static Tiles_Games.MainWindow;

namespace Plataformas
{
    public static class Steam
    {
        public static string dominioImagenes = "https://cdn.cloudflare.steamstatic.com";

        public static void Cargar()
        {
            CambiarSubPestañaInstalados();

            ObjetosVentana.botonSteamJuegosInstalados.Click += CambiarSubPestañaInstalados;
            ObjetosVentana.botonSteamJuegosInstalados.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonSteamJuegosInstalados.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonSteamCualquierJuego.Click += CambiarSubPestañaCualquiera;
            ObjetosVentana.botonSteamCualquierJuego.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonSteamCualquierJuego.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.tbSteamCualquierJuego.TextChanged += EnlaceCualquierJuegoTextoCambia;
        }

        private static void CambiarSubPestañaInstalados(object sender, RoutedEventArgs e)
        {
            CambiarSubPestañaInstalados();
        }

        private static void CambiarSubPestañaInstalados()
        {
            ObjetosVentana.gridSteamJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gridSteamCualquierJuego.Visibility = Visibility.Collapsed;

            ObjetosVentana.botonSteamJuegosInstalados.BorderThickness = new Thickness(0, 0, 0, 1);
            ObjetosVentana.botonSteamCualquierJuego.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private static void CambiarSubPestañaCualquiera(object sender, RoutedEventArgs e)
        {
            CambiarSubPestañaCualquiera();
        }

        private static void CambiarSubPestañaCualquiera()
        {
            ObjetosVentana.gridSteamJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.gridSteamCualquierJuego.Visibility = Visibility.Visible;

            ObjetosVentana.botonSteamJuegosInstalados.BorderThickness = new Thickness(0, 0, 0, 0);
            ObjetosVentana.botonSteamCualquierJuego.BorderThickness = new Thickness(0, 0, 0, 1);
        }

        public async static void CargarJuegosInstalados()
        {
            ActivarDesactivar(false);

            ObjetosVentana.prSteamJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvSteamJuegosInstalados.Visibility = Visibility.Collapsed;

            string contenidoLibreria = string.Empty;

            try
            {
                RegistryKey registro = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
                string carpetaSteam = registro.GetValue("SteamPath").ToString();
                carpetaSteam = carpetaSteam.Replace("/", "\\");

                string ficheroLibreria = carpetaSteam + "\\steamapps\\libraryfolders.vdf";
                StorageFile ficheroLibreria2 = await StorageFile.GetFileFromPathAsync(ficheroLibreria);

                contenidoLibreria = await FileIO.ReadTextAsync(ficheroLibreria2);
            }
            catch { }

            if (contenidoLibreria != string.Empty)
            {
                if (contenidoLibreria.Trim().Length > 0)
                {
                    List<string> listaCarpetas = new List<string>();

                    int i = 0;
                    while (i < 100)
                    {
                        if (contenidoLibreria.Contains(Strings.ChrW(34) + "path" + Strings.ChrW(34)) == true)
                        {
                            int int1 = contenidoLibreria.IndexOf(Strings.ChrW(34) + "path" + Strings.ChrW(34));
                            contenidoLibreria = contenidoLibreria.Remove(0, int1 + 6);

                            int int2 = contenidoLibreria.IndexOf(Strings.ChrW(34));
                            contenidoLibreria = contenidoLibreria.Remove(0, int2 + 1);

                            int int3 = contenidoLibreria.IndexOf(Strings.ChrW(34));
                            string temp1 = contenidoLibreria.Remove(int3, contenidoLibreria.Length - int3);

                            listaCarpetas.Add(temp1);
                        }
                        else
                        {
                            break;
                        }

                        i += 1;
                    }

                    if (listaCarpetas.Count > 0)
                    {
                        List<SteamJuego> listaJuegos = new List<SteamJuego>();

                        foreach (string carpetaRuta in listaCarpetas)
                        {
                            string temp1 = carpetaRuta.Replace("\\\\", "\\");

                            StorageFolder carpeta = await StorageFolder.GetFolderFromPathAsync(temp1 + "\\steamapps");

                            IReadOnlyList<StorageFile> ficheros = await carpeta.GetFilesAsync();

                            foreach (StorageFile fichero in ficheros)
                            {
                                if (fichero.FileType.Contains(".acf") == true)
                                {
                                    string contenidoFichero = await FileIO.ReadTextAsync(fichero);

                                    int int1 = contenidoFichero.IndexOf(Strings.ChrW(34) + "name" + Strings.ChrW(34));
                                    contenidoFichero = contenidoFichero.Remove(0, int1 + 6);

                                    int int2 = contenidoFichero.IndexOf(Strings.ChrW(34));
                                    contenidoFichero = contenidoFichero.Remove(0, int2 + 1);

                                    int int3 = contenidoFichero.IndexOf(Strings.ChrW(34));
                                    string nombre = contenidoFichero.Remove(int3, contenidoFichero.Length - int3);

                                    string temp2 = fichero.Name;
                                    temp2 = temp2.Replace("appmanifest_", null);
                                    temp2 = temp2.Replace(".acf", null);
                                    string id = temp2.Trim();

                                    bool añadir = true;

                                    if (id == "228980")
                                    {
                                        añadir = false;
                                    }

                                    if (añadir == true)
                                    {
                                        listaJuegos.Add(new SteamJuego(id, nombre));
                                    }
                                }
                            }
                        }

                        if (listaJuegos.Count > 0)
                        {
                            ObjetosVentana.gvSteamJuegosInstalados.Items.Clear();

                            listaJuegos.Sort(delegate (SteamJuego c1, SteamJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                            foreach (SteamJuego juego in listaJuegos)
                            {
                                ImageEx imagen = new ImageEx
                                {
                                    IsCacheEnabled = true,
                                    EnableLazyLoading = true,
                                    Stretch = Stretch.UniformToFill,
                                    Source = dominioImagenes + "/steam/apps/" + juego.id + "/library_600x900.jpg",
                                    CornerRadius = new CornerRadius(2)
                                };

                                imagen.ImageExFailed += ImagenJuegoFalla;

                                Button2 botonJuego = new Button2
                                {
                                    Content = imagen,
                                    Margin = new Thickness(0),
                                    Padding = new Thickness(2),
                                    Background = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                    BorderThickness = new Thickness(0),
                                    Tag = juego,
                                    MaxWidth = 300,
                                    CornerRadius = new CornerRadius(5)
                                };

                                botonJuego.Click += ImagenJuegoClick;
                                botonJuego.PointerEntered += Animaciones.EntraRatonBoton2;
                                botonJuego.PointerExited += Animaciones.SaleRatonBoton2;

                                GridViewItem item = new GridViewItem
                                {
                                    Content = botonJuego,
                                    Margin = new Thickness(5, 0, 5, 10)
                                };

                                ObjetosVentana.gvSteamJuegosInstalados.Items.Add(item);
                            }
                        }
                    }
                }
            }

            ObjetosVentana.prSteamJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.gvSteamJuegosInstalados.Visibility = Visibility.Visible;

            if (ObjetosVentana.gvSteamJuegosInstalados.Items.Count == 0)
            {
                CambiarSubPestañaCualquiera();

                ObjetosVentana.botonSteamJuegosInstalados.Visibility = Visibility.Collapsed;
            }

            ActivarDesactivar(true);
        }

        private static void ImagenJuegoFalla(object sender, ImageExFailedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;
            string enlace = imagen.Source.ToString();

            if (enlace.Contains("/library_600x900.jpg") == true)
            {
                enlace = enlace.Replace("/library_600x900.jpg", "/header.jpg");
                imagen.Source = enlace;
                imagen.Stretch = Stretch.Uniform;
            }
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e) 
        { 
            Button boton = sender as Button;
            SteamJuego juego = boton.Tag as SteamJuego;

            Tiles.PrecargarJuego(juego.nombre,
                    "steam://rungameid/" + juego.id + "/", null, juego.id, "steam",
                    dominioImagenes + "/steam/apps/" + juego.id + "/header.jpg",
                    dominioImagenes + "/steam/apps/" + juego.id + "/library_600x900.jpg");
        }

        private async static void EnlaceCualquierJuegoTextoCambia(object sender, TextChangedEventArgs e)
        {
            TextBox tb = ObjetosVentana.tbSteamCualquierJuego;

            if (tb.Text.Trim().Length > 0)
            {
                if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
                {
                    ActivarDesactivar(false);
                    await Task.Delay(100);

                    if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
                    {
                        string id = tb.Text;
                        id = id.Replace("https://store.steampowered.com/app/", null);

                        if (id.Contains("/") == true)
                        {
                            int int1 = id.IndexOf("/");
                            id = id.Remove(int1, id.Length - int1);
                        }

                        string html = await Decompiladores.CogerHtml("https://store.steampowered.com/api/appdetails?appids=" + id);

                        if (html != null)
                        {
                            int int1 = html.IndexOf(":");
                            string temp1 = html.Remove(0, int1 + 1);
                            temp1 = temp1.Remove(temp1.Length - 1, 1);

                            SteamAPI json = JsonConvert.DeserializeObject<SteamAPI>(temp1);

                            if (json != null)
                            {
                                Tiles.PrecargarJuego(json.datos.titulo,
                                    "steam://rungameid/" + id + "/", null, id, "steam",
                                    dominioImagenes + "/steam/apps/" + id + "/header.jpg",
                                    dominioImagenes + "/steam/apps/" + id + "/library_600x900.jpg");

                                tb.Text = string.Empty;
                            }
                        }
                    }

                    ActivarDesactivar(true);
                }
            }
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonSteamJuegosInstalados.IsEnabled = estado;
            ObjetosVentana.botonSteamCualquierJuego.IsEnabled = estado;

            ObjetosVentana.tbSteamCualquierJuego.IsEnabled = estado;
        }
    }

    public class SteamJuego
    {
        public string id { get; set; }
        public string nombre { get; set; }

        public SteamJuego(string Id, string Nombre)
        {
            id = Id;
            nombre = Nombre;
        }
    }
}
