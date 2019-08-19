using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // [row, column]
        private TextBox[,] _sudokuGrid = new TextBox[9, 9];
        public MainWindow()
        {
            InitializeComponent();
            InitSudokuGrid();
        }

        private void InitSudokuGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sudokuGrid[i, j] = new TextBox();
                }
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                for (int j = 0; j < 9; j++)
                {
                    TextBox tb = _sudokuGrid[i, j];
                    FormatBorders(i, j);
                    tb.PreviewTextInput += Tb_PreviewTextInput;
                    sp.Children.Add(tb);
                }
                root.Children.Add(sp);
            }
        }

        private void Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FormatBorders(int i, int j)
        {
            double borderThickness = 2.5;
            TextBox tb = _sudokuGrid[i, j];
            tb.BorderBrush = Brushes.Black;
            Thickness thickness = new Thickness(0.5);
            if (IsTop(i))
            {
                thickness.Top = borderThickness;                
            }
            if (IsBottom(i))
            {
                thickness.Bottom = borderThickness;
            }
            if (IsLeft(j))
            {
                thickness.Left = borderThickness;
            }
            if (IsRight(j))
            {
                thickness.Right = borderThickness;
            }
            tb.BorderThickness = thickness;
        }

        private bool IsTop(int i) { return i == 0; }
        private bool IsBottom(int i) { return i % 3 == 2; }
        private bool IsLeft(int j) { return j == 0; }
        private bool IsRight(int j) { return j % 3 == 2; }
    }
}
