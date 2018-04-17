using System;

namespace Lista
{
		public class Lista
		{
			private class Nodo{
				public int dato;
				public Nodo siguiente;
				public Nodo(int d, Nodo s){
					dato =d;
					siguiente=s;
				}
			}
			Nodo pri;
			public Lista ()
			{
				pri = null;
			}
			public void InsertaIni(int a){
				Nodo ini = new Nodo (a,pri);
				pri = a;
			}
			Nodo BuscaNodo(int e){
				Nodo busqueda = pri;
				while (busqueda != null && busqueda.dato != e) {
					busqueda = busqueda.siguiente;
				}
				return busqueda;

		}
	}
}
