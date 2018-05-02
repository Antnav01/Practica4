using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Listas;

namespace Tests
{
    [TestClass]
    public class TestLista
    {
        [TestMethod]
        public void TestCrearLista1()
        {
            //arrange
            string a = "1:2:3:1:2:3:1:2:3";
            //act
            Listas.Lista lis = new Listas.Lista(3, 3);
            string b = lis.Verlista();
            //assert
            Assert.AreEqual(a, b, "Las lista esperada no está bien escrita.");

        }

        [TestMethod]
        public void TestCrearLista2()
        {
            //arrange
            string a = "";
            //act
            Listas.Lista lis = new Listas.Lista(0, 0);
            string b = lis.Verlista();
            //assert
            Assert.AreEqual(a, b, "Las lista esperada no está bien escrita.");
        }

        [TestMethod]
        public void TestCuentaEltos1()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(0, 0);
            int n;
            //act
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(0, n, "La lista vacía dice no tener cero elementos.");
        }

        [TestMethod]
        public void TestCuentaEltos2()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(1, 1);
            int n;
            //act
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(1, n, "La lista de un elemento dice no tener un solo elemento.");
        }

        [TestMethod]
        public void TestCuentaEltos3()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            //act
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(9, n, "La lista de 9 elementos dice no tener 9 elementos.");
        }

        [TestMethod]
        public void TestInsertaFin1()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista();
            int n;
            //act
            lis.IntroducirElementoFinal(0);
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(1, n, "No hay un elemento en la lista.");
            Assert.AreEqual("0", lis.Verlista(), "La lista tiene un elemento distinto al esperado.");
        }

        [TestMethod]
        public void TestInsertaFin2()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(1,1);
            int n;
            //act
            lis.IntroducirElementoFinal(0);
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(2, n, "No hay dos elementos en la lista.");
            Assert.AreEqual("1:0", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }

        [TestMethod]
        public void TestInsertaFin3()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            //act
            lis.IntroducirElementoFinal(0);
            n = lis.CuentaEltos();
            //assert
            Assert.AreEqual(10, n, "No hay diez elementos en la lista.");
            Assert.AreEqual("1:2:3:1:2:3:1:2:3:0", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }

        [TestMethod]
        public void TestBorraElto1()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            bool b;
            //act
            b = lis.borraElto(1);
            n = lis.CuentaEltos();
            //assert
            Assert.IsTrue(b,"El metodo dice que no borra.");
            Assert.AreEqual(8, n, "No hay ocho elementos en la lista.");
            Assert.AreEqual("2:3:1:2:3:1:2:3", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }

        [TestMethod]
        public void TestBorraElto2()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            bool b;
            //act
            b = lis.borraElto(0);
            n = lis.CuentaEltos();
            //assert
            Assert.IsFalse(b, "El metodo dice que borra.");
            Assert.AreEqual(9, n, "No hay ocho elementos en la lista.");
            Assert.AreEqual("1:2:3:1:2:3:1:2:3", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }

        [TestMethod]
        public void TestBorraElto3()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(0, 0);
            int n;
            bool b;
            //act
            b = lis.borraElto(1);
            n = lis.CuentaEltos();
            //assert
            Assert.IsFalse(b, "El metodo dice que borra.");
            Assert.AreEqual(0, n, "No hay cero elementos en la lista.");
            Assert.AreEqual("", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }
        [TestMethod]
        public void TestBorraElto4()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 1);
            int n;
            bool b;
            //act
            b = lis.borraElto(3);
            n = lis.CuentaEltos();
            //assert
            Assert.IsTrue(b, "El metodo dice que no borra.");
            Assert.AreEqual(2, n, "No hay ocho elementos en la lista.");
            Assert.AreEqual("1:2", lis.Verlista(), "La lista tiene elementos distintos a los esperados.");
        }

        [TestMethod]
        public void TestnEsimo1()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            //act
            n = lis.NEsimo(0);
            //assert
            Assert.AreEqual(1, n, "El elemento no es el esperado");
        }

        [TestMethod]
        public void TestnEsimo2()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            //act
            n = lis.NEsimo(2);
            //assert
            Assert.AreEqual(3, n, "El elemento no es el esperado");
        }

        [TestMethod]
        public void TestnEsimo3()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3, 3);
            int n;
            //act
            try
            {
                n = lis.NEsimo(-1);
                //assert
                Assert.Fail("No se ha producido el error.");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void TestnEsimo4()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(0, 0);
            int n;
            //act
            try
            {
                n = lis.NEsimo(0);
                //assert
                Assert.Fail("No se ha producido el error.");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void TestnEsimo5()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(0, 0);
            int n;
            //act
            try
            {
                n = lis.NEsimo(-1);
                //assert
                Assert.Fail("No se ha producido el error.");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void TestnEsimo6()
        {
            //arrange
            Listas.Lista lis = new Listas.Lista(3,1);
            int n;
            //act
            n = lis.NEsimo(2);
            //assert
            Assert.AreEqual(3, n, "El elemento no es el esperado");
        }
    }
}
