using System;
using System.IO;


namespace Task01
{
    public class Backuper
    {
        private String wathcing_dir;

        private String history_dir;

        private DateTime readDateTime()
        {
             return DateTime.Parse(Console.ReadLine());
        }

        private String extractSubString(String str,char startChar, char endChar)
        {
            int startIndex = str.IndexOf(startChar);
            int endIndex = str.IndexOf(endChar);
            int len = endIndex - startIndex;
            if (len > 0)
                return str.Substring(startIndex + 1, len - 1);
            else
                return null;
        }

        private String getLogStringByDateTime(DateTime dt)
        {
            String logFileName = history_dir + "\\historyLog.txt";
            using (StreamReader infile = new StreamReader(logFileName))
            {
                String logString;

                bool greaterThan = false;// sign dt > log_data

                String lastLogString = null;

                while ((logString = infile.ReadLine()) != null)
                {
                    String dateString = extractSubString(logString, '[', ']');
                    if (dateString == null)
                        continue;

                    DateTime logDateTime = DateTime.Parse(dateString);

                    int result = DateTime.Compare(dt, logDateTime);

                    if (result > 0)
                        greaterThan = true;

                    if (result == 0)
                        return logString;

                    if ((result < 0) && (greaterThan))
                        return lastLogString;

                    lastLogString = logString;
                }

                if (greaterThan)
                    return lastLogString;
            }
            return null;
       }

        private int getDirIndexByDateTime(DateTime dt)
        {
            String logString = getLogStringByDateTime(dt);
            if (logString != null)
            {
                String dirIndedx = extractSubString(logString, '<','>');
                return int.Parse(dirIndedx);
            }
            else
                return -1;
        }

        public Backuper(String wathcing_dir, String history_dir)
        {
            this.wathcing_dir = wathcing_dir;
            this.history_dir = history_dir;

            Console.WriteLine("Введите дату и время");
            int dirIndex = getDirIndexByDateTime(readDateTime());

            if (dirIndex != -1)
            {
                String srcDir = history_dir + "\\" + dirIndex.ToString();
                DirCopy.DeleateAllTextFilesInDirectory(wathcing_dir);
                DirCopy.DirectoryCopy(srcDir, wathcing_dir);
            }
        }

    }
}
