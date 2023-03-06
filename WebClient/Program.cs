using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static HttpClient client = new HttpClient();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Что будем делать? \n1-создавать пользователя\n2-получить пользователя по Id\n3-выход");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        GetUser();
                        break;
                    case "3":
                        exit = true;
                        break;
                }
            }
        }


        private async static void CreateUser()
        {
            var user = CustomerService.RandomCustomer();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44391/customers", user);
            if (response.IsSuccessStatusCode)
            {
                var customerId = await response.Content.ReadAsAsync<long>();
                Console.WriteLine($"Id: {customerId}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                Console.WriteLine("Пользователь уже добавлен.");
            }
            else
            {
                Console.WriteLine("Ошибка выполнения.");
            }
        }

        private async static void GetUser()
        {
            Console.WriteLine($"Введите Id пользователя:");
            var userId = Console.ReadLine();

            HttpResponseMessage response = await client.GetAsync($"https://localhost:44391/customers/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var customer = await response.Content.ReadAsAsync<Customer>();
                Console.WriteLine($"Id: {customer.Id} Имя: {customer.Firstname} Фамилия: {customer.Lastname}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Пользователь не найден.");
            }
            else
            {
                Console.WriteLine("Ошибка выполнения.");
            }
        }
    }
}