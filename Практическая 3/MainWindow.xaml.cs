using System;
using System.Windows;
using LibMas;
using Lib_10;

namespace Practical3
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш текст с информацией о программе.", "О программе");
        }

        private void CreateMatrixButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем случайную матрицу размера 3x3
            matrix = ArrayUtils.CreateRandomMatrix(3, 3);

            // Отображаем матрицу в DataGrid
            MatrixDataGrid.ItemsSource = ToDataTable(matrix).DefaultView;
            ResultTextBox.Clear();
        }

        private void FindColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                ResultTextBox.Text = "Сначала создайте матрицу.";
                return;
            }

            int columnIndex = MatrixSolver.FindColumnWithMostDuplicates(matrix);

            if (columnIndex == -1)
            {
                ResultTextBox.Text = "В матрице нет столбцов.";
            }
            else
            {
                ResultTextBox.Text = $"Результат: {columnIndex + 1}";
            }
        }

        private System.Data.DataTable ToDataTable(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            System.Data.DataTable table = new System.Data.DataTable();

            for (int j = 0; j < cols; j++)
            {
                table.Columns.Add($"Столбец {j + 1}");
            }

            for (int i = 0; i < rows; i++)
            {
                System.Data.DataRow row = table.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    row[j] = array[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
