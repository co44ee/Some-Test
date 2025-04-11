using System.IO;
using System.Windows;
using System.Reflection;

namespace testapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string resourceName = "testapp.jujutsu.mp4"; // замените namespace и путь!
            string tempPath = Path.Combine(Path.GetTempPath(), "jujutsu_temp.mp4");

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    MessageBox.Show("Ресурс не найден: " + resourceName);
                    return;
                }

                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }

            BackgroundVideo.Source = new Uri(tempPath);
            BackgroundVideo.Play();
        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Position = TimeSpan.Zero;
            BackgroundVideo.Play();
        }
    }
}