using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio1.ArbolHuffman
{
    public class ArbolHuff
    {
        public double EPSILON { get; private set; }
        List<NodoHuffman> Arbol = new List<NodoHuffman>();
        //Recibe el string de caracteres y los agrega a un dicctionario, con su respectiva probabilidad y caracter, para luego crear los nodos
        public void agregarNodos(Dictionary<char, int> Diccionario_Caracteres, string Text_archivo, List<NodoHuffman> listadeNodos)
        {
            foreach (var item in Diccionario_Caracteres)
            {
                NodoHuffman nodotemp = new NodoHuffman();
                nodotemp.probabilidad = Math.Round((item.Value / Convert.ToDouble(Text_archivo.Length)),5); //Calcula la probabilidad
                nodotemp.caracter = item.Key;                             //El caracter es la llave primaria
                listadeNodos.Add(nodotemp);                               //Agrega cada nuevo nodo a una lista de nodos
            }
            AgregarNodoAlArbol(listadeNodos);   //Llama a la funcion para agregar los nodos al arbol
        }
        //Ordena los nodos dependiendo de su probabilidadl, ascendentemente
        public void OrdenamientoListaNodos(List<NodoHuffman> listadeNodos)
        {
            listadeNodos= listadeNodos.OrderBy(x => x.probabilidad).ToList();
        }
        //Recibe la lista de notos de agregarNodos
        public void AgregarNodoAlArbol(List<NodoHuffman> listadeNodos)
        {
            OrdenamientoListaNodos(listadeNodos);
            //Ya que deben de existir minimo 2 nodos para poder emparejarlos
            if (listadeNodos.Count > 1)
            {
                NodoHuffman nodotemp = new NodoHuffman();
                //La probabilidad del nodo es la suma de la probabilidad de sus nodos hijos, iz y derecha.
                nodotemp.probabilidad = (listadeNodos[0].probabilidad + listadeNodos[1].probabilidad);
                //Ya que cuando es un nodo, producto de la suma de 2 letras, no nos importa el caracter, solo su probabilidad
                nodotemp.caracter = Convert.ToChar("x");
                //El nodo con menor probabilidad se convierte en el hijo derecha.
                if (Math.Abs(listadeNodos[0].probabilidad - listadeNodos[1].probabilidad) > EPSILON)
                {
                    if (listadeNodos[0].probabilidad < listadeNodos[1].probabilidad)
                    {
                        nodotemp.HijoDerecho = listadeNodos[0];
                    }
                    else
                    {
                        nodotemp.HijoIzquierdo = listadeNodos[1];
                    }
                }
                //No importa si es iz o derecha, ya que son iguales
                else
                {
                    nodotemp.HijoIzquierdo = listadeNodos[0];
                    nodotemp.HijoDerecho = listadeNodos[1];
                }
                //Eliminamos los 2 mas pequeños de la lista, ya que forman un nuevo nodo, y se vuelven hijos del nuevo nodo
                listadeNodos.RemoveAt(0);
                listadeNodos.RemoveAt(1);
                //Se agrega a la lista de nodos, el nuevo nodo creado
                listadeNodos.Add(nodotemp);
                Arbol.Add(nodotemp);
                //Se ordena nuevamente encontrar nuevamente los 2 mas pequeños
                OrdenamientoListaNodos(listadeNodos);
                //La función es recursiva, hasta que en la lista unicamente queden menos de 2 nodos
                AgregarNodoAlArbol(listadeNodos);
            }
        }
    }
}