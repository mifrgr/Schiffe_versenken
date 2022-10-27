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
using System.Windows.Shapes;

namespace Schiffe_versenken
{
    /// <summary>
    /// Interaktionslogik für StartUpMessage.xaml
    /// </summary>
    public partial class StartUpMessage : Window
    {
        public StartUpMessage()
        {
            InitializeComponent();
            Height = 130;
            Width = 200;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Show();
            Topmost = true;
            Focus();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
