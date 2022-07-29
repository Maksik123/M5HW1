namespace M5HW1
{
    using System.Net;
    using System.Net.Http.Json;
    using System.Text;
    using Newtonsoft.Json;

    internal class Program
    {

        static async Task Main(string[] args)
        {
            string userID = "2";
            await GetUsers();
            await AddCustomer();
            await PutCustomer(userID);
        }

        static async Task GetUsers()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            HttpResponseMessage responseMessage = await client.GetAsync("api/users");
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var AllUsers = await responseMessage.Content.ReadAsStringAsync();
                //Console.WriteLine(AllUsers);
                PagesInfomation infomation = JsonConvert.DeserializeObject<PagesInfomation>(AllUsers);
                if (infomation != null)
                {
                    Console.WriteLine(infomation.WritePageInfortamion());
                    Console.WriteLine(AllUsers);
                }
            }
        }

        static async Task AddCustomer()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            CreateCustomerParameters customerParameters = new CreateCustomerParameters
            {
                Name = "Maxim",
                Job = "Junior"
            };

            var serializedCustomer = JsonConvert.SerializeObject(customerParameters);
            StringContent stringContent = new StringContent(serializedCustomer, Encoding.Unicode, "application/json");

            HttpResponseMessage result = await client.PostAsync("api/users", stringContent);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Created");

                var content = await result.Content.ReadAsStringAsync();

                Console.WriteLine(content);
            }
        }

        static async Task PutCustomer(string UserID)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            var responce = await client.PutAsJsonAsync
                (
                $"api/users/{UserID}",
                new CreateCustomerParameters { Name = "Slava" , Job ="Worker"}
                );

            if (responce.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Put Customer");
                var content = await responce.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        static async Task DeleteCustomer(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");


        }
    }
}