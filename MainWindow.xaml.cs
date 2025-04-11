using System.IO;
using System.Windows;

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
            // Путь к файлу — должен лежать в bin/Debug/... или рядом с exe
            string videoFileName = @"jujutsu.mp4"; //тут название нужного файла указываем

            // Собираем абсолютный путь
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, videoFileName);

            if (File.Exists(fullPath))
            {
                BackgroundVideo.Source = new Uri(fullPath);
                BackgroundVideo.Play();
            }
            else
            {
                MessageBox.Show("Видео не найдено по пути:\n" + fullPath);
            }
        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Position = TimeSpan.Zero;
            BackgroundVideo.Play();
        }
    }
}