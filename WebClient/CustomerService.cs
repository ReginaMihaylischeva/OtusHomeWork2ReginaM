using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    class CustomerService
    {
        private static string[] NamesArray = new string[]
        {
            "Джеймс",
            "Марсель",
            "Фридрих",
            "Эрих",
            "Иммануил",
        };

        private static string[] LastNamesArray = new string[]
        {
            "Джойс",
            "Пруст",
            "Ницше",
            "Фромм",
            "Кант",
        };
        public static CustomerCreateRequest RandomCustomer()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 5);
            return new CustomerCreateRequest()
            {
                Firstname = NamesArray[value],
                Lastname = LastNamesArray[value]
            };
        }
    }
}
