using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    public class Lista
    {
        class Elemento
        {
            Elemento siguiente;
            int dato;
            public Elemento()
            {
                siguiente = null;
                dato = 0;
            }
            public Elemento(Elemento _siguiente, int _dato)
            {
                siguiente = _siguiente;
                dato = _dato;
            }

            public Elemento Siguiente()
            {
                return siguiente;
            }

            public Elemento Siguiente(Elemento _siguiente)
            {
                return siguiente = _siguiente;
            }

            public int Dato()
            {
                return dato;
            }

            public int Dato(int _dato)
            {
                return dato = _dato;
            }
        }

        Elemento primero;
        Elemento ultimo;
        int numeroElementos;

        public Lista()
        {
            primero = null;
            ultimo = null;
            numeroElementos = 0;
        }

        public Lista(int limite, int rep)
        {
            primero = null;
            ultimo = null;
            numeroElementos = 0;

            for(int i = 0; i<rep; i++)
            {
                for (int j = 1; j <= limite; j++)
                {
                    IntroducirElementoFinal(j);
                }
            }
        }

        public string Verlista()
        {
            Elemento aux = primero;
            string texto = "";

            while(aux!=null)
            {
                texto = texto + aux.Dato()+":";
            }
            return texto.Remove(texto.Length - 1);
        }

        public void IntroducirElementoInicio(int dato)
        {
            Elemento aux = new Elemento();
            aux.Dato(dato);
            if(primero==null)
            {
                primero = aux;
                ultimo = aux;
            }
            else
            {
                aux.Siguiente(primero);
            }
            numeroElementos++;
        }

        public void IntroducirElementoFinal(int dato)
        {

            Elemento aux = new Elemento();
            aux.Dato(dato);
            if (primero == null)
            {
                primero = aux;
                ultimo = aux;
            }
            else
            {
                ultimo.Siguiente(aux);
                ultimo = aux;
            }
            numeroElementos++;
        }

        public int NumeroElementos()
        {
            return numeroElementos;
        }

        public void IntroducirElementoEnPosicion(int posicion, int dato)
        {
            if (posicion < 0 || posicion > numeroElementos)
            {
                throw new Exception("La posicion " + posicion + " de elemento no válida");
            }
            else
            {
                numeroElementos++;
                if (posicion == 0)
                {
                    IntroducirElementoInicio(dato);
                }
                else
                {
                    
                    Elemento aux = primero;
                    for (int i = 1; i < posicion; i++ )
                    {
                        i++;
                        aux = aux.Siguiente();
                    }
                    aux.Siguiente(new Elemento(aux.Siguiente(), dato));
                }
            }
        }

        public bool borraElto(int e)
        {
            Elemento aux = primero;
            if(aux!=null)
            {
                while (aux.Siguiente() != null && aux.Siguiente().Dato() != e)
                    aux = aux.Siguiente();
                if (aux.Siguiente() == null)
                    return false;
                else
                {
                    aux.Siguiente(aux.Siguiente().Siguiente());
                    return true;
                }
            }
            return false;
        }




    }
}
