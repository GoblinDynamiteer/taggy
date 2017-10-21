using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taggy
{
    class MusicFolder
    {
        string fullPath;
        string[] filesPaths;
        List<MusicFile> musicFiles;

        public MusicFolder(string path)
        {
            fullPath = path;
            musicFiles = new List<MusicFile>();
            ListFiles();
        }

        void ListFiles()
        {
            string[] filesPaths = Directory.GetFiles(fullPath, "*.flac");

            for (int i = 0; i < filesPaths.Length; i++)
            {
                musicFiles.Add(new MusicFile(filesPaths[i]));
            }
        }

        public string[] GetMusicFileNames()
        {
            string[] fileNames = new string[musicFiles.Count];

            for (int i = 0; i < musicFiles.Count; i++)
            {
                fileNames[i] = musicFiles[i].FileName();
            }

            return fileNames;
        }

    }
}
