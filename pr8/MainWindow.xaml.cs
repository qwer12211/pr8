using Microsoft.Win32;
using System.Windows;
using JsonLib;
using Path = System.IO.Path;
using Newtonsoft.Json;
using System.IO;


namespace pr8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Theme = "BlueTheme";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            App.Theme = "RedTheme";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                string textToSerialize = TextBoxic.Text;
                string jsonFilePath = saveFileDialog.FileName;

         
                File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(textToSerialize));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonFilePath = openFileDialog.FileName;
                    string jsonText = File.ReadAllText(jsonFilePath);

                    string txt = JsonConvert.DeserializeObject<string>(jsonText);

                    if (!string.IsNullOrEmpty(txt))
                    {
                        TextBoxic.Text = txt;
                    }
                    else
                    {
                        MessageBox.Show("Файл JSON пустой.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
                }
            }

        }


    }
}
