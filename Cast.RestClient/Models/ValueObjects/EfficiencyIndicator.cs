namespace Cast.RestClient.Models.ValueObjects
{
    public class EfficiencyIndicator
    {
        public static EfficiencyIndicator Null
        {
            get { return new EfficiencyIndicator(); }
        }

        public double SoftwareResiliency { get; internal set; }
        public double SoftwareAgility { get; internal set; }
        public double SoftwareElegance { get; internal set; }
        public double SoftwareHealth { get; internal set; }
        public double CloudReady { get; internal set; }
        public double CloudReadyScan { get; internal set; }
    }
}