using Moq;
using NUnit.Framework;
using Utilities;

namespace UtilitiesTests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<IRepository> _mock;
        private IRepository _repository;
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IRepository>();
            _repository = _mock.Object;
        }
        [Test]
        public void Get_ShallReturnPerson_ForGettingPersonFromRepository()
        {
            _mock
                .Setup(repository => repository.Get(5))
                .Returns(() => new Person() { Id = 5, Name = "User-Defined", Age = 73 });
            var input = _repository.Get(5);
            var expected = new Person() { Id = 5, Name = "User-Defined", Age = 73 };
            Assert.AreEqual(expected, input);
        }
        [Test]
        public void Get_ShallReturnPerson_CallingMethodWithOneArgument()
        {
            int id = 5, age = 62;
            string name = "User-Define";
            _repository.Add(id, name, age);
            _mock.Verify(mock => mock.Add(id, name, age));
        }
    }
}
