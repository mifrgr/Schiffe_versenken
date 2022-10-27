using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;

namespace Schiffe_versenken
{
    static class Game_Functions
    {
       
        static public void KITurn(List<Button> ShipToDestroy)
        {

            if (Game_Data.playerorKITurn == (int)Game_Data.PlayerOrKITurn.KITurn)
            {
                if (Game_Data.HitOnShip == 0)
                {
                    NewRound:
                    var random = new Random();
                    int range = Game_Data.buttonsPlayerField.Count;

                    int randomValue = random.Next(range);

                    Button KIButtonselected = Game_Data.buttonsPlayerField[randomValue];

                    if (!IsKINextRandomHitValid(KIButtonselected, Game_Data.buttonsPlayerField) || !MakeHitSense(Game_Data.Player_Shipsetted, KIButtonselected) || !FieldSelect(KIButtonselected) )
                        goto NewRound;

                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                    return;
                }

                if (Game_Data.HitOnShip >= 2 )
                {
                    //0 = Vertikal, 1 = Horiztonal
                    int directionOfShip = CheckIfShipIsInARowOrColoumn(Game_Data.ShipToDestroy);

                    if (directionOfShip == 0)
                    {

                        FindSpotToFire:

                        Random random = new Random();

                        // 0 = -, 1 = +
                        int direction = random.Next(Game_Data.directionforKIMultipleHit.Count);

                        if (direction == 1)
                        {
                            for (int i = 0; i < ShipToDestroy.Count; i++)
                            {
                                if (IsKINextHitValid(ShipToDestroy[i], Game_Data.buttonsPlayerField, +1) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) + 1]))
                                {
                                    FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) + 1]);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                            }
                            
                            goto FindSpotToFire;
                        }

                        if (direction == 0)
                        {
                            for (int i = 0; i < ShipToDestroy.Count; i++)
                            {
                                if (IsKINextHitValid(ShipToDestroy[i], Game_Data.buttonsPlayerField, -1) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) - 1]))
                                {
                                    FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) - 1]);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                            }

                            goto FindSpotToFire;
                        }

                    }

                    if (directionOfShip == 1)
                    {
                        FindSpotToFire:
                        Random random = new Random();

                        // 0 = -, 1 = +
                        int direction = random.Next(Game_Data.directionforKIMultipleHit.Count);

                        if (direction == 1)
                        {
                            for (int i = 0; i < ShipToDestroy.Count; i++)
                            {
                                if (IsKINextHitValid(ShipToDestroy[i], Game_Data.buttonsPlayerField, +10) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) + 10]))
                                {
                                    FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) + 10]);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                            }

                            goto FindSpotToFire;
                        }
                        if (direction == 0)
                        {
                            for (int i = 0; i < ShipToDestroy.Count; i++)
                            {
                                if (IsKINextHitValid(ShipToDestroy[i], Game_Data.buttonsPlayerField, -10) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) - 10]))
                                {
                                    FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[i]) - 10]);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                            }

                            goto FindSpotToFire;
                        }

                    }

                }

                if (Game_Data.HitOnShip < 2)
                {
                    int countOfTrys = 0;

                    FindSpotToFire:
                    Random random = new Random();

                    if(Game_Data.directionforKIOneHit.Count == 0)
                    {
                        Game_Data.directionforKIOneHit = new List<int> { 0, 1, 2, 3 };
                    }

                    // 0 = Up, 1 = Right, 2 = Down, 3 = Left
                    int direction = Game_Data.directionforKIOneHit[random.Next(Game_Data.directionforKIOneHit.Count)];

                    if(countOfTrys == 4)
                    {
                        Game_Data.directionforKIOneHit = new List<int> { 0, 1, 2, 3 };
                    }

                    switch (direction)
                    {
                        case 0:
                            if(IsKINextHitValid(ShipToDestroy[0], Game_Data.buttonsPlayerField,-1) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) - 1]))
                            {
                                if(FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) - 1]))
                                {
                                    Game_Data.directionforKIOneHit.Remove(0);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                               
                            }

                            countOfTrys++;
                            goto FindSpotToFire;


                        case 1:
                            if (IsKINextHitValid(ShipToDestroy[0], Game_Data.buttonsPlayerField, +10) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) + 10]))
                            {
                                if(FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) + 10]))
                                {
                                    Game_Data.directionforKIOneHit.Remove(1);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                                
                            }
                            countOfTrys++;
                            goto FindSpotToFire;

                        case 2:
                            if (IsKINextHitValid(ShipToDestroy[0], Game_Data.buttonsPlayerField, +1) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) + 1]))
                            {
                                if (FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) + 1]))
                                {
                                    Game_Data.directionforKIOneHit.Remove(2);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }

                            }
                            countOfTrys++;
                            goto FindSpotToFire;


                        case 3:
                            if (IsKINextHitValid(ShipToDestroy[0], Game_Data.buttonsPlayerField, -10) && IsFieldEmpty(Game_Data.buttonsPlayerField, Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) - 10]))
                            {
                                if(FieldSelect(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(ShipToDestroy[0]) - 10]))
                                {
                                    Game_Data.directionforKIOneHit.Remove(3);
                                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.Playerturn;
                                    return;
                                }
                                

                            }
                            countOfTrys++;
                            goto FindSpotToFire;
                            
                    }
                    
                }

            }
            MessageBox.Show("Error");
        }
        static public int CheckIfShipIsInARowOrColoumn(List<Button> ShipToDestroy, bool indexisenemyfield)
        {
            //0 = vertikal, 1 = horizontal
            List<int> buttonindex2 = new List<int>();

            foreach (Button button in ShipToDestroy)
            {
                buttonindex2.Add(Game_Data.buttonsEnemyField.IndexOf(button));
               
            }

            buttonindex2.Sort();
            //vertikal
            if (buttonindex2[0] - buttonindex2[1] == 1 || buttonindex2[0] - buttonindex2[1] == -1)
            {
                return 0;
            }

            //horizontal
            if (buttonindex2[0] - buttonindex2[1] == 10 || buttonindex2[0] - buttonindex2[1] == -10)
            {
                return 1;
            }

            return 2;
        }

        static public int CheckIfShipIsInARowOrColoumn(List<Button> ShipToDestroy)
        {
            //0 = vertikal, 1 = horizontal
            List<int> buttonindex2 = new List<int>();

            foreach (Button button in ShipToDestroy)
            {
                buttonindex2.Add(Game_Data.buttonsPlayerField.IndexOf(button));
            }

            buttonindex2.Sort();
            //vertikal
            if (buttonindex2[0] - buttonindex2[1] == 1 || buttonindex2[0] - buttonindex2[1] == -1)
            {
                return 0;
            }

            //horizontal
            if (buttonindex2[0] - buttonindex2[1] == 10 || buttonindex2[0] - buttonindex2[1] == -10)
            {
                return 1;
            }

            return 2;
        }

        static public void KIShipSetv2()
        {
           
            bool KIIsReady = false;
            while (!KIIsReady)
            {

                while (Game_Data.Enemy_Flugzeugträger1.Count < (int)Game_Data.Shipmodel.Flugzeugträger)
                {
                    Random random = new Random();
                    int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                    // 0 = vertikal , 1 = Horizontal
                    int orientation = random.Next(0, 2);

                    if (orientation == 0)
                    {
                        for (int i = 0; i < (int)Game_Data.Shipmodel.Flugzeugträger; i++)
                        {
                            if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                break;
                            Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                        }
                    }

                    if (Game_Data.Enemy_Flugzeugträger1.Count == (int)Game_Data.Shipmodel.Flugzeugträger && !IsShipInColoumn(Game_Data.Enemy_Flugzeugträger1, Game_Data.buttonsEnemyField))
                    {
                        Game_Data.Enemy_Flugzeugträger1.Clear();
                    }

                    if (orientation == 1)
                    {
                        for (int i = 0; i < ((int)Game_Data.Shipmodel.Flugzeugträger * 10); i += 10)
                        {
                            if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                break;
                            Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                        }
                    }

                    if (!(Game_Data.Enemy_Flugzeugträger1.Count == (int)Game_Data.Shipmodel.Flugzeugträger))
                    {
                        Game_Data.Enemy_Flugzeugträger1.Clear();
                    }

                }

                while (Game_Data.Enemy_Kreuzer1.Count < (int)Game_Data.Shipmodel.Kreuzer | (Game_Data.Enemy_Kreuzer2.Count < (int)Game_Data.Shipmodel.Kreuzer))
                {
                    if (Game_Data.Enemy_Kreuzer1.Count < (int)Game_Data.Shipmodel.Kreuzer)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.Kreuzer; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted,indexofbutton + i))
                                {
                                    break;
                                }

                                Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Kreuzer1.Count == (int)Game_Data.Shipmodel.Kreuzer && !IsShipInColoumn(Game_Data.Enemy_Kreuzer1, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_Kreuzer1.Clear();
                        }



                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.Kreuzer * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                {
                                    break;
                                }
                                Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Kreuzer1.Count != (int)Game_Data.Shipmodel.Kreuzer)
                        {
                            Game_Data.Enemy_Kreuzer1.Clear();
                        }

                    }

                    if (Game_Data.Enemy_Kreuzer2.Count < (int)Game_Data.Shipmodel.Kreuzer)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = 0;//random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.Kreuzer; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                {
                                    break;
                                }
                                Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Kreuzer2.Count == (int)Game_Data.Shipmodel.Kreuzer && !IsShipInColoumn(Game_Data.Enemy_Kreuzer2, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_Kreuzer2.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.Kreuzer * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                {
                                    break;
                                }
                                Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Kreuzer2.Count != (int)Game_Data.Shipmodel.Kreuzer)
                        {
                            Game_Data.Enemy_Kreuzer2.Clear();
                        }

                    }


                }

                while (Game_Data.Enemy_Zerstörer1.Count < (int)Game_Data.Shipmodel.Zerstörer | (Game_Data.Enemy_Zerstörer2.Count < (int)Game_Data.Shipmodel.Zerstörer) | (Game_Data.Enemy_Zerstörer3.Count < (int)Game_Data.Shipmodel.Zerstörer))
                {
                    if (Game_Data.Enemy_Zerstörer1.Count < (int)Game_Data.Shipmodel.Zerstörer)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.Zerstörer; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Zerstörer1.Count == (int)Game_Data.Shipmodel.Zerstörer && !IsShipInColoumn(Game_Data.Enemy_Zerstörer1, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_Zerstörer1.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.Zerstörer * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_Zerstörer1.Count == (int)Game_Data.Shipmodel.Zerstörer))
                        {
                            Game_Data.Enemy_Zerstörer1.Clear();
                        }
                    }

                    if (Game_Data.Enemy_Zerstörer2.Count < (int)Game_Data.Shipmodel.Zerstörer)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.Zerstörer; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted,indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Zerstörer2.Count == (int)Game_Data.Shipmodel.Zerstörer && !IsShipInColoumn(Game_Data.Enemy_Zerstörer2, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_Zerstörer2.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.Zerstörer * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_Zerstörer2.Count == (int)Game_Data.Shipmodel.Zerstörer))
                        {
                            Game_Data.Enemy_Zerstörer2.Clear();
                        }
                    }

                    if (Game_Data.Enemy_Zerstörer3.Count < (int)Game_Data.Shipmodel.Zerstörer)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.Zerstörer; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_Zerstörer3.Count == (int)Game_Data.Shipmodel.Zerstörer && !IsShipInColoumn(Game_Data.Enemy_Zerstörer3, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_Zerstörer3.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.Zerstörer * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_Zerstörer3.Count == (int)Game_Data.Shipmodel.Zerstörer))
                        {
                            Game_Data.Enemy_Zerstörer3.Clear();
                        }
                    }

                }

                while (Game_Data.Enemy_UBoot1.Count < (int)Game_Data.Shipmodel.UBoot | (Game_Data.Enemy_UBoot2.Count < (int)Game_Data.Shipmodel.UBoot) | (Game_Data.Enemy_UBoot3.Count < (int)Game_Data.Shipmodel.UBoot) | (Game_Data.Enemy_UBoot4.Count < (int)Game_Data.Shipmodel.UBoot))
                {
                    if (Game_Data.Enemy_UBoot1.Count < (int)Game_Data.Shipmodel.UBoot)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.UBoot; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_UBoot1.Count == (int)Game_Data.Shipmodel.UBoot && !IsShipInColoumn(Game_Data.Enemy_UBoot1, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_UBoot1.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.UBoot * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_UBoot1.Count == (int)Game_Data.Shipmodel.UBoot))
                        {
                            Game_Data.Enemy_UBoot1.Clear();
                        }
                    }

                    if (Game_Data.Enemy_UBoot2.Count < (int)Game_Data.Shipmodel.UBoot)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.UBoot; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_UBoot2.Count == (int)Game_Data.Shipmodel.UBoot && !IsShipInColoumn(Game_Data.Enemy_UBoot2, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_UBoot2.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.UBoot * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_UBoot2.Count == (int)Game_Data.Shipmodel.UBoot))
                        {
                            Game_Data.Enemy_UBoot2.Clear();
                        }
                    }

                    if (Game_Data.Enemy_UBoot3.Count < (int)Game_Data.Shipmodel.UBoot)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.UBoot; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_UBoot3.Count == (int)Game_Data.Shipmodel.UBoot && !IsShipInColoumn(Game_Data.Enemy_UBoot3, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_UBoot3.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.UBoot * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_UBoot3.Count == (int)Game_Data.Shipmodel.UBoot))
                        {
                            Game_Data.Enemy_UBoot3.Clear();
                        }
                    }

                    if (Game_Data.Enemy_UBoot4.Count < (int)Game_Data.Shipmodel.UBoot)
                    {
                        Thread.Sleep(30);
                        Random random = new Random();
                        int indexofbutton = random.Next(Game_Data.buttonsEnemyField.Count);

                        // 0 = vertikal , 1 = Horizontal
                        int orientation = random.Next(0, 2);

                        if (orientation == 0)
                        {
                            for (int i = 0; i < (int)Game_Data.Shipmodel.UBoot; i++)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (Game_Data.Enemy_UBoot4.Count == (int)Game_Data.Shipmodel.UBoot && !IsShipInColoumn(Game_Data.Enemy_UBoot4, Game_Data.buttonsEnemyField))
                        {
                            Game_Data.Enemy_UBoot4.Clear();
                        }

                        if (orientation == 1)
                        {
                            for (int i = 0; i < ((int)Game_Data.Shipmodel.UBoot * 10); i += 10)
                            {
                                if ((indexofbutton + i) >= 100 || !IsFieldEmpty(Game_Data.Enemy_Shipsetted, indexofbutton + i))
                                    break;
                                Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofbutton + i]);
                            }
                        }

                        if (!(Game_Data.Enemy_UBoot4.Count == (int)Game_Data.Shipmodel.UBoot))
                        {
                            Game_Data.Enemy_UBoot4.Clear();
                        }
                    }



                }

                int countOfShips = 0;

                foreach (List<List<Button>> listtoclear in Game_Data.Enemy_Shipsetted)
                {
                    foreach (List<Button> listlisttoclear in listtoclear)
                    {
                        foreach(Button buttonToCount in listlisttoclear)
                        {
                            countOfShips++;
                        }
                    }
                }

                if (countOfShips == 30 && WereShipsRightSetted(Game_Data.Enemy_Shipsetted,Game_Data.buttonsEnemyField))
                {

                    KIIsReady = true;
                    MessageBox.Show("KI ist bereit!", "Start");
                }


                StreamWriter writer1 = new StreamWriter(File.Open(@".\Index.txt", FileMode.Append));

                foreach (List<List<Button>> list in Game_Data.Enemy_Shipsetted)
                {
                    foreach (List<Button> listlist in list)
                    {
                        foreach (Button button in listlist)
                        {
                            writer1.WriteLine(Game_Data.buttonsEnemyField.IndexOf(button));
                        }
                    }
                }
                writer1.WriteLine("Satz beendet");
                writer1.Close();
            }

           
        }
        //static public void KIShipSet()
        //{
        //    var random = new Random();

        //    bool KiIsReady = false;

            
        //    while (!KiIsReady)
        //    {
        //        int testindex = 0;
        //        int testrange = 0;
        //        //try
        //        //{
                    
        //            int range = Game_Data.buttonsEnemyField.Count;
        //            testrange = range;

        //            while (Game_Data.Enemy_Flugzeugträger1.Count < 5)
        //            {                        
        //                int indexofButton = random.Next(range);

        //                testindex = indexofButton;

        //                //0 = vertikal , 1 = Horizontal
        //                int orientation = random.Next(0, 2);

        //                //0 = Left , 1 = Right
        //                int direction = random.Next(0, 2);

        //                Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                if (orientation == 0)
        //                {
        //                    if (direction == 0 && indexofButton - 4 > 0)
        //                    {
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 3]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 4]);

        //                    }

        //                    if (direction == 1 && indexofButton + 4 < 100)
        //                    {
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 3]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 4]);
        //                    }

        //                }

        //                if (orientation == 1)
        //                {
        //                    if (direction == 0 && indexofButton - 40 > 0)
        //                    {
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 30]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton - 40]);
        //                    }

        //                    if (direction == 1 && indexofButton + 40 < 100)
        //                    {
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 30]);
        //                        Game_Data.Enemy_Flugzeugträger1.Add(Game_Data.buttonsEnemyField[indexofButton + 40]);
        //                    }

        //                }

        //                if (Game_Data.Enemy_Flugzeugträger1.Count == 5 && CheckForPossibilityToSet(Game_Data.Enemy_Flugzeugträger1, (int)Game_Data.Shipmodel.Flugzeugträger, false))
        //                {
        //                    foreach (Button buttontodelete in Game_Data.Enemy_Flugzeugträger1)
        //                    {
        //                        Game_Data.buttonsEnemyField.Remove(buttontodelete);
                                
        //                    }
        //                    SetSpaceBetweenShipts(Game_Data.Enemy_Flugzeugträger1, Game_Data.buttonsEnemyField);
        //                    range = Game_Data.buttonsEnemyField.Count;
        //                break;

        //                }

        //                else
        //                {
        //                    Game_Data.Enemy_Flugzeugträger1.Clear();
        //                }
        //            }


        //            while (Game_Data.Enemy_Kreuzer1.Count < 4 | Game_Data.Enemy_Kreuzer2.Count < 4)
        //            {
        //                int indexofButton = random.Next(range);
        //                testindex = indexofButton;

        //                //0 = vertikal , 1 = Horizontal
        //                int orientation = random.Next(0, 2);

        //                //0 = Left , 1 = Right
        //                int direction = random.Next(0, 2);

        //                if (Game_Data.Enemy_Kreuzer1.Count < 4)
        //                {
        //                    Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 3 > 0)
        //                        {
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 3]);

        //                        }

        //                        if (direction == 1 && indexofButton + 3 < 100)
        //                        {
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 3]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 30 > 0)
        //                        {
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton - 30]);
        //                        }

        //                        if (direction == 1 && indexofButton + 30 < 100)
        //                        {
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                            Game_Data.Enemy_Kreuzer1.Add(Game_Data.buttonsEnemyField[indexofButton + 30]);
        //                        }

        //                    }

        //                    if (Game_Data.Enemy_Kreuzer1.Count == 4 && CheckForPossibilityToSet(Game_Data.Enemy_Kreuzer1, (int)Game_Data.Shipmodel.Kreuzer, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_Kreuzer1)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
                                
        //                        }
        //                        SetSpaceBetweenShipts(Game_Data.Enemy_Kreuzer1, Game_Data.buttonsEnemyField);
        //                        range = Game_Data.buttonsEnemyField.Count;

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_Kreuzer1.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_Kreuzer2.Count < 4)
        //                {
        //                    Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 3 > 0)
        //                        {
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 3]);

        //                        }

        //                        if (direction == 1 && indexofButton + 3 < 100)
        //                        {
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 3]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 30 > 0)
        //                        {
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton - 30]);
        //                        }

        //                        if (direction == 1 && indexofButton + 30 < 100)
        //                        {
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                            Game_Data.Enemy_Kreuzer2.Add(Game_Data.buttonsEnemyField[indexofButton + 30]);
        //                        }

        //                    }

        //                    if (Game_Data.Enemy_Kreuzer2.Count == 4 && CheckForPossibilityToSet(Game_Data.Enemy_Kreuzer2, (int)Game_Data.Shipmodel.Kreuzer, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_Kreuzer2)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
                                    
        //                        }
        //                        SetSpaceBetweenShipts(Game_Data.Enemy_Kreuzer2, Game_Data.buttonsEnemyField);
        //                        range = Game_Data.buttonsEnemyField.Count;

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_Kreuzer2.Clear();
        //                    }

        //                }

        //            }

        //            while (Game_Data.Enemy_Zerstörer1.Count < 3 | Game_Data.Enemy_Zerstörer2.Count < 3 | Game_Data.Enemy_Zerstörer3.Count < 3)
        //            {

        //                int indexofButton = random.Next(range);
        //                testindex = indexofButton;

        //                //0 = vertikal , 1 = Horizontal
        //                int orientation = random.Next(0, 2);

        //                //0 = Left , 1 = Right
        //                int direction = random.Next(0, 2);

        //                if (Game_Data.Enemy_Zerstörer1.Count < 3)
        //                {
        //                    Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 2 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);

        //                        }

        //                        if (direction == 1 && indexofButton + 2 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 20 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                        }

        //                        if (direction == 1 && indexofButton + 20 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                            Game_Data.Enemy_Zerstörer1.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                        }

        //                    }

        //                    if (Game_Data.Enemy_Zerstörer1.Count == 3 && CheckForPossibilityToSet(Game_Data.Enemy_Zerstörer1, (int)Game_Data.Shipmodel.Zerstörer, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_Zerstörer1)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_Zerstörer1, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_Zerstörer1.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_Zerstörer2.Count < 3)
        //                {
        //                    Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 2 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);

        //                        }

        //                        if (direction == 1 && indexofButton + 2 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 20 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                        }

        //                        if (direction == 1 && indexofButton + 20 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                            Game_Data.Enemy_Zerstörer2.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                        }

        //                    }

        //                    if (Game_Data.Enemy_Zerstörer2.Count == 3 && CheckForPossibilityToSet(Game_Data.Enemy_Zerstörer2, (int)Game_Data.Shipmodel.Zerstörer, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_Zerstörer2)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_Zerstörer2, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_Zerstörer2.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_Zerstörer3.Count < 3)
        //                {
        //                    Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 2 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton - 2]);

        //                        }

        //                        if (direction == 1 && indexofButton + 2 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton + 2]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 20 > 0)
        //                        {
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton - 20]);
        //                        }

        //                        if (direction == 1 && indexofButton + 20 < 100)
        //                        {
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);
        //                            Game_Data.Enemy_Zerstörer3.Add(Game_Data.buttonsEnemyField[indexofButton + 20]);
        //                        }

        //                    }

        //                    if (Game_Data.Enemy_Zerstörer3.Count == 3 && CheckForPossibilityToSet(Game_Data.Enemy_Zerstörer3, (int)Game_Data.Shipmodel.Zerstörer, false))
        //                    {
        //                    foreach (Button buttontodelete in Game_Data.Enemy_Zerstörer3)
        //                    {
        //                        Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                        SetSpaceBetweenShipts(Game_Data.Enemy_Zerstörer3, Game_Data.buttonsEnemyField);
        //                        range = Game_Data.buttonsEnemyField.Count;

        //                    }
        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_Zerstörer3.Clear();
        //                    }

        //                }

        //            }


        //            while (Game_Data.Enemy_UBoot1.Count < 2 | Game_Data.Enemy_UBoot2.Count < 2 | Game_Data.Enemy_UBoot3.Count < 2 | Game_Data.Enemy_UBoot4.Count < 2)
        //            {

        //                int indexofButton = random.Next(range);
        //                testindex = indexofButton;

        //                //0 = vertikal , 1 = Horizontal
        //                int orientation = random.Next(0, 2);

        //                //0 = Left , 1 = Right
        //                int direction = random.Next(0, 2);

        //                if (Game_Data.Enemy_UBoot1.Count < 2)
        //                {
        //                    Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 1 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);

        //                        }

        //                        if (direction == 1 && indexofButton + 1 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 10 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                        }

        //                        if (direction == 1 && indexofButton + 10 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot1.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);

        //                        }

        //                    }

        //                    if (Game_Data.Enemy_UBoot1.Count == 2 && CheckForPossibilityToSet(Game_Data.Enemy_UBoot1, (int)Game_Data.Shipmodel.UBoot, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_UBoot1)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_UBoot1, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_UBoot1.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_UBoot2.Count < 2)
        //                {
        //                    Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 1 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);

        //                        }

        //                        if (direction == 1 && indexofButton + 1 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 10 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                        }

        //                        if (direction == 1 && indexofButton + 10 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot2.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);

        //                        }

        //                    }

        //                    if (Game_Data.Enemy_UBoot2.Count == 2 && CheckForPossibilityToSet(Game_Data.Enemy_UBoot2, (int)Game_Data.Shipmodel.UBoot, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_UBoot2)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_UBoot2, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_UBoot2.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_UBoot3.Count < 2)
        //                {
        //                    Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 1 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);

        //                        }

        //                        if (direction == 1 && indexofButton + 1 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 10 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                        }

        //                        if (direction == 1 && indexofButton + 10 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot3.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);

        //                        }

        //                    }

        //                    if (Game_Data.Enemy_UBoot3.Count == 2 && CheckForPossibilityToSet(Game_Data.Enemy_UBoot3, (int)Game_Data.Shipmodel.UBoot, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_UBoot3)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_UBoot3, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_UBoot3.Clear();
        //                    }

        //                }

        //                if (Game_Data.Enemy_UBoot4.Count < 2)
        //                {
        //                    Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofButton]);

        //                    if (orientation == 0)
        //                    {
        //                        if (direction == 0 && indexofButton - 1 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofButton - 1]);

        //                        }

        //                        if (direction == 1 && indexofButton + 1 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofButton + 1]);
        //                        }

        //                    }

        //                    if (orientation == 1)
        //                    {
        //                        if (direction == 0 && indexofButton - 10 > 0)
        //                        {
        //                            Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofButton - 10]);
        //                        }

        //                        if (direction == 1 && indexofButton + 10 < 100)
        //                        {
        //                            Game_Data.Enemy_UBoot4.Add(Game_Data.buttonsEnemyField[indexofButton + 10]);

        //                        }

        //                    }

        //                    if (Game_Data.Enemy_UBoot4.Count == 2 && CheckForPossibilityToSet(Game_Data.Enemy_UBoot4, (int)Game_Data.Shipmodel.UBoot, false))
        //                    {
        //                        foreach (Button buttontodelete in Game_Data.Enemy_UBoot4)
        //                        {
        //                            Game_Data.buttonsEnemyField.Remove(buttontodelete);
        //                            SetSpaceBetweenShipts(Game_Data.Enemy_UBoot4, Game_Data.buttonsEnemyField);
        //                            range = Game_Data.buttonsEnemyField.Count;
        //                        }

        //                    }

        //                    else
        //                    {
        //                        Game_Data.Enemy_UBoot4.Clear();
        //                    }

        //                }

        //            }
                  
        //        //}

        //        //catch(Exception ex)
        //        //{
        //        //    MessageBox.Show(ex.Source + "Index Choice: " + testindex.ToString() + "Range: " + testrange.ToString());
        //        //    foreach (List<List<Button>> listtocheck in Game_Data.Enemy_Shipsetted)
        //        //    {
        //        //        foreach(List<Button> listlisttocheck in listtocheck)
        //        //        {
        //        //            listlisttocheck.Clear();
        //        //        }
        //        //    }
        //        //    Game_Data.enemyField.Close();
        //        //    Game_Data.enemyField = new EnemyField();
        //        //    Game_Data.enemyField.Show();
        //        //    Game_Data.enemyField.WindowStartupLocation = WindowStartupLocation.Manual;
        //        //    Game_Data.enemyField.Left = 1000d;
        //        //    Game_Data.enemyField.Top = 300d;
        //        //    KIShipSet();
        //        //}

        //        KiIsReady = true;
        //        MessageBox.Show("KI is ready");
        //    }
            

        //}

        static public void SetSpaceBetweenShipts(List<Button> Ship, List<Button> Field)
        {
            foreach(Button button in Ship)
            {

                    if (Field.IndexOf(button) + 1 < 100 && !Ship.Contains(Field.ElementAt(Field.IndexOf(button) + 1)))
                    {
                        Field.Remove(button);
                    }

                    if (Field.IndexOf(button) - 1 > 0 && !Ship.Contains(Field.ElementAt(Field.IndexOf(button) - 1)))
                    {
                        Field.Remove(button);
                    }

                    if (Field.IndexOf(button) - 10 > 0 && !Ship.Contains(Field.ElementAt(Field.IndexOf(button) - 10)))
                    {
                        Field.Remove(button);
                    }
 
                    if (Field.IndexOf(button) + 10 < 100 && !Ship.Contains(Field.ElementAt(Field.IndexOf(button) + 10)))
                    {
                        Field.Remove(button);
                    }
            }
        }

        static public void PlayerTurn(object sender)
        {

            if (Game_Data.buttonsPlayerField.Count > 0)
            {

                if (Game_Data.playerorKITurn == (int)Game_Data.PlayerOrKITurn.Playerturn)
                {
                    FieldSelect(sender);

                }
               

                else
                {
                    MessageBox.Show("Der Computer ist an der Reihe!");
                }
            }

            else
            {
                //Keine Züge mehr verfügbar = Fehler! 

            }


        }

        static public void FieldClear(object sender)
        {
            if (Game_Data.gamestate == (int)Game_Data.Gamestate.initialized)
            {
                Button ButtonToClear = (Button)sender;
                ButtonToClear.Content = "";
            }
        }

        static public bool FieldSelect(object sender)
        {
            Button ButtonToSelect = (Button)sender;

            if(Game_Data.gamestate == (int)Game_Data.Gamestate.initialized && (string)ButtonToSelect.Content == "X")
            {
                MessageBox.Show("Dieses Feld wurde bereits gewählt, bitte wählen Sie ein Neues", "Fehler");
                return false;
            }

            if (Game_Data.playerorKITurn == (int)Game_Data.PlayerOrKITurn.Playerturn &&(string)ButtonToSelect.Content == "X")
            {
                MessageBox.Show("Dieses Feld wurde bereits gewählt, bitte wählen Sie ein Neues","Fehler");
                return false;
            }

            if(Game_Data.gamestate == (int)Game_Data.Gamestate.initialized)
            {
                ButtonToSelect.Content = "X";
                ButtonToSelect.FontSize = 20;
                return true;
            }

            if (Game_Data.gamestate == (int)Game_Data.Gamestate.started)
            {
                if(Game_Data.playerorKITurn == (int)Game_Data.PlayerOrKITurn.KITurn)
                {
                    foreach (List<List<Button>> listtocheck in Game_Data.Player_Shipsetted)
                    {
                        foreach (List<Button> listlisttocheck in listtocheck)
                        {
                            if (listlisttocheck.Contains(ButtonToSelect) )
                            {
                                if (Game_Data.SoundOnOrOff)
                                {
                                    SoundPlayer soundPlayerhit = new SoundPlayer();
                                    soundPlayerhit.Stream = File.Open(@".\Hit.wav", FileMode.Open);
                                    soundPlayerhit.Play();
                                    Thread.Sleep(6000);
                                    soundPlayerhit.Stream.Close();
                                }
                                ButtonToSelect.Content = "X";
                                ButtonToSelect.FontSize = 20;
                                ButtonToSelect.Foreground = Brushes.Red;
                                Game_Data.ShipToDestroy.Add(ButtonToSelect);
                                listlisttocheck.Remove(ButtonToSelect);
                                Game_Data.HitOnShip++;
                                if (listlisttocheck.Count == 0)
                                {
                                    MessageBox.Show("KI hat Schiff versenkt");
                                    Game_Data.HitOnShip = 0;
                                    Game_Data.ShipToDestroy.Clear();
                                    Game_Data.directionforKIOneHit = new List<int> { 0,1,2,3};
                                    Game_Data.directionforKIMultipleHit = new List<int> { 0, 1 };
                                    CheckIfGameOver();
                                }
                                return true;
                            }
                           
                        }

                    }
                    if((string)ButtonToSelect.Content == "X" && (ButtonToSelect.Foreground == Brushes.Blue | ButtonToSelect.Foreground == Brushes.Red))
                    {
                        return false;
                    }
                    if(Game_Data.SoundOnOrOff)
                    {
                        SoundPlayer soundPlayer = new SoundPlayer();
                        soundPlayer.Stream = File.Open(@".\Missed.wav", FileMode.Open);
                        soundPlayer.Play();
                        Thread.Sleep(4000);
                        soundPlayer.Stream.Close();
                    }
                    ButtonToSelect.Content = "X";
                    ButtonToSelect.FontSize = 20;
                    ButtonToSelect.Foreground = Brushes.Blue;
                    return true;
                }

                if (Game_Data.playerorKITurn == (int)Game_Data.PlayerOrKITurn.Playerturn)
                {
                    foreach (List<List<Button>> listtocheck in Game_Data.Enemy_Shipsetted)
                    {
                        foreach (List<Button> listlisttocheck in listtocheck)
                        {
                            if (listlisttocheck.Contains(ButtonToSelect))
                            {
                                if (Game_Data.SoundOnOrOff)
                                {
                                    SoundPlayer soundPlayerhit = new SoundPlayer();
                                    soundPlayerhit.Stream = File.Open(@".\Hit.wav", FileMode.Open);
                                    soundPlayerhit.Play();
                                    Thread.Sleep(6000);
                                    soundPlayerhit.Stream.Close();
                                }
                                ButtonToSelect.Content = "X";
                                ButtonToSelect.FontSize = 20;
                                ButtonToSelect.Foreground = Brushes.Red;
                                listlisttocheck.Remove(ButtonToSelect);
                                if (listlisttocheck.Count == 0)
                                {
                                    MessageBox.Show("Schiff wurde versenkt", "Treffer!");
                                    CheckIfGameOver();

                                }
                                Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.KITurn;
                                KITurn(Game_Data.ShipToDestroy);
                                return true;
                            }

                        }

                    }

                    if (Game_Data.SoundOnOrOff)
                    {
                        SoundPlayer soundPlayer = new SoundPlayer();
                        soundPlayer.Stream = File.Open(@".\Missed.wav", FileMode.Open);
                        soundPlayer.Play();
                        Thread.Sleep(4000);
                        soundPlayer.Stream.Close();
                    }
                    ButtonToSelect.Content = "X";
                    ButtonToSelect.FontSize = 20;
                    ButtonToSelect.Foreground = Brushes.Blue;
                    Game_Data.playerorKITurn = (int)Game_Data.PlayerOrKITurn.KITurn;
                    KITurn(Game_Data.ShipToDestroy);
                    return true;

                }

            }
            return false;
        }

        static public bool IsFieldEmpty(List<List<List<Button>>> ShipSetToCheck , int IndexOfButton)
        {
            List<int> indexesOfShipsSetted = new List<int>();

            foreach (List<List<Button>> listtocheck in ShipSetToCheck)
            {
                foreach (List<Button> listlisttocheck in listtocheck)
                {
                    foreach(Button button in listlisttocheck)
                    {
                        indexesOfShipsSetted.Add(Game_Data.buttonsEnemyField.IndexOf(button));
                    }

                }
            }

            //StreamWriter writer1 = new StreamWriter(File.Open(@".\Index.txt", FileMode.Append));
            //writer1.WriteLine("Index:");
            //foreach (int index in indexesOfShipsSetted)
            //{
            //    writer1.WriteLine(index);
            //}
            //writer1.WriteLine("Index of Button:" + IndexOfButton);
            //writer1.WriteLine("Index Ende");
            //writer1.Close();

            return (!indexesOfShipsSetted.Contains(IndexOfButton));
            
        }

        static public bool WereShipsRightSetted(List<List<List<Button>>> ShipSetToCheck, List<Button> FieldToCheck)
        {
            //StreamWriter writer1 = new StreamWriter(File.Open(@".\Index.txt", FileMode.Append));
            //writer1.WriteLine("False");
            //writer1.Close();
            foreach (List<List<Button>> listofShips in ShipSetToCheck)
            {

                foreach (List<Button> Ship in listofShips)
                {
                        // 0 = Vertikal, 1 = Horizontal
                        if (CheckIfShipIsInARowOrColoumn(Ship, true) == 0)
                        {
                            for (int i = 0; i < Ship.Count - 1; i++)
                            {
                                foreach (List<List<Button>> listofShips2 in ShipSetToCheck)
                                {
                                    foreach (List<Button> Ship2 in listofShips2)
                                    {
                                        foreach (Button buttonToCheck in Ship2)
                                        {
                                            if (i == 0)
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }



                                            }

                                            if (i == Ship.Count - 1)
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }


                                            }

                                            else
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }


                                            }

                                        }

                                    }
                                }

                            }
                        }

                        if (CheckIfShipIsInARowOrColoumn(Ship, true) == 1)
                        {
                            for (int i = 0; i < Ship.Count - 1; i++)
                            {
                                foreach (List<List<Button>> listofShips2 in ShipSetToCheck)
                                {
                                    foreach (List<Button> Ship2 in listofShips2)
                                    {
                                        foreach (Button buttonToCheck in Ship2)
                                        {
                                            if (i == 0)
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }



                                            }

                                            if (i == Ship.Count - 1)
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +10) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 10])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                            }

                                            else
                                            {
                                                if (IsKINextHitValid(Ship[i], FieldToCheck, -1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) - 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }

                                                if (IsKINextHitValid(Ship[i], FieldToCheck, +1) && buttonToCheck == FieldToCheck[FieldToCheck.IndexOf(Ship[i]) + 1])
                                                {
                                                    Ship.Clear();
                                                    return false;
                                                }


                                            }

                                        }

                                    }
                                }

                            }

                        }

                    



                }
            }

            int countOfShips = 0;

            foreach (List<List<Button>> listtoclear in Game_Data.Enemy_Shipsetted)
            {
                foreach (List<Button> listlisttoclear in listtoclear)
                {
                    foreach (Button buttonToCount in listlisttoclear)
                    {
                        countOfShips++;
                    }
                }
            }

            if (countOfShips == 30)
            {
                return true;
            }

            else return false;
        }
        
        static public bool IsFieldEmpty(List<Button> Field, Button HitToCheck)
        {
            foreach(Button FieldToCheck in Field )
            {
                if(FieldToCheck == HitToCheck && (string)FieldToCheck.Content == "X" && (FieldToCheck.Foreground == Brushes.Blue | FieldToCheck.Foreground == Brushes.Red))
                {
                    return false;
                }
            }
            return true;
        }

        static public bool IsShipInColoumn(List<Button> ShipToCheck, List<Button> FieldToCheck)
        {
            if(FieldToCheck.IndexOf(ShipToCheck[0]) > 0 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 9)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 9)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 9 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 19)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 19)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 19 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 29)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 29)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 29 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 39)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 39)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 39 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 49)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 49)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 49 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 59)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 59)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 59 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 69)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 69)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 69 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 79)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 79)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 79 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 89)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 89)
                {
                    return true;
                }

                else return false;
            }


            if (FieldToCheck.IndexOf(ShipToCheck[0]) > 89 & FieldToCheck.IndexOf(ShipToCheck[0]) <= 99)
            {
                if (FieldToCheck.IndexOf(ShipToCheck[(ShipToCheck.Count - 1)]) <= 99)
                {
                    return true;
                }

                else return false;
            }

            else return false;
        }

        static public bool IsKINextHitValid(Button HitToCheck, List<Button> FieldToCheck, int direction)
        {
            if(FieldToCheck.IndexOf(HitToCheck) == 0)
            {                

                if (direction == 1 )
                {
                    return true;
                }

                if (direction == 10)
                {
                    return true;
                }

                else return false;
            }
     
            if (FieldToCheck.IndexOf(HitToCheck) > 0 & FieldToCheck.IndexOf(HitToCheck) <= 9)
            {
                if (direction == -1)
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 9)
                {
                    return true;
                }

                if (direction == 10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 9 & FieldToCheck.IndexOf(HitToCheck) <= 19)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 10))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 19)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }
            if (FieldToCheck.IndexOf(HitToCheck) > 19 & FieldToCheck.IndexOf(HitToCheck) <= 29)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 20))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 29)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 29 & FieldToCheck.IndexOf(HitToCheck) <= 39)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 30))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 39)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 39 & FieldToCheck.IndexOf(HitToCheck) <= 49)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 40))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 49)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 49 & FieldToCheck.IndexOf(HitToCheck) <= 59)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 50))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 59)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 59 & FieldToCheck.IndexOf(HitToCheck) <= 69)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 60))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 69)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 69 & FieldToCheck.IndexOf(HitToCheck) <= 79)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 70))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 79)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 79 & FieldToCheck.IndexOf(HitToCheck) <= 89)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 80))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 89)
                {
                    return true;
                }

                if (direction == 10 | direction == -10)
                {
                    return true;
                }

                else return false;
            }


            if (FieldToCheck.IndexOf(HitToCheck) > 89 & FieldToCheck.IndexOf(HitToCheck) <= 99)
            {
                if (direction == -1 && (FieldToCheck.IndexOf(HitToCheck) > 90))
                {
                    return true;
                }

                if (direction == 1 && FieldToCheck.IndexOf(HitToCheck) < 99)
                {
                    return true;
                }

                if (direction == -10)
                {
                    return true;
                }

                else return false;
            }
            return false;
        }

        static public bool MakeHitSense(List<List<List<Button>>> ShipSetToCheck, Button HitToCheck)
        {
            bool HitMakeSense = false;

            int smallestShip = 2;
            foreach(List<List<Button>> Ships in ShipSetToCheck)
                foreach(List<Button> Shipleft in Ships)
                {
                    if (Shipleft.Count == smallestShip)
                        break;

                    if (Shipleft.Count > smallestShip)
                    {
                        smallestShip = Shipleft.Count;
                        break;
                    }
                }

            for(int i = 0; i < smallestShip; i++)
            {
                HitMakeSense = IsKINextHitValid(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(HitToCheck)+ i], Game_Data.buttonsPlayerField, 1);
               
            }

            if (HitMakeSense)
                return true;

            for (int i = 0; i < smallestShip; i++)
            {
                HitMakeSense = IsKINextHitValid(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(HitToCheck) + i], Game_Data.buttonsPlayerField, 10);

            }

            if (HitMakeSense)
                return true;

            for (int i = 0; i < smallestShip; i++)
            {
                HitMakeSense = IsKINextHitValid(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(HitToCheck) + i], Game_Data.buttonsPlayerField, -1);

            }

            if (HitMakeSense)
                return true;

            for (int i = 0; i < smallestShip; i++)
            {
                HitMakeSense = IsKINextHitValid(Game_Data.buttonsPlayerField[Game_Data.buttonsPlayerField.IndexOf(HitToCheck) + i], Game_Data.buttonsPlayerField, -10);

            }

            if (HitMakeSense)
                return true;

            return false;
        }

        static public bool IsKINextRandomHitValid(Button HitToCheck, List<Button> FieldToCheck)
        {
            if (FieldToCheck.IndexOf(HitToCheck) == 0)
            {

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 0 & FieldToCheck.IndexOf(HitToCheck) <= 9)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 9 & FieldToCheck.IndexOf(HitToCheck) <= 19)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }
            if (FieldToCheck.IndexOf(HitToCheck) > 19 & FieldToCheck.IndexOf(HitToCheck) <= 29)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 29 & FieldToCheck.IndexOf(HitToCheck) <= 39)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 39 & FieldToCheck.IndexOf(HitToCheck) <= 49)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 49 & FieldToCheck.IndexOf(HitToCheck) <= 59)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 59 & FieldToCheck.IndexOf(HitToCheck) <= 69)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 69 & FieldToCheck.IndexOf(HitToCheck) <= 79)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) > 79 & FieldToCheck.IndexOf(HitToCheck) <= 89)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }


            if (FieldToCheck.IndexOf(HitToCheck) > 89 & FieldToCheck.IndexOf(HitToCheck) < 99)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) + 1].Foreground == Brushes.Red)
                {
                    return false;
                }

                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }

            if (FieldToCheck.IndexOf(HitToCheck) == 99)
            {
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 1].Foreground == Brushes.Red)
                {
                    return false;
                }
                if ((string)FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Content == "X" && FieldToCheck[FieldToCheck.IndexOf(HitToCheck) - 10].Foreground == Brushes.Red)
                {
                    return false;
                }

                else return true;
            }
            return false;
        }
            
        static bool CheckForPossibilityToSet(List<Button> shipSetToCheck, int placesused, bool isPlayerField)
        {
            List<int> buttonindex2 = new List<int>();
            bool returnvar = false;

            if(isPlayerField)
            {
                foreach (Button button in shipSetToCheck)
                {
                    buttonindex2.Add(Game_Data.buttonsPlayerField.IndexOf(button));
                }
            }

            else
            {
                foreach (Button button in shipSetToCheck)
                {
                    buttonindex2.Add(Game_Data.buttonsEnemyFieldReference.IndexOf(button));
                }
            }
            
            buttonindex2.Sort();
            //vertikal
            if (buttonindex2[0] - buttonindex2[1] == 1 || buttonindex2[0] - buttonindex2[1] == -1)
            {
                if (buttonindex2.Max() - buttonindex2.Min() == placesused - 1 || (buttonindex2.Max() - buttonindex2.Min() == -(placesused - 1)))
                {
                    returnvar = true;
                }

                else returnvar = false;
            }

            //horizontal
            if (buttonindex2[0] - buttonindex2[1] == 10 || buttonindex2[0] - buttonindex2[1] == -10)
            {
                if (buttonindex2.Max() - buttonindex2.Min() == ((placesused - 1) * 10) || buttonindex2.Max() - buttonindex2.Min()== -(10 * (placesused - 1)))
                {
                    returnvar = true;
                }

                else
                {
                    returnvar = false;
                }
                 
            }

            return returnvar;

        }

        static public void Shipset(object sender)
        {
            
            if (Game_Data.gamestate == (int)Game_Data.Gamestate.initialized)
            {
                switch (Game_Data.shiptoset)
                {
                    case 2:                       

                        if (!FieldSelect(sender))
                            return;

                        if (Game_Data.Uboot[Game_Data.indexoflist].Count < 2)
                        {
                            Game_Data.Uboot[Game_Data.indexoflist].Add((Button)sender);
                        }

                        else
                        {
                            Game_Data.indexoflist += 1;
                            Game_Data.Uboot[Game_Data.indexoflist].Add((Button)sender);

                        }

                        foreach (TextBlock blocktocheck in Game_Data.XOnTheRightSideForShips)
                        {
                            if (blocktocheck.Visibility == Visibility.Visible)
                            {
                                blocktocheck.Visibility = Visibility.Hidden;
                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 1 && CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true)) //&& WereShipsRightSetted(Game_Data.Player_Shipsetted, Game_Data.buttonsPlayerField))
                                {

                                    MessageBox.Show("U-Boot 1 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }


                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 3 && CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true)) //&& WereShipsRightSetted(Game_Data.Player_Shipsetted, Game_Data.buttonsPlayerField))
                                {

                                    MessageBox.Show("U-Boot 2 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }

                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 5 && CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true)) //&& WereShipsRightSetted(Game_Data.Player_Shipsetted, Game_Data.buttonsPlayerField))
                                {

                                    MessageBox.Show("U-Boot 3 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }

                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 7 && CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true)) //&& WereShipsRightSetted(Game_Data.Player_Shipsetted, Game_Data.buttonsPlayerField))
                                {

                                    MessageBox.Show("U-Boot 4 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    CheckIfAllShipsWereSet();
                                    return;
                                }


                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 1 && !CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 3 && !CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 5 && !CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }
                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 7 && !CheckForPossibilityToSet(Game_Data.Uboot[Game_Data.indexoflist], (int)Game_Data.Shipmodel.UBoot, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                return;

                            }

                        }
                        break;
                    case 3:
                        
                        if (!FieldSelect(sender))
                            return;

                        if (Game_Data.Zerstörer[Game_Data.indexoflist].Count < 3)
                        {
                            Game_Data.Zerstörer[Game_Data.indexoflist].Add((Button)sender);
                        }

                        else
                        {
                            Game_Data.indexoflist += 1;
                            Game_Data.Zerstörer[Game_Data.indexoflist].Add((Button)sender);

                        }

                        foreach (TextBlock blocktocheck in Game_Data.XOnTheRightSideForShips)
                        {
                            if (blocktocheck.Visibility == Visibility.Visible)
                            {
                                blocktocheck.Visibility = Visibility.Hidden;
                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 2 && CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {

                                    MessageBox.Show("Zerstörer 1 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }


                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 5 && CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {

                                    MessageBox.Show("Zerstörer 2 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }

                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 8 && CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {

                                    MessageBox.Show("Zerstörer 3 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    Game_Data.indexoflist = 0;
                                    CheckIfAllShipsWereSet();
                                    return;
                                }


                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 2 && !CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 5 && !CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 8 && !CheckForPossibilityToSet(Game_Data.Zerstörer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Zerstörer, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                return;

                            }

                        }
                        break;

                    case 4:

                        if (!FieldSelect(sender))
                            return;

                        if (Game_Data.Kreuzer[Game_Data.indexoflist].Count < 4)
                        {
                            Game_Data.Kreuzer[Game_Data.indexoflist].Add((Button)sender);
                        }

                        else
                        {
                            Game_Data.indexoflist += 1;
                            Game_Data.Kreuzer[Game_Data.indexoflist].Add((Button)sender);

                        }

                        foreach (TextBlock blocktocheck in Game_Data.XOnTheRightSideForShips)
                        {
                            if (blocktocheck.Visibility == Visibility.Visible)
                            { 
                                blocktocheck.Visibility = Visibility.Hidden;
                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 3 && CheckForPossibilityToSet(Game_Data.Kreuzer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Kreuzer, true))
                                {
                                    
                                    MessageBox.Show("Kreuzer 1 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    return;
                                }

                                
                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 7 && CheckForPossibilityToSet(Game_Data.Kreuzer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Kreuzer, true))
                                {
                                    
                                    MessageBox.Show("Kreuzer 2 wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    Game_Data.indexoflist = 0;
                                    CheckIfAllShipsWereSet();
                                    return;
                                }
                            

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 3 && !CheckForPossibilityToSet(Game_Data.Kreuzer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Kreuzer, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 7 && !CheckForPossibilityToSet(Game_Data.Kreuzer[Game_Data.indexoflist], (int)Game_Data.Shipmodel.Kreuzer, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                return;

                            }
                        
                }
                break;


                    case 5:
                        if (!FieldSelect(sender))
                            return;
                        Game_Data.Flugzeugträger1.Add((Button)sender);

                        foreach (TextBlock blocktocheck in Game_Data.XOnTheRightSideForShips)
                        {
                            if (blocktocheck.Visibility == Visibility.Visible)
                            {
                                blocktocheck.Visibility = Visibility.Hidden;

                                if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 4 && CheckForPossibilityToSet(Game_Data.Flugzeugträger1, (int)Game_Data.Shipmodel.Flugzeugträger, true))
                                {
                                    MessageBox.Show("Flugzeugträger wurde gesetzt");
                                    Game_Data.shiptoset = 0;
                                    Game_Data.indexoflist = 0;
                                    CheckIfAllShipsWereSet();
                                    return;
                                }

                                else if (Game_Data.XOnTheRightSideForShips.IndexOf(blocktocheck) == 4 && !CheckForPossibilityToSet(Game_Data.Flugzeugträger1, (int)Game_Data.Shipmodel.Flugzeugträger, true))
                                {
                                    string newLine = Environment.NewLine;
                                    MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                                    return;
                                }

                                return;
                                    
                            }
                        }
                        if(!CheckForPossibilityToSet(Game_Data.Flugzeugträger1, (int)Game_Data.Shipmodel.Flugzeugträger, true))
                        {
                            string newLine = Environment.NewLine;
                            MessageBox.Show("Die Schiffe dürfen nur in einer Linie" + newLine + "horizontal oder vertikal gesetzt werden");
                            return;
                        }
                        break;


                     default:
                        Console.WriteLine();
                        break;
                }
            }

            else
            {
                MessageBox.Show("Das Spiel hat bereits begonnen, Änderungen sind nicht mehr möglich!");
            }
        }

        static public void ShipDelete()
        {

        }

        static public void ShipToPickSelect()
        {

        }

        static public void CheckIfAllShipsWereSet()
        {
            int PlayerShipsOnField = 0;

            foreach(List<List<Button>> listtocheck in Game_Data.Player_Shipsetted)
            {
                foreach(List<Button> listlisttocheck in listtocheck)
                {
                    foreach(Button buttontocount in listlisttocheck)
                    {
                        PlayerShipsOnField++;
                    }
                }
            }
            if (PlayerShipsOnField == 30)
                MessageBox.Show("Alle Schiffe wurden gesetzt. Drücken Sie Start, um zu beginnen!", "Bereit");
        }

        static public void CheckIfGameOver()
        {
            int Enemy_Shift_Left = 0;

            
                foreach (List<List<Button>> listtocheck in Game_Data.Enemy_Shipsetted)
                {
                    foreach (List<Button> listlisttocheck in listtocheck)
                    {
                        foreach(Button ShipToCount in listlisttocheck)
                        {
                            Enemy_Shift_Left++;
                        }
                        

                    }
                }
            

            if(Enemy_Shift_Left == 0)
            {
                MessageBox.Show("Sie haben gewonnen!", "Glückwunsch");
                Application.Current.Shutdown();
            }


            int Player_Shift_Left = 0;

                foreach(List<List<Button>> listtocheck in Game_Data.Player_Shipsetted)
                {
                    foreach (List<Button> listlisttocheck in listtocheck)
                    {
                        foreach (Button ShipToCount in listlisttocheck)
                        {
                            Player_Shift_Left++;
                        }
                    }
                }           

            if (Player_Shift_Left == 0)
            {
                MessageBox.Show("Schade, der Computer hat gewonnen!", "GameOver");
                Application.Current.Shutdown();
            }

        }
    }

    public class Game_Data
    {
        public static bool SoundOnOrOff = true;
        public static EnemyField enemyField;

        public static List<Button> buttonsPlayerField;
        public static List<Button> buttonsPlayerFieldReference;
        public static List<Button> buttonsEnemyField;
        public static List<Button> buttonsEnemyFieldReference;

        public static int gamestate;
        public static int playerorKITurn;
        public static int shiptoset = 0;
        public static int indexoflist = 0;
        public static int HitOnShip = 0;

        public static List<int> indexesOfShipsSetted = new List<int>();
        public static List<int> directionforKIOneHit = new List<int> { 0, 1, 2, 3 };
        public static List<int> directionforKIMultipleHit = new List<int> { 0, 1};

        public static List<Button> ShipToDestroy = new List<Button>();


        public static List<TextBlock> XOnTheRightSideForShips;

        public enum PlayerOrKITurn { KITurn = 1, Playerturn = 2 };
        public enum Gamestate { initialized = 1, started = 2, finished = 3 };

        public enum Shipmodel { Flugzeugträger = 5, Kreuzer = 4, Zerstörer = 3, UBoot = 2 };
        public static List<Button> Flugzeugträger1= new List<Button>();
        public static List<List<Button>> Flugzeugträger = new List<List<Button>> { Flugzeugträger1 };

        public static List<Button> Kreuzer1 = new List<Button>();
        public static List<Button> Kreuzer2 = new List<Button>();
        public static List<List<Button>> Kreuzer = new List<List<Button>> { Kreuzer1, Kreuzer2 };

        public static List<Button> Zerstörer1 = new List<Button>();
        public static List<Button> Zerstörer2 = new List<Button>();
        public static List<Button> Zerstörer3 = new List<Button>();
        public static List<List<Button>> Zerstörer = new List<List<Button>> { Zerstörer1, Zerstörer2, Zerstörer3 };

        public static List<Button> UBoot1 = new List<Button>();
        public static List<Button> UBoot2 = new List<Button>();
        public static List<Button> UBoot3 = new List<Button>();
        public static List<Button> UBoot4 = new List<Button>();
        public static List<List<Button>> Uboot = new List<List<Button>> { UBoot1, UBoot2, UBoot3, UBoot4 };
        
        public static List<List<List<Button>>> Player_Shipsetted = new List<List<List<Button>>> {Flugzeugträger,Kreuzer,Zerstörer, Uboot };


        public static List<Button> Enemy_Flugzeugträger1 = new List<Button>();
        public static List<List<Button>> Enemy_Flugzeugträger = new List<List<Button>> { Enemy_Flugzeugträger1 };

        public static List<Button> Enemy_Kreuzer1 = new List<Button>();
        public static List<Button> Enemy_Kreuzer2 = new List<Button>();
        public static List<List<Button>> Enemy_Kreuzer = new List<List<Button>> { Enemy_Kreuzer1, Enemy_Kreuzer2 };

        public static List<Button> Enemy_Zerstörer1 = new List<Button>();
        public static List<Button> Enemy_Zerstörer2 = new List<Button>();
        public static List<Button> Enemy_Zerstörer3 = new List<Button>();
        public static List<List<Button>> Enemy_Zerstörer = new List<List<Button>> { Enemy_Zerstörer1, Enemy_Zerstörer2, Enemy_Zerstörer3 };

        public static List<Button> Enemy_UBoot1 = new List<Button>();
        public static List<Button> Enemy_UBoot2 = new List<Button>();
        public static List<Button> Enemy_UBoot3 = new List<Button>();
        public static List<Button> Enemy_UBoot4 = new List<Button>();
        public static List<List<Button>> Enemy_Uboot = new List<List<Button>> { Enemy_UBoot1, Enemy_UBoot2, Enemy_UBoot3, Enemy_UBoot4 };

        public static List<List<List<Button>>> Enemy_Shipsetted = new List<List<List<Button>>> { Enemy_Flugzeugträger, Enemy_Kreuzer, Enemy_Zerstörer, Enemy_Uboot };


    }
}
