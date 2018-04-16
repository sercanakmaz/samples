using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample1
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleForEach(p => p.ValueList).SetValidator(new ProductAttributeValueValidator());
        }

        public override ValidationResult Validate(ValidationContext<Product> context)
        {
            var errorList = base.Validate(context).Errors.ToList();
            var result = new ValidationResult(errorList);

            return result;
        }

        public class ProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
        {
            public override ValidationResult Validate(ValidationContext<ProductAttributeValue> context)
            {
                var errorList = new List<ValidationFailure>();


                if (context.InstanceToValidate.Attribute.Required)
                {
                    if (string.IsNullOrEmpty(context.InstanceToValidate.Value))
                    {
                        errorList.Add(new ValidationFailure(context.InstanceToValidate.Attribute.Code, "This field is required"));
                    }
                }

                if (context.InstanceToValidate.Attribute.MinCharacter.HasValue)
                {
                    if (context.InstanceToValidate.Attribute.MinCharacter.Value > context.InstanceToValidate.Value?.Length)
                    {
                        errorList.Add(new ValidationFailure(context.InstanceToValidate.Attribute.Code, $"Min character: {context.InstanceToValidate.Attribute.MinCharacter}"));
                    }
                }

                if (context.InstanceToValidate.Attribute.MaxCharacter.HasValue)
                {
                    if (context.InstanceToValidate.Attribute.MaxCharacter.Value < context.InstanceToValidate.Value?.Length)
                    {
                        errorList.Add(new ValidationFailure(context.InstanceToValidate.Attribute.Code, $"Max character: {context.InstanceToValidate.Attribute.MaxCharacter}"));
                    }
                }

                var result = new ValidationResult(errorList);

                return result;
            }
        }
    }
}
