using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Question01
{
    public class DecReprSenior
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite Valor");

            Solution(Convert.ToInt32(Console.ReadLine()));

            Console.ReadKey();
        }

        static List<List<int>> lstCombinarNumeros;
        static bool[] used;
        static void Solution(int N)
        {
            // Quebrar o valor de N e jogar em uma lista
            List<int> lstnumeros = new List<int>();
            for (int i = 0; i < N.ToString().Length; i++)
            {
                lstnumeros.Add(int.Parse(N.ToString().Substring(i, 1)));
            }

            // Controlar qual já foi usado para combinação
            used = new bool[lstnumeros.Count];

            lstCombinarNumeros = new List<List<int>>();
            List<int> lstAux = new List<int>();

            // Criar as combinações possíveis
            CriarCombinacao(lstnumeros, 0, lstAux);

            // Variáveis Auxiliares
            string AuxValor = null;
            int MaxValor = 0;
            List<int> T = new List<int>();

            // Varrer a lista criada e imprimir o maior
            foreach (var item in lstCombinarNumeros)
            {
                AuxValor = null;

                foreach (var x in item)
                {
                    AuxValor = string.Concat(AuxValor, x);
                }

                //Adicionar os valores em uma lista, para pegar o MAX.
                T.Add(Convert.ToInt32(AuxValor));
            }

            MaxValor = T.Max();


            if (MaxValor < 10000000)
            {
                Console.WriteLine("Resultado: " + MaxValor.ToString());
            }
            else
            {
                Console.WriteLine("Resultado: -1");

            }


        }


        static void CriarCombinacao(List<int> lstnumeros, int Colx, List<int> lstAux)
        {
            if (Colx >= lstnumeros.Count)
            {
                lstCombinarNumeros.Add(new List<int>(lstAux));
                return;
            }

            for (int i = 0; i < lstnumeros.Count; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    lstAux.Add(lstnumeros[i]);
                    CriarCombinacao(lstnumeros, Colx + 1, lstAux);
                    lstAux.RemoveAt(lstAux.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}
