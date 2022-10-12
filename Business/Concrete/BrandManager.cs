using Business.Abstract;
using Business.BusinessAspects.Autofac.Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }



        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDelete);
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);

        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(brandId));
            if (result != null)
            {
                return new ErrorDataResult<Brand>();
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }




        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.SameNameExist);
            }
            return new SuccessResult();
        }
        private IResult CheckBrandExist(int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == brandId).Any();
            if (!result)
            {
                return new ErrorResult("marka bulunamadı.");
            }
            return new SuccessResult();
        }
    }
}
