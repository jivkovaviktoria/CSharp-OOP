using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Models.FormulaOneCars;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            var car = carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            if (car == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));


            pilot.AddCar(car);
            carRepository.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            var pilot = pilotRepository.FindByName(pilotFullName);

            if (race == null) throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilot.FullName, race.RaceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == nameof(Ferrari)) car = new Ferrari(model, horsepower, engineDisplacement);
            else if (type == nameof(Williams)) car = new Williams(model, horsepower, engineDisplacement);
            else throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));

            if (carRepository.Models.Any(x => x.Model == model)) throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));

            carRepository.Add(car);
            return String.Format(string.Format(OutputMessages.SuccessfullyCreateCar, type, model));
        }

        public string CreatePilot(string fullName)
        {
            var pilot = pilotRepository.FindByName(fullName);

            if (pilot == null)
            {
                pilotRepository.Add(new Pilot(fullName));
                return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var x = raceRepository.FindByName(raceName);
            if (x != null) throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
                sb.AppendLine(pilot.ToString());

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
                sb.AppendLine(race.RaceInfo());

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null) throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (race.Pilots.Count < 3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));

            if (race.TookPlace == true)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));


            race.TookPlace = true;

            var winners = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            var first = winners[0];
            var second = winners[1];
            var third = winners[2];

            first.WinRace();

            var sb = new StringBuilder();
            sb.AppendLine($"Pilot {first.FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {second.FullName} is second in the {race.RaceName} race.");
            sb.Append($"Pilot {third.FullName} is third in the {race.RaceName} race.");

            return sb.ToString().Trim();
        }
    }
}
