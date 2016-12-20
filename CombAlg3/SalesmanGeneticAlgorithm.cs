using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace CombAlg3
{
    class SalesmanGeneticAlgorithm : GeneticAlgorithm<SalesmanGenom>
    {
        //Значение, исходя из которого будет вычисляться значение FitnessFunction - длина пройденного оптимального пути

        int startTown;

        public int StartTown
        {
            get { return startTown; }
            set { startTown = value; }
        }

        //Матрицы достижимости
        int[,] adjacencyMatrix;

        //Количество мутаций - чтобы каждый раз не считать при мутировании очередного генома
        int mutationsCount;

        //Количество мутировавших геномов
        int mutatedGenomsCount;

        //Количество генов в геноме - опять же, чтобы каждый раз не находить заново
        int genesCount;

        //Очередное поколение
        SalesmanGenom[] generation;

        Random Generator;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="AdjacencyMatrix">Матрица достижимости городов</param>
        /// <param name="StartTown">Индекс города, с которого начнется и которым закончится путь</param>
        /// <param name="GenerationsCount">Количество поколений, которое будет сгенерировано</param>
        /// <param name="MutationsPercentage">Процентное соотношение количества мутаций к размеру генома</param>
        /// <param name="GenomsToMutatePercentage">Процентное соотношение количества мутировавших геномов к общему числу геномов в поколении</param>
        /// <param name="FirstGenerationGenomsCount">Количество геномов в первом (и последующем) поколениях</param>
        /// <param name="MostFit">Количество наиболее приспособленных геномов, отбираемых каждое новое поколение</param>
        public SalesmanGeneticAlgorithm(
            int[,]  AdjacencyMatrix,
            int     StartTown,
            int     GenerationsCount,
            double  MutationsPercentage,
            double  GenomsToMutatePercentage,
            int     FirstGenerationGenomsCount,
            int     MostFit)
            : base(
                  GenerationsCount,
                  MutationsPercentage,
                  GenomsToMutatePercentage,
                  FirstGenerationGenomsCount,
                  MostFit)
        {
            adjacencyMatrix = AdjacencyMatrix;
            startTown = StartTown;
            genesCount = adjacencyMatrix.GetLength(0) - 1;
            mutationsCount = (int)(genesCount / 100.0 * mutationsPercentage);
            mutatedGenomsCount = (int)(firstGenerationGenomsCount / 100.0 * GenomsToMutatePercentage);
            generation = new SalesmanGenom[firstGenerationGenomsCount];
            Generator = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Метод генерации первого поколения
        /// </summary>
        protected override void GetFirstGeneration()
        {
            for(int i = 0; i < firstGenerationGenomsCount; ++i)
            {
                SalesmanGenom temp = new SalesmanGenom(genesCount);
                temp.GetRandomGenom();
                generation[i] = temp;
            }
        }

        protected override void GetMostFit()
        { }

        /// <summary>
        /// Метод скрещивания двух геномов. В данном случае, берется по полвине генома родителей и "склеивается" в новый
        /// </summary>
        /// <param name="FirstParent">Геном первого родителя, участвующего в скрещивании</param>
        /// <param name="SecondParent">Геном второго родителя, участвующего в скрещивании</param>
        /// <returns>Геном, получившийся в результате скрещивания</returns>
        protected override SalesmanGenom Crossingover(SalesmanGenom FirstParent, SalesmanGenom SecondParent)
        {
            return SalesmanGenom.Crossingover(FirstParent, SecondParent);
        }

        /// <summary>
        /// Метод, получающий разницу между оптимальным значением и длиной Genom как пути
        /// </summary>
        /// <param name="Genom">Проверяемый геном</param>
        /// <returns>Разницу между оптимальным значением и полученной длиной пути</returns>
        protected override double FitnessFunction(SalesmanGenom Genom)
        {
            int RoadLength = adjacencyMatrix[startTown, Genom[0]];
            //Считаем длину пути
            for (int i = 0; i < genesCount - 1; ++i)
                RoadLength += adjacencyMatrix[Genom[i], Genom[i + 1]];
            RoadLength += adjacencyMatrix[startTown, Genom[genesCount - 1]];
            Dictionary<byte, int> Towns = new Dictionary<byte, int>();
            for (int i = 0; i < genesCount; ++i)
                if (!Towns.Keys.Contains<byte>(Genom[i]))
                    Towns.Add(Genom[i], 0);
            return RoadLength == 0 ? double.MaxValue : RoadLength * 1.0 / Math.Pow(Towns.Keys.Count, Towns.Keys.Count);
        }

        /// <summary>
        /// Метод, вводящий мутации в заданный геном
        /// </summary>
        /// <param name="Genom">Изменяемый геном</param>
        protected override void MutateGenom(SalesmanGenom Genom)
        {
            byte[] temp = new byte[mutationsCount];
            Generator.NextBytes(temp);
            for (int i = 0; i < mutationsCount; ++i)
                temp[i] %= (byte)genesCount;
            for (int i = 0; i < mutationsCount; ++i)
                Genom[Generator.Next(0, genesCount - 1)] = temp[i];
        }

        /// <summary>
        /// Метод получения нового поколения путем скрещивания лучших геномов.
        /// </summary>
        void GetNewGeneration()
        {
            //Сортируем массив геномов по степени "подходимости"
            double[] GenerationFitnesses = new double[firstGenerationGenomsCount];
            for (int i = 0; i < firstGenerationGenomsCount; ++i)
                GenerationFitnesses[i] = FitnessFunction(generation[i]);
            Array.Sort(GenerationFitnesses, generation);
            //Сохраним в новом поколении лучших, поэтому начнем заполнять массив поколений, начиная с (mostFitCount + 1)-й позиции
            int InsertPosition = mostFitCount;
            //идем по всем "выжившим" и попарно их скрещиваем
            for(int i = 0; i < mostFitCount; ++i)
            {
                //избегаем скрещивания генома с самим собой
                for (int j = 0; j < i; ++j)
                    generation[InsertPosition++] = Crossingover(generation[i], generation[j]);
                for(int j = i + 1; j < mostFitCount; ++j)
                    generation[InsertPosition++] = Crossingover(generation[i], generation[j]);
            }
        }

        /// <summary>
        /// Метод, производящий мутации над заданным количеством случайных геномов
        /// </summary>
        void MutateGeneration()
        {
            for (int i = 0; i < mutatedGenomsCount; ++i)
                MutateGenom(generation[Generator.Next(0, firstGenerationGenomsCount)]);
        }

        void Log(int GenerationNumber)
        {
            string Filename = @"C:\Users\Alex\Documents\Visual Studio 2015\Projects\CombAlgs\CombAlg3\CombAlg3\log_files\"
                + DateTime.Now.Hour.ToString()
                + DateTime.Now.Minute.ToString()
                + DateTime.Now.Second.ToString()
                + DateTime.Now.Millisecond.ToString() + ".txt";
            StreamWriter Writer = new StreamWriter(Filename, false);
            Writer.Write("Generation #" + GenerationNumber.ToString() + Writer.NewLine);
            for(int i = 0; i < firstGenerationGenomsCount; ++i)
            {
                StringBuilder b = new StringBuilder(genesCount);
                for (int j = 0; j < genesCount; ++j)
                    b.Append(generation[i][j].ToString());
                Writer.Write(b.ToString() + Writer.NewLine);
            }
            Writer.Close();
        }

        /// <summary>
        /// Метод, запускающий "эволюционный процесс" для заданных начальных значений
        /// </summary>
        /// <param name="Result">Результат работы алгоритма - приближенная последовательность городов для их обхода</param>
        public SalesmanGenom Evolve()
        {
            SalesmanGenom Result = null;
            //Генерируем стартовые поколения
            GetFirstGeneration();
            //Запускаем процесс эволюции
            for(int i = 0; i < iterationsCount; ++i)
            {
                //Скрещиваем и получаем новое поколение
                GetNewGeneration();
                //"Мутируем" поколение
                MutateGeneration();
            }
            //Находим наиболее подходящий геном
            double MinDifference = double.MaxValue;
            foreach(SalesmanGenom Genom in generation)
            {
                double CurrentDifference = FitnessFunction(Genom);
                if(CurrentDifference < MinDifference)
                {
                    MinDifference = CurrentDifference;
                    Result = Genom;
                }
            }
            return Result;
        }
    }
}
