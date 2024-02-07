using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Button[] buttons;
        int player = 0;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };

        }
        public void Bot(string player)
        {
            Random random = new Random();
            int hod = random.Next(1, 9);

            while (buttons[hod].IsEnabled == false)
                hod = random.Next(1, 9);


            Debug.WriteLine(hod);
            buttons[hod].Content = player;
            buttons[hod].IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Content").SetValue(sender, "X");
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    Bot("O");
                    TB.Text = "Ход крестиков";
                    break;
                case 0:
                    sender.GetType().GetProperty("Content").SetValue(sender, "O");
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    Bot("X");
                    TB.Text = "Ход ноликов";

                    break;

            }
            WinDrawLose(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bclick();
        }

        public void block()
        {
            foreach (var but in buttons)
            {
                but.IsEnabled = false;
            }
        }
        public void bclick()
        {
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            b1.Content = "  ";
            b2.Content = "   ";
            b3.Content = "    ";
            b4.Content = "     ";
            b5.Content = "      ";
            b6.Content = "       ";
            b7.Content = "        ";
            b8.Content = "         ";
            b9.Content = "          ";

        }


        public void WinDrawLose(object sender, RoutedEventArgs e)
        {


            if (buttons.All(but => but.IsEnabled == false))
            {
                TB.Text = "Ничья";
            }
            if (b1.Content == b2.Content && b2.Content == b3.Content && b3.Content.ToString() == "O" || b4.Content == b5.Content && b5.Content == b6.Content && b6.Content.ToString() == "O"  || b7.Content == b8.Content && b8.Content == b9.Content && b9.Content.ToString() == "O" || b1.Content == b5.Content && b5.Content == b9.Content && b9.Content.ToString() == "O" || b3.Content == b5.Content && b5.Content == b7.Content && b7.Content.ToString() == "O" || b1.Content == b4.Content && b4.Content == b7.Content && b7.Content.ToString() == "O" || b2.Content == b5.Content && b8.Content == b5.Content && b5.Content.ToString() == "O" || b3.Content == b6.Content && b6.Content == b9.Content && b9.Content.ToString() == "O")
            {
                block();

                TB.Text = "Победили нолики";
                player = 1;
            }
            if (b1.Content == b2.Content && b2.Content == b3.Content && b3.Content.ToString() == "X" || b4.Content == b5.Content && b5.Content == b6.Content && b6.Content.ToString() == "X" || b7.Content == b8.Content && b8.Content == b9.Content && b9.Content.ToString() == "X" || b1.Content == b5.Content && b5.Content == b9.Content && b9.Content.ToString() == "X" || b3.Content == b5.Content && b5.Content == b7.Content && b7.Content.ToString() == "X" || b1.Content == b4.Content && b4.Content == b7.Content && b7.Content.ToString() == "X" || b2.Content == b5.Content && b8.Content == b5.Content  && b5.Content.ToString() == "X" || b3.Content == b6.Content && b6.Content == b9.Content && b9.Content.ToString() == "X")
            {
                block();

                TB.Text = "Победили крестики";
                player = 0;
            }


        }

    }



}