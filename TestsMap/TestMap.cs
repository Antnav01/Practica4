using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallE;

namespace TestsMap
{
    [TestClass]
    public class TestMap
    {
        [TestMethod]
        public void TestGetMovesSinDirecciones()
        {
            //Arrange
            Map m = new Map(1, 1, 1);
            string esperado = "";
            //Act
            string final = m.GetMoves(0);
            //Assert
            Assert.AreEqual(esperado, final, "Devuelve una direccion cuando no tendria que hacerlo");
        }
        
        [TestMethod]
        public void TestGetMovesCuatroDirecciones()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "North: Nombre15\nEast: Nombre0\nSouth: Nombre1\nWest: Nombre2";
            //Act
            string final = m.GetMoves(15);
            //Assert
            Assert.AreEqual(esperado, final, "No ha escrito bien las Direcciones");
        }

        [TestMethod]
        public void TestGetMovesTresDirecciones()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "East: Nombre15\nSouth: Nombre0\nWest: Nombre1";
            //Act
            string final = m.GetMoves(14);
            //Assert
            Assert.AreEqual(esperado, final, "No ha escrito bien las Direcciones");
        }

        [TestMethod]
        public void TestGetMovesFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            try
            {
                //Act
                m.GetMoves(-1);
                //Assert
                Assert.Fail("No hay error al dar un lugar fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetMovesFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            try
            {
                //Act
                m.GetMoves(17);
                //Assert
                Assert.Fail("No hay error al dar un lugar fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetNumItemsCeroUnoDosTresYCuatro()
        {
            //Arrange
            Map m = new Map(5, 4, 1);
            int esperado0 = 0, esperado1 = 1, esperado2 = 2, esperado3 = 3, esperado4 = 4;
            //Act
            int final0 = m.GetNumItems(0);
            int final1 = m.GetNumItems(1);
            int final2 = m.GetNumItems(2);
            int final3 = m.GetNumItems(3);
            int final4 = m.GetNumItems(4);
            //Assert
            Assert.AreEqual(esperado0, final0, "Numero de items distinto de cero.");
            Assert.AreEqual(esperado1, final1, "Numero de items distinto de uno.");
            Assert.AreEqual(esperado2, final2, "Numero de items distinto de dos.");
            Assert.AreEqual(esperado3, final3, "Numero de items distinto de tres.");
            Assert.AreEqual(esperado4, final4, "Numero de items distinto de cuatro.");
        }

        [TestMethod]
        public void TestGetNumItemsFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            try
            {
                //Act
                m.GetNumItems(-1);
                //Assert
                Assert.Fail("No hay error al dar un lugar fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetNumItemsFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            try
            {
                //Act
                m.GetNumItems(17);
                //Assert
                Assert.Fail("No hay error al dar un lugar fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetItemInfoSimple()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "0: Nombre0 Descripcion0\n";
            //Act
            string final = m.GetItemInfo(0);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestGetItemInfoFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(16, 2, 0);
            try
            {
                //Act
                m.GetItemInfo(-1);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }

        }

        [TestMethod]
        public void TestGetItemInfoFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            try
            {
                //Act
                m.GetItemInfo(4);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetItemsPlaceSinObjetos()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "";
            //Act
            string final = m.GetItemsPlace(0);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestGetItemsPlaceConUnObjeto()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "0: Nombre0 Descripcion0";
            //Act
            string final = m.GetItemsPlace(1);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestGetItemsPlaceConDosObjetos()
        {
            //Arrange
            Map m = new Map(16, 2, 0);
            string esperado = "0: Nombre0 Descripcion0\n1: Nombre1 Descripcion1";
            //Act
            string final = m.GetItemsPlace(2);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestGetItemsPlaceFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            try
            {
                //Act
                m.GetItemsPlace(16);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestGetItemsPlaceFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            try
            {
                //Act
                m.GetItemsPlace(-1);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestPickItemPlaceCogiendoUnoDeUnSitioConUno()
        {
            //Arrange
            Map m = new Map(16, 2, 0);
            string esperado = "";
            //Act
            m.PickItemPlace(1,0);
            //Assert
            Assert.AreEqual(esperado, m.GetItemsPlace(1), "Información no válida.");
        }

        [TestMethod]
        public void TestPickItemPlaceCogiendoUnoDeUnSitioConDos()
        {
            //Arrange
            Map m = new Map(16, 2, 0);
            string esperado = "0: Nombre0 Descripcion0";
            //Act
            m.PickItemPlace(2, 1);
            //Assert
            Assert.AreEqual(esperado, m.GetItemsPlace(2), "Información no válida.");
        }

        [TestMethod]
        public void TestPickItemPlaceCogiendoUnoDeUnSitioSinEse()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            try
            {
                //Act
                m.PickItemPlace(2,2);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestPickItemPlaceCogiendoUnoDeUnSitioSinNinguno()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            try
            {
                //Act
                m.PickItemPlace(0, 2);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestDropItemPlaceEnVacio()
        {
            //Arrange
            Map m = new Map(5, 2, 0);
            string esperado = "0: Nombre0 Descripcion0";
            //Act
            m.DropItemPlace(0, 0);
            //Assert
            Assert.AreEqual(esperado, m.GetItemsPlace(0), "Información no válida.");
        }

        [TestMethod]
        public void TestDropItemPlaceEnUnElemento()
        {
            //Arrange
            Map m = new Map(5, 2, 0);
            string esperado = "1: Nombre1 Descripcion1\n0: Nombre0 Descripcion0";
            //Act
            m.DropItemPlace(1, 1);
            //Assert
            Assert.AreEqual(esperado, m.GetItemsPlace(1), "Información no válida.");
        }

        [TestMethod]
        public void TestDropItemPlaceEnVariosElementos()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            string esperado = "2: Nombre2 Descripcion2\n0: Nombre0 Descripcion0\n1: Nombre1 Descripcion1";
            //Act
            m.DropItemPlace(2, 2);
            //Assert
            Assert.AreEqual(esperado, m.GetItemsPlace(2), "Información no válida.");
        }

        [TestMethod]
        public void TestDropItemPlaceFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(7, 3, 0);
            try
            {
                //Act
                m.DropItemPlace(8, 2);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestDropItemPlaceFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(7, 3, 0);
            try
            {
                //Act
                m.DropItemPlace(-2, 2);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMoveEnSitioSinSalidas()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            int esperado = -1;
            //Act
            int final0 = m.Move(0, Direction.East);
            int final1 = m.Move(0, Direction.North);
            int final2 = m.Move(0, Direction.South);
            int final3 = m.Move(0, Direction.West);
            //Assert
            Assert.AreEqual(esperado, final0, "Tiene salida en el este.");
            Assert.AreEqual(esperado, final1, "Tiene salida en el norte.");
            Assert.AreEqual(esperado, final2, "Tiene salida en el sur.");
            Assert.AreEqual(esperado, final3, "Tiene salida en el oeste.");
        }

        [TestMethod]
        public void TestMoveEnSitioConTodasLasSalidas()
        {
            //Arrange
            Map m = new Map(16, 3, 0);
            int esperado0 = 0,
                esperado1 = 15,
                esperado2 = 1,
                esperado3 = 2;
            //Act
            int final0 = m.Move(15, Direction.East);
            int final1 = m.Move(15, Direction.North);
            int final2 = m.Move(15, Direction.South);
            int final3 = m.Move(15, Direction.West);
            //Assert
            Assert.AreEqual(esperado0, final0, "No tiene salida en el este.");
            Assert.AreEqual(esperado1, final1, "No tiene salida en el norte.");
            Assert.AreEqual(esperado2, final2, "No tiene salida en el sur.");
            Assert.AreEqual(esperado3, final3, "No tiene salida en el oeste.");
        }

        [TestMethod]
        public void TestMoveFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(7, 3, 0);
            try
            {
                //Act
                m.Move(-2, Direction.East);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }
        [TestMethod]
        public void TestMoveFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(7, 3, 0);
            try
            {
                //Act
                m.Move(10, Direction.East);
                //Assert
                Assert.Fail("No hay error.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestisSpaceShipVerdadero()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            bool esperado = true;
            //Act
            bool final = m.isSpaceShip(0);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestisSpaceShipFalso()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            bool esperado = false;
            //Act
            bool final = m.isSpaceShip(1);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

        [TestMethod]
        public void TestisSpaceShipFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            try
            {//Act
                m.isSpaceShip(-1);
                //Assert
                Assert.Fail("No hay fallo.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestisSpaceShipFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(5, 3, 0);
            try
            {//Act
                m.isSpaceShip(50);
                //Assert
                Assert.Fail("No hay fallo.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreatePlaceUnaCalleEnVacio()
        {
            //Arrange
            Map.Place esperado;
            esperado.name = "Nombre0";
            esperado.description = "";
            esperado.spaceShip = false;
            esperado.itemsInPlace = new Listas.Lista();
            esperado.connections = new int[4];
            for (int i = 0; i < 4; i++)
                esperado.connections[i] = -1;
            string[] frase = new string[4] { "place", "0", "Nombre0", "noSpaceShip" };
            Map m = new Map(1,1);
            //Act
            m.CreatePlace(frase);
            //Assert
            Assert.AreEqual(esperado.name, m.Sitio(0).name, "El nombre del sitio no es el esperado.");
            Assert.AreEqual(esperado.description, m.Sitio(0).description, "La descripcion del sitio no es la esperada.");
            Assert.AreEqual(esperado.spaceShip, m.Sitio(0).spaceShip, "La variable la nave no es la esperada.");
            Assert.AreEqual(esperado.itemsInPlace.Verlista(), m.Sitio(0).itemsInPlace.Verlista(), "La lista de objetos no es la misma.");
            Assert.AreEqual(esperado.connections[0], m.Sitio(0).connections[0], "La direccion Norte no es la esperada.");
            Assert.AreEqual(esperado.connections[1], m.Sitio(0).connections[1], "La direccion Este no es la esperada.");
            Assert.AreEqual(esperado.connections[2], m.Sitio(0).connections[2], "La direccion Sur no es la esperada.");
            Assert.AreEqual(esperado.connections[3], m.Sitio(0).connections[3], "La direccion Oeste no es la esperada.");
        }

        [TestMethod]
        public void TestCreatePlaceUnaCalleConUnaYaCreada()
        {
            //Arrange
            Map.Place esperado;
            esperado.name = "Nombre1";
            esperado.description = "";
            esperado.spaceShip = true;
            esperado.itemsInPlace = new Listas.Lista();
            esperado.connections = new int[4];
            for (int i = 0; i < 4; i++)
                esperado.connections[i] = -1;
            string[] frase = new string[4] { "place", "1", "Nombre1", "spaceShip" };
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            //Act
            m.CreatePlace(frase);
            //Assert
            Assert.AreEqual(esperado.name, m.Sitio(1).name, "El nombre del sitio no es el esperado.");
            Assert.AreEqual(esperado.description, m.Sitio(1).description, "La descripcion del sitio no es la esperada.");
            Assert.AreEqual(esperado.spaceShip, m.Sitio(1).spaceShip, "La variable la nave no es la esperada.");
            Assert.AreEqual(esperado.itemsInPlace.Verlista(), m.Sitio(1).itemsInPlace.Verlista(), "La lista de objetos no es la misma.");
            Assert.AreEqual(esperado.connections[0], m.Sitio(1).connections[0], "La direccion Norte no es la esperada.");
            Assert.AreEqual(esperado.connections[1], m.Sitio(1).connections[1], "La direccion Este no es la esperada.");
            Assert.AreEqual(esperado.connections[2], m.Sitio(1).connections[2], "La direccion Sur no es la esperada.");
            Assert.AreEqual(esperado.connections[3], m.Sitio(1).connections[3], "La direccion Oeste no es la esperada.");
        }

        [TestMethod]
        public void TestCreatePlaceConMenosParametros()
        {
            //Arrange
            string[] frase = new string[3] { "place", "0", "Nombre0" };
            Map m = new Map(1, 1);
            try
            {//Act
                m.CreatePlace(frase);
                //Assert
                Assert.Fail("No hay error al introducir menos parametros.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreatePlaceRepetida()
        {
            //Arrange
            string[] frase = new string[4] { "place", "0", "Nombre1", "spaceShip" };
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            try
            {//Act
                m.CreatePlace(frase);
                //Assert
                Assert.Fail("No hay error al repetir calle.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreatePlaceParametroSpaceShipMal()
        {
            //Arrange
            string[] frase = new string[4] { "place", "0", "Nombre1", "SpaceShip" };
            Map m = new Map(2, 1);
            try
            {//Act
                m.CreatePlace(frase);
                //Assert
                Assert.Fail("No hay error al escribir mal el parametro spacechip.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreatePlaceFueraDeRangoPorAbajo()
        {
            //Arrange
            string[] frase = new string[4] { "place", "-1", "Nombre1", "spaceShip" };
            Map m = new Map(2, 1);
            try
            {//Act
                m.CreatePlace(frase);
                //Assert
                Assert.Fail("No hay error al poner un valor menor que cero en el indice del lugar.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreatePlaceFueraDeRangoPorArriba()
        {
            //Arrange
            string[] frase = new string[4] { "place", "2", "Nombre1", "spaceShip" };
            Map m = new Map(2, 1);
            try
            {//Act
                m.CreatePlace(frase);
                //Assert
                Assert.Fail("No hay error al poner un valor mayor que el indice maximo del mapa.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetSimple()
        {
            //Arrange

            int[] dir1 = new int[4] { 1, -1, -1, -1 };
            int[] dir2 = new int[4] { -1, -1, 0, -1 };

            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });
            //Act
            m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "1" });
            //Assert
            Assert.AreEqual(m.Sitio(0).connections[0], dir1[0], "El Norte de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[1], dir1[1], "El Este de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[2], dir1[2], "El Sur de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[3], dir1[3], "El Oeste de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[0], dir2[0], "El Norte de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[1], dir2[1], "El Este de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[2], dir2[2], "El Sur de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[3], dir2[3], "El Oeste de la segunda direccion no es el esperado.");
        }

        [TestMethod]
        public void TestCreateStreetSobreescritura()
        {
            //Arrange
                        Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });
            m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "1" });
            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "2" });
                //Assert
                Assert.Fail("No ha habido error al sobreescribir una calle.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetSobreescrituraSinError()
        {
            //Arrange
            int[] dir1 = new int[4] { 1, -1, -1, -1 };
            int[] dir2 = new int[4] { -1, -1, 0, -1 };
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });
            //Act
            m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "1" });
            m.CreateStreet(new string[7] { "street", "0", "place", "1", "south", "place", "0" });
            //Assert
            Assert.AreEqual(m.Sitio(0).connections[0], dir1[0], "El Norte de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[1], dir1[1], "El Este de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[2], dir1[2], "El Sur de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(0).connections[3], dir1[3], "El Oeste de la primera direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[0], dir2[0], "El Norte de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[1], dir2[1], "El Este de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[2], dir2[2], "El Sur de la segunda direccion no es el esperado.");
            Assert.AreEqual(m.Sitio(1).connections[3], dir2[3], "El Oeste de la segunda direccion no es el esperado.");
        }

        [TestMethod]
        public void TestCreateStreetMenosArgumentos()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });
            
            try
            {//Act
                m.CreateStreet(new string[6] { "street", "0", "place", "0", "north", "place" });
                //Assert
                Assert.Fail("No ha habido error introducir menos argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetPrimerEnteroNoParseable()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "a", "north", "place", "1" });
                //Assert
                Assert.Fail("No ha habido error un entero no parseable en el primer lugar");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetSegundoEnteroNoParseable()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "b" });
                //Assert
                Assert.Fail("No ha habido error un entero no parseable en el segundo lugar");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetDireccionNoParseable()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "0", "norn", "place", "1" });
                //Assert
                Assert.Fail("No ha habido error un enetero no parseable en el primer lugar");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetPrimerEnteroFueraDeRango()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "-1", "north", "place", "1" });
                //Assert
                Assert.Fail("No ha habido error al tener el primer entero fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetSegundoEnteroFueraDeRango()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "place", "4" });
                //Assert
                Assert.Fail("No ha habido error al tener el segundo entero fuera de rango.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetPalabraClave1Incorrecta()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "placce", "0", "north", "place", "1" });
                //Assert
                Assert.Fail("No ha habido error al tener el primer place mal escrito.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateStreetPalabraClave2Incorrecta()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateStreet(new string[7] { "street", "0", "place", "0", "north", "plaaace", "1" });
                //Assert
                Assert.Fail("No ha habido error al tener el segundo place mal escrito.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) {}
        }

        [TestMethod]
        public void TestCreateItemEnBuenLugar()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });
            Map.Item esperado0;
            esperado0.name = "Objeto0";
            esperado0.description = "Descripcion0";
            //Act
            m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "place", "0", "\"Descripcion0\""});
            //Assert
            Assert.AreEqual(esperado0, m.Objeto(0), "Valor del objeto no esperado.");
            Assert.AreEqual("0: Objeto0 Descripcion0", m.GetItemsPlace(0), "El objeto no esta en el sitio.");
            Assert.AreEqual("", m.GetItemsPlace(1), "El objeto esta en un sitio que no debería.");
        }

        [TestMethod]
        public void TestCreateItemPalabraClaveIncorrecta()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "placcce", "0", "\"Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al tener el place mal escrito.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemIndiceFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "5", "Objeto0", "place", "0", "\"Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al tener pedir poner un objeto fuera de rango por arriba.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemIndiceFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "-1", "Objeto0", "place", "0", "\"Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al tener pedir poner un objeto fuera de rango por abajo.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemIndiceLugarFueraDeRangoPorArriba()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "place", "3", "\"Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al tener pedir poner el objeto en un lugar fuera de rango por arriba.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemIndiceLugarFueraDeRangoPorAbajo()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "place", "-1", "\"Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al tener pedir poner el objeto en un lugar fuera de rango por abajo.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemSinComillaInicial()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "place", "0", "Descripcion0\"" });
                //Assert
                Assert.Fail("No ha habido error al introducir una descripcion la primera comilla.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestCreateItemSinComillaFinal()
        {
            //Arrange
            Map m = new Map(2, 1);
            m.CreatePlace(new string[4] { "place", "0", "Nombre0", "noSpaceShip" });
            m.CreatePlace(new string[4] { "place", "1", "Nombre1", "spaceShip" });

            try
            {//Act
                m.CreateItem(new string[6] { "garbage", "0", "Objeto0", "place", "0", "\"Descripcion0" });
                //Assert
                Assert.Fail("No ha habido error al introducir una descripcion la segunda comilla.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }
    }
}
