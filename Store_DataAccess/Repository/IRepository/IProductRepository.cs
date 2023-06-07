using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
