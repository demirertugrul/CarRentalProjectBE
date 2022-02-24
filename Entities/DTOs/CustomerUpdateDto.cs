using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerUpdateDto : IDto
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
    }
}
