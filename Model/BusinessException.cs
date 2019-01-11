using System;

namespace Elmah.Model
{
    public class BusinessException : Exception
    {
        public BusinessException(Product product)
             : base($"Product ({product.Name}) cannot be processed")
        { }
    }
}
