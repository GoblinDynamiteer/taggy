using Microsoft.Win32;
using System.Windows;

namespace taggy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textboxTagInfo.Clear();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FLAC Files (*.flac)|*.flac|MP3 Files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var file = TagLib.File.Create(openFileDialog.FileName);
                    var year = file.Tag.Year;
                    var track = file.Tag.Track;
                    var title = file.Tag.Title;
                    var artist = file.Tag.FirstArtist;
                    var album = file.Tag.Album;

                    textboxTagInfo.Clear();
                    textboxTagInfo.AppendText(
                        year.ToString() + "\r\n" +
                        title.ToString() + "\r\n" +
                        track.ToString() + "\r\n" +
                        album.ToString() + "\r\n" +
                        artist.ToString() + "\r\n"
                        );

                    file.Save();
                }

                catch
                {
                }
            }

        }
    }
}
