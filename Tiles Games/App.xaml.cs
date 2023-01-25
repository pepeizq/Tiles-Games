using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using Windows.System;

namespace Tiles_Games
{
    public partial class App : Application
    {
        private Window m_window;

        public App()
        {
            this.InitializeComponent();
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            bool abrirApp = false;
            string[] argumentos = Environment.GetCommandLineArgs();

            if (argumentos.Length > 1)
            {
                abrirApp = false;
            }
            else
            {
                abrirApp = true;
            }
         
            if (abrirApp == true)
            {
                m_window = new MainWindow();
                m_window.Activate();
            }
            else
            {
                if (argumentos[1].Contains("steam://rungameid/") == true || argumentos[1].Contains("uplay://launch/") == true ||
                    argumentos[1].Contains("amazon-games://play/") == true || argumentos[1].Contains("com.epicgames.launcher://apps/") == true)
                {
                    await Launcher.LaunchUriAsync(new Uri(argumentos[1]));
                }
                else
                {
                    string ejecutable = argumentos[1].Trim();

                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ejecutable;
                    proceso.Start();
                }

                Application app = Application.Current;
                app.Exit();
            }
        }
    }
}
