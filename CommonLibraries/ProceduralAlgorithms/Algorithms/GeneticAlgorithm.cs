using System;
using System.Collections.Generic;
using System.Linq;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    /// <summary>
    /// Implements a basic genetic algorithm for procedural generation.
    /// </summary>
    public class GeneticAlgorithm<M, C> : ProceduralAlgorithmBase<M, C>
        where C : ICell
        where M : IMatrix<C>
    {
        private static ProceduralAlgorithmParameterCollection _parameters;

        public GeneticAlgorithm(object sender, M grid, int xDim, int yDim)
            : base(sender, grid, xDim, yDim)
        {
        }

        public override ProceduralAlgorithmParameterCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new ProceduralAlgorithmParameterCollection(5)
                    {
                        new ProceduralAlgorithmParameter<int>("PopulationSize"),
                        new ProceduralAlgorithmParameter<int>("Generations"),
                        new ProceduralAlgorithmParameter<double>("MutationRate"),
                        new ProceduralAlgorithmParameter<Func<M, double>>("FitnessFunction"),
                        new ProceduralAlgorithmParameter<int>("EliteCount")
                    };
                }
                return _parameters;
            }
        }

        protected override void DoAlgorithmInternal(params object[] args)
        {
            int populationSize = Parameters.GetParameterValue<int>(args, "PopulationSize");
            int generations = Parameters.GetParameterValue<int>(args, "Generations");
            double mutationRate = Parameters.GetParameterValue<double>(args, "MutationRate");
            Func<M, double> fitnessFunction = Parameters.GetParameterValue<Func<M, double>>(args, "FitnessFunction");
            int eliteCount = Parameters.GetParameterValue<int>(args, "EliteCount");

            List<M> population = InitializePopulation(populationSize);

            for (int gen = 0; gen < generations; gen++)
            {
                // Evaluate fitness
                var fitnessScores = population.Select(individual => fitnessFunction(individual)).ToList();

                // Select elites
                var elites = population.Zip(fitnessScores, (ind, fit) => new { ind, fit })
                                      .OrderByDescending(x => x.fit)
                                      .Take(eliteCount)
                                      .Select(x => x.ind)
                                      .ToList();

                // Selection (roulette wheel)
                var selected = SelectPopulation(population, fitnessScores, populationSize - eliteCount);

                // Crossover
                var offspring = Crossover(selected);

                // Mutation
                Mutate(offspring, mutationRate);

                // Form new population
                population = elites.Concat(offspring).ToList();

                InvokeCallback(0);
            }

            // Optionally, set the grid to the best individual
            var bestIndividual = population.OrderByDescending(fitnessFunction).First();
            CopyToGrid(bestIndividual);
        }

        private List<M> InitializePopulation(int populationSize)
        {
            var population = new List<M>(populationSize);
            for (int i = 0; i < populationSize; i++)
            {
                // Deep copy or randomize grid for each individual
                population.Add(CloneGrid(_grid));
            }
            return population;
        }

        private List<M> SelectPopulation(List<M> population, List<double> fitnessScores, int count)
        {
            var selected = new List<M>();
            double totalFitness = fitnessScores.Sum();
            var rand = R;

            for (int i = 0; i < count; i++)
            {
                double pick = rand.NextDouble() * totalFitness;
                double cumulative = 0;
                for (int j = 0; j < population.Count; j++)
                {
                    cumulative += fitnessScores[j];
                    if (cumulative >= pick)
                    {
                        selected.Add(CloneGrid(population[j]));
                        break;
                    }
                }
            }
            return selected;
        }

        private List<M> Crossover(List<M> selected)
        {
            var offspring = new List<M>();
            var rand = R;
            for (int i = 0; i < selected.Count / 2; i++)
            {
                var parent1 = selected[2 * i];
                var parent2 = selected[2 * i + 1];
                offspring.Add(CrossoverGrids(parent1, parent2));
                offspring.Add(CrossoverGrids(parent2, parent1));
            }
            // If odd, copy last individual
            if (selected.Count % 2 == 1)
                offspring.Add(CloneGrid(selected.Last()));
            return offspring;
        }

        private void Mutate(List<M> offspring, double mutationRate)
        {
            foreach (var individual in offspring)
            {
                MutateGrid(individual, mutationRate);
            }
        }

        // --- Utility methods ---

        private M CloneGrid(M grid)
        {
            return (M)grid.Clone();
        }

        private M CrossoverGrids(M parent1, M parent2)
        {
            return (M)StaticRoutines.CrossoverWith(parent1, parent2, R);
        }

        private void MutateGrid(M grid, double mutationRate)
        {
            if(grid.First())
            {
                do
                {
                    if (R.NextDouble() < mutationRate)
                    {
                        // Mutate cell content
                        grid.Current.Content = MutateCellContent(grid.Current.Content);
                    }
                } while (grid.Next());
            }
        }

        private object MutateCellContent(object content)
        {
            // Implement mutation logic for cell content
            // This is a placeholder; actual implementation depends on cell type
            return content; // No-op
        }

        private void CopyToGrid(M source)
        {
            _grid.CopyFrom(source);
        }
    }
}