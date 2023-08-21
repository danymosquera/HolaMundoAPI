using HolaMundoAPI.Data.Models;

namespace HolaMundoAPI.Data.Models
{
    public class ClientDetailDto : Client
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public double LifeExpectancy { get; set; }
    }

}
