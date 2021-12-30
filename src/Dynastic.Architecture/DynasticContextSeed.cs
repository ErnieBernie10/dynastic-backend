using Dynastic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynastic.Architecture
{
    public static class DynasticContextSeed
    {
        public static async Task SeedSampleDataAsync(DynasticContext context)
        {
            if (!context.Dynasties.Any())
            {
                var mother = new Person()
                {
                    BirthDate = new DateTime(1975, 1, 1),
                    Firstname = "Momma",
                    Lastname = "Doe",
                    ModifiedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                };
                var father = new Person()
                {
                    BirthDate = new DateTime(1975, 1, 1),
                    Firstname = "Father",
                    Lastname = "Doe",
                    ModifiedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                };

                mother = context.People.Add(mother).Entity;
                father = context.People.Add(father).Entity;
                
                var jad = new Person()
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    Firstname = "Jane",
                    Lastname = "Doe",
                    ModifiedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                };
                var jod = new Person()
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    Firstname = "John",
                    Lastname = "Doe",
                    ModifiedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    MotherId = mother.Id,
                    FatherId = father.Id,
                };
                jod = context.People.Add(jod).Entity;
                jad = context.People.Add(jad).Entity;
                await context.SaveChangesAsync();

                var userDynasties = new UserDynasties
                {
                    Id = "auth0|61cde640d27de7006abb72cc",
                    Dynasty = new Dynasty
                    {
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Name = "Doe",
                        Description = "Doe family",
                        Members = new List<Person> { jod, jad, mother, father }
                    }
                };
                context.UserDynasties.Add(userDynasties);
                await context.SaveChangesAsync();
            }
        }
    }
}
