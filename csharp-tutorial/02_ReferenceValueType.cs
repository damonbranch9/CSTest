﻿using Xunit;

namespace csharp_tutorial
{
    public class RefVal
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters
        // Types are passed to methods by value
        // Passing a value-type variable to a method by value means passing a copy of the variable to the method
        // A variable of a reference type does not contain its data directly; it contains a reference to its data

        // http://net-informations.com/faq/general/valuetype-referencetype.htm

        [Fact]
        public void Update_Value()
        {
            int original = 2;

            DoSomething(original);
            Assert.Equal(2, original);

            DoSomething(ref original);
            Assert.Equal(5, original);
        }

        private void DoSomething(int myValue)
        {
            myValue = 5;
        }

        private void DoSomething(ref int myValue)
        {
            myValue = 5;
        }

        public class Person
        {
            public string Name { get; set; }
        }

        [Fact]
        public void Update_Class()
        {
            var person = new Person { Name = "Harry" };

            UpdatePerson(person);
            Assert.Equal("Harry", person.Name);

            UpdatePersonName(person);
            Assert.Equal("Timmy", person.Name);

            UpdatePerson(ref person);
            Assert.Equal("Sammy", person.Name);
        }

        private void UpdatePerson(Person person)
        {
            person = new Person { Name = "Sammy" };
        }

        private void UpdatePersonName(Person person)
        {
            person.Name = "Timmy";
        }

        private void UpdatePerson(ref Person person)
        {
            person = new Person { Name = "Sammy" };
        }

        [Fact]
        public void Out()
        {
            void GetSome(out int value)
            {
                value = 5;
            }

            GetSome(out var myValue);

            Assert.Equal(5, myValue);
        }

        private class User
        {
            public string Ssn { get; set; }

            public string Name { get; set; }

            public override bool Equals(object obj) => obj is User ? Ssn == ((User)obj).Ssn : false;

            public override int GetHashCode() => Ssn.GetHashCode();
        }

        [Fact]
        public void EqualsExample()
        {
            var person1 = new Person { Name = "James" };
            var person2 = new Person { Name = "James" };

            Assert.False(person1.Equals(person2));
            Assert.False(person1 == person2);
            Assert.True(person1 == person1);

            var user1 = new User { Ssn = "12345" };
            var user2 = new User { Ssn = "12345" };

            Assert.True(user1.Equals(user2));
            Assert.False(user1 == user2);
        }
    }
}