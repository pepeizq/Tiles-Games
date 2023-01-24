using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.System;
using Windows.UI;
using static Tiles_Games.MainWindow;

namespace Plataformas
{
    public static class Ubisoft
    {
        public static void Cargar()
        {
            ObjetosVentana.botonUbisoftJuegosNoBBDDContactar.Click += AbrirContactarClick;
            ObjetosVentana.botonUbisoftJuegosNoBBDDContactar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonUbisoftJuegosNoBBDDContactar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static async void AbrirContactarClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/contact/"));
        }

        public static async void CargarJuegosInstalados()
        {
            ObjetosVentana.expanderUbisoftJuegosNoBBDD.Visibility = Visibility.Collapsed;
            ObjetosVentana.prUbisoftJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvUbisoftJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.tbUbisoftMensajeNoJuegos.Visibility = Visibility.Collapsed;

            List<string> listaIDsInstaladas = new List<string>();
            RegistryKey registro = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Ubisoft\\Launcher\\Installs");

            foreach (string id in registro.GetSubKeyNames())
            {
                bool añadir = true;

                if (listaIDsInstaladas.Count > 0)
                {
                    foreach (string idInstalada in listaIDsInstaladas)
                    {
                        if (id == idInstalada)
                        {
                            añadir = false;
                        }
                    }
                }

                if (añadir == true)
                {
                    listaIDsInstaladas.Add(id);
                }
            }

            if (listaIDsInstaladas.Count > 0)
            {
                ObjetosVentana.tbUbisoftMensajeNoJuegos.Visibility = Visibility.Collapsed;
                ObjetosVentana.gvUbisoftJuegosInstalados.Items.Clear();

                List<UbisoftJuego> listaJuegos = new List<UbisoftJuego>();
                List<string> listaIDsNoEncontradas = new List<string>();
                string bbdd = await Decompiladores.CogerHtml("https://raw.githubusercontent.com/pepeizq/Database-Games/master/Base%20de%20Datos%20Plataformas/Jsons/Ubisoft.json");
                
                if (bbdd != null)
                {
                    List<UbisoftAPI> json = JsonConvert.DeserializeObject<List<UbisoftAPI>>(bbdd);

                    if (json != null)
                    {
                        if (json.Count > 0)
                        {
                            foreach (string id in listaIDsInstaladas)
                            {
                                bool idEncontrada = false;

                                foreach (UbisoftAPI juegoJson in json)
                                {
                                    foreach (string id2 in juegoJson.idsUbi)
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
                                  
                                            listaJuegos.Add(new UbisoftJuego(juegoJson.nombre, "uplay://launch/" + id + "/0",
                                                                    imagenPequeña, imagenGrande));
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
                    ObjetosVentana.expanderUbisoftJuegosNoBBDD.Visibility = Visibility.Visible;
                    ObjetosVentana.expanderUbisoftJuegosNoBBDD.IsExpanded = true;

                    string idsNoEncontradas = string.Empty;

                    foreach (string idNoEncontrada in listaIDsNoEncontradas)
                    {
                        idsNoEncontradas = idsNoEncontradas + idNoEncontrada + Environment.NewLine;
                    }

                    if (idsNoEncontradas != string.Empty) 
                    { 
                        ObjetosVentana.tbUbisoftJuegosNoBBDDIds.Text = idsNoEncontradas;
                    }
                }
                else
                {
                    ObjetosVentana.expanderUbisoftJuegosNoBBDD.Visibility = Visibility.Collapsed;
                }
                
                if (listaJuegos.Count > 0)
                {
                    ObjetosVentana.tbUbisoftMensajeNoJuegos.Visibility = Visibility.Collapsed;
                    ObjetosVentana.gvUbisoftJuegosInstalados.Visibility = Visibility.Visible;
                    ObjetosVentana.gvUbisoftJuegosInstalados.Items.Clear();

                    listaJuegos.Sort(delegate (UbisoftJuego c1, UbisoftJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                    foreach (UbisoftJuego juego in listaJuegos)
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

                        ObjetosVentana.gvUbisoftJuegosInstalados.Items.Add(item);
                    }
                }
                else
                {
                    ObjetosVentana.tbUbisoftMensajeNoJuegos.Visibility = Visibility.Visible;                 
                }
            }
            else
            {
                ObjetosVentana.tbUbisoftMensajeNoJuegos.Visibility = Visibility.Visible;
            }

            ObjetosVentana.prUbisoftJuegosInstalados.Visibility = Visibility.Collapsed;
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            UbisoftJuego juego = boton.Tag as UbisoftJuego;

            //WidgetPrecarga.PrecargarJuego(juego.nombre,
            //        juego.ejecutable, null,
            //        juego.imagenPequeña, juego.imagenGrande);
        }
    }

    public class UbisoftJuego
    {
        public string nombre { get; set; }
        public string ejecutable { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenGrande { get; set; }

        public UbisoftJuego(string Nombre, string Ejecutable, string ImagenPequeña, string ImagenGrande)
        {
            nombre = Nombre;
            ejecutable = Ejecutable;
            imagenPequeña = ImagenPequeña;
            imagenGrande = ImagenGrande;
        }
    }
}
