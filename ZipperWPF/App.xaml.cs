using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ZipperWPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        string fileLog;

        void app_Startup(object sender, StartupEventArgs e)
        {
            // If no command line arguments were provided, don't process them 
            if (e.Args.Length == 0) return;

            if (e.Args.Length > 0)
            {
                fileLog = e.Args[0] + @"\ko.log";
                StreamWriter sw = new StreamWriter(fileLog, false);
                try
                {
                    // Open the text file using a stream reader. 
                    //using (StreamReader sr = new StreamReader(args[0]))
                    //{
                    // Read the stream to a string, and write  
                    // the string to the text box 
                    //String line = sr.ReadToEnd();
                    //textBox.AppendText(line.ToString());
                    //textBox.AppendText("\n");                    
                    sw.WriteLine("# Informaion de parametros de entrada: " + fileLog);
                    
                    //}
                }
                catch (Exception error)
                {
                    //textBox.AppendText("The file could not be read:");
                    //textBox.AppendText("\n");
                    //textBox.AppendText(e.Message);
                    sw.WriteLine("# Informaion de parametros de error: " + error.Message);
                }
                sw.Close();

                Application.Current.Shutdown();
            }
        }

    }
}
