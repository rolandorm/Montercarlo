using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montercarlo
{
    public class ClassMT
    {
        public List<List<int>> SimSatelite(int min_paneles, int paneles, int vida_min, int vida_max, int n_simulaciones)
        {
            List<List<int>> res = new List<List<int>>();
            List<int> numSimulacion = new List<int>();
            double promedio = 0;

            for (int i = 0; i < n_simulaciones; i++)
            {
                // generar lista de entetos aleatorios entre vida_min y vida_max con longitud paneles
                List<int> vida = new List<int>();
                vida.Add(i);
                for (int j = 0; j < paneles; j++)
                {
                    vida.Add(new Random().Next(vida_min, vida_max));
                }
                // ordenar la lista de enteros
                vida.Sort();
                vida.Add(vida[paneles - min_paneles]);
                promedio += vida[paneles - min_paneles];
                res.Add(vida);
            }
            promedio /= n_simulaciones;
            // hacer una lista de longitud paneles con ceros
            List<int> listaResultados = new List<int>();
            for (int i = 0; i < paneles + 1; i++)
            {
                listaResultados.Add(0);
            }

            listaResultados.Add((int)promedio);
            res.Add(listaResultados);
            return transmat(res);
        }

        public List<List<int>> transmat(List<List<int>> input)
        {
            int rowCount = input.Count;
            int colCount = input[0].Count;

            List<List<int>> result = new List<List<int>>();

            for (int col = 0; col < colCount; col++)
            {
                List<int> newRow = new List<int>();
                for (int row = 0; row < rowCount; row++)
                {
                    newRow.Add(input[row][col]);
                }
                result.Add(newRow);
            }

            return result;
        }
    }
}
