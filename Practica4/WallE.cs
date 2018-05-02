using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listas;

namespace WallE
{
    class WallE
    {
        int pos; // posicion de Wall-e en el mapa
        Lista bag; // lista de items recogidos por wall-e
                   // (son indices a la lista de items del mapa)

        public WallE()
        {
            pos = 0;
            bag = new Lista();
        }

        public int GetPosition()
        {
            return pos;
        }

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

        public void DropItem(Map m, int it)
        {
            if(!bag.borraElto(it))
                throw new Exception("No existe el item a dejar.");
            m.DropItemPlace(pos, it);
        }

        public string Bag(Map m)
        {
            int tam = bag.CuentaEltos();
            string ret="";
            for(int i =0; i<tam; i++)
            {
                ret += m.GetItemInfo(bag.NEsimo(i));
            }
            return ret;
        }

        public bool atSpaceShip(Map m)
        {
            return m.isSpaceShip(pos);
        }
    }
}
