using Services;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ServiceTests
{
    public class PersonServiceTests
    {
        [Fact]
        public void IsValid_Fact()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Bill",
                Age = 20
            };
            var personService = new PersonService();

            // Act
            var result = personService.IsValid(person);

            // Assert
            Assert.True(result);
        }

        // Get from [method] in the [same] class
        [Theory]
        [MemberData(nameof(GetPersons))]
        public void IsValid_Theory(Person person)
        {
            // Arrange
            var personService = new PersonService();

            // Act
            var result = personService.IsValid(person);

            // Assert
            Assert.True(result);
        }

        // Get from [method] in a [different] class (can even pass parameter)
        [Theory]
        [MemberData(nameof(PersonData.GetPersons2), parameters: 1, MemberType = typeof(PersonData))]
        public void IsValid_Theory2(Person person)
        {
            // Arrange
            var personService = new PersonService();

            // Act
            var result = personService.IsValid(person);

            // Assert
            Assert.True(result);
        }

        // Get from [property] in a different class
        [Theory]
        [MemberData(nameof(PersonData.Persons3), MemberType = typeof(PersonData))]
        public void IsValid_Theory3(Person person)
        {
            // Arrange
            var personService = new PersonService();

            // Act
            var result = personService.IsValid(person);

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> GetPersons() => new List<object[]>
        {
            new object[]
            {
                new Person
                {
                    Id = 2,
                    Name = "Mark",
                    Age = 19
                }
            },
            new object[]
            {
                new Person
                {
                    Id = 3,
                    Name = "David",
                    Age = 18
                }
            }
        };
    }

    public class PersonData
    {
        public static IEnumerable<object[]> GetPersons2(int number) => new List<object[]>
        {
            new object[]
            {
                new Person
                {
                    Id = 2,
                    Name = "Mark",
                    Age = 19
                }
            },
            new object[]
            {
                new Person
                {
                    Id = 3,
                    Name = "David",
                    Age = 18
                }
            }
        }.Take(number);

        public static IEnumerable<object[]> Persons3 => new List<object[]>
        {
            new object[]
            {
                new Person
                {
                    Id = 2,
                    Name = "Mark",
                    Age = 19
                }
            },
            new object[]
            {
                new Person
                {
                    Id = 3,
                    Name = "David",
                    Age = 18
                }
            }
        };
    }
}
