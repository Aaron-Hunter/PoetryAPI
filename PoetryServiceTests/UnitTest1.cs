using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using PoetryAPI.Models;
using PoetryAPI.Services;
using System.Text;

namespace PoetryServiceTests
{
    public class Tests
    {
        public static void AreEqualByJson(RawPoem expected, RawPoem actual)
        {
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenACorrectUrlIsProvided_ServiceShouldReturnARawPoem()
        {
            //Arrange
            JArray poems = new JArray();
            var poem = new RawPoem
            {
                Title = "A Solitary Greeting",
                Author = "Many A Programmer",
                Lines = new string[] { "Hello, World" }
            };

            string json = "[{\"title\": \"A Solitary Greeting\", \"author\": \"Many A Programmer\", \"lines\": [ \"Hello, World\"]}]";

            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var url = "https://stackoverflow.com";
            var fakeHttpMessageHandler = new PoetryAPI.FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);
            httpClientFactoryMock.CreateClient(Arg.Any<string>()).Returns(fakeHttpClient);

            //Act
            var service = new PoetryService(httpClientFactoryMock);
            var result = await service.RawPoemFromTitle(url, "A Solitary Greeting");

            //Assert
            AreEqualByJson(poem, result);
        }
    }
}