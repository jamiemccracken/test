using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 4)
                Console.WriteLine("insufficient arguments");

            var query = new ContractQuery(args[0], args[1], args[2], args[3]);
            foreach (string s in query.ResultList)
                Console.WriteLine(s);


        }
    }
}
