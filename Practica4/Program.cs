using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallE;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Practica4
{
    enum Comando { Go, Pick, Drop, Items, Info, Bag, Quit };

    class Program
    {
        static TextInfo myTI;
        static void Main(string[] args)
        {
            Map mapa = new Map(10, 3);
            mapa.ReadMap("madrid.map");
            WallE.WallE wallE = new WallE.WallE();
            myTI = new CultureInfo("en-US", false).TextInfo;
            string comandos = "";

            Console.WriteLine(mapa.GetPlaceInfo(wallE.GetPosition()));
            do
            {
                Console.Write(">");
            } while (!ProcesaInput(Console.ReadLine(), wallE, mapa, ref comandos));
            Console.WriteLine("Finalmente vuelves a base, llevas contigo:");
            Console.WriteLine(wallE.Bag(mapa));
            Console.ReadLine();
        }
        static bool ProcesaInput(string com, WallE.WallE w, Map m, ref string historial)
        {
            string[] comandos = Regex.Split(com, " ");
            try
            {
                Comando comando = (Comando)Enum.Parse(typeof(Comando), myTI.ToTitleCase(comandos[0]));
                switch(comando)
                {
                    case Comando.Go:
                        Direction direccion = (Direction)Enum.Parse(typeof(Direction), myTI.ToTitleCase(comandos[1]));
                        if (comandos.Length == 2)
                        {
                            try
                            {
                                w.Move(m, direccion);
                                Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
                            }
                            catch
                            {
                                throw new Exception("No es posible moverse a esa dirección.");
                            }
                        }
                        else
                            throw new Exception("Comando no válido.");
                        break;
                    case Comando.Pick:
                        if (comandos.Length == 2)
                        {
                            try
                            {
                                w.PickItem(m, int.Parse(comandos[1]));
                            
                            }
                            catch
                            {
                                Console.WriteLine("No encuentro ese objeto.");
                            }
                        }
                        else
                            throw new Exception("Comando no válido.");
                        break;
                    case Comando.Drop:
                        if (comandos.Length == 2)
                        {
                            try
                            {
                                w.DropItem(m, int.Parse(comandos[1]));
                            }
                            catch
                            {
                                Console.WriteLine("No encuentro ese objeto.");
                            }
                        }
                        else
                            throw new Exception("Comando no válido.");
                         break;
                    case Comando.Items:
                        if (comandos.Length == 1)
                        {
                            Console.WriteLine(m.GetItemsPlace(w.GetPosition()));
                        }
                        else
                        {
                            throw new Exception("Comando no válido.");
                        }
                        break;
                    case Comando.Info:
                        if (comandos.Length == 1)
                        {
                            Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
                        }
                        else
                        {
                            throw new Exception("Comando no válido.");
                        }
                        break;
                    case Comando.Bag:
                        if (comandos.Length == 1)
                        {
                            Console.WriteLine(w.Bag(m));
                        }
                        else
                        {
                            throw new Exception("Comando no válido.");
                        }
                        break;
                    case Comando.Quit:
                        if (comandos.Length == 1)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Comando no válido.");
                        }
                    default:
                        throw new Exception("Comando no válido.");
                }
                historial += "\n" + com;
                return w.atSpaceShip(m);
            }
            catch(Exception e)
            {
                if(e.Message== "No es posible moverse a esa dirección.")
                    Console.WriteLine("No puedes moverte ahí.");
                else
                {
                    Console.WriteLine("No te entiendo.");
                }
            }
            return false;
        }

    }
}
