using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.IO.Compression;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Configuration;

namespace ZipperWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string startPath = @"c:\example\start";
        string zipPath = @"c:\example\result.zip";
        string extractPath = @"c:\example\extract";        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnComprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZipFile.CreateFromDirectory(lblPathOrigen.Content.ToString(), zipPath);
                
            }
            catch (Exception ex)
            {
                lblMsgError.Content = ex.Message.ToString();                
            }

        }


        

        private void BtnExtraer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, lblPathDestino.Content.ToString());
            }
            catch (Exception ex)
            {
                lblMsgError.Content = ex.Message.ToString();
            }
           
        }

      

        private void BtnRutaOrigen_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;

            if (ConfigurationManager.AppSettings["PrevPathOrigen"].ToString() != "")
                folderDialog.SelectedPath = ConfigurationManager.AppSettings["PrevPathOrigen"].ToString();

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblPathOrigen.Content = folderDialog.SelectedPath;
                ConfigurationManager.AppSettings["PrevPathOrigen"] = folderDialog.SelectedPath;
            }
        }

        private void BtnRutaDestino_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblPathDestino.Content = folderDialog.SelectedPath;
            }

        }
        private void ClearMsgError()
        {
            lblPathDestino.Content = "";
        }
    }
}
