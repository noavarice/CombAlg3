using System;
using System.Linq;

namespace CombAlg3
{
    static class SalesmanTaskSolver
    {
        //Матрица смежности
        static int[,] adjacencyMatrix;

        static bool matrixIsCorrect;

        public static bool MatrixIsCorrect
        {
            get { return matrixIsCorrect; }
        }

        static byte startTown;

        //Длина пути, полученная в ходе поиска решения путем простого перебора
        static int optimalValue;

        /// <summary>
        /// Статический конструктор, автоматически вызываемый при первом обращении или создании экземпляра
        /// </summary>
        static SalesmanTaskSolver()
        {
            adjacencyMatrix = null;
            matrixIsCorrect = false;
            optimalValue = 0;
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
        static bool NextPermutation(ref byte[] Permutation)
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
            SalesmanGenom ResultSequence = null;
            int MatrixSize = adjacencyMatrix.GetLength(0);
            //Генерируем антилексикографически упорядоченную перестановку из индексов городов, кроме того, с которого начинаем идти
            byte[] TempSequence = new byte[MatrixSize - 1];
            int InsertPosition = 0;
            for(byte i = 0; i < MatrixSize; ++i)
            {
                TempSequence[InsertPosition] = i;
                if (i != startTown)
                    ++InsertPosition;
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
                    MinDistance = optimalValue = CurrentDistance;
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
        public static SalesmanGenom SolveViaGeneticAlgorithm(int IterationsCount)
        {
            SalesmanGeneticAlgorithm Solver = new SalesmanGeneticAlgorithm(adjacencyMatrix, optimalValue, IterationsCount, 3.0, 3.0, 25, 5);
            return Solver.Evolve();
        }
    }
}
