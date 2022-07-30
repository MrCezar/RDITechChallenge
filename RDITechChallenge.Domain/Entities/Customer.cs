using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDITechChallenge.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
