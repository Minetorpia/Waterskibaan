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
using Waterskibaan;

namespace WaterskibaanWPF
{
    /// <summary>
    /// Interaction logic for AdminDashboardWindow.xaml
    /// </summary>
    public partial class AdminDashboardWindow : Window
    {
        public Game Game { get; set; }

        public AdminDashboardWindow()
        {
            InitializeComponent();
        }


        public void NieuweBezoekerHandler(NieuweBezoekerArgs args)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                LabelTotaalBezoekers.Content = Game?.Logger.Bezoekers.Count();
                UpdateHighestScoreLabel();
                UpdateRedClothesLabel();
                UpdateLightestColor();
                UpdateTotalRounds();
                UpdateUniqueMoves();
            });
        }


        private void Window_Closing(object source, System.ComponentModel.CancelEventArgs args)
        {
            args.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }


        private void UpdateHighestScoreLabel()
        {
            if (Game?.Logger.Bezoekers.Count() > 0)
            {
                Sporter bestSporter = Game.Logger.Bezoekers.OrderByDescending(i => i.Score).First();

                if (bestSporter != null && bestSporter.Score != 0)
                {
                    LabelBestMove.Content = $"{bestSporter.Id} Score: {bestSporter.Score}";
                }
            }
        }


        private void UpdateRedClothesLabel()
        {
            if (Game?.Logger.Bezoekers.Count() > 0)
            {

                int amount = Game.Logger.Bezoekers.FindAll(i => ColorsAreClose(Color.FromRgb(i.KledingKleur.Item1, i.KledingKleur.Item2, i.KledingKleur.Item3), Color.FromRgb(Convert.ToByte(255), Convert.ToByte(0), Convert.ToByte(0))) == true).Count();
                LabelRood.Content = amount;
            }
        }


        private bool ColorsAreClose(Color a, Color z, int threshold = 150)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }


        private void UpdateLightestColor()
        {
            if (Game?.Logger.Bezoekers.Count() > 0)
            {
                KledingSP.Children.Clear();

                IEnumerable<Sporter> lightestSporters = Game.Logger.Bezoekers.OrderByDescending(i => CalcColorLight(i)).Take(10);
                foreach (Sporter sp in lightestSporters)
                {
                    Label label = new Label();
                    label.Content = $"Sporter: {sp.Id}";
                    label.Height /= 2;
                    label.Background = new SolidColorBrush(Color.FromRgb(sp.KledingKleur.Item1, sp.KledingKleur.Item2, sp.KledingKleur.Item3));
                    KledingSP.Children.Add(label);
                }
            }
        }


        private double CalcColorLight(Sporter sporter)
        {
            return Math.Sqrt(sporter.KledingKleur.Item1) + Math.Sqrt(sporter.KledingKleur.Item2) + Math.Sqrt(sporter.KledingKleur.Item3);
        }

        private void UpdateTotalRounds()
        {
            if (Game?.Logger.Bezoekers.Count() > 0)
            {
                LabelTotRondjes.Content = Game.Logger.FinishedRounds;
            }
        }

        
        private void UpdateUniqueMoves()
        {
            if (Game?.Logger.Bezoekers.Count() > 0)
            {
                UniqueMovesSP.Children.Clear();

                List<string> allMoves = new List<string>();
                List<Sporter> sportersOpBaan = Game.Logger.Bezoekers.Where(i => i.AantalRondenNogTeGaan != -1).ToList();

                sportersOpBaan.ForEach(i => i.Moves.ForEach(m => allMoves.Add(m.GetMoveNaam())));

                IEnumerable<string> uniqueMoves = allMoves.Distinct();

                foreach (string moveName in uniqueMoves)
                {
                    Label label = new Label();
                    label.Content = moveName;
                    UniqueMovesSP.Children.Add(label);
                }
                
            }
        }
    }
}
