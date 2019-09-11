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
            string[]  palabras = textocompleto.Split(' ');
            string codificado = palabras[0];
            textocompleto = textocompleto.Substring(codificado.Length);
            string[] delimiters = new string[] { "[ ", "]", ", ", "|" };
            string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            /* char[] delimiters = new char[] { '[', ']', ',', ' ' };
             string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

             */
             for (int i = 0; i < parts.Length-1; i += 2)
             {
                 Diccionario.Add(parts[i], parts[i + 1].Remove(0,1));
             }
           
            int bufferLength = textocompleto.Length - 1;
            var byteBuffer = new byte[bufferLength];
            using (var stream = new FileStream(path, FileMode.Open))
            {

                List<string> Textarchivo = new List<string>();
                using (var reader = new BinaryReader(stream))
                {

                  
                    byteBuffer = reader.ReadBytes(bufferLength);

                    foreach (var item in byteBuffer)
                    {
                        if (item.ToString() == "124")
                        {
                            break;
                        }
                        Text_archivo.Add(Convert.ToString(item));
                    }
                }
            }
            string Text_Binario="";
            //Obtengo el texto en binario
            foreach (var item in Text_archivo)
            {
                Text_Binario += DecimalToBinary(item);
            }
            int inicial = 0;
            string Text_Descomprimido = "";
            for (int i = 1; i < Text_Binario.Length; i++)
            {
                if (Diccionario.ContainsKey(Text_Binario.Substring(inicial, i)))
                {
                    Text_Descomprimido += Diccionario.Where(x => x.Key == Text_Binario.Substring(inicial, i));
                    inicial = Text_Descomprimido.Length;
                }
              
            }
            /* TextoCodificado = 
             string[]  palabras  =  textocompleto.Split(' ');
             string codificado = palabras[0];
             textocompleto = textocompleto.Substring(codificado.Length);
             char[] delimiters = new char[] {'[',']', ',', ' '};
             string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);*/

        }
        //Convertir a Binario
        static string DecimalToBinary(string n)
        {
            int N = Convert.ToInt32(n); //Lo convierto a un int
            string binario= Convert.ToString(N,2); //lo convierto en un string de base 2
            int tamano = binario.Length;
            //Ya que cada numero en decimal debe de ocupar 8 posiciones, si el numero en binario es menor a ese tamaño, se le agregan 0 a la derecha
            if (binario.Length < 8)
            {
                for (int i = 0; i < (8 - tamano); i++)
                {
                    binario = "0" + binario;
                }
            }
            return binario;
        }

            
    }
}