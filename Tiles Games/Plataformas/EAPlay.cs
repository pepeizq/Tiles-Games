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
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using WinRT.Interop;
using static Tiles_Games.MainWindow;

namespace Plataformas
{
    public static class EAPlay
    {
        public static void Cargar()
        {
            ObjetosVentana.botonEAPlayBuscarJuegosInstalados.Click += BuscarCarpetaJuegosInstalados;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

            if (datos.Values["CarpetaEAPlay"] != null)
            {
                ObjetosVentana.tbEAPlayCarpetaJuegosInstalados.Text = datos.Values["CarpetaEAPlay"].ToString();
            }         
        }

        public static async void BuscarCarpetaJuegosInstalados(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.botonEAPlayBuscarJuegosInstalados.IsEnabled = false;

            FolderPicker carpetaPicker = new FolderPicker();
            carpetaPicker.FileTypeFilter.Add("*");

            IntPtr hwnd = WindowNative.GetWindowHandle(ObjetosVentana.ventana);
            InitializeWithWindow.Initialize(carpetaPicker, hwnd);

            StorageFolder carpetaElegida = null;

            try
            {
                carpetaElegida = await carpetaPicker.PickSingleFolderAsync();
            }
            catch { }

            if (carpetaElegida != null)
            {
                ObjetosVentana.tbEAPlayCarpetaJuegosInstalados.Text = carpetaElegida.Path;

                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["CarpetaEAPlay"] = carpetaElegida.Path;

                CargarJuegosInstalados();
            }

            ObjetosVentana.botonEAPlayBuscarJuegosInstalados.IsEnabled = true;
        }

        public static async void CargarJuegosInstalados()
        {
            ObjetosVentana.botonEAPlayBuscarJuegosInstalados.IsEnabled = false;
            ObjetosVentana.tbEAPlayMensajeNoJuegos.Visibility = Visibility.Collapsed;
            ObjetosVentana.prEAPlayJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvEAPlayJuegosInstalados.Visibility = Visibility.Collapsed;

            List<EAPlayJuego> listaJuegos = new List<EAPlayJuego>();

            if (ObjetosVentana.tbEAPlayCarpetaJuegosInstalados.Text.Trim().Length > 0) 
            {
                StorageFolder carpetaDatos = await StorageFolder.GetFolderFromPathAsync("E:\\Juegos");

                IReadOnlyList<StorageFolder> carpetasJuegos = await carpetaDatos.GetFoldersAsync();

                foreach (StorageFolder carpetaJuego in carpetasJuegos)
                {
                    IReadOnlyList<StorageFolder> carpetasJuegoInstalacion = await carpetaJuego.GetFoldersAsync();

                    bool carpetaEncontrada = false;

                    foreach (StorageFolder carpetaInstalacion in carpetasJuegoInstalacion)
                    {
                        if (carpetaInstalacion.Name == "__Installer")
                        {
                            carpetaEncontrada = true;
                        }
                    }

                    if (carpetaEncontrada == true)
                    {
                        string datosInstalacion = Ficheros.LeerFicheroFueraAplicacion(carpetaJuego.Path + "\\__Installer\\installerdata.xml");

                        if (datosInstalacion.Contains("<contentID>") == true)
                        {
                            int int1 = datosInstalacion.IndexOf("<contentID>");
                            string temp1 = datosInstalacion.Remove(0, int1 + 11);

                            int int2 = temp1.IndexOf("</contentID>");
                            string temp2 = temp1.Remove(int2, temp1.Length - int2);

                            string idWeb = temp2.Trim();

                            if (datosInstalacion.Contains("<launcher") == true)
                            {
                                int int3 = datosInstalacion.IndexOf("<launcher");
                                string temp3 = datosInstalacion.Remove(0, int3 + 2);

                                int int4 = temp3.IndexOf("<filePath>");
                                string temp4 = temp3.Remove(0, int4 + 10);

                                int int5 = temp4.IndexOf("</filePath>");
                                string temp5 = temp4.Remove(int5, temp4.Length - int5);

                                if (temp5.Contains("[HKEY_LOCAL_MACHINE\\SOFTWARE\\") == true)
                                {
                                    int int6 = temp5.IndexOf("[");
                                    string temp6 = temp5.Remove(0, int6 + 1);

                                    int int7 = temp6.IndexOf("]");
                                    string temp7 = temp6.Remove(int7, temp6.Length - int7);

                                    temp7 = temp7.Replace("HKEY_LOCAL_MACHINE\\", null);
                                    temp7 = temp7.Replace("\\Install Dir", null);

                                    RegistryKey registro = Registry.LocalMachine.OpenSubKey(temp7);
                                    string carpetaRuta = registro.GetValue("Install Dir").ToString();

                                    int int8 = temp5.IndexOf("]");
                                    string restoRuta = temp5.Remove(0, int8 + 1);

                                    if (datosInstalacion.Contains("<gameTitle locale=" + Strings.ChrW(34) + "en_US") == true)
                                    {
                                        int int9 = datosInstalacion.IndexOf("<gameTitle locale=" + Strings.ChrW(34) + "en_US");
                                        string temp9 = datosInstalacion.Remove(0, int9);

                                        int int10 = temp9.IndexOf(">");
                                        string temp10 = temp9.Remove(0, int10 + 1);

                                        int int11 = temp10.IndexOf("</gameTitle>");
                                        string temp11 = temp10.Remove(int11, temp10.Length - int11);

                                        listaJuegos.Add(new EAPlayJuego(idWeb, temp11.Trim(), carpetaRuta + restoRuta, null));
                                    }
                                }
                            }
                        }
                    }
                }
            }
      
            if (listaJuegos.Count > 0)
            {
                ObjetosVentana.gvEAPlayJuegosInstalados.Items.Clear();

                listaJuegos.Sort(delegate (EAPlayJuego c1, EAPlayJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                string html = await Decompiladores.CogerHtml("https://api3.origin.com/supercat/GB/en_GB/supercat-PCWIN_MAC-GB-en_GB.json.gz");

                if (html != null) 
                {
                    EAPlayAPI json = JsonConvert.DeserializeObject<EAPlayAPI>(html);

                    foreach (EAPlayJuego juego in listaJuegos)
                    {
                        string imagenEnlace = string.Empty;

                        foreach (EAPlayAPIJuego juegoAPI in json.juegos)
                        {
                            if (juego.id == juegoAPI.idWeb)
                            {
                                imagenEnlace = juegoAPI.imagenRaiz + juegoAPI.i18n.imagenGrande;
                                break;
                            }
                        }

                        if (imagenEnlace != string.Empty)
                        {
                            juego.imagen = imagenEnlace;

                            ImageEx imagen = new ImageEx
                            {
                                IsCacheEnabled = true,
                                EnableLazyLoading = true,
                                Stretch = Stretch.UniformToFill,
                                Source = juego.imagen,
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

                            ObjetosVentana.gvEAPlayJuegosInstalados.Items.Add(item);
                        }
                    }             
                }

                ObjetosVentana.gvEAPlayJuegosInstalados.Visibility = Visibility.Visible;
                ObjetosVentana.tbEAPlayMensajeNoJuegos.Visibility = Visibility.Collapsed;
            }
            else
            {               
                ObjetosVentana.gvEAPlayJuegosInstalados.Visibility = Visibility.Collapsed;
                ObjetosVentana.tbEAPlayMensajeNoJuegos.Visibility = Visibility.Visible;
            }

            ObjetosVentana.botonEAPlayBuscarJuegosInstalados.IsEnabled = true;
            ObjetosVentana.prEAPlayJuegosInstalados.Visibility = Visibility.Collapsed;
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            EAPlayJuego juego = boton.Tag as EAPlayJuego;

            Tiles.PrecargarJuego(juego.nombre,
                    juego.ejecutable, null, null, "eaplay",
                    string.Empty,
                    juego.imagen);
        }
    }

    public class EAPlayJuego
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string ejecutable { get; set; }
        public string imagen { get; set; }

        public EAPlayJuego(string Id, string Nombre, string Ejecutable, string Imagen)
        {
            id = Id;
            nombre = Nombre;
            ejecutable = Ejecutable;
            imagen = Imagen;
        }
    }
}
