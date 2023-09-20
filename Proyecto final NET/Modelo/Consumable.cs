using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_NET.Modelo
{
    public class Consumable : IProduct
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public Consumable(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }


        public string DisplayProduct()
        {
            return $"Nombre: {Name} - Price: {Price} ({Quantity})";
        }

        public int QProduct(string pname)
        {
            throw new NotImplementedException();
        }
    }
}
