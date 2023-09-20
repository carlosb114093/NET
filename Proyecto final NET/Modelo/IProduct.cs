using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_NET.Modelo
{
     interface IProduct
    {
        string Name { get; set; }
        int Quantity { get; set; }
        int Price { get; set; }
        string DisplayProduct();
        int QProduct(string pname);
    }
}
