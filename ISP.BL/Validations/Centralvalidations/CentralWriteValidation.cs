using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class CentralWriteValidation:AbstractValidator<WriteCentralDTO>
    {
        public CentralWriteValidation()
        {
            RuleFor(a => a.Name).MaximumLength(5);
        }
           
    }
}
