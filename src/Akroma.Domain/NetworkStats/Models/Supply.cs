namespace Akroma.Domain.NetworkStats.Models
{
    public class Supply
    {

        public Supply(double circulating)
        {
            Circulating = circulating;
        }

        public double Circulating { get; set; }
    }
}
