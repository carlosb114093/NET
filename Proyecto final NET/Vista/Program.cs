using Proyecto_final_NET.Controlador;
using Proyecto_final_NET.Modelo;
using System;
using System.Timers;

namespace Proyecto_final_NET.Vista // Note: actual namespace depends on the project name.
{
    internal class View
    {
      
        static void Main(string[] args)

            
        {
            Controller controller = new Controller();
            string bienvenida = "Bienvenido a la maquina expendedora digite C para Cliente P para proveedor";
            string entrada_cliente = "";
            string entrada_producto = "";
            string restock = "";
            string reprice = "";
            string compra = "";
           
 


            while (true) 
            { 
                do
                {
                    Console.WriteLine(bienvenida);
                    entrada_cliente = Console.ReadLine();

                } while (entrada_cliente != "C" && entrada_cliente != "P");

                Console.WriteLine("la lista de productos es: ");

                Console.WriteLine(controller.DisplayProductList());

                if (entrada_cliente == "C")
                {

                    bool valido = false;
                    do
                    {

                        Console.WriteLine("Escoja un producto de la lista");
                        entrada_producto = Console.ReadLine();
                        valido = controller.ProductExists(entrada_producto) && controller.ProductHasInventory(entrada_producto);
                    } while (valido == false);

                    //Console.WriteLine("Ingrese los billetes para el pago del producto");
                    int suma_billetes = 0;
                    int billete = 0;
                    while (true)
                    {
                        Console.WriteLine("Ingrese el billete");

                        try
                        {
                            billete = Convert.ToInt32(Console.ReadLine());
                            suma_billetes = suma_billetes + billete;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"Por favor ingrese un valor númerico: {e.Message}");
                        }

                        if (billete != 1000)
                        {
                            if (billete != 2000)
                            {
                                if (billete != 5000)
                                {
                                    if (billete != 10000)
                                    {
                                        if (billete != 20000)
                                        {
                                            Console.WriteLine("Esta maquina solo recibe billetes de $1000,$2000,$5000,$10000,$20000");
                                            break;
                                        }
                                    }
                                }
                            }

                        }


                        Console.WriteLine("para dejar de recibir billetes escriba STOP");
                        string cash = Console.ReadLine();
                        if (cash == "STOP")
                        {
                            break;

                        }

                    }
                    //comparar precio vs la suma_de billetes para calcular la devuelta

                    valido = controller.amountvalid(suma_billetes, entrada_producto);
                    if (valido == true)
                    {
                        
                        Console.WriteLine("El producto seleccionado es: "+entrada_producto);
                        int residuo = controller.residue(suma_billetes, entrada_producto);
                        Console.WriteLine("Su devuelta es:");
                        int res = residuo / 500;
                        Console.WriteLine(res + " monedas de quinientos");
                        residuo = residuo % 500;
                        if (residuo != 0)
                        {
                            res = residuo / 200;
                            Console.WriteLine(res + " monedas de doscientos");
                            residuo = residuo % 200;
                            if (residuo != 0)
                            {
                                res = residuo / 100;
                                Console.WriteLine(res + " monedas de cien");
                                residuo = residuo % 100;
                                if (residuo != 0)
                                {
                                    res = residuo / 50;
                                    Console.WriteLine(res + " monedas de cincuenta");

                                }

                            }

                        }



                    }
                    else
                    {
                        Console.WriteLine("la cantidad de dinero no puede ser menor al valor del producto");
                    }

                }

                else if (entrada_cliente == "P")
                {
                    bool valido = false;
                    Console.WriteLine("Ingrese el nombre de un producto");
                    entrada_producto = Console.ReadLine();
                    valido = controller.ProductExists(entrada_producto);
                    if (valido == true)
                    {
                        Console.WriteLine("Ingrese la nueva cantidad para el producto");
                        try
                        {
                            restock = Console.ReadLine();
                            int temporal = Int32.Parse(restock);
                            string cantidad = controller.newquantity(temporal, entrada_producto);
                            Console.WriteLine(cantidad);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"Por favor ingrese un valor númerico: {e.Message}");
                        }
                        
                        
                    }
                    else
                    {
                        try 
                        { 
                        Console.WriteLine("Ingrese la nueva cantidad para el producto");
                        restock = Console.ReadLine();
                        int temporal = Int32.Parse(restock);
                        Console.WriteLine("Ingrese el precio para el producto");
                        reprice = Console.ReadLine();
                        int temporales = Int32.Parse(reprice);
                        string add = controller.newProduct(entrada_producto, temporales, temporal);
                        Console.WriteLine(add);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"Por favor ingrese un valor númerico: {e.Message}");
                        }
                    }
                }       
                     
            }
        }
        
    }
}
