using Gym.Core.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment = new EquipmentRepository();
        private List<IGym> gyms =new List<IGym>();

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            Athlete athlete;
            if (athleteType == nameof(Boxer)) athlete = new Boxer(athleteName, motivation, numberOfMedals);
            else if (athleteType == nameof(Weightlifter)) athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            else throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);

            var gym = gyms.Find(x => x.Name == gymName);
            if (athleteType == nameof(Boxer) && gym.GetType().Name == nameof(BoxingGym))
            {
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else if (athleteType == nameof(Weightlifter) && gym.GetType().Name == nameof(WeightliftingGym))
            {
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else return OutputMessages.InappropriateGym;
        }

        public string AddEquipment(string equipmentType)
        {
            Equipment eq;
            if (equipmentType == nameof(BoxingGloves)) eq = new BoxingGloves();
            else if (equipmentType == nameof(Kettlebell)) eq = new Kettlebell();
            else throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);

            this.equipment.Add(eq);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym)) gym = new BoxingGym(gymName);
            else if (gymType == nameof(WeightliftingGym)) gym = new WeightliftingGym(gymName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidGymType);

            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.Find(x => x.Name == gymName);
            var weight = $"{gym.EquipmentWeight:f2}";

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.Find(x => x.Name == gymName);
            var eq = equipment.FindByType(equipmentType);

            if(eq == null) throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            else if (eq.GetType().Name == nameof(BoxingGloves))
            {
                var boxingGloves = new BoxingGloves();
                gym.AddEquipment(boxingGloves);
                equipment.Remove(boxingGloves);
            }
            else if (eq.GetType().Name == nameof(Kettlebell))
            {
                var kettlebell = new Kettlebell();
                gym.AddEquipment(kettlebell);
                equipment.Remove(kettlebell);
            }
            

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
                sb.AppendLine(gym.GymInfo());

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.Find(x => x.Name == gymName);
            foreach (var x in gym.Athletes)
                x.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
