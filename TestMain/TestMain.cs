using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallE;
using Practica4;
using System.IO;

namespace TestMain
{
    [TestClass]
    public class TestMain
    {
        [TestMethod]
        public void TestProcesaInputMovePosible()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            int posEsperada = 3;
            string a = "";
            string comando = "go east";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);

                //Assert
                Assert.AreEqual(posEsperada, wallE.GetPosition(), "Ha ido a una posicion inesperada.");
                Assert.AreEqual(comando + "\n", a, "No se ha guardado correctamente el historial");
                Assert.AreEqual("Nombre3\nDescripcion3\n\nNorth: Nombre3\nEast: Nombre0\n\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputMoveImposible()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("go east", wallE, m, ref a);
                //Assert
                Assert.Fail("No ha producido un fallo al ir a un lugar incorrecto.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
            
        }

        [TestMethod]
        public void TestProcesaInputMoveMenosArgumentos()
        {
            //Arrange
            Map m = new Map(6, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("go ", wallE, m, ref a);
                //Assert
                Assert.Fail("No ha producido un fallo al introducir menos argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputMoveMasArgumentos()
        {
            //Arrange
            Map m = new Map(1, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("go north a", wallE, m, ref a);
                //Assert
                Assert.Fail("No ha producido un fallo al introducir mas argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputMoveErrata()
        {
            //Arrange
            Map m = new Map(1, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("go nor", wallE, m, ref a);
                //Assert
                Assert.Fail("No ha producido un fallo al introcudir mal la direccion");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputPickPosible()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(6);
            string esperado = "5: Nombre5 Descripcion5";
            string a = "";
            string comando = "Pick 5";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(esperado, wallE.Bag(m), "Ha recogido el objeto incorrecto.");
                Assert.AreEqual(comando + "\n", a, "No se ha guardado correctamente el historial");
                Assert.AreEqual("\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputPickImposible()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(7);
            string esperado = "5: Nombre5 Descripcion5";
            string a = "";
            try
            {//Act
                Program.ProcesaInput("Pick 5", wallE, m, ref a);
                //Assert
                Assert.Fail("Ha podido recoger el item.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputPickMenosArgumentos()
        {
            //Arrange
            Map m = new Map(6, 2, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("pick", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir mal el comando pick");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }
        
        [TestMethod]
        public void TestProcesaInputPickMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 0, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("pick 5 300", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir mal el comando pick");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputPickArgumentoChar()
        {
            //Arrange
            Map m = new Map(4, 0, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("pick a", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir mal el comando pick");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputDropPosible()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(6);
            string esperado = "";
            string a = "";
            string comando1 = "Pick 5", comando2 = "Drop 5";
            Program.ProcesaInput(comando1, wallE, m, ref a);
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando2, wallE, m, ref a);
                //Assert
                Assert.AreEqual(esperado, wallE.Bag(m), "Ha recogido el objeto incorrecto.");
                Assert.AreEqual(comando1 + "\n" + comando2 + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputDropImposible()
        {
            //Arrange
            Map m = new Map(4, 0, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("drop 0", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al depositar un objeto que no se tiene.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputDropMenosArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            Program.ProcesaInput("pick 0", wallE, m, ref a);
            try
            {
                //Act
                Program.ProcesaInput("drop              ", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando drop con menos argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputDropMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            Program.ProcesaInput("pick 0", wallE, m, ref a);
            try
            {
                //Act
                Program.ProcesaInput("drop  4 4", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando drop con menos argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputItemsBienLleno()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            string a = "";
            string comando = "items";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("0: Nombre0 Descripcion0\n1: Nombre1 Descripcion1\n\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputItemsBienVacio()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            string a = "";
            string comando = "items";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("There is no items in this place.\n\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputItemsMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("items items", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando items con mas argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputInfoBien()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            string a = "";
            string comando = "info";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("Nombre2\nDescripcion2\n\nEast: Nombre3\n\n", texto.ToString().Replace("\r",""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputInfoMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("info inf", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando items con mas argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputBagBienVacia()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            string a = "";
            string comando = "Bag";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("Your bag is empty.\n\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputBagBienLlena()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            string a = "";
            string comando = "Bag";
            Program.ProcesaInput("Pick 0", wallE, m, ref a);
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual("Pick 0\n"+comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("0: Nombre0 Descripcion0\n\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputBagMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("Bag b", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando items con mas argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputQuitBien()
        {
            //Arrange
            Map m = new Map(30, 6, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(2);
            string a = "";
            string comando = "Quit";
            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.ProcesaInput(comando, wallE, m, ref a);
                //Assert
                Assert.AreEqual(comando + "\n", a, "El historial no se ha guardado bien.");
                Assert.AreEqual("\n", texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }

        [TestMethod]
        public void TestProcesaInputQuitMasArgumentos()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("Quit b", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir el comando bag con mas argumentos.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestProcesaInputStringAleatorio()
        {
            //Arrange
            Map m = new Map(4, 1, 0);
            WallE.WallE wallE = new WallE.WallE();
            wallE.ForcePosition(1);
            string a = "";
            try
            {
                //Act
                Program.ProcesaInput("dagshdk", wallE, m, ref a);
                //Assert
                Assert.Fail("No se ha producido un fallo al introducir caracteres aleatorios.");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void TestEjecucionMapa()
        {
            //Arrange
            Map m = new Map(10, 3);
            m.ReadMap("madrid.map");
            WallE.WallE wallE = new WallE.WallE();
            string a = "";
            string comandos = "info\nbag\npick 3\ndrop 0\ncodo\nitems\npick 0\npick 1\ngo west\ngo west\ngo north\nitems\ngo north\ngo east\ninfo\ngo south\ngo south\ngo south\ngo east\ngo east\ngo south\ngo north\ngo north\ngo north\ngo north\ngo south\ngo east";
            string textoConsola = "Sol\nYou are at the PUERTA DEL SOL, the center of Madrid\nUfff, there are a lot of streets, but all of them are full of garbage.\nYou should walk around this place to look for some interesting\nobjects to pick up.\nNote that there is a big clock. Remember, leave the square before \nnight. It can be dangerous\n\nNorth: PlazaDeCallao\nEast: Cibeles\nSouth: PlazaDeJacintoBenavente\nWest: PlazaMayor\n\n>info\nSol\nYou are at the PUERTA DEL SOL, the center of Madrid\nUfff, there are a lot of streets, but all of them are full of garbage.\nYou should walk around this place to look for some interesting\nobjects to pick up.\nNote that there is a big clock. Remember, leave the square before \nnight. It can be dangerous\n\nNorth: PlazaDeCallao\nEast: Cibeles\nSouth: PlazaDeJacintoBenavente\nWest: PlazaMayor\n\n>bag\nYour bag is empty.\n\n>pick 3\nYou can't pick that item.\n\n>drop 0\nYou don't carry it.\n\n>codo\nInvalid command.\n\n>items\n0: Newspapers1 News\n1: Newspapers2 More News\n\n>pick 0\n\n>pick 1\n\n>go west\nPlazaMayor\nMmmh... it smells squid fried in butter. You should try to eat something\n\nNorth: PlazaEspaña\nEast: Sol\n\n>go west\nYou can't move in that direction.\n\n>go north\nPlazaEspaña\nWhat a big square! You have a big park where you can sleep under a tree.\nBut you have a problem, you have to come back to PLAZA MAYOR. \nThere is no other exit\n\nEast: PlazaDeCallao\nSouth: PlazaMayor\n\n>items\n2: Newspapers3 News on sport\n\n>go north\nYou can't move in that direction.\n\n>go east\nPlazaDeCallao\nIn this small square you can find some some fuel. \nGo to fnac and take the fuel for the heating\n\nSouth: Sol\nWest: PlazaEspaña\n\n>info\nPlazaDeCallao\nIn this small square you can find some some fuel. \nGo to fnac and take the fuel for the heating\n\nSouth: Sol\nWest: PlazaEspaña\n\n>go south\nSol\nYou are at the PUERTA DEL SOL, the center of Madrid\nUfff, there are a lot of streets, but all of them are full of garbage.\nYou should walk around this place to look for some interesting\nobjects to pick up.\nNote that there is a big clock. Remember, leave the square before \nnight. It can be dangerous\n\nNorth: PlazaDeCallao\nEast: Cibeles\nSouth: PlazaDeJacintoBenavente\nWest: PlazaMayor\n\n>go south\nPlazaDeJacintoBenavente\nIf you are cold you can start a fire with the wheels of those old buses\n\nNorth: Sol\nEast: Neptuno\n\n>go south\nYou can't move in that direction.\n\n>go east\nNeptuno\nWatch Wall-e! Another fountain! Perhaps this one has water for drinking\nIf you are cold, use that red and white scarf\n\nNorth: Cibeles\nSouth: Atocha\nWest: PlazaDeJacintoBenavente\n\n>go east\nYou can't move in that direction.\n\n>go south\nAtocha\nYou have a lot of old trains here, but they do not work\nAll trains were destroyed during the crisis of 2013\nTake all the iron you find\n\nNorth: Neptuno\n\n>go north\nNeptuno\nWatch Wall-e! Another fountain! Perhaps this one has water for drinking\nIf you are cold, use that red and white scarf\n\nNorth: Cibeles\nSouth: Atocha\nWest: PlazaDeJacintoBenavente\n\n>go north\nCibeles\nArggg, the fountain is ugly! The water is very dirty. \nYou should leave before the lions attack you\n\nNorth: PlazaDeColon\nEast: PuertaDeAlcala\nSouth: Neptuno\nWest: Sol\n\n>go north\nPlazaDeColon\nSometime ago, Spanish people concentrates here to watch football \nin a big screen.\nWall-e, did you know that in Spain there were very good football teams?.\nLook for cans! People throw cans after watching football!\n\nSouth: Cibeles\n\n>go north\nYou can't move in that direction.\n\n>go south\nCibeles\nArggg, the fountain is ugly! The water is very dirty. \nYou should leave before the lions attack you\n\nNorth: PlazaDeColon\nEast: PuertaDeAlcala\nSouth: Neptuno\nWest: Sol\n\n>go east\nPuertaDeAlcala\nOk, finally you have found your spaceship....\n\nWest: Cibeles\n\n";
            StreamWriter usuario = new StreamWriter("usuario.user");
            usuario.Write(comandos);
            usuario.Close();

            using (StringWriter texto = new StringWriter())
            {
                //Act
                Console.SetOut(texto);
                Program.LeerHistorial("usuario", wallE, m);
                //Assert
                Assert.AreEqual(textoConsola, texto.ToString().Replace("\r", ""), "El texto escrito en consola no es correcto");
            }
        }
    }
}
