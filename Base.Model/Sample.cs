using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Sample
    {
        public Sample()
        {
            this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }
    }
}
