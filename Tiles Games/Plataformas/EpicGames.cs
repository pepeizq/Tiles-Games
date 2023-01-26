using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.System;
using Windows.UI;
using static Tiles_Games.MainWindow;

namespace Plataformas
{
    public static class EpicGames
    {
        public static void Cargar()
        {
            ObjetosVentana.botonEpicGamesJuegosNoBBDDContactar.Click += AbrirContactarClick;
            ObjetosVentana.botonEpicGamesJuegosNoBBDDContactar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonEpicGamesJuegosNoBBDDContactar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static async void AbrirContactarClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/contact/"));
        }

        public static async void CargarJuegosInstalados()
        {
            ObjetosVentana.expanderEpicGamesJuegosNoBBDD.Visibility = Visibility.Collapsed;
            ObjetosVentana.prEpicGamesJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvEpicGamesJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.tbEpicGamesMensajeNoJuegos.Visibility = Visibility.Collapsed;

            List<string> listaIDsInstaladas = new List<string>();
            string rutaJuegosInstalados = Path.Combine(Environment.ExpandEnvironmentVariables("%PROGRAMDATA%"), "Epic\\UnrealEngineLauncher");

            if (rutaJuegosInstalados != null)
            {
                string contenidoJuegosInstalados = Ficheros.LeerFicheroFueraAplicacion(rutaJuegosInstalados + "\\LauncherInstalled.dat");

                if (contenidoJuegosInstalados != null)
                {
                    int i = 0;
                    while (i < 1000)
                    {
                        if (contenidoJuegosInstalados.Contains(Strings.ChrW(34) + "AppName" + Strings.ChrW(34)) == true)
                        {
                            int int1 = contenidoJuegosInstalados.IndexOf(Strings.ChrW(34) + "AppName" + Strings.ChrW(34));
                            string temp1 = contenidoJuegosInstalados.Remove(0, int1 + 10);

                            contenidoJuegosInstalados = temp1;

                            int int2 = contenidoJuegosInstalados.IndexOf(Strings.ChrW(34));
                            string temp2 = contenidoJuegosInstalados.Remove(0, int2 + 1);

                            int int3 = temp2.IndexOf(Strings.ChrW(34));
                            string temp3 = temp2.Remove(int3, temp2.Length - int3);

                            listaIDsInstaladas.Add(temp3);
                        }
                        else
                        {
                            break;
                        }
                        i += 1;
                    }
                }
            }

            if (listaIDsInstaladas.Count > 0)
            {
                ObjetosVentana.tbEpicGamesMensajeNoJuegos.Visibility = Visibility.Collapsed;
                ObjetosVentana.gvEpicGamesJuegosInstalados.Items.Clear();

                List<EpicGamesJuego> listaJuegos = new List<EpicGamesJuego>();
                List<string> listaIDsNoEncontradas = new List<string>();
                string bbdd = await Decompiladores.CogerHtml("https://raw.githubusercontent.com/pepeizq/Database-Games/master/Base%20de%20Datos%20Plataformas/Jsons/EpicGames.json");

                if (bbdd != null)
                {
                    List<EpicGamesAPI> json = JsonConvert.DeserializeObject<List<EpicGamesAPI>>(bbdd);

                    if (json != null)
                    {
                        if (json.Count > 0)
                        {
                            foreach (string id in listaIDsInstaladas)
                            {
                                bool idEncontrada = false;

                                foreach (EpicGamesAPI juegoJson in json)
                                {
                                    foreach (string id2 in juegoJson.idsEpic)
                                    {
                                        if (id == id2)
                                        {
                                            idEncontrada = true;

                                            string imagenPequeña = string.Empty;

                                            if (juegoJson.imagenPequeña != string.Empty)
                                            {
                                                imagenPequeña = juegoJson.imagenPequeña;
                                            }
                                            else
                                            {
                                                if (juegoJson.idSteam != string.Empty)
                                                {
                                                    imagenPequeña = Steam.dominioImagenes + "/steam/apps/" + juegoJson.idSteam + "/header.jpg";
                                                }
                                            }

                                            string imagenGrande = string.Empty;

                                            if (juegoJson.imagenGrande != string.Empty)
                                            {
                                                imagenGrande = juegoJson.imagenGrande;
                                            }
                                            else
                                            {
                                                if (juegoJson.idSteam != string.Empty)
                                                {
                                                    imagenGrande = Steam.dominioImagenes + "/steam/apps/" + juegoJson.idSteam + "/library_600x900.jpg";
                                                }
                                            }

                                            listaJuegos.Add(new EpicGamesJuego(juegoJson.nombre, "com.epicgames.launcher://apps/" + id + "?action=launch&silent=true",
                                                                               imagenPequeña, imagenGrande, juegoJson.idSteam));
                                            break;
                                        }
                                    }

                                    if (idEncontrada == true)
                                    {
                                        break;
                                    }
                                }

                                if (idEncontrada == false)
                                {
                                    listaIDsNoEncontradas.Add(id);
                                }
                            }
                        }
                    }
                }

                if (listaIDsNoEncontradas.Count > 0)
                {
                    ObjetosVentana.expanderEpicGamesJuegosNoBBDD.Visibility = Visibility.Visible;
                    ObjetosVentana.expanderEpicGamesJuegosNoBBDD.IsExpanded = true;

                    string idsNoEncontradas = string.Empty;

                    foreach (string idNoEncontrada in listaIDsNoEncontradas)
                    {
                        idsNoEncontradas = idsNoEncontradas + idNoEncontrada + Environment.NewLine;
                    }

                    if (idsNoEncontradas != string.Empty)
                    {
                        ObjetosVentana.tbEpicGamesJuegosNoBBDDIds.Text = idsNoEncontradas.Trim();
                    }
                }
                else
                {
                    ObjetosVentana.expanderEpicGamesJuegosNoBBDD.Visibility = Visibility.Collapsed;
                }

                if (listaJuegos.Count > 0)
                {
                    ObjetosVentana.tbEpicGamesMensajeNoJuegos.Visibility = Visibility.Collapsed;
                    ObjetosVentana.gvEpicGamesJuegosInstalados.Visibility = Visibility.Visible;
                    ObjetosVentana.gvEpicGamesJuegosInstalados.Items.Clear();

                    listaJuegos.Sort(delegate (EpicGamesJuego c1, EpicGamesJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                    foreach (EpicGamesJuego juego in listaJuegos)
                    {
                        ImageEx imagen = new ImageEx
                        {
                            IsCacheEnabled = true,
                            EnableLazyLoading = true,
                            Stretch = Stretch.UniformToFill,
                            Source = juego.imagenGrande,
                            CornerRadius = new CornerRadius(2)
                        };

                        Button2 botonJuego = new Button2
                        {
                            Content = imagen,
                            Margin = new Thickness(0),
                            Padding = new Thickness(0),
                            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                            BorderThickness = new Thickness(2),
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

                        ObjetosVentana.gvEpicGamesJuegosInstalados.Items.Add(item);
                    }
                }
                else
                {
                    ObjetosVentana.tbEpicGamesMensajeNoJuegos.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ObjetosVentana.tbEpicGamesMensajeNoJuegos.Visibility = Visibility.Visible;
            }

            ObjetosVentana.prEpicGamesJuegosInstalados.Visibility = Visibility.Collapsed;
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            EpicGamesJuego juego = boton.Tag as EpicGamesJuego;

            Tiles.PrecargarJuego(juego.nombre,
                    juego.ejecutable, null, juego.idSteam, "epicgames",
                    juego.imagenPequeña,
                    juego.imagenGrande);
        }
    }

    public class EpicGamesJuego
    {
        public string nombre { get; set; }
        public string ejecutable { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenGrande { get; set; }
        public string idSteam { get; set; }

        public EpicGamesJuego(string Nombre, string Ejecutable, string ImagenPequeña, string ImagenGrande, string IdSteam)
        {
            nombre = Nombre;
            ejecutable = Ejecutable;
            imagenPequeña = ImagenPequeña;
            imagenGrande = ImagenGrande;
            idSteam = IdSteam;
        }
    }
}
