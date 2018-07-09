using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PersonService
    {
        public bool IsValid(Person person)
        {
            return person.Age >= 18 && person.Age <= 50;
        }
    }
}
