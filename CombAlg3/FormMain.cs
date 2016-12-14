using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CombAlg3
{
    public partial class FormMain : Form
    {
        const int Count = 6;
        
        const int SideSize = 40;

        const int MaxCellInputStringLength = 3;

        const string NaNErrorText = "Введенное значение не является натуральным числом";

        const string NegativeNumberOrZeroErrorText = "Введенное значение не является натуральным числом";

        int[,] AdjacencyMatrix;

        public FormMain()
        {
            InitializeComponent();
            Application.Idle += Idle;
            AdjacencyMatrix = new int[Count, Count];
            //Устанавливаем количество строк и столбцов
            dataGridViewMain.RowCount = dataGridViewMain.ColumnCount = Count;
            //Размер таблицы
            dataGridViewMain.Size = new Size(SideSize * Count + 3, SideSize * Count + 3);
            foreach (DataGridViewColumn Column in dataGridViewMain.Columns)
            {
                //Ширина столбцов
                Column.Width = SideSize;
                //Максимальная длина вводимого текста
                ((DataGridViewTextBoxColumn)Column).MaxInputLength = MaxCellInputStringLength;
            }
            foreach (DataGridViewRow Row in dataGridViewMain.Rows)
                //Высота строк
                Row.Height = SideSize;
            //Диагональные ячейки должны быть по умолчанию равну нулю
            for (int i = 0; i < Count; ++i)
                for(int j = 0; j < Count; ++j)
                {
                    dataGridViewMain[i, i].ReadOnly = true;
                    dataGridViewMain[i, i].ValueType = typeof(int);
                    if(i == j)
                        dataGridViewMain[i, i].Value = 0;
                }
            //Выравнивание содержимого ячеек таблицы
            dataGridViewMain.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Шрифт
            dataGridViewMain.DefaultCellStyle.Font = new Font("Arial", 16f, GraphicsUnit.Pixel);
        }

        void Idle(object sender, EventArgs e)
        {
            buttonStartGenetic.Enabled = SalesmanTaskSolver.MatrixIsCorrect;
        }

        private void dataGridViewMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(!dataGridViewMain.Rows[e.RowIndex].IsNewRow && e.RowIndex != e.ColumnIndex)
            {
                int Value = -1;
                e.Cancel = !int.TryParse((string)(e.FormattedValue), out Value) || Value <= 0;
                if (e.Cancel)
                    dataGridViewMain[e.ColumnIndex, e.RowIndex].ErrorText = Value <= 0
                        ? NegativeNumberOrZeroErrorText
                        : NaNErrorText;
                else
                    AdjacencyMatrix[e.RowIndex, e.ColumnIndex] = AdjacencyMatrix[e.ColumnIndex, e.RowIndex] = Value;
            }
        }

        private void dataGridViewMain_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMain[e.ColumnIndex, e.RowIndex].ErrorText = null;
        }

        private void dataGridViewMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMain[e.RowIndex, e.ColumnIndex].Value = dataGridViewMain[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridViewMain_Enter(object sender, EventArgs e)
        {
            dataGridViewMain.CausesValidation = true;
        }

        private void dataGridViewMain_MouseEnter(object sender, EventArgs e)
        {
            dataGridViewMain.CausesValidation = true;
        }

        private void dataGridViewMain_Leave(object sender, EventArgs e)
        {
            dataGridViewMain.CausesValidation = false;
        }

        private void dataGridViewMain_MouseLeave(object sender, EventArgs e)
        {
            dataGridViewMain.CausesValidation = false;
        }

        private void buttonStartExhaustive_Click(object sender, EventArgs e)
        {
            int Size = AdjacencyMatrix.GetLength(0);
            int temp = 0;
            for (int i = 0; i < Size; ++i)
                for (int j = i + 1; j < Size; ++j)
                    if (dataGridViewMain[i, j].Value == null || !int.TryParse((string)(dataGridViewMain[i, j].Value), out temp))
                    {
                        MessageBox.Show("Wrong values of adjacency matrix");
                        return;
                    }
                    else
                        AdjacencyMatrix[i, j] = AdjacencyMatrix[j, i] = temp;
            byte StartTown = (byte)(numericUpDownStartTown.Value);
            if (!SalesmanTaskSolver.InitializeAdjancencyMatrix(ref AdjacencyMatrix, StartTown))
                MessageBox.Show("Wrong values of adjacency matrix");
            else
            {
                var Genom = SalesmanTaskSolver.SolveViaExhaustiveAlgorithm();
                StringBuilder Builder = new StringBuilder(StartTown.ToString(), 11);
                for (int i = 0; i < Genom.GenesCount; ++i)
                {
                    Builder.Append('-');
                    Builder.Append(Genom[i].ToString());
                }
                Builder.Append("-" + StartTown.ToString());
                labelExhaustiveResult.Text = Builder.ToString();
            }
        }

        private void buttonStartGenetic_Click(object sender, EventArgs e)
        {
            byte StartTown = (byte)(numericUpDownStartTown.Value);
            SalesmanGenom Genom = SalesmanTaskSolver.SolveViaGeneticAlgorithm(10);
            StringBuilder Builder = new StringBuilder(StartTown.ToString(), 11);
            for (int i = 0; i < Genom.GenesCount; ++i)
            {
                Builder.Append('-');
                Builder.Append(Genom[i].ToString());
            }
            Builder.Append("-" + StartTown.ToString());
        }
    }
}
