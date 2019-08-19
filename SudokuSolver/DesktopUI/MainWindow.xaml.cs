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
                    ConfigureTextBox(i, j, sp);
                }
                root.Children.Add(sp);
            }
        }

        private void ConfigureTextBox(int row, int column, StackPanel sp)
        {
            TextBox tb = _sudokuGrid[row, column];
            FormatBorders(row, column);
            FormatBackground(row, column);
            tb.PreviewTextInput += Tb_PreviewTextInput;
            sp.Children.Add(tb);
        }

        private void Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FormatBorders(int row, int column)
        {
            double borderThickness = 2.5;
            TextBox tb = _sudokuGrid[row, column];
            tb.BorderBrush = Brushes.Black;
            Thickness thickness = new Thickness(0.5);
            if (IsTop(row))
            {
                thickness.Top = borderThickness;                
            }
            if (IsBottom(row))
            {
                thickness.Bottom = borderThickness;
            }
            if (IsLeft(column))
            {
                thickness.Left = borderThickness;
            }
            if (IsRight(column))
            {
                thickness.Right = borderThickness;
            }
            tb.BorderThickness = thickness;
        }

        private bool IsTop(int row) { return row == 0; }
        private bool IsBottom(int row) { return row % 3 == 2; }
        private bool IsLeft(int column) { return column == 0; }
        private bool IsRight(int column) { return column % 3 == 2; }

        private void FormatBackground(int row, int column)
        {
            var color = Brushes.AliceBlue;
            var tb = _sudokuGrid[row, column];

            if (row < 3 || row > 5)
            {
                if (column < 3 || column > 5)
                {
                    tb.Background = color;
                }
            }
            else 
            {
                if (column >= 3 && column <= 5)
                {
                    tb.Background = color;
                }
            }          
        }
    }
}
