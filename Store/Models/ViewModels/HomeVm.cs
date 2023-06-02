using System.Collections;
using System.Collections.Generic;

namespace Store.Models.ViewModels
{
    public class HomeVm
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set;}
    }
}
