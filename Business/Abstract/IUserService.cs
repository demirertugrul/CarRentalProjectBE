using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        IResult Update(UserUpdateDto userUpdateDto);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId);
    }
}
