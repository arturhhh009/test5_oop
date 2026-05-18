namespace Lab5_App.Classes
{
    public class Apartment
    {
        private List<ElectricalAppliance> appliances = new List<ElectricalAppliance>();

        public void AddAppliance(ElectricalAppliance app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app), "Прилад не може бути null");
            appliances.Add(app);
        }

        // Підрахунок споживаної потужності
        public double CalculateTotalPower()
        {
            return appliances.Where(a => a.IsPluggedIn).Sum(a => a.Power);
        }

        // Сортування за потужністю
        public List<ElectricalAppliance> SortByPower()
        {
            return appliances.OrderBy(a => a.Power).ToList();
        }

        // Пошук приборів в певному діапазоні випромінювання
        public List<ElectricalAppliance> FindByRadiationRange(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("Мінімальне значення не може бути більшим за максимальне");

            var result = appliances.Where(a => a.EmRadiation >= min && a.EmRadiation <= max).ToList();

            return result;
        }

        public string ShowAllAppliances()
        {
            return string.Join("\n", appliances);
        }
    }
}
