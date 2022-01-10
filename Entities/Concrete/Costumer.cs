using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Costumer:IEntity
    {
        public int CostumerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
