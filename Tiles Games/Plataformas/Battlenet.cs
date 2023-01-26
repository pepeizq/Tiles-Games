using Microsoft.UI.Xaml;
using Microsoft.Win32;
using static Tiles_Games.MainWindow;
using System.Collections.Generic;
using Herramientas;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using Interfaz;

namespace Plataformas
{
    public static class Battlenet
    {
        public static async void CargarJuegosInstalados()
        {
            ObjetosVentana.spBattlenetJuegosInstaladosMensaje.Visibility = Visibility.Collapsed;
            ObjetosVentana.prBattlenetJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvBattlenetJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Collapsed;

            List<BattlenetJuego> listaJuegos = new List<BattlenetJuego>();

            RegistryKey registro = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Blizzard Entertainment\\Battle.net\\Capabilities");
            
            if (registro != null) 
            {
                string rutaEjecutable = registro.GetValue("ApplicationIcon").ToString();

                if (rutaEjecutable != null)
                {
                    rutaEjecutable = rutaEjecutable.Replace(Strings.ChrW(34).ToString(), null);
                    rutaEjecutable = rutaEjecutable.Remove(rutaEjecutable.Length - 2, 2);

                    string bbdd = await Decompiladores.CogerHtml("https://raw.githubusercontent.com/pepeizq/Database-Games/master/Base%20de%20Datos%20Plataformas/Jsons/Battlenet.json");

                    if (bbdd != null)
                    {
                        List<BattlenetAPI> json = JsonConvert.DeserializeObject<List<BattlenetAPI>>(bbdd);

                        if (json != null)
                        {
                            if (json.Count > 0)
                            {
                                foreach (BattlenetAPI juegoJson in json)
                                {
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

                                    listaJuegos.Add(new BattlenetJuego(juegoJson.nombre, 
                                                        Strings.ChrW(34).ToString() + rutaEjecutable + Strings.ChrW(34).ToString() + " --exec=" + Strings.ChrW(34).ToString() + "launch " + juegoJson.idBattlenet + Strings.Chr(34).ToString(),
                                                        imagenPequeña, imagenGrande, juegoJson.idSteam));
                                }
                            }
                        }
                    }

                    if (listaJuegos.Count > 0)
                    {
                        ObjetosVentana.spBattlenetJuegosInstaladosMensaje.Visibility = Visibility.Visible;
                        ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Collapsed;
                        ObjetosVentana.gvBattlenetJuegosInstalados.Visibility = Visibility.Visible;
                        ObjetosVentana.gvBattlenetJuegosInstalados.Items.Clear();

                        listaJuegos.Sort(delegate (BattlenetJuego c1, BattlenetJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                        foreach (BattlenetJuego juego in listaJuegos)
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
                                BorderThickness = new Thickness(3),
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

                            ObjetosVentana.gvBattlenetJuegosInstalados.Items.Add(item);
                        }
                    }
                    else
                    {
                        ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
            }

            ObjetosVentana.prBattlenetJuegosInstalados.Visibility = Visibility.Collapsed;
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            BattlenetJuego juego = boton.Tag as BattlenetJuego;

            Tiles.PrecargarJuego(juego.nombre,
                    juego.ejecutable, null, juego.idSteam, "battlenet",
                    juego.imagenPequeña,
                    juego.imagenGrande);
        }
    }

    public class BattlenetJuego
    {
        public string nombre { get; set; }
        public string ejecutable { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenGrande { get; set; }
        public string idSteam { get; set; }

        public BattlenetJuego(string Nombre, string Ejecutable, string ImagenPequeña, string ImagenGrande, string IdSteam)
        {
            nombre = Nombre;
            ejecutable = Ejecutable;
            imagenPequeña = ImagenPequeña;
            imagenGrande = ImagenGrande;
            idSteam = IdSteam; 
        }
    }
}
