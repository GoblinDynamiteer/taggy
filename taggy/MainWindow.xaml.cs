using System.Windows;
using System.Windows.Forms;

namespace taggy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MusicFolder musicFolder;

        public MainWindow()
        {
            InitializeComponent();
            textboxTagInfo.Clear();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                musicFolder = new MusicFolder(folderDialog.SelectedPath);

                string[] files = musicFolder.GetMusicFileNames();

                for (int i = 0; i < files.Length; i++)
                {
                    listFiles.Items.Add(files[i]);
                }
            }
        }
    }
}
