namespace Lab5_App.Classes
{
    public class Oven : ElectricalAppliance
    {
        private string mode;
        public string Mode
        {
            get => mode;
            set
            {
                if (value == null)
                    mode = "За замовчуванням";
                else mode = value;
            }
        }

        public Oven(string name, double power, double radiation, string mode = "За замовчуванням") : base(name, power, radiation)
        {
            Mode = mode;
        }

        public override string ToString() =>
        base.ToString() + $", Режим: {Mode}";
    }

}
