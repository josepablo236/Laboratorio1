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
        const int bufferLength = 1000;

        // GET: ReadText
        public ActionResult Index()
        {
            return View();
        }

        //Guardaremos la letra y cuantas veces se repite
        public Dictionary<string, int> Diccionario_Caracteres = new Dictionary<string, int>();
        //Recibo los datos de FileUploadController

        public void Read(string filename)
        {
            List<string> Text_archivo = new List<string>();
            var path = Path.Combine(Server.MapPath("~/Archivo"), filename);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream))
                {
                    var byteBuffer = new byte[bufferLength];
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        byteBuffer = reader.ReadBytes(bufferLength);
                    }
                    foreach (var item in byteBuffer)
                    {
                        if (Diccionario_Caracteres.ContainsKey(Convert.ToString(item)) == true)
                        {
                            Diccionario_Caracteres[Convert.ToString(item)] += 1;
                        }
                        else
                        {
                            Diccionario_Caracteres.Add(Convert.ToString(item), 1);
                        }
                        Text_archivo.Add(Convert.ToString(item));
                    }
                }
            }
            ArbolHuff arbol = new ArbolHuff();
            //Manda a llamar el metodo del arbol en el que agrega a una lista de nodos, los distintos caracteres que existen
            arbol.agregarNodos(Diccionario_Caracteres, Text_archivo, listadeNodos);
         
         }
        
        }
    }
