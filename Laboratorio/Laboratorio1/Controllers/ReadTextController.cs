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
            string path = Path.Combine(Server.MapPath("~/Archivos"), filename);
            System.IO.StreamReader Leer = new System.IO.StreamReader(path);
            string lector = "a";
            while (!Leer.EndOfStream)
            {
                lector = Leer.ReadLine();
            }

            /*Convierte a codigo Ascii, utiliza unicamente la cantidad de diferentes caracteres que hay
            el problema que tiene es que si detecta 2 caracteres iguales seguidos, solo lo coloca 1 vez XD, hay
            que revisar eso*/
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
                    i = 0;
                }

            }
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