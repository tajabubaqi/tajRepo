using System.Collections.Generic;

namespace Creative_Harmony.Models
{
    public class OurWorks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<InternalWorks> internalWorks { get; set; }
    }
}
