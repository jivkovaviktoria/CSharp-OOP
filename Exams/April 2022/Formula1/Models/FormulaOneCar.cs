using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        public FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            if (string.IsNullOrEmpty(model) || model.Length < 3) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, model));
            if (horsePower < 900 || horsePower > 1050) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, horsePower));
            if (engineDisplacement < 1.6 || engineDisplacement > 2.0) throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, engineDisplacement));

            this.Model = model;
            this.Horsepower = horsePower;
            this.EngineDisplacement = engineDisplacement;
        }
        public string Model { get; }

        public int Horsepower { get; }

        public double EngineDisplacement { get; }

        public double RaceScoreCalculator(int laps)
        {
            return this.EngineDisplacement / this.Horsepower * laps;
        }
    }
}
