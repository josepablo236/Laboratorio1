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

        public ViewResult Read(string filename)
        {
            List<string> Text_archivo = new List<string>();
            var path = Path.Combine(Server.MapPath("~/Archivo"), filename);
            var FilePath = Server.MapPath("~/Archivo");
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
            arbol.agregarNodos(Diccionario_Caracteres, Text_archivo, listadeNodos, FilePath);
            var items = FilesUploaded();
            return View(items);
        }
        private List<string> FilesUploaded()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Archivo"));
            //Unicamente tome los archivos de text, ahorita lo puse como doc para probar pero al final lo podriamos dejar como .txt
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.huff");
            //Creo una lista con los nombres de todos los archivos para luego poder mostrarlos
            List<string> filesupld = new List<string>();
            foreach (var file in fileNames)
            {
                filesupld.Add(file.Name);
            }
            //Devuelvo la lista
            return filesupld;
        }
        // Este lo vamos a usar luego que ya podamos descomprimir jajaja
        public FileResult Download(string TxtName)
        {
            var FileVirtualPath = "Archivo/" + TxtName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

    }
}
