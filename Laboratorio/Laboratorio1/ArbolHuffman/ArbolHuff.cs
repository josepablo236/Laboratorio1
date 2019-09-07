using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio1.ArbolHuffman
{
    public class ArbolHuff
    {
        public double EPSILON { get; private set; }
        public static List<NodoHuffman> listaNodos;
        List<NodoHuffman> Arbol = new List<NodoHuffman>();
        List<NodoHuffman> ArbolCodigos = new List<NodoHuffman>();
        public Dictionary<string, string> codigos = new Dictionary<string, string>();
        //Recibe el string de caracteres y los agrega a un dicctionario, con su respectiva probabilidad y caracter, para luego crear los nodos
        public void agregarNodos(Dictionary<string, int> Diccionario_Caracteres, List<string> Text_archivo, List<NodoHuffman> listadeNodos)
        {
            foreach (var item in Diccionario_Caracteres)
            {
                var nodotemp = new NodoHuffman();
                nodotemp.probabilidad = Math.Round((item.Value / Convert.ToDouble(Text_archivo.Count)),5); //Calcula la probabilidad
                nodotemp.caracter = item.Key;                             //El caracter es la llave primaria
                listadeNodos.Add(nodotemp);                               //Agrega cada nuevo nodo a una lista de nodos
            }
            AgregarNodoAlArbol(listadeNodos);   //Llama a la funcion para agregar los nodos al arbol
        }
        //Ordena los nodos dependiendo de su probabilidadl, ascendentemente
        public void OrdenamientoListaNodos(List<NodoHuffman> listadeNodos)
        {
            listaNodos = listadeNodos.OrderBy(x => x.probabilidad).ToList();
        }
        //Recibe la lista de notos de agregarNodos
        public ActionResult MostrarArbol(List<NodoHuffman> arbol)
        {
            return View(arbol);
        }

        private ActionResult View(List<NodoHuffman> arbol)
        {
            throw new NotImplementedException();

        }

        public void AgregarNodoAlArbol(List<NodoHuffman> listadeNodos)
        {
            OrdenamientoListaNodos(listadeNodos);
            //Ya que deben de existir minimo 2 nodos para poder emparejarlos
            if (listaNodos.Count > 2)
            {
                var nodotemp = new NodoHuffman();
                //La probabilidad del nodo es la suma de la probabilidad de sus nodos hijos, iz y derecha.
                nodotemp.probabilidad = (listaNodos[0].probabilidad + listaNodos[1].probabilidad);
                //Ya que cuando es un nodo, producto de la suma de 2 letras, no nos importa el caracter, solo su probabilidad
                nodotemp.caracter = Convert.ToString("x");
                //El nodo con menor probabilidad se convierte en el hijo derecha.
                if (listadeNodos[0].probabilidad < listadeNodos[1].probabilidad)
                {
                    nodotemp.HijoIzquierdo = listaNodos[1];
                    nodotemp.HijoDerecho = listaNodos[0];
                }
                else if (listadeNodos[1].probabilidad < listadeNodos[0].probabilidad)
                {
                    nodotemp.HijoIzquierdo = listaNodos[0];
                    nodotemp.HijoDerecho = listaNodos[1];
                }
                else
                {
                    nodotemp.HijoIzquierdo = listaNodos[1];
                    nodotemp.HijoDerecho = listaNodos[0];
                }
                //Eliminamos los 2 mas pequeños de la lista, ya que forman un nuevo nodo, y se vuelven hijos del nuevo nodo
                listaNodos.RemoveAt(0);
                listaNodos.RemoveAt(0);
                //Se agrega a la lista de nodos, el nuevo nodo creado
                listaNodos.Add(nodotemp);
                Arbol.Add(nodotemp);
                //Se ordena nuevamente encontrar nuevamente los 2 mas pequeños
                //La función es recursiva, hasta que en la lista unicamente queden menos de 2 nodos
                AgregarNodoAlArbol(listaNodos);

            }
            else
            {
                NodoHuffman nodotemp = new NodoHuffman();
                //La probabilidad del nodo es la suma de la probabilidad de sus nodos hijos, iz y derecha.
                nodotemp.probabilidad = (listaNodos[0].probabilidad + listaNodos[1].probabilidad);
                //Ya que cuando es un nodo, producto de la suma de 2 letras, no nos importa el caracter, solo su probabilidad
                nodotemp.caracter = Convert.ToString("x");
                nodotemp.HijoIzquierdo = listaNodos[1];
                nodotemp.HijoDerecho = listaNodos[0];
                Arbol.Add(nodotemp);
                string lado = "raiz";
                Codigo(nodotemp, nodotemp,lado);
                MostrarArbol(ArbolCodigos);
            }
        }

        public bool EsHoja(NodoHuffman nodo)
        {
            if (nodo.HijoIzquierdo == null && nodo.HijoIzquierdo == null)
            { return true; }
            else { return false; }

        }

        public void Codigo(NodoHuffman nodo, NodoHuffman nodopadre, string lado)
        {
            if (nodo.HijoIzquierdo != null)
            {
                nodo.HijoIzquierdo.codigo = nodo.codigo + "0";
                Codigo(nodo.HijoIzquierdo, nodo, "iz");
            }
            if (nodo.HijoDerecho != null)
            {
                nodo.HijoDerecho.codigo = nodo.codigo + "1";
                Codigo(nodo.HijoDerecho, nodo,  "der");
            }
            if (EsHoja(nodo))
            {
                if (lado == "iz")
                { nodo.codigo = nodopadre.codigo + "0";
                    ArbolCodigos.Add(nodo);
 }
                if (lado == "der")
                { nodo.codigo = nodopadre.codigo + "1";
                    ArbolCodigos.Add(nodo);
                }
            }
        }
    }
}