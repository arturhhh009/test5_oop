namespace Lab5_App.Classes
{
    public class Computer : ElectricalAppliance
    {
        public string CPU { get; set; }
        private int ramSize;
        public int RamSize
        {
            get => ramSize;
            set
            {
                if (value <= 0) throw new ArgumentException("Обсяг оперативної пам'яті має бути додатним");
                ramSize = value;
            }
        }

        public Computer(string name, double power, double radiation, string cpu, int ram)
                : base(name, power, radiation)
        {
            CPU = cpu;
            RamSize = ram;
        }

        public override string ToString() =>
            base.ToString() + $", Процесор: {CPU}, ОЗП: {RamSize} ГБ";
    }

}
