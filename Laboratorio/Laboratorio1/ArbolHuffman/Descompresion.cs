using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string TextoCodificado;
            string textocompleto3;
            byte[] bytes;
          Dictionary<string, string> Diccionario = new Dictionary<string, string>();
            string FileP = filepath;
            List<string> Text_archivo = new List<string>();
            var path = Path.Combine(FileP, textname);
            var result = new Dictionary<string, string>();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader Str = new StreamReader(stream))
                {
                    textocompleto = Str.ReadLine();
                    Str.Close();
                }
            }
            int bufferLength = textocompleto.Length-1;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                List<string> Textarchivo = new List<string>();
                using (var reader = new BinaryReader(stream))
                {
                    var byteBuffer = new byte[bufferLength];
                    
                        byteBuffer = reader.ReadBytes(bufferLength);
                
                    foreach (var item in byteBuffer)
                    {

                        Text_archivo.Add(Convert.ToString(item));
                    }
                }

                /* TextoCodificado = 
                 string[]  palabras  =  textocompleto.Split(' ');
                 string codificado = palabras[0];
                 textocompleto = textocompleto.Substring(codificado.Length);
                 char[] delimiters = new char[] {'[',']', ',', ' '};
                 string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);*/
            }
        }
    }
}