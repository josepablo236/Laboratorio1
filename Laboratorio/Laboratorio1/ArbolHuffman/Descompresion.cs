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
//<<<<<<< Updated upstream
            for (int i = 0; i < textocompleto.Length-2; i+=2)
            {
                Diccionario.Add(parts[i], parts[i + 1]);
            }
//=======
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[0].Substring(0, 1) == " ")
                {
                    parts[0] = parts[0].Substring(1, parts[0].Length-1);
            }
            }
            
            /* char[] delimiters = new char[] { '[', ']', ',', ' ' };
             string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

             */
             
             for (int i = 0; i < parts.Length-1; i += 2)
             {
                 Diccionario.Add(parts[i].Remove(0, 1), parts[i + 1]);
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
                    {//El delimitador entre el diccionario y el texto comprimido es una barra | 
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
            int inicial = 0; //en que posicion del Text_Binario comenzara a comparar
            string Text_Descomprimido = "";
            int tamano = 1; bool salirse = false;

            while ((inicial+tamano)<=Text_Binario.Length) //Mientras no se finalice el Text_Binario
            {
                string temp = Text_Binario.Substring(inicial, tamano); //Si el primer caracter no se encuentra en el diccionario, voy tomando en cada vuelta 1 mas hasta encontra un similar
                if (Diccionario.ContainsValue(temp)) //si si se encuentra en el diccionario
                {
                    var tempo = Diccionario.FirstOrDefault(x => x.Value == temp).Key; //Tomo le valor en decimal
                    var strFinal = (char)Convert.ToInt32(tempo); //Lo convierto a letra
                    Text_Descomprimido += strFinal.ToString(); //Se concatena al Text_Descomprimido
                    inicial = inicial + temp.Length;  //Esto significa que ahora tendra que comenzr a comparar a partir de esa posicion en adelanta 
                    tamano = 1;
                }
                else { tamano++; }
                
            }
            string Texto = Text_Descomprimido;
            /* TextoCodificado = 
             string[]  palabras  =  textocompleto.Split(' ');
             string codificado = palabras[0];
             textocompleto = textocompleto.Substring(codificado.Length);
             char[] delimiters = new char[] {'[',']', ',', ' '};
             string[] parts = textocompleto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);*/
//>>>>>>> Stashed changes

        }

        private string DecimalToBinary(string item)
        {
            throw new NotImplementedException();
        }
    }
}