using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T rental);
        IResult Delete(T rental);
        IResult Update(T rental);
    }
}
