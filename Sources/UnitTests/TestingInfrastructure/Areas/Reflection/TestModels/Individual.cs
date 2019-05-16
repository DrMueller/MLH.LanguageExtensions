using System;

namespace Mmu.Mlh.LanguageExtensions.UnitTests.TestingInfrastructure.Areas.Reflection.TestModels
{
    public class Individual
    {
        public DateTime Birthdate { get; }
        public string FirstName { get; set; }
        public string LastName { get; }

        public Individual(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }
    }
}