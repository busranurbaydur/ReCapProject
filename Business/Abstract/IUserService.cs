using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        //IDataResult<List<User>> GetAll();
        //IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult Add(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
    }
}
