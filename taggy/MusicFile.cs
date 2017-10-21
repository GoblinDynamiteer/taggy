using System.IO;

namespace taggy
{
    class MusicFile
    {
        enum Type
        {
            FLAC, MP3
        }

        string fullPath;
        string fileName;
        string album, title, artist, year, track;
        Type type;

        public MusicFile(string path)
        {
            fullPath = path;
            fileName = Path.GetFileName(path);

            if (Path.GetExtension(path) == "flac")
            {
                type = Type.FLAC;
            }

            if (Path.GetExtension(path) == "mp3")
            {
                type = Type.MP3;
            }

            ReadTags();
        }

        void ReadTags()
        {
            try
            {
                var file = TagLib.File.Create(fullPath);
                year = file.Tag.Year.ToString();
                track = file.Tag.Track.ToString();
                title = file.Tag.Title;
                artist = file.Tag.FirstArtist;
                album = file.Tag.Album;

                file.Save();
            }

            catch
            {
            }
        }

        public string FileName()
        {
            return fileName;
        }
    }
}
