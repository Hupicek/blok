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
using System.ComponentModel;
using System.IO;


namespace WpfApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _contentTextBox;

        public string ContentTextBox
        {
            get { return _contentTextBox; }
            set
            {
                _contentTextBox = value;
                OnPropertyChanged("ContentTextBox");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Otevřít_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ContentTextBox = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Uložit_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt"; saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, ContentTextBox);
            }
        }

        private void oAplikaci_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Autor: Jan Ptáček\nSchool: Educhem\nRok: {System.DateTime.Now.Year}");
        }

        private void Zvětšit_Click(object sender, RoutedEventArgs e)
        {
          ContentTextBox = ContentTextBox.ToUpper();
        }

        private void Zmenšit_Click(object sender, RoutedEventArgs e)
        {
            if (ContentTextBox.Length > 2)
            {
                ContentTextBox = ContentTextBox.ToLower();
            }
        }

        private void Vymazat_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBox = string.Empty;
        }

        private void Spočítat_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(hovno.SelectedText))
            {
                MessageBox.Show($"Počet znaků: {ContentTextBox.Length}");
            }
            else
            {
                MessageBox.Show($"Text obsahuje {hovno.SelectedText.Length} characters.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.MergedDictionaries.Contains(lightTheme))
            {
                Application.Current.Resources.MergedDictionaries.Remove(lightTheme);
                Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Remove(darkTheme);
                Application.Current.Resources.MergedDictionaries.Add(lightTheme);
            }
        }
    }
}