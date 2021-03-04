using System.Collections.Generic;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public interface IProductsRepo
    {
        IEnumerable<Product> getAll(string nameFilter=null, int? discontinuedFilter=null);
    }
}