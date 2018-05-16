using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallE;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace Practica4
{
    enum Comando { Go, Pick, Drop, Items, Info, Bag, Quit };

    public class Program
    {
        //Objeto que sirve para el parseo del enum Comandos
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        static void Main(string[] args)
        {
            //Creamos el mapa con los 10 sitio y los tres objetos.
            Map mapa = new Map(10, 3);
            mapa.ReadMap("madrid.map");
            WallE.WallE wallE = new WallE.WallE();

            string comandos = "";
            string usuario;
            Console.Write("Username: ");
            usuario = Console.ReadLine();
            Console.Clear();
            try
            {
                //Lee la partida anterior y guarda los comandos usados.
                comandos = LeerHistorial(usuario, wallE, mapa);
            }
            catch (Exception e)
            {
                //Si no existe el archivo lo crea.
                if (e.Message == "User doesn't exist.")
                {
                    (new StreamWriter(usuario + ".user")).Close();
                    Console.Write("Creating profile...\n");
                }
                else
                {
                    //Si ha habido un error al leer la partida ignora la informacion y sobreescribe.
                    Console.Clear();
                    Console.WriteLine("Corrupt user file. Starting new game...");
                }
                //Escribe la escena inicial.
                Console.WriteLine(mapa.GetPlaceInfo(wallE.GetPosition()));
                Console.WriteLine();
                Console.WriteLine(mapa.GetMoves(wallE.GetPosition()));
                Console.WriteLine();
            }

            string comando = "";

            //si el usuario escribe el comando de salir o esta en un lugar con nave espacial termina el programa(si carga una partida terminada no entrara en el bucle).
            while (comando.ToLower() != "quit" && !wallE.atSpaceShip(mapa))
            {
                //Escribe la marca para que el usuario sepa que puede escribir.
                Console.Write(">");
                comando = Console.ReadLine();

                try
                {
                    ProcesaInput(comando, wallE, mapa, ref comandos);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            } 

            //Sobreescribe los datos de la partida.
            StreamWriter archivo = new StreamWriter(usuario + ".user");
            archivo.Write(comandos);
            archivo.Close();

            //Escribe el contenido de la mochila.
            Console.WriteLine("You carry in your bag: ");
            string mochila = wallE.Bag(mapa);
            if(mochila=="")
                Console.WriteLine("¡Nothing!");
            else
                Console.WriteLine(mochila);

            Console.Write("\nPress ENTER to finish...");
            Console.ReadLine();
        }

        //Metodo que lee un comando y modifica el mapa y a WallE en consecuencia.
        public static void ProcesaInput(string com, WallE.WallE w, Map m, ref string historial)
        {
            //Troceamos el comando
            string[] comandos = Regex.Split(com, " ");
            Comando comando;
            //Parseamos la primera palabra del comando
            try
            {
                comando = (Comando)Enum.Parse(typeof(Comando), myTI.ToTitleCase(comandos[0]));
            }
            catch
            {
                throw new Exception("Invalid command.");
            }

            switch (comando)
            {
                case Comando.Go:
                    Direction direccion;
                    //Parseamos la direccion del comando.
                    try
                    {
                        direccion = (Direction)Enum.Parse(typeof(Direction), myTI.ToTitleCase(comandos[1]));
                    }
                    catch
                    {
                        throw new Exception("Invalid command.");
                    }
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 2)
                    {
                        try
                        {
                            w.Move(m, direccion);
                            Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
                            Console.WriteLine();
                            Console.WriteLine(m.GetMoves(w.GetPosition()));
                        }
                        catch
                        {
                            throw new Exception("You can't move in that direction.");
                        }
                    }
                    else
                        throw new Exception("Invalid command.");
                    break;
                case Comando.Pick:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 2)
                    {
                        try
                        {
                            w.PickItem(m, int.Parse(comandos[1]));
                        }
                        catch
                        {
                            throw new Exception("You can't pick that item.");
                        }
                    }
                    else
                        throw new Exception("Invalid command.");
                    break;
                case Comando.Drop:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 2)
                    {
                        try
                        {
                            w.DropItem(m, int.Parse(comandos[1]));
                        }
                        catch
                        {
                            throw new Exception("You don't carry it.");
                        }
                    }
                    else
                        throw new Exception("Invalid command.");
                    break;
                case Comando.Items:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 1)
                    {
                        string items = m.GetItemsPlace(w.GetPosition());
                        if (items == "")
                        {
                            Console.WriteLine("There is no items in this place.");
                        }
                        else
                        {
                            Console.WriteLine(items);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid command.");
                    }
                    break;
                case Comando.Info:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 1)
                    {
                        Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
                        Console.WriteLine();
                        Console.WriteLine(m.GetMoves(w.GetPosition()));
                    }
                    else
                    {
                        throw new Exception("Invalid command.");
                    }
                    break;
                case Comando.Bag:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length == 1)
                    {
                        string mochila = w.Bag(m);
                        if (mochila == "")
                        {
                            Console.WriteLine("Your bag is empty.");
                        }
                        else
                        {
                            Console.WriteLine(mochila);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid command.");
                    }
                    break;
                case Comando.Quit:
                    //Si tiene los argumentos requeridos intenta la orden.
                    if (comandos.Length != 1)
                    {
                        throw new Exception("Invalid command.");
                    }
                    break;
            }

            Console.WriteLine();
            historial += com + "\n";
        }

        public static string LeerHistorial(string nombreArchivo, WallE.WallE w, Map m)
        {
            StreamReader archivo;
            try
            {
                archivo = new StreamReader(nombreArchivo + ".user");
            }
            catch
            {
                throw new Exception("User doesn't exist.");
            }
            try
            {
                //Escribe la primera escena.
                Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
                Console.WriteLine();
                Console.WriteLine(m.GetMoves(w.GetPosition()));
                Console.WriteLine();
                
                string historial = "";
                while (!archivo.EndOfStream)
                {
                    string comando = archivo.ReadLine();
                    Console.WriteLine(">" + comando);

                    try
                    {
                        ProcesaInput(comando, w, m, ref historial);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                    }
                }
                archivo.Close();
                return historial;
            }
            catch
            {
                archivo.Close();
                throw new Exception("Command error.");
            }

        }

    }
}
