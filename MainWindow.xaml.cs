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
using System.Media;
using System.Threading;

namespace Schiffe_versenken
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Game_Data.gamestate = (int)Game_Data.Gamestate.initialized;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new StartUpMessage();
            Game_Data.buttonsPlayerField = new List<Button> { A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, G1, G2, G3, G4, G5, G6, G7, G8, G9, G10, H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, J1, J2, J3, J4, J5, J6, J7, J8, J9, J10 };
            Game_Data.buttonsPlayerFieldReference = new List<Button> { A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, G1, G2, G3, G4, G5, G6, G7, G8, G9, G10, H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, J1, J2, J3, J4, J5, J6, J7, J8, J9, J10 };

        }

        private void Test()
        {
             

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher?","Bitte bestätigen",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //if(Game_Data.PlayerShipsOnField != 30)
                //{
                //    MessageBox.Show("Es wurden noch nicht alle Schiffe gesetzt!", "Fehler");
                //    return;
                //}
                Game_Data.gamestate = (int)Game_Data.Gamestate.started;                             
                Game_Data.enemyField = new EnemyField();
                Left = 100d;
                Top = 300d;
                Game_Data.enemyField.Show();
                Game_Data.enemyField.WindowStartupLocation = WindowStartupLocation.Manual;
                Game_Data.enemyField.Left = 1000d;
                Game_Data.enemyField.Top = 300d;
                Focus();
                Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                Game_Functions.KIShipSetv2();
            }
        }  
        
        

        private void A1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void A10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void B10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void C10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void D10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void E10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void F10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);

        }

        private void G5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void G10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void H10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void I10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.Shipset(sender);
        }

        private void J10_Click(object sender, RoutedEventArgs e)
        {
             Game_Functions.Shipset(sender);
        }

        private void A1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void A10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void B10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void C10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void D10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void E10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void F10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void G10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void H10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void I10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void J10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Game_Functions.FieldClear(sender);
        }

        private void AircraftCarrierSet_Click(object sender, RoutedEventArgs e)
        {
            if(Game_Data.gamestate == (int)Game_Data.Gamestate.initialized && Game_Data.shiptoset == 0)
            {
                Game_Data.shiptoset = (int)Game_Data.Shipmodel.Flugzeugträger;
                Game_Data.XOnTheRightSideForShips = new List<TextBlock> {ACS1,ACS2,ACS3,ACS4,ACS5 };
            }

            else
            {
                MessageBox.Show((Game_Data.Shipmodel)Game_Data.shiptoset + " ist noch aktiviert. Bitte erst Setzen oder Löschen","WARNUNG!");
            }
        }

        private void AircraftCarrierSetAbort_Click(object sender, RoutedEventArgs e)
        {
            Game_Data.XOnTheRightSideForShips.Clear();
            Game_Data.XOnTheRightSideForShips = new List<TextBlock> { ACS1, ACS2, ACS3, ACS4, ACS5 };
        

        Game_Data.shiptoset = 0;

                Game_Data.indexoflist = 0;

                foreach (TextBlock blocktoclear in Game_Data.XOnTheRightSideForShips)
                {
                    blocktoclear.Visibility = Visibility.Visible;
                }

                foreach(Button buttontoclear in Game_Data.Flugzeugträger1)
                {
                    buttontoclear.Content = "";
                   
                }

                Game_Data.Flugzeugträger1.Clear();

            
        }

        private void CruiserSet_Click(object sender, RoutedEventArgs e)
        {
            if (Game_Data.gamestate == (int)Game_Data.Gamestate.initialized && Game_Data.shiptoset == 0)
            {
                Game_Data.shiptoset = (int)Game_Data.Shipmodel.Kreuzer;
                Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Cr1_1,Cr1_2,Cr1_3,Cr1_4,Cr2_1,Cr2_2,Cr2_3,Cr2_4};
            }

            else
            {
                MessageBox.Show((Game_Data.Shipmodel)Game_Data.shiptoset + " ist noch aktiviert. Bitte erst Setzen oder Löschen", "WARNUNG!");
            }
        }

        private void CruiserSetAbort_Click(object sender, RoutedEventArgs e)
        {
            Game_Data.XOnTheRightSideForShips.Clear();
            Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Cr1_1, Cr1_2, Cr1_3, Cr1_4, Cr2_1, Cr2_2, Cr2_3, Cr2_4 };

            Game_Data.shiptoset = 0;

                Game_Data.indexoflist = 0;

                foreach (TextBlock blocktoclear in Game_Data.XOnTheRightSideForShips)
                {
                    blocktoclear.Visibility = Visibility.Visible;
                }


                foreach (List<Button> listtocheck in Game_Data.Kreuzer)
                {
                    foreach (Button buttontoclear in listtocheck)
                    {
                        buttontoclear.Content = "";
                    }

                }

                foreach (List<Button> listtoclear in Game_Data.Kreuzer)
                {
                    listtoclear.Clear();
                }
            
        }

        private void DestroyerSet_Click(object sender, RoutedEventArgs e)
        {
            if (Game_Data.gamestate == (int)Game_Data.Gamestate.initialized && Game_Data.shiptoset == 0)
            {
                Game_Data.shiptoset = (int)Game_Data.Shipmodel.Zerstörer;
                Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Des1_1,Des1_2,Des1_3,Des2_1,Des2_2,Des2_3,Des3_1,Des3_2,Des3_3,};
            }

            else
            {
                MessageBox.Show((Game_Data.Shipmodel)Game_Data.shiptoset + " ist noch aktiviert. Bitte erst Setzen oder Löschen", "WARNUNG!");
            }
        }

        private void DestroyerSetAbort_Click(object sender, RoutedEventArgs e)
        {
            Game_Data.XOnTheRightSideForShips.Clear();
            Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Des1_1, Des1_2, Des1_3, Des2_1, Des2_2, Des2_3, Des3_1, Des3_2, Des3_3, };

            Game_Data.shiptoset = 0;

                Game_Data.indexoflist = 0;

                foreach (TextBlock blocktoclear in Game_Data.XOnTheRightSideForShips)
                {
                    blocktoclear.Visibility = Visibility.Visible;
                }

                foreach (List<Button> listtocheck in Game_Data.Zerstörer)
                {
                    foreach(Button buttontoclear in listtocheck)
                    {
                        buttontoclear.Content = "";
                    }
                    
                }

                foreach (List<Button> listtoclear in Game_Data.Zerstörer)
                {
                    listtoclear.Clear();
                }
            
        }

        private void UbootSet_Click(object sender, RoutedEventArgs e)
        {
            if (Game_Data.gamestate == (int)Game_Data.Gamestate.initialized && Game_Data.shiptoset == 0)
            {
                Game_Data.shiptoset = (int)Game_Data.Shipmodel.UBoot;
                Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Ub1_1,Ub1_2,Ub2_1,Ub2_2,Ub3_1,Ub3_2,Ub4_1,Ub4_2 };
            }

            else
            {
                MessageBox.Show((Game_Data.Shipmodel)Game_Data.shiptoset + " ist noch aktiviert. Bitte erst Setzen oder Löschen", "WARNUNG!");
            }
        }

        private void UbootSetAbort_Click(object sender, RoutedEventArgs e)
        {
            Game_Data.XOnTheRightSideForShips.Clear();
            Game_Data.XOnTheRightSideForShips = new List<TextBlock> { Ub1_1, Ub1_2, Ub2_1, Ub2_2, Ub3_1, Ub3_2, Ub4_1, Ub4_2 };

            Game_Data.shiptoset = 0;

                Game_Data.indexoflist = 0;

                foreach (TextBlock blocktoclear in Game_Data.XOnTheRightSideForShips)
                {
                    blocktoclear.Visibility = Visibility.Visible;
                }


                foreach (List<Button> listtocheck in Game_Data.Uboot)
                {
                    foreach (Button buttontoclear in listtocheck)
                    {
                        buttontoclear.Content = "";
                    }

                }

                foreach (List<Button> listtoclear in Game_Data.Uboot)
                {
                    listtoclear.Clear();
                }
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!SoundOption.IsChecked)
            {

                Game_Data.SoundOnOrOff = false;
            }

            if (SoundOption.IsChecked)
            {

                Game_Data.SoundOnOrOff = true;
            }

        }
    }
}
