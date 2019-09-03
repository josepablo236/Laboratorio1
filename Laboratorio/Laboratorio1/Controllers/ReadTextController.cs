using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text; //Este permite utilizar Encoding
using Laboratorio1.ArbolHuffman;

namespace Laboratorio1.Controllers
{
    public class ReadTextController : Controller
    {
        List<NodoHuffman> listadeNodos = new List<NodoHuffman>();

        // GET: ReadText
        public ActionResult Index()
        {
            return View();
        }

        int i = 0;
        int[] letras;
        //Guardaremos la letra y cuantas veces se repite
        public Dictionary<char, int> Diccionario_Caracteres = new Dictionary<char, int>();
        //Recibo los datos de FileUploadController

        public void Read(string filename)
        {
            int[] letras_contador = new int[100];
            string path = Path.Combine(Server.MapPath("~/Archivo"), filename);
            System.IO.StreamReader Leer = new System.IO.StreamReader(path);
            string Text_archivo = "a";
            //Leo todo el archivo de texto
            while (!Leer.EndOfStream)
            {
                Text_archivo = Leer.ReadToEnd();
            }

            //  En el diccionario cuenta cuantas veces se repite cada caracter (char, cantidad de repeticiones)
            foreach (char letra in Text_archivo)
            {
                if (Diccionario_Caracteres.ContainsKey(letra) == true)
                {
                    Diccionario_Caracteres[letra] += 1;
                }
                else
                {
                    Diccionario_Caracteres.Add(letra, 1);
                }
            }

            ArbolHuff arbol = new ArbolHuff();
            //Manda a llamar el metodo del arbol en el que agrega a una lista de nodos, los distintos caracteres que existen
            arbol.agregarNodos(Diccionario_Caracteres, Text_archivo, listadeNodos);
         
         }
        
        }
    }
