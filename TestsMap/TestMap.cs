using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallE;

namespace TestsMap
{
    [TestClass]
    public class TestMap
    {
        [TestMethod]
        public void TestGetMoves1()
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
        public void TestGetMoves2()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "North: Nombre0\nEast: Nombre0\nSouth: Nombre0\nWest: Nombre0";
            //Act
            string final = m.GetMoves(15);
            //Assert
            Assert.AreEqual(esperado, final, "No ha escrito bien las Direcciones");
        }

        [TestMethod]
        public void TestGetMoves3()
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
            catch
            {

            }
        }

        [TestMethod]
        public void TestGetMoves4()
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
            catch
            {

            }
        }

        [TestMethod]
        public void TestGetNumItems1()
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
        public void TestGetNumItems2()
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
            catch
            {

            }
        }

        [TestMethod]
        public void TestGetNumItems3()
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
            catch
            {

            }
        }

        [TestMethod]
        public void TestGetItemInfo1()
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
        public void TestGetItemInfo2()
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
            catch { }

        }

        [TestMethod]
        public void TestGetItemInfo3()
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
            catch { }
        }

        [TestMethod]
        public void TestGetItemsPlace1()
        {
            //Arrange
            Map m = new Map(16, 1, 0);
            string esperado = "0: Nombre0 Descripcion0\n";
            //Act
            string final = m.GetItemsPlace(0);
            //Assert
            Assert.AreEqual(esperado, final, "Información no válida.");
        }

    }
}
