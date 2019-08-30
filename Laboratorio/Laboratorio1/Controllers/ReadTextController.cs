using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text; //Este permite utilizar Encoding

namespace Laboratorio1.Controllers
{
    public class ReadTextController : Controller
    {
        // GET: ReadText
        public ActionResult Index()
        {
            return View();
        }

        int i = 0;
        int[] letras;
        //Recibo los datos de FileUploadController

        public void Read(string filename)
        {
            int[] letras_contador = new int[100];
            string path = Path.Combine(Server.MapPath("~/Archivos"), filename);
            System.IO.StreamReader Leer = new System.IO.StreamReader(path);
            string lector = "a";

            //Leo todo el archivo de texto
            while (!Leer.EndOfStream)
            {
                lector = Leer.ReadToEnd();
            }
            //Tomo cada caracter de todo el texto
            int contador_letras = 0;

            foreach (char letra in lector)
            {
                CheckIfStringContain(letra);
            }
            bool CheckIfStringContain(char myChar)
            {
                bool myBool = false;
                char[] a = lector.ToCharArray();
                for (int i = 0; i < lector.Length - 1; i++)
                {
                    if (a[i] == myChar)
                    {
                        myBool = true;
                        break;
                    }
                    else { contador_letras++; }
                }
                return myBool;
            }
            char[] letras = new char[100];
            letras[0] = Convert.ToChar(lector.FirstOrDefault());
            foreach (char word in lector)
            {
                if (letras[0] == null)
                {
                    letras[0] = word;
                }
                else
                {

                }

                int i = 0;
                if (word == letras[i])
                {
                    //letras_contador[i]++;r
                }
                else
                {
                    while (i != letras.Length)
                    {
                        if (word == letras[i])
                        {
                            letras_contador[i]++;
                        }
                        else
                        {
                            letras[i] = word;
                        }
                        i++;
                    }
                }
            }
            //array.length = total
            //PROBABILIDAD
            /*for (int i =0; i<total; i++)
            {
                array[i]/total;
            }
            Convertir a pila
            .Sort();
            Para sacar los 2 menores hacemos .pop()

            0.111.Pop
            0.05.pop
            -
            -
            -
            -
            -

            Luego hariamos un push con la suma de los 2 a los que le hicimos pop
            Luego hacer .Sort a la pila para volverlo a ordenar
            Hacerlo recursivo hasta que termine de leer todos los caracteres.

            iz 0, derecha 1
            Raiz sin codigo
            1. visito nodo derecha, este es igual a 1
                Recursivo que se vaya a derecha hasta que no tenga derecha le concatene un un 1 al codigo.
                Y que agregue el char y el nuevo codigo al diccionario
            2. Visito iz 
            Recorrido preorden iz 0
            Dictionary diccionario = new Dictionary

            Cada nodo tiene en su lista el codigo que anteriormente sacamos
            
            Crear diccionario con codigo y letra //Ya no usaria la lista en el nodo
            Remplazar cada char por su codigo
            foreach(char word in texto)
            {
                if (diccionario.Compare(x => x.char == word)

            }
            Escribir todo el texto en codigo del arbol
            Escibir en el archivo el diccionario 
            Agrupar en grupos de 8 chars
            Se convierte a decimal y luego a Ascii (caracter normal)


            */
            /*
            byte[] bytes = Encoding.ASCII.GetBytes(lector);
            int result = BitConverter.ToInt32(bytes, 0);
            letras = new int[bytes.Length]; //Esta matriz va a guardar cuantas veces se repite
            string[] letras_binary = new string[127]; //Esta matriz va a guardar la letra en binario
            int cantidad_letras = lector.Length; //Para saber cuantas letras y espacios hay
            //Esto puede servir para las probabilidades
            foreach (int word in lector)
            {

                while (word != bytes[i])
                {

                    letras[i]++;
                    i ++;
                }


            }*/
        }
        //Función recursiva para comparar cuantas veces se repite, pienso que podria estar mejor, pero por el momento va a servir jaja
        /*
                public void Contar_repeticiones(int letra, byte[] bites)
                {
                    if (letra == bites[i])
                    {
                        letras[i]++;
                    }
                    else
                    {
                        Contar_repeticiones(letra, bites);
                        i++; 
                    }
                }
                */


    }
}