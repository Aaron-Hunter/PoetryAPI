using PoetryAPI.Models;
using PoetryAPI.Services;

namespace PoemDataServiceTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(PoemDataService.GetAll(), Is.EqualTo(new List<Poem> { }));
        }

        [Test]
        public void Test2()
        {
            //Arrange
            Poem poem = new Poem("A title", "An author", new string[] {"lines"});
            List<Poem> poems = new List<Poem> { poem };

            //Act
            PoemDataService.Add(poem);

            //Assert
            Assert.That(PoemDataService.GetAll(), Is.EqualTo(poems));
        }
    }
}