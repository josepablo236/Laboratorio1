using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio1.ArbolHuffman
{
    public class ArbolHuff
    {
        public double EPSILON { get; private set; }
<<<<<<< HEAD
=======
        public static List<NodoHuffman> listaNodos;
>>>>>>> 707543d5bd051fd165cb74a5524e18d40a1602c8
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
<<<<<<< HEAD
            listadeNodos.OrderBy(x => x.probabilidad);
=======
            listaNodos = listadeNodos.OrderBy(x => x.probabilidad).ToList();
>>>>>>> 707543d5bd051fd165cb74a5524e18d40a1602c8
        }
        //Recibe la lista de notos de agregarNodos
        public void AgregarNodoAlArbol(List<NodoHuffman> listadeNodos)
        {
<<<<<<< HEAD
            //Ya que deben de existir minimo 2 nodos para poder emparejarlos
            if (listadeNodos.Count > 1)
            {
                NodoHuffman nodotemp = new NodoHuffman();
                //La probabilidad del nodo es la suma de la probabilidad de sus nodos hijos, iz y derecha.
                nodotemp.probabilidad = (listadeNodos[0].probabilidad + listadeNodos[1].probabilidad);
=======
            OrdenamientoListaNodos(listadeNodos);
            //Ya que deben de existir minimo 2 nodos para poder emparejarlos
            if (listaNodos.Count > 2)
            {
                NodoHuffman nodotemp = new NodoHuffman();
                //La probabilidad del nodo es la suma de la probabilidad de sus nodos hijos, iz y derecha.
                nodotemp.probabilidad = (listaNodos[0].probabilidad + listaNodos[1].probabilidad);
>>>>>>> 707543d5bd051fd165cb74a5524e18d40a1602c8
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
<<<<<<< HEAD
                listadeNodos.RemoveAt(0);
                listadeNodos.RemoveAt(1);
                //Se agrega a la lista de nodos, el nuevo nodo creado
                listadeNodos.Add(nodotemp);
                Arbol.Add(nodotemp);
                //Se ordena nuevamente encontrar nuevamente los 2 mas pequeños
                OrdenamientoListaNodos(listadeNodos);
                //La función es recursiva, hasta que en la lista unicamente queden menos de 2 nodos
                AgregarNodoAlArbol(listadeNodos);
=======
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
                nodotemp.caracter = Convert.ToChar("x");
                nodotemp.HijoIzquierdo = listaNodos[0];
                nodotemp.HijoDerecho = listaNodos[1];
                Arbol.Add(nodotemp);
                    
>>>>>>> 707543d5bd051fd165cb74a5524e18d40a1602c8
            }
        }
    }
}