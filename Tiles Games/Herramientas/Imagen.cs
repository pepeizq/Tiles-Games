using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Herramientas
{
    public static class Imagen
    {
        public static async Task<bool> Generar(Grid gridImagen, string clave, int ancho, int alto)
        {
            bool descargaFinalizada = false;

            StorageFolder carpetaInstalacion = ApplicationData.Current.LocalFolder;
            StorageFile ficheroImagen = await carpetaInstalacion.CreateFileAsync(clave, CreationCollisionOption.ReplaceExisting);

            RenderTargetBitmap resultado = new RenderTargetBitmap();
            await resultado.RenderAsync(gridImagen, ancho, alto);

            IBuffer buffer = await resultado.GetPixelsAsync();
            byte[] pixeles = buffer.ToArray();
            //DisplayInformation rawdpi = DisplayInformation.GetForCurrentView();

            using (IRandomAccessStream stream = await ficheroImagen.OpenAsync(FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);

                try
                {
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)resultado.PixelWidth, (uint)resultado.PixelHeight, 24, 24, pixeles);

                    await encoder.FlushAsync();
                }
                catch { }
            }

            return descargaFinalizada;
        }
    }
}