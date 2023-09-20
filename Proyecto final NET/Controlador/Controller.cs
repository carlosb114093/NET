using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Proyecto_final_NET.Modelo;

namespace Proyecto_final_NET.Controlador
{
    internal class Controller
    {
      public List<IProduct> ListaProductos { get; set; }

      public Controller()
        {
            ListaProductos = new List<IProduct>();

            ListaProductos.Add(new Consumable("Cocacola",3000,1));
            ListaProductos.Add(new Consumable("Snacks",2500,10));
            ListaProductos.Add(new Consumable("Chocolatina",2800,8));
        }

        public string newProduct(string name, int price,int quantity)
        {
            string value = "";
            ListaProductos.Add(new Consumable(name,price,quantity));

            foreach (IProduct product in ListaProductos)
            {
                value += product.DisplayProduct() + '\n';
            }
            return value;
        }

        public string DisplayProductList()
        {
            string value = "";

         foreach(IProduct product in ListaProductos)
            {
                value += product.DisplayProduct() + '\n';
            }
            return value;
        }
                  
        public bool ProductExists(string pname)
        {
           bool producto_existe = false;

            ListaProductos.ForEach(x =>
            {
                if (x.Name == pname)
                {
                    producto_existe = true;
                }

            }
            );
            return producto_existe;
        }

        public bool ProductHasInventory(string pname)
        {
            bool tiene_inv = false;

            ListaProductos.ForEach(x =>
            {
                if (x.Name == pname && x.Quantity > 0)
                {
                    tiene_inv = true;
                }
                

            }
            );
            return tiene_inv;
        }

        public bool amountvalid(int suma,string name)
        {
            bool valid = false;
            foreach (IProduct product in ListaProductos)
            {
             
                if(product.Name == name)
                {
                    if (suma >= product.Price) {
                        valid = true;
                        
                        product.Quantity = product.Quantity - 1;
                    if (product.Quantity == 0)
                    {
                            product.Name = "el producto: " + product.Name + " No esta disponible";
                    }
                        
                    }
                }
            }
            return valid;
        }

        public int residue(int suma, string name)
        {
            int res = 0;
            foreach (IProduct product in ListaProductos)
            {

                
                    res = suma - product.Price;
                
            }
            return res;
        }

        public string newquantity(int can, string name)
        {
            string res = "";
            
            foreach (IProduct product in ListaProductos)
            {
                if (product.Name == name) { 
                product.Quantity = can;
                res += product.DisplayProduct() + '\n';
                }
            }
            return res;
        }

        

    }
}
