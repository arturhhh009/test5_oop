namespace Lab5_App.Classes
{
    public abstract class ElectricalAppliance
    {
        private double power;
        private double emRadiation;
        public string Name { get; set; }
        public double Power
        {
            get => power;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Потужність не може бути від'ємною");
                else power = value;
            }
        }
        public bool IsPluggedIn { get; private set; }
        public double EmRadiation
        {
            get => emRadiation;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Електровипромінювання не може бути від'ємним");
                else emRadiation = value;
            }
        }

        protected ElectricalAppliance(string name, double power, double radiation)
        {
            Name = name;
            Power = power;
            EmRadiation = radiation;
            IsPluggedIn = false;
        }

        public void PlugIn() => IsPluggedIn = true;
        public void Unplug() => IsPluggedIn = false;

        public override string ToString() =>
            $"{Name}: {Power}Вт, Випромінювання: {EmRadiation} мкТл, Увімкнено: {IsPluggedIn}";
    }

}
