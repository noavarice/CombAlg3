namespace CombAlg3
{
    abstract class GeneticAlgorithm<T>
    {
        protected int       iterationsCount;

        protected double    mutationsPercentage;

        protected double    genomsToMutatePercentage;

        protected int       firstGenerationGenomsCount;

        protected int       mostFitCount;

        public GeneticAlgorithm(
            int     IterationsCount,
            double  MutationsPercentage,
            double  GenomsToMutatePercentage,
            int     FirstGenerationGenomsCount,
            int     MostFit)
        {
            iterationsCount             = IterationsCount;
            mutationsPercentage         = MutationsPercentage;
            genomsToMutatePercentage    = GenomsToMutatePercentage;
            firstGenerationGenomsCount  = FirstGenerationGenomsCount;
            mostFitCount                = MostFit;
        }

        protected abstract void     GetFirstGeneration();

        protected abstract double   FitnessFunction(T Genom);

        protected abstract void     GetMostFit();

        protected abstract T        Crossingover(T FirstParent, T SecondParent);

        protected abstract void     MutateGenom(T Genom);
    }
}
