using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths = new BoothRepository();

        public string AddBooth(int capacity)
        {
            var id = this.booths.Models.Count + 1;
            this.booths.AddModel(new Booth(id, capacity));
            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = this.booths.Models.First(x => x.BoothId == boothId);

            IDelicacy x;
            if (delicacyTypeName == nameof(Gingerbread)) x = new Gingerbread(delicacyName);
            else if (delicacyTypeName == nameof(Stolen)) x = new Stolen(delicacyName);
            else return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            booth.DelicacyMenu.AddModel(x);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = this.booths.Models.First(x => x.BoothId == boothId);

            ICocktail x;
            if (cocktailTypeName == nameof(Hibernation)) x = new Hibernation(cocktailName, size);
            else if (cocktailTypeName == nameof(MulledWine)) x = new MulledWine(cocktailName, size);
            else return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);

            if (size != "Small" && size != "Middle" && size != "Large")
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            booth.CocktailMenu.AddModel(x);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = this.booths.Models.Where(x => !x.IsReserved && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).FirstOrDefault();

            if (booth == null) 
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            
            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string type;
            var tokens = order.Split('/');
            var itemTypeName = tokens[0];
            var itemName = tokens[1];
            var count = int.Parse(tokens[2]);

            if (tokens.Length == 4) type = "cocktail";
            else type = "delicacy";

            var booth = this.booths.Models.First(x => x.BoothId == boothId);
            
            if (type == "cocktail")
            {
                var size = tokens[3];
                
                if (this.booths.Models.Any(x => x.CocktailMenu.Models.Any(x => x.GetType().Name == itemTypeName)) ==
                    false) return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

                if (this.booths.Models.Any(x => x.CocktailMenu.Models.Any(x => x.Name == itemName)) == false)
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);

                var item = booth.CocktailMenu.Models.FirstOrDefault(x =>
                    x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size);
                if (item == null) return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                
                booth.UpdateCurrentBill(item.Price*count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
            else
            {
                if (this.booths.Models.Any(x => x.DelicacyMenu.Models.Any(x => x.GetType().Name == itemTypeName)) ==
                    false) return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

                if (this.booths.Models.Any(x => x.DelicacyMenu.Models.Any(x => x.Name == itemName)) == false)
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);

                var item = booth.DelicacyMenu.Models.FirstOrDefault(x =>
                    x.GetType().Name == itemTypeName && x.Name == itemName);
                if (item == null) return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                
                booth.UpdateCurrentBill(item.Price*count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            var booth = this.booths.Models.First(x => x.BoothId == boothId);
            var bill = $"{booth.CurrentBill:f2}";

            booth.Charge();
            booth.ChangeStatus();
            return string.Format(OutputMessages.GetBill, bill) + Environment.NewLine +
                   string.Format(OutputMessages.BoothIsAvailable, boothId);
        }

        public string BoothReport(int boothId)
        {
            var booth = this.booths.Models.First(x => x.BoothId == boothId);

            var sb = new StringBuilder();
            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {booth.Capacity}");
            sb.AppendLine($"Turnover: {booth.Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var c in booth.CocktailMenu.Models)
                sb.AppendLine($"--{c.ToString()}");

            sb.AppendLine($"-Delicacy menu:");

            foreach (var d in booth.DelicacyMenu.Models)
                sb.AppendLine($"--{d.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}