using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByUnitsPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);

    }
}
