using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Laboratorio1.ArbolHuffman;
using Newtonsoft.Json;

namespace Laboratorio1.Controllers
{
    public class Descompresion
    {
        public void LeerArchivo(string textname, string filepath)
        {
            //Guardaremos la letra y cuantas veces se repite
            string[] texto;
            string textocompleto;
            Dictionary<string, string> Diccionario = new Dictionary<string, string>();
            string FileP = filepath;
            List<string> Text_archivo = new List<string>();
            var path = Path.Combine(FileP, textname);
            var result = new Dictionary<string, string>();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        textocompleto = reader.ReadToEnd();
                    }
            }
            string[]  palabras  =  textocompleto.Split(' ');
            string codificado = palabras[0];
            textocompleto = textocompleto.Substring(codificado.Length);
            char[] delimiters = new char[] {'[',']', ',', ' '};
            string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textocompleto.Length-2; i+=2)
            {
                Diccionario.Add(parts[i], parts[i + 1]);
            }

        }
    }
}