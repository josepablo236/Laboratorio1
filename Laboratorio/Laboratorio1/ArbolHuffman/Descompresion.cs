using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Laboratorio1.ArbolHuffman;

namespace Laboratorio1.Controllers
{
    public class Descompresion
    {
        public void LeerArchivo(string textname, string filepath)
        {
            //Guardaremos la letra y cuantas veces se repite
            string[] texto;
            string textocompleto;
            Dictionary<string, int> Diccionario = new Dictionary<string, int>();
            const int bufferLength = 1000;
            string FileP = filepath;
            List<string> Text_archivo = new List<string>();
            var path = Path.Combine(FileP, textname);
            var result = new Dictionary<string, string>();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        textocompleto = reader.ReadString();
                    }
            }

        }
    }
}