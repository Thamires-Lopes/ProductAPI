using Entities.DTOs;
using Entities.Entities;
using System.Net.Http.Json;

namespace IntegrationTest
{
    public class Tests
    {
        private ProductApiWebApplicationFactory api;

        [OneTimeSetUp]
        public void Setup()
        {
            api = new ProductApiWebApplicationFactory();
        }

        [Test, Order(1)]
        public async Task SaveBook()
        {
            var client = api.CreateClient();

            var book = new BookDTO { Author = "Teste", ReleaseDate = DateTime.Now, Name = "Teste", Price = 20 };

            var response = await client.PostAsJsonAsync("/saveBook", book);
            var bookSavedReponse = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("Saved Book", bookSavedReponse);
        }

        [Test, Order(2)]
        public async Task GetBooks()
        {
            var client = api.CreateClient();

            var response = await client.GetAsync("/books");

            var booksReponse = await response.Content.ReadFromJsonAsync<List<Book>>();

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(booksReponse.Count == 1);
        }
    }
}