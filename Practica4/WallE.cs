//Amparo Rubio Bellón
//Carlos Durán Domínguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listas;

namespace WallE
{
    public class WallE
    {
        int pos; // posicion de Wall-e en el mapa
        Lista bag; // lista de items recogidos por wall-e
                   // (son indices a la lista de items del mapa)

        public WallE()
        {
            pos = 0;
            bag = new Lista();
        }

        //Metodo que devuelve la posicion de WallE
        public int GetPosition()
        {
            return pos;
        }

        //Metodo que mueve a WallE
        public void Move(Map m, Direction dir)
        {
            int mov = m.Move(pos, dir);
            if (mov != -1)
                pos = mov;
            else
            {
                throw new Exception("Imposible realizar Movimiento.");
            }
        }

        //Metodo que coge un objeto de un sitio y lo mete ne la mochila.
        public void PickItem(Map m, int it)
        {
            try
            {
                m.PickItemPlace(pos, it);
                bag.IntroducirElementoInicio(it);
            }
            catch
            {
                throw new Exception("No existe el item a recoger.");
            }
        }

        //Metodo que deposito un objeto en un sitio y lo saca de la mochila.
        public void DropItem(Map m, int it)
        {
            if(!bag.borraElto(it))
                throw new Exception("No existe el item a dejar.");
            m.DropItemPlace(pos, it);
        }

        //Metodo que devuelve el contenido de la mochila de WallE
        public string Bag(Map m)
        {
            int tam = bag.CuentaEltos();
            string ret="";
            if(tam>0)
                ret += m.GetItemInfo(bag.NEsimo(0));
            for(int i =1; i<tam; i++)
            {
                ret += "\n"+m.GetItemInfo(bag.NEsimo(i));
            }
            return ret;
        }

        //Metodo que devuelve true si WallE esta en un sitio con nave espacial.
        public bool atSpaceShip(Map m)
        {
            return m.isSpaceShip(pos);
        }

        #region Tests Map
        
        public void ForcePosition(int i)
        {
            pos = i;
        }

        public Lista ForceBag()
        {
            return bag;
        }

        #endregion
    }
}
