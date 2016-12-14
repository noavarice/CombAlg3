using System;
using System.Linq;

namespace CombAlg3
{
    class SalesmanGenom 
    {
        //Сам геном - последовательность индексов городов
        byte[] townsIndicesSequence;

        /// <summary>
        /// Индексатор для обеспечения доступа к произвольному гену
        /// </summary>
        /// <param name="i">Индекс гена</param>
        /// <returns>Возвращает индекс города в данном гене</returns>
        public byte this[int i]
        {
            get { return townsIndicesSequence[i]; }
            set { townsIndicesSequence[i] = value; }
        }

        //Длина генома - количество генов в нем
        int genesCount;

        /// <summary>
        /// Количество генов в геноме
        /// </summary>
        public int GenesCount
        {
            get { return genesCount; }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="GenesCount">Количество генов в геноме</param>
        public SalesmanGenom(int GenesCount)
        {
            genesCount = GenesCount;
            townsIndicesSequence = new byte[GenesCount];
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Initializer">Массив байт - инициализатор генома</param>
        public SalesmanGenom(byte[] Initializer)
        {
            genesCount = Initializer.Count();
            townsIndicesSequence = new byte[genesCount];
            Array.Copy(Initializer, townsIndicesSequence, Initializer.Count());
        }

        /// <summary>
        /// Метод генерации случайной последовательности байт
        /// </summary>
        public void GetRandomGenom()
        {
            Random generator = new Random(DateTime.Now.Millisecond);
            generator.NextBytes(townsIndicesSequence);
        }

        /// <summary>
        /// Метод осуществляет скрещивание заданных геномов
        /// </summary>
        /// <param name="FirstParent">Геном первого родителя</param>
        /// <param name="SecondParent">Геном второго родителя</param>
        /// <returns>Возвращает геном, полученный в результате скрещивания</returns>
        public static SalesmanGenom Crossingover(SalesmanGenom FirstParent, SalesmanGenom SecondParent)
        {
            int GenesCount = FirstParent.GenesCount;
            SalesmanGenom NewGenom = new SalesmanGenom(GenesCount);
            //Копируем половину (или меньше округленную в меньшую часть половину, если GenesCount - нечетное) генома первого родителя
            Array.ConstrainedCopy(FirstParent.townsIndicesSequence, 0, NewGenom.townsIndicesSequence, 0, GenesCount / 2);
            //..и затем вторую половину генома второго родителя
            int SecondHalfGenomStartIndex = GenesCount / 2 + GenesCount % 2;
            Array.ConstrainedCopy(SecondParent.townsIndicesSequence, SecondHalfGenomStartIndex, NewGenom.townsIndicesSequence, SecondHalfGenomStartIndex, SecondHalfGenomStartIndex);
            return NewGenom;
        }
    }
}
