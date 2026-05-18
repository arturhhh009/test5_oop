namespace Lab5_App.Classes
{
    public class Fridge : ElectricalAppliance
    {
        private int temperature;
        public int Temperature
        {
            get => temperature;
            set
            {
                if (value < -10 || value > 10)
                    throw new ArgumentException("Температура холодильника має бути в межах від -10 до +10");
                else temperature = value;
            }
        }

        public Fridge(string name, double power, double radiation, int temperature) : base(name, power, radiation)
        {
            Temperature = temperature;
        }

        public override string ToString() =>
            base.ToString() + $", Температура: {Temperature}°C";
    }

}
