using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LivesetAnalyzer
{
    class AnalyzerLib
    {
        private static String currentFilePath = null;

        public static String GetLastFilePath()
        {
            return currentFilePath;
        }

	    public static String readFile(String filePath) {
            currentFilePath = filePath;
            if (filePath == null) throw new Exception();
            String s = "";
            
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        s += sr.ReadLine() + Environment.NewLine;
                    }
                }
            }
            return s;
        }

    


        // not tested
	    public static void writeFile(String text, String filePath) 
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (!File.Exists(filePath))
            {
                // Create the file
                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        System.Diagnostics.Debug.WriteLine(s);
                    }
                }
            }
	    }





    }

}
