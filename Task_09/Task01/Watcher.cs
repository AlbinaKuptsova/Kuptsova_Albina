using System;
using System.IO;
using System.Timers;

namespace Task01
{
    public class Watcher
    {

        private String wathcing_dir;

        private String history_dir;

        private FileSystemWatcher watcher = new FileSystemWatcher();

        public Watcher(String wathcing_dir, String history_dir)
        {
            this.wathcing_dir = wathcing_dir;
            this.history_dir = history_dir;

            Console.WriteLine("Наблюдаемая папка:{0}", wathcing_dir);
            Console.WriteLine("Папка истории:{0}", history_dir);


            watcher.Path = wathcing_dir;
  
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
       
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;

       
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

    
            watcher.EnableRaisingEvents = true;
        }


        private  void writeLog(String message)
        {
            String logFileName = history_dir + "\\historyLog.txt";
            using (StreamWriter outfile = new StreamWriter(logFileName, true))
            {
                outfile.WriteLineAsync("["+DateTime.Now.ToString() +"]"+ " " + message);
            }
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            ((Timer)sender).Stop();
            watcher.Changed += new FileSystemEventHandler(OnChanged);
        }

       
        private  void OnChanged(object source, FileSystemEventArgs e)
        {

            
            int index = MakeReserve();

            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            writeLog(e.FullPath + " " + e.ChangeType + " <" + index + ">");

            Timer t = new Timer();
            ((FileSystemWatcher)source).Changed -= new FileSystemEventHandler(OnChanged);
            t.Interval = 100;
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
        }


        private  void OnRenamed(object source, RenamedEventArgs e)
        {
            
            int index = MakeReserve();
            writeLog(e.FullPath + " " + e.ChangeType + " <" + index + ">");
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }


        private  int MakeReserve()
        {
            int index = 1;
            String destDirName = history_dir + "\\" + index.ToString();
            while (Directory.Exists(destDirName))
            {
                index++;
                destDirName = history_dir + "\\" + index.ToString();
            }
            DirCopy.DirectoryCopy(wathcing_dir, destDirName);
            return index;
        }


    }
}
