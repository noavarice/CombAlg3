using System;
using System.Linq;

namespace CombAlg3
{
    /// <summary>
    /// Статический класс, предоставляющий методы для решения задачи коммивояжера перебором и с помощью генетического алгоритма
    /// </summary>
    static class SalesmanTaskSolver
    {
        //Матрица смежности
        private static int[,] adjacencyMatrix;

        //Поле корректности матрицы
        private static bool matrixIsCorrect;

        /// <summary>
        /// Является ли асcоциированная с классом матрица корректной. Свойство только на чтение
        /// </summary>
        public static bool MatrixIsCorrect
        {
            get { return matrixIsCorrect; }
        }

        //Город, с которого начинается обход
        private static int startTown;

        /// <summary>
        /// Индекс города, с которого начинается обход
        /// </summary>
        public static int StartTown
        {
            get { return startTown; }
            set { startTown = value; }
        }

        //Время выполнения генетического алгоритма
        private static TimeSpan geneticExecutionTime;

        /// <summary>
        /// Возвращает время выполнения генетического алгоритма. Свойство только на чтение
        /// </summary>
        public static TimeSpan GeneticExecutionTime
        {
            get { return geneticExecutionTime; }
        }

        //Время выполнения полного перебораj
        private static TimeSpan exhaustiveExecutionTime;

        /// <summary>
        /// Возвращает последнее время выполнения перебора всех вариантов. Свойство только на чтение
        /// </summary>
        public static TimeSpan ExhaustiveExecutionTime
        {
            get { return exhaustiveExecutionTime; }
        }

        /// <summary>
        /// Статический конструктор, автоматически вызываемый при первом обращении или создании экземпляра
        /// </summary>
        static SalesmanTaskSolver()
        {
            adjacencyMatrix = null;
            matrixIsCorrect = false;
            exhaustiveExecutionTime = new TimeSpan();
            geneticExecutionTime = new TimeSpan();
        }

        /// <summary>
        /// Метод инициализации матрицы смежности, для которой будет находиться решение задачи коммивояжера
        /// </summary>
        /// <param name="InitializingMatrix"></param>
        /// <returns></returns>
        public static bool InitializeAdjancencyMatrix(ref int[,] InitializingMatrix, byte StartTown)
        {
            startTown = StartTown;
            //Если инициализирующая матрица - не квадратная, она не подходит
            if (InitializingMatrix.GetLength(0) != InitializingMatrix.GetLength(1))
                return false;
            int Size = InitializingMatrix.GetLength(0);
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    if (i != j && InitializingMatrix[i, j] <= 0)
                        return false;
            adjacencyMatrix = InitializingMatrix;
            matrixIsCorrect = true;
            return true;
        }

        /// <summary>
        /// Вспомогательный метод генераци перестановок
        /// </summary>
        /// <param name="Permutation">Исходная перестановка</param>
        /// <returns>Возвращает false, если перестановка упорядочена</returns>
        private static bool NextPermutation(ref byte[] Permutation)
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

        /// <summary>
        /// Метод нахождения решения задачи коммивояжера для заданной матрицы смежности простым перебором
        /// </summary>
        /// <param name="ResultSequence"></param>
        /// <returns>Возвращает значение, позволющее судить о возникновении определенных исключительных ситуаций</returns>
        public static SalesmanGenom SolveViaExhaustiveAlgorithm()
        {
            //Засекаем начальное время
            DateTime StartTime = DateTime.Now;
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
            //Вычисляем разницу между временем начала работы алгоритма и его концом
            exhaustiveExecutionTime = new TimeSpan((DateTime.Now - StartTime).Milliseconds);
            return ResultSequence;
        }

        /// <summary>
        /// Метод нахождения решения задачи коммивояжера для заданной матрицы смежности генетическим алгоритмом
        /// </summary>
        /// <param name="ResultSequence">Выходной параметр - последовательность вершин</param>
        /// <returns></returns>
        public static SalesmanGenom SolveViaGeneticAlgorithm()
        {
            SalesmanGeneticAlgorithm Solver = new SalesmanGeneticAlgorithm(adjacencyMatrix, startTown, 1000, 60.0, 80.0, 100, 10);
            var Result = Solver.Evolve();
            geneticExecutionTime = Solver.ExecutionTime;
            return Result;
        }
    }
}
