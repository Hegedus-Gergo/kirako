using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button ures = new();
        public MainWindow()
        {
            InitializeComponent();
            Kirajzol(3);
            
        }

        private void Csere(object sender, RoutedEventArgs e)
        {
            Button gomb = (Button)sender;
            int sor = Grid.GetRow(gomb);
            int oszlop = Grid.GetColumn(gomb);
            int uresSor = Grid.GetRow(ures);
            int uresOszlop = Grid.GetColumn(ures);
            if (uresOszlop - oszlop == 1 && uresSor-sor == 0 || uresOszlop - oszlop == -1 && uresSor-sor == 0 || uresSor-sor == 1 && uresOszlop-oszlop == 0 || uresSor - sor == -1 && uresOszlop - oszlop == 0)
            {
                /*string tempContent = Convert.ToString(gomb.Content);
                gomb.Content = ures.Content;
                ures.Content = tempContent;*/
                Grid.SetRow(gomb, uresSor);
                Grid.SetColumn(gomb, uresOszlop);
                Grid.SetRow(ures, sor);
                Grid.SetColumn(ures, oszlop);
            }
        }

        private void btnKeveres_Click(object sender, RoutedEventArgs e)
        {
            sp.Children.Clear();
            List<int> szamok = new();
            for (int i = 0; i < Math.Pow(3, 2) - 1; i++)
            {
                Random r = new Random();
                
                int szam = r.Next(1, 9);                
                if (szamok.Contains(szam))
                {
                    i--;
                }
                else
                {
                    szamok.Add(szam);
                    System.Windows.Controls.Button t1 = new Button();
                    t1.Click += Csere;
                    t1.Content =  szam;
                    if (i < 3)
                    {
                        Grid.SetRow(t1, 0);
                        Grid.SetColumn(t1, i);
                    }
                    else if (i < 3 * 2)
                    {
                        Grid.SetRow(t1, 1);
                        Grid.SetColumn(t1, i - 3);
                    }
                    else
                    {
                        Grid.SetRow(t1, 2);
                        Grid.SetColumn(t1, i - 3 * 2);
                    }
                    sp.Children.Add(t1);
                }
                Grid.SetRow(ures, 2);
                Grid.SetColumn(ures, 2);
                ures.Content = "";
            }
        }
        private void Kirajzol(int meret) {
            for (int i = 0; i < Math.Pow(meret,2)-1; i++)
            {
                System.Windows.Controls.Button t1 = new Button();
                t1.Click += Csere;
                t1.Content = i + 1;
                if (i < meret)
                {
                    Grid.SetRow(t1, 0);
                    Grid.SetColumn(t1, i);
                }
                else if (i < meret * 2)
                {
                    Grid.SetRow(t1, 1);
                    Grid.SetColumn(t1, i - meret);
                }
                else
                {
                    Grid.SetRow(t1, 2);
                    Grid.SetColumn(t1, i - meret * 2);
                }
                sp.Children.Add(t1);
            }
            Grid.SetRow(ures, 2);
            Grid.SetColumn(ures, 2);
            ures.Content = "";
        }

    }
}


