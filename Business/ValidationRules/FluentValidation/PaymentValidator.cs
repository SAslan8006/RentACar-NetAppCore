using Business.Constans;
using Core.Utilities.Results;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
                      
     
        }               
  
    }
}
