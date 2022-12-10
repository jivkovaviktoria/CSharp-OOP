using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public Booth(int boothId, int capacity)
        {
            if (capacity <= 0) throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
            
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
            
            this.CocktailMenu = new CocktailRepository();
            this.DelicacyMenu = new DelicacyRepository();
        }
        public int BoothId { get; }
        public int Capacity { get; }
        public IRepository<IDelicacy> DelicacyMenu { get; }
        public IRepository<ICocktail> CocktailMenu { get; }
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }
        
        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var c in this.CocktailMenu.Models)
                sb.AppendLine($"--{c.ToString()}");

            sb.AppendLine($"-Delicacy menu:");

            foreach (var d in this.DelicacyMenu.Models)
                sb.AppendLine($"--{d.ToString()}");

            return sb.ToString().TrimEnd();

        }
    }
}