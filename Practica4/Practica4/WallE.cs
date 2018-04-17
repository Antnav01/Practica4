using System;
using Lista;
namespace WallE
{
		// posibles direcciones
		public enum Direction {North,South,East,West};
		class Map{
			// items basura
			struct Item{
				public string name, description;
			}
			// lugares del mapa
			struct Place {
				public string name, description;
				public bool spaceShip;
				public int [] connections; // vector de 4 componentes
				// con el lugar al norte, sur, este y oeste
				// -1 si no hay conexion
				public Lista itemsInPlace; // liste de enteros, indices al vector de items
			}
			Place [] places; // vector de lugares del mapa
			Item [] items; // vector de items del juego
		int nPlaces, nItems;
		public Map(){
			places= new Place[nPlaces];
			items= new Item[nItems];

		}
	}
}
