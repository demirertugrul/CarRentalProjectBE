using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICostumerService
    {
        IDataResult<List<Costumer>> GetAll();
        IDataResult<Costumer> GetById(int id);
        IResult Add(Costumer costumer);
        IResult Delete(Costumer costumer);
        IResult Update(Costumer costumer);
    }
}
