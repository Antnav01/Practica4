using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listas;
using System.IO;
using System.Text.RegularExpressions;

namespace WallE
{
    // posibles direcciones
    public enum Direction { North, East, South, West };
    public class Map
    {
        enum EstadosLectura { LeyendoLugares, LeyendoCalles, LeyendoItems, Fin };
        // items basura
        struct Item
        {
            public string name, description;
        }
        // lugares del mapa
        public struct Place
        {
            public string name, description;
            public bool spaceShip;
            public int[] connections; // vector de 4 componentes
                                      // con el lugar al norte, sur, este y oeste
                                      // -1 si no hay conexion
            public Lista itemsInPlace; // liste de enteros, indices al vector de items
        }
        Place[] places; // vector de lugares del mapa
        Item[] items; // vector de items del juego
        int nPlaces, nItems; // numero de lugares y numero de items del mapa

        public Map(int numPlaces, int numItems)
        {
            nPlaces = numPlaces;
            nItems = numItems;
            places = new Place[nPlaces];
            int numeroDirecciones = Enum.GetValues(typeof(Direction)).Length;
            Place lugarVacio = CreateEmptyPlace(numeroDirecciones);
            for (int i = 0; i < nPlaces; i++)
            {
                places[i] = lugarVacio;
            }
            items = new Item[nItems];
            Item itemVacio;
            itemVacio.name = "";
            itemVacio.description = "";
            for (int i = 0; i < nItems; i++)
            {
                items[i] = itemVacio;
            }
        }

        Place CreateEmptyPlace(int numeroDirecciones)
        {
            Place place;
            place.name = "";
            place.description = "";
            place.spaceShip = false;
            place.connections = new int[numeroDirecciones];
            place.itemsInPlace = new Lista();
            return place;
        }

        public void ReadMap(string file)
        {
            StreamReader archivo = new StreamReader(file);
            EstadosLectura estado = EstadosLectura.LeyendoLugares;
            while (!archivo.EndOfStream && estado != EstadosLectura.Fin)
            {
                string[] linea = Regex.Split(archivo.ReadLine(), " ");
                switch (estado)
                {
                    case EstadosLectura.LeyendoLugares:
                        switch (linea[0])
                        {
                            case "place":
                                try
                                {
                                    int numeroLugar = CreatePlace(linea);
                                    places[numeroLugar].description = ReadDescription(archivo);
                                    archivo.ReadLine();
                                }
                                catch
                                {
                                    throw new Exception("Error al leer un lugar.");
                                }
                                break;
                            case "street":
                                CreateStreet(linea);
                                estado = EstadosLectura.LeyendoCalles;
                                break;
                            default:
                                throw new Exception("Error lectura archivo.");
                        }
                        break;
                    case EstadosLectura.LeyendoCalles:
                        switch (linea[0])
                        {
                            case "street":
                                CreateStreet(linea);
                                estado = EstadosLectura.LeyendoCalles;
                                break;
                            case "":
                                estado = EstadosLectura.LeyendoItems;
                                break;
                            default:
                                throw new Exception("Error lectura archivo.");
                        }
                        break;
                    case EstadosLectura.LeyendoItems:
                        switch (linea[0])
                        {
                            case "garbage":
                                CreateItem(linea);
                                break;
                            case "":
                                estado = EstadosLectura.Fin;
                                break;
                            default:
                                throw new Exception("Error al leer el archivo.");
                        }
                        break;
                }
            }
        }

        //Metodo que crea el lugar indicado y devuelve su indice.
        public int CreatePlace(string[] palabras)
        {
            if (palabras.Length == 4)
            {
                Place lugar;
                lugar.connections = new int[4];
                for (int i = 0; i < 4; i++)
                    lugar.connections[i] = -1;

                switch (palabras[3])
                {
                    case "noSpaceShip":
                        lugar.spaceShip = false;
                        break;
                    case "spaceShip":
                        lugar.spaceShip = true;
                        break;
                    default:
                        throw new Exception("Lectura del lugar errónea.");
                }
                lugar.itemsInPlace = new Lista();

                lugar.name = palabras[2];
                lugar.description = "";

                int numeroLugar = int.Parse(palabras[1]);

                if (numeroLugar >= 0 && numeroLugar < nPlaces && places[numeroLugar].name == "")
                {
                    places[numeroLugar] = lugar;
                    return numeroLugar;
                }
                else
                    throw new Exception("Lugar existente o fuera de rango.");
            }
            else
                throw new Exception("Lectura del lugar errónea.");
        }

        //metodo que devuelve la cadena de caracteres que se encuentra entre dos """ en un archivo. Si lo leido no empieza con un """ o no contiene una segunda recurrencia de este caracter lanza una excepcion.
        string ReadDescription(StreamReader archivo)
        {
            if (!archivo.EndOfStream)
            {
                string aux = archivo.ReadLine();
                if (aux.Length != 0 && aux[0] == '\"')
                {

                    string ret = "";
                    bool encontradaComilla;
                    int i = 1;

                    //Lee la primera linea
                    while (i < aux.Length && aux[i] != '\"')
                    {
                        ret += aux[i];
                        i++;
                    }

                    encontradaComilla = i != aux.Length;
                    //LL
                    while (!(archivo.EndOfStream || encontradaComilla))
                    {
                        aux = archivo.ReadLine();
                        i = 0;
                        ret += "\n";
                        while (i < aux.Length && aux[i] != '\"')
                        {
                            ret += aux[i];
                            i++;
                        }
                        encontradaComilla = i != aux.Length;
                    }
                    if (encontradaComilla)
                        return ret;
                    else
                        throw new Exception("Falta cerrar el texto.");
                }
                else
                    throw new Exception("Descripcion del lugar errónea.");
            }
            else
                throw new Exception("No hay texto que leer.");
        }

        public void CreateStreet(string[] palabras)
        {
            if (palabras.Length == 7 && palabras[2] == "place" && palabras[5] == "place")
            {
                int numeroPrimerLugar = int.Parse(palabras[3]),
                    numeroSegundoLugar = int.Parse(palabras[6]);
                if (numeroPrimerLugar >= 0 && numeroPrimerLugar < nPlaces && numeroSegundoLugar >= 0
                    && numeroSegundoLugar < nPlaces && numeroPrimerLugar != numeroSegundoLugar)
                {

                    int direccionPrimeroSegundo;
                    switch (palabras[4])
                    {
                        case "north":
                            direccionPrimeroSegundo = (int)Direction.North;
                            break;
                        case "south":
                            direccionPrimeroSegundo = (int)Direction.South;
                            break;
                        case "west":
                            direccionPrimeroSegundo = (int)Direction.West;
                            break;
                        case "east":
                            direccionPrimeroSegundo = (int)Direction.East;
                            break;
                        default:
                            throw new Exception("Direccion no parseable.");
                    }

                    int direccionSegundoPrimero = (direccionPrimeroSegundo + 2) % 4;

                    if ((places[numeroPrimerLugar].connections[direccionPrimeroSegundo] == -1 || places[numeroPrimerLugar].connections[direccionPrimeroSegundo] == numeroSegundoLugar) &&
                        (places[numeroSegundoLugar].connections[direccionSegundoPrimero] == -1 || places[numeroSegundoLugar].connections[direccionSegundoPrimero] == numeroPrimerLugar))
                    {
                        places[numeroPrimerLugar].connections[direccionPrimeroSegundo] = numeroSegundoLugar;
                        places[numeroSegundoLugar].connections[direccionSegundoPrimero] = numeroPrimerLugar;
                    }
                    else
                        throw new Exception("Error al sobreescribir una calle de un lugar.");
                }
                else
                {
                    throw new Exception("Calle imposible.");
                }
            }
            else
            {
                throw new Exception("Parseo imposible.");
            }
        }

        public void CreateItem(string[] palabras)
        {
            if (palabras[3] == "place")
            {
                int numeroItem = int.Parse(palabras[1]);
                if (numeroItem >= 0 && numeroItem < nItems && items[numeroItem].name == "")
                {
                    items[numeroItem].name = palabras[2];

                    string aux = "";
                    for (int i = 5; i < palabras.Length; i++)
                        aux += palabras[i] + " ";
                    string comprobacion = aux;
                    aux = aux.Trim('"', ' ');
                    if (aux.Length + 3 == comprobacion.Length)
                        items[numeroItem].description = aux;
                    else
                        throw new Exception("Faltan \" en la descripción.");
                    int numeroLugar = int.Parse(palabras[4]);
                    if (numeroLugar >= 0 && numeroLugar < nPlaces)
                    {
                        places[numeroLugar].itemsInPlace.IntroducirElementoFinal(numeroItem);
                    }
                    else
                    {
                        throw new Exception("Lugar del item fuera de rango.");
                    }
                }
                else
                {
                    throw new Exception("Item existente o fuera de rango.");
                }
            }
            else
                throw new Exception("Falta palabra clase \"place\".");
        }

        public string GetPlaceInfo(int pl)
        {
            try
            {
                return places[pl].description;
            }
            catch
            {
                throw new Exception("Lugar no existente.");
            }
        }

        public string GetMoves(int pl)
        {
            try
            {
                string ret = "";
                int tam = Enum.GetValues(typeof(Direction)).Length;
                for (int i = 0; i < tam; i++)
                {
                    if (places[pl].connections[i] != -1)
                    {
                        ret += ((Direction)i).ToString("g") + ": " + places[places[pl].connections[i]].name + "\n";
                    }
                }
                if (ret != "")
                {
                    ret = ret.Remove(ret.Length - 1, 1);
                }
                return ret;
            }
            catch
            {
                throw new Exception("No existe el lugar.");
            }
        }

        public int GetNumItems(int pl)
        {
            try
            {
                return places[pl].itemsInPlace.CuentaEltos();
            }
            catch
            {
                throw new Exception("Lugar fuera de rango.");
            }
        }

        public string GetItemInfo(int it)
        {
            try
            {
                return it + ": " + items[it].name + " " + items[it].description + "\n";
            }
            catch
            {
                throw new Exception("No existe ese item.");
            }
        }

        public string GetItemsPlace(int pl)
        {
            int tam = places[pl].itemsInPlace.CuentaEltos();
            string ret="";
            for (int i = 0; i < tam; i++)
                ret += GetItemInfo(places[pl].itemsInPlace.NEsimo(i));
            return ret;
        }

        public void PickItemPlace(int pl, int it)
        {
            if (!places[pl].itemsInPlace.borraElto(it))
                throw new Exception("No existe el item.");
        }

        public void DropItemPlace(int pl, int it)
        {
            places[pl].itemsInPlace.IntroducirElementoInicio(it);
        }

        public int Move(int pl, Direction dir)
        {
            try
            {
                return places[pl].connections[(int)dir];
            }catch
            {
                throw new Exception("El sitio no existe.");
            }
        }

        public bool isSpaceShip(int pl)
        {
            try
            {
                return places[pl].spaceShip;
            }
            catch
            {
                throw new Exception("No existe el sitio.");
            }
        }

        #region Tests Map
        public Map(int sitios, int objetos, int irrelevante)
        {
            places = new Place[sitios];
            for (int i = 0; i < sitios; i++) {
                places[i].connections = new int[4];
                places[i].connections[0] = i % 2 == 0 ? -1 : 0;
                places[i].connections[1] = (i / 2)%2==0 ? -1 : 0;
                places[i].connections[2] = (i / 4) % 2 == 0 ? -1 : 0;
                places[i].connections[3] = (i / 8) % 2 == 0 ? -1 : 0;
                places[i].description = "Descripcion" + i;
                places[i].name = "Nombre" + i;
                places[i].itemsInPlace = new Lista();

                for(int j= 0; j<i%(objetos+1); j++)
                {
                    places[i].itemsInPlace.IntroducirElementoFinal(Math.Min(j, objetos-1));
                }
                places[i].spaceShip = i % 2 == 0;                
            }
            items = new Item[objetos];
            for (int i = 0; i < objetos; i++)
            {
                items[i].name = "Nombre" + i;
                items[i].description = "Descripcion" + i;
            }
            nPlaces = sitios;
            nItems = objetos;
        }

        public Place Sitio(int pl)
        {
            return places[pl];
        }
        #endregion
    }

}
