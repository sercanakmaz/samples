using System;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product
            {
                ValueList = new System.Collections.Generic.List<ProductAttributeValue>
                {
                    new ProductAttributeValue
                    {
                        Attribute = new Attribute
                        {
                            Code = "SKU",
                            MinCharacter =  3,
                            Required = true
                        },
                        Value =""
                    },
                    new ProductAttributeValue
                    {
                        Attribute = new Attribute
                        {
                            Code = "TitleShort",
                            MinCharacter =  10,
                            Required = true
                        },
                        Value ="Deneme "
                    },
                    new ProductAttributeValue
                    {
                        Attribute = new Attribute
                        {
                            Code = "Description",
                            MinCharacter =  10
                        },
                        Value = "324"
                    }
                }
            };

            ProductValidator validator = new ProductValidator();

            var result = validator.Validate(product);

            foreach (var item in result.Errors)
            {
                Console.WriteLine($"{item.PropertyName}: {item.ErrorMessage}");
            }

            Console.ReadKey();
        }
    }
}
