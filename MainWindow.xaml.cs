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
using Microsoft.Win32;

namespace My_Office_Word
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string FilePath = "";
        void File_Open(object sender, RoutedEventArgs args)
        {
            OpenFileDialog ofd = new OpenFileDialog { Title = "Выберите файл", Filter = "Rich Text Files(*.rtf)|*.rtf" };
            if (ofd.ShowDialog() == true)
            {
                FilePath = ofd.FileName;
                TextRange document = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
                using(FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    document.Load(fs, DataFormats.Rtf);
                }
                
            }
        }

        void File_Save(object sender, RoutedEventArgs args)
        {
            if(FilePath != "")
            {
                TextRange document = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(FilePath))
                {
                    document.Save(fs, DataFormats.Rtf);
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog { Title = "Выберите, куда сохранить документ", Filter = "Rich Text Files(*.rtf)|*.rtf", DefaultExt = ".rtf" };
                if (sfd.ShowDialog() == true)
                {
                    TextRange document = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);

                    using (FileStream fs = File.Create(sfd.FileName))
                    {
                        document.Save(fs, DataFormats.Rtf);
                    }
                    FilePath = sfd.FileName;
                }
            }
        }

        void File_SaveAs(object sender, RoutedEventArgs args)
        {
            SaveFileDialog sfd = new SaveFileDialog { Title = "Выберите, куда сохранить документ", Filter = "Rich Text Files(*.rtf)|*.rtf", DefaultExt = ".rtf"};
            if (sfd.ShowDialog() == true)
            {
                TextRange document = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);

                using (FileStream fs = File.Create(sfd.FileName))
                {
                    document.Save(fs, DataFormats.Rtf);
                }
                FilePath = sfd.FileName;
            }
        }

        void File_Create(object sender, RoutedEventArgs args)
        {
            FilePath = "";
            TextBox.Document = new FlowDocument();
        }

    }
}
