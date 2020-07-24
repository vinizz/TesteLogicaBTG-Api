using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace TesteBTGApi.Repository
{
    public class CortarRepository
    {

        public string CortarTijolo(List<int[]> parede, int max_int)
        {

            var res = new Dictionary<int, int>();

            foreach (var linha in parede)
            {
                if (linha.Sum() > max_int)
                    return "Existem linhas que ultrapassam o max_int";

                var soma = 0;

                for (var i = 0; i < linha.Length - 1; i++)
                {
                    soma += linha[i];

                    res[soma] = res.ContainsKey(soma) ? res[soma] + 1 : 1;
                }
            }

            int cortados = parede.Count() - (res.Count > 0 ? res.Values.Max() : 0);

            return "Foram cortados apenas: " + cortados.ToString() + " tijolos.";

        }

    }
}