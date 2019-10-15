﻿using System;
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
using Waterskibaan;

namespace WaterskibaanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            game.NieuweBezoeker += NieuweBezoekerHandler;
            game.Initialize();
            Console.WriteLine("tetst");
            
        }


        public void NieuweBezoekerHandler(NieuweBezoekerArgs args)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                UpdateWindow(args);
            });
        }


        public void UpdateWindow(NieuweBezoekerArgs args)
        {
            UpdateWachtrij(game.WachtrijInstructie, WachtrijInstructieSP);
            UpdateWachtrij(game.InstructieGroep, SPInstructieGroep);
            UpdateWachtrij(game.WachtrijStarten, SPWachtrijStarten);
            UpdateWachtrijLabel(game.WachtrijInstructie, LabelWachtrijInstructie);
            UpdateWachtrijLabel(game.WachtrijStarten, LabelWachtrijStarten);
            UpdateWaterskibaan();
            LabelVooraadNumber.Content = game.Waterskibaan.LijnenVoorraad.GetAantalLijnen();
        }

        public void UpdateWachtrij(Wachtrij wachtrij, StackPanel stackPanel)
        {
            stackPanel.Children.Clear();
            foreach(Sporter sporter in wachtrij.GetAlleSporters())
            {
                TextBlock tb = new TextBlock();
                tb.Background = GetSporterBackgroundColor(sporter);
                tb.Text = $"Sporter {sporter.Id}";
                stackPanel.Children.Add(tb);
            }
        }

        public void UpdateWachtrijLabel(Wachtrij wachtrij, Label label)
        {
            label.Content = $"{nameof(wachtrij)} ({wachtrij.GetAlleSporters().Count})";
        }


        public SolidColorBrush GetSporterBackgroundColor(Sporter sporter)
        {
            return new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.Item1, sporter.KledingKleur.Item2, sporter.KledingKleur.Item3));
        }

        public void UpdateWaterskibaan()
        {
            SPWaterskibaan.Children.Clear();
            LinkedListNode<Lijn> currentNode = game.Waterskibaan.Kabel.Lijnen.First;
            while(currentNode != null)
            {
                Label label = new Label();
                Lijn currentLijn = currentNode.Value;
                label.Content = $"Positie: {currentLijn.PositieOpDeKabel} Sporter: {currentLijn.Sporter.Id} Aantal ronden tegaan {currentLijn.Sporter.AantalRondenNogTeGaan}";
                if (currentLijn.Sporter.HuidigeMove != null)
                    label.Content += $" {currentLijn.Sporter.HuidigeMove}";
                label.Background = GetSporterBackgroundColor(currentLijn.Sporter);
                SPWaterskibaan.Children.Add(label);

                currentNode = currentNode.Next;
            }
        }

        private void VersnelButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameTimer.Interval /= 2;
            game.instructieTimer.Interval /= 2;
            game.instructieAfgelopenTimer.Interval /= 2;
        }

        private void VertraagButton_Click(object sender, RoutedEventArgs e)
        {
            game.gameTimer.Interval *= 2;
            game.instructieTimer.Interval *= 2;
            game.instructieAfgelopenTimer.Interval *= 2;
        }
    }
}
