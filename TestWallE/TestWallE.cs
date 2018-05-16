using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallE;

namespace TestWallE
{
    [TestClass]
    public class TestWallE
    {
        [TestMethod]
        public void TestMoveMovimientoImposibleNorte()
        {
            //Arrange
            Map m = new Map(2, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            try
            {
                wallE.Move(m, Direction.North);
                //Assert
                Assert.Fail("El movimiento hacia el norte ha sido imposible.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMoveMovimientoImposibleEste()
        {
            //Arrange
            Map m = new Map(4, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            //Act
            try
            {
                wallE.Move(m, Direction.East);
                //Assert
                Assert.Fail("El movimiento hacia el este ha sido imposible.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMoveMovimientoImposibleSur()
        {
            //Arrange
            Map m = new Map(10, 5, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            //Act
            try
            {
                wallE.Move(m, Direction.South);
                //Assert
                Assert.Fail("El movimiento hacia el sur ha sido imposible.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMoveMovimientoImposibleOeste()
        {
            //Arrange
            Map m = new Map(16, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(3);
            //Act
            try
            {
                wallE.Move(m, Direction.West);
                //Assert
                Assert.Fail("El movimiento hacia el oeste ha sido imposible.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestMoveMovimientoPosibleNorte()
        {
            //Arrange
            Map m = new Map(2, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            int posEsperada = 1;
            //Act
            wallE.Move(m, Direction.North);
            //Assert
            Assert.AreEqual(posEsperada, wallE.GetPosition(), "La posicion yendo al norte no es la esperada.");
        }

        [TestMethod]
        public void TestMoveMovimientoPosibleEste()
        {
            //Arrange
            Map m = new Map(4, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            int posEsperada = 3;
            //Act
            wallE.Move(m, Direction.East);
            //Assert
            Assert.AreEqual(posEsperada, wallE.GetPosition(), "La posicion yendo al este no es la esperada.");
        }

        [TestMethod]
        public void TestMoveMovimientoPosibleSur()
        {
            //Arrange
            Map m = new Map(11, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(4);
            int posEsperada = 6;
            //Act
            wallE.Move(m, Direction.South);
            //Assert
            Assert.AreEqual(posEsperada, wallE.GetPosition(), "La posicion yendo al sur no es la esperada.");
        }

        [TestMethod]
        public void TestMoveMovimientoPosibleOeste()
        {
            //Arrange
            Map m = new Map(9, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(8);
            int posEsperada = 2;
            //Act
            wallE.Move(m, Direction.West);
            //Assert
            Assert.AreEqual(posEsperada, wallE.GetPosition(), "La posicion yendo al oeste no es la esperada.");
        }

        [TestMethod]
        public void TestPickItemInexistenteEnSitio()
        {
            //Arrange
            Map m = new Map(2, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            try
            {
                wallE.PickItem(m, 0);
                //Assert
                Assert.Fail("Ha recogido un objeto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestPickItemInexistente()
        {
            //Arrange
            Map m = new Map(10, 9, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(5);
            //Act
            try
            {
                wallE.PickItem(m, 11);
                //Assert
                Assert.Fail("Ha recogido un objeto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestPickItemExistenteEnSitio()
        {
            //Arrange
            Map m = new Map(12, 15, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(5);
            string esperado = "3";
            //Act
            wallE.PickItem(m, 3);
            //Assert
            Assert.AreEqual(esperado, wallE.ForceBag().Verlista(), "El item no es el esperado");
        }

        [TestMethod]
        public void TestPickItemLugarInexistente()
        {
            //Arrange
            Map m = new Map(4, 9, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(15);
            //Act
            try
            {
                wallE.PickItem(m, 1);
                //Assert
                Assert.Fail("Ha recogido un objeto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestDropItemInexistente()
        {
            //Arrange
            Map m = new Map(2, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            try
            {
                wallE.DropItem(m, 0);
                //Assert
                Assert.Fail("Ha depositado un objeto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestDropItemExistenteEnSitio()
        {
            //Arrange
            Map m = new Map(4, 3, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForceBag().IntroducirElementoInicio(0);
            wallE.ForceBag().IntroducirElementoInicio(1);
            string esperado = "1";
            //Act
            wallE.DropItem(m, 0);
            //Assert
            Assert.AreEqual(esperado, wallE.ForceBag().Verlista(), "La mochila no contiene lo que se esperaba");
        }

        [TestMethod]
        public void TestDropItemLugarInexistente()
        {
            //Arrange
            Map m = new Map(6, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            try
            {
                wallE.DropItem(m, -1);
                //Assert
                Assert.Fail("Ha depositado un objeto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestBagVacia()
        {
            //Arrange
            Map m = new Map(4, 3, 0);
            WallE.WallE wallE = new WallE.WallE();
            string esperado = "";
            //Act
            string final = wallE.Bag(m);
            //Assert
            Assert.AreEqual(esperado, final, "La mochila contiene algo.");
        }

        [TestMethod]
        public void TestBagConUnObjeto()
        {
            //Arrange
            Map m = new Map(10, 9, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(5);
            wallE.PickItem(m, 0);
            string esperado = "0: Nombre0 Descripcion0";
            //Act
            string final = wallE.Bag(m);
            //Assert
            Assert.AreEqual(esperado, final, "La mochila no contiene lo esperado.");
        }

        [TestMethod]
        public void TestBagConVariosObjetos()
        {
            //Arrange
            Map m = new Map(8, 7, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(6);
            wallE.PickItem(m, 3);
            wallE.PickItem(m, 4);
            wallE.PickItem(m, 5);
            string esperado = "5: Nombre5 Descripcion5\n4: Nombre4 Descripcion4\n3: Nombre3 Descripcion3";
            //Act
            string final = wallE.Bag(m);
            //Assert
            Assert.AreEqual(esperado, final, "La mochila no contiene lo esperado.");
        }

        [TestMethod]
        public void TestatSpaceShipHay()
        {
            //Arrange
            Map m = new Map(8, 7, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(0);
            //Act
            bool final = wallE.atSpaceShip(m);
            //Assert
            Assert.IsTrue(final, "No esta en un sitio con nave espacial.");
        }

        [TestMethod]
        public void TestatSpaceShipNoHay()
        {
            //Arrange
            Map m = new Map(10, 3, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            //Act
            bool final = wallE.atSpaceShip(m);
            //Assert
            Assert.IsFalse(final, "Esta en un sitio con nave espacial.");
        }

        [TestMethod]
        public void TestatSpaceShipLugarInexistente()
        {
            //Arrange
            Map m = new Map(4, 0, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(6);
            //Act
            try
            {
                wallE.atSpaceShip(m);
                //Assert
                Assert.Fail("No ha dado error al pedir un sitio inexistente.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }
    }
}
