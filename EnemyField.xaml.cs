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
    /// Interaktionslogik für EnemyField.xaml
    /// </summary>
    public partial class EnemyField : Window
    {
        public EnemyField()
        {
            InitializeComponent();
            Game_Data.buttonsEnemyField = new List<Button> { Enemy_A1, Enemy_A2, Enemy_A3, Enemy_A4, Enemy_A5, Enemy_A6, Enemy_A7, Enemy_A8, Enemy_A9, Enemy_A10, Enemy_B1, Enemy_B2, Enemy_B3, Enemy_B4, Enemy_B5, Enemy_B6, Enemy_B7, Enemy_B8, Enemy_B9, Enemy_B10, Enemy_C1, Enemy_C2, Enemy_C3, Enemy_C4, Enemy_C5, Enemy_C6, Enemy_C7, Enemy_C8, Enemy_C9, Enemy_C10, Enemy_D1, Enemy_D2, Enemy_D3, Enemy_D4, Enemy_D5, Enemy_D6, Enemy_D7, Enemy_D8, Enemy_D9, Enemy_D10, Enemy_E1, Enemy_E2, Enemy_E3, Enemy_E4, Enemy_E5, Enemy_E6, Enemy_E7, Enemy_E8, Enemy_E9, Enemy_E10, Enemy_F1, Enemy_F2, Enemy_F3, Enemy_F4, Enemy_F5, Enemy_F6, Enemy_F7, Enemy_F8, Enemy_F9, Enemy_F10, Enemy_G1, Enemy_G2, Enemy_G3, Enemy_G4, Enemy_G5, Enemy_G6, Enemy_G7, Enemy_G8, Enemy_G9, Enemy_G10, Enemy_H1, Enemy_H2, Enemy_H3, Enemy_H4, Enemy_H5, Enemy_H6, Enemy_H7, Enemy_H8, Enemy_H9, Enemy_H10, Enemy_I1, Enemy_I2, Enemy_I3, Enemy_I4, Enemy_I5, Enemy_I6, Enemy_I7, Enemy_I8, Enemy_I9, Enemy_I10, Enemy_J1, Enemy_J2, Enemy_J3, Enemy_J4, Enemy_J5, Enemy_J6, Enemy_J7, Enemy_J8, Enemy_J9, Enemy_J10 };
            Game_Data.buttonsEnemyFieldReference = new List<Button> { Enemy_A1, Enemy_A2, Enemy_A3, Enemy_A4, Enemy_A5, Enemy_A6, Enemy_A7, Enemy_A8, Enemy_A9, Enemy_A10, Enemy_B1, Enemy_B2, Enemy_B3, Enemy_B4, Enemy_B5, Enemy_B6, Enemy_B7, Enemy_B8, Enemy_B9, Enemy_B10, Enemy_C1, Enemy_C2, Enemy_C3, Enemy_C4, Enemy_C5, Enemy_C6, Enemy_C7, Enemy_C8, Enemy_C9, Enemy_C10, Enemy_D1, Enemy_D2, Enemy_D3, Enemy_D4, Enemy_D5, Enemy_D6, Enemy_D7, Enemy_D8, Enemy_D9, Enemy_D10, Enemy_E1, Enemy_E2, Enemy_E3, Enemy_E4, Enemy_E5, Enemy_E6, Enemy_E7, Enemy_E8, Enemy_E9, Enemy_E10, Enemy_F1, Enemy_F2, Enemy_F3, Enemy_F4, Enemy_F5, Enemy_F6, Enemy_F7, Enemy_F8, Enemy_F9, Enemy_F10, Enemy_G1, Enemy_G2, Enemy_G3, Enemy_G4, Enemy_G5, Enemy_G6, Enemy_G7, Enemy_G8, Enemy_G9, Enemy_G10, Enemy_H1, Enemy_H2, Enemy_H3, Enemy_H4, Enemy_H5, Enemy_H6, Enemy_H7, Enemy_H8, Enemy_H9, Enemy_H10, Enemy_I1, Enemy_I2, Enemy_I3, Enemy_I4, Enemy_I5, Enemy_I6, Enemy_I7, Enemy_I8, Enemy_I9, Enemy_I10, Enemy_J1, Enemy_J2, Enemy_J3, Enemy_J4, Enemy_J5, Enemy_J6, Enemy_J7, Enemy_J8, Enemy_J9, Enemy_J10 };

        }

        public static void InitializeButtonField()
        {

        }

        private void Enemy_A1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_A10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_B10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_C10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_D10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_E10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_F10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_G10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_H10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_I10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J1_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J2_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J3_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J4_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J5_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J6_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J7_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J8_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J9_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }

        private void Enemy_J10_Click(object sender, RoutedEventArgs e)
        {
            Game_Functions.PlayerTurn(sender);
        }
    }
}
