using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;

namespace CombAlg3
{
    class SalesmanTaskSolver : INotifyPropertyChanged
    {
        #region Private fields

        private static Random generator;

        private int townsCount;

        //Матрица смежности
        private int[,] adjacencyMatrix;

        //Город, с которого начинается путь
        private int startTown;

        #endregion

        #region INotifyPropertyChanged implemenatation
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Суммарное колиество городов
        /// </summary>
        public int TownsCount
        {
            get { return townsCount; }
            set
            {
                townsCount = value;
                OnPropertyChanged("TownsCount");
            }
        }

        /// <summary>
        /// Город, с которого начинается путь
        /// </summary>
        public int StartTown
        {
            get { return startTown; }
            set
            {
                startTown = value;
                OnPropertyChanged("StartTown");
            }
        }

        #endregion

        #region Private methods and static constructors

        static SalesmanTaskSolver()
        {
            generator = new Random(DateTime.Now.Millisecond);
        }
        
        /// <summary>
        /// Вспомогательный метод генерации перестановок
        /// </summary>
        /// <param name="Permutation">Исходная перестановка</param>
        /// <returns>Возвращает false, если перестановка упорядочена</returns>
        private bool NextPermutation(ref byte[] Permutation)
        {
            //индекс последнего элемента перестановки
            int n = Permutation.Count() - 1;
            //индекс скачка
            int i = n;
            //ищем скачок
            for (; i > 0 && Permutation[i - 1] > Permutation[i]; --i) ;
            if (i == 0)
                return false;
            //ищем первый элемент, больший того, что на позиции скачка
            int j = n;
            for (;Permutation[j] < Permutation[i - 1]; --j) ;
            //меняем найденные элементы местами
            byte temp;
            temp = Permutation[i - 1];
            Permutation[i - 1] = Permutation[j];
            Permutation[j] = temp;
            //затем меняем местами все элементы после скачка
            for (j = 0; j <= (n - i + 1) / 2 - 1; ++j)
            {
                temp = Permutation[i + j];
                Permutation[i + j] = Permutation[n - j];
                Permutation[n - j] = temp;
            }
            return true;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Конструктор
        /// </summary>
        public SalesmanTaskSolver()
        {
            townsCount = startTown = 0;
            adjacencyMatrix = null;
        }

        /// <summary>
        /// Создание новой случайно заполненной матрицы
        /// </summary>
        public void GenerateNewRandomDataMatrix()
        {
            adjacencyMatrix = new int[townsCount, townsCount];
            for (int i = 0; i < townsCount; ++i)
                for (int j = i + 1; j < townsCount; ++j)
                    adjacencyMatrix[i, j] = adjacencyMatrix[j, i] = generator.Next();
        }

        /// <summary>
        /// Метод нахождения решения задачи коммивояжера для заданной матрицы смежности простым перебором
        /// </summary>
        /// <param name="ResultSequence"></param>
        /// <returns>Возвращает значение, позволющее судить о возникновении определенных исключительных ситуаций</returns>
        public SalesmanGenom SolveViaExhaustiveAlgorithm()
        {
            SalesmanGenom ResultSequence = null;
            int MatrixSize = adjacencyMatrix.GetLength(0);
            //Генерируем антилексикографически упорядоченную перестановку из индексов городов, кроме того, с которого начинаем идти
            byte[] TempSequence = new byte[MatrixSize - 1];
            int InsertPosition = 0;
            for(byte i = 0; i < MatrixSize; ++i)
            {
                if (i != startTown)
                {
                    TempSequence[InsertPosition] = i;
                    ++InsertPosition;
                }
            }
            //Переменная, хранящая минимальное пройденное расстояние
            int MinDistance = int.MaxValue;
            int t = 0;
            do
            {
                int CurrentDistance = adjacencyMatrix[startTown, TempSequence[0]];
                //Считаем расстояния между городами
                for(int i = 0; i < MatrixSize - 2; ++i)
                    CurrentDistance += adjacencyMatrix[TempSequence[i], TempSequence[i + 1]];
                //Учитывая, что коммивояжер должен вернуться в первый город, прибавляем расстояние от последнего города до первого
                CurrentDistance += adjacencyMatrix[startTown, TempSequence[TempSequence.Count() - 1]];
                //Если путь валидный и его длина меньше минимальной
                if (CurrentDistance < MinDistance)
                {
                    MinDistance = CurrentDistance;
                    ResultSequence = new SalesmanGenom(TempSequence);
                }
                ++t;
            }
            //Генерируем следующую перестановку
            while (NextPermutation(ref TempSequence));
            return ResultSequence;
        }

        /// <summary>
        /// Метод нахождения решения задачи коммивояжера для заданной матрицы смежности генетическим алгоритмом
        /// </summary>
        /// <param name="ResultSequence">Выходной параметр - последовательность вершин</param>
        /// <returns></returns>
        public SalesmanGenom SolveViaGeneticAlgorithm()
        {
            SalesmanGeneticAlgorithm Solver = new SalesmanGeneticAlgorithm(adjacencyMatrix, startTown, 100, 60.0, 80.0, 100, 10);
            return Solver.Evolve();
        }
        
        #endregion
    }
}
