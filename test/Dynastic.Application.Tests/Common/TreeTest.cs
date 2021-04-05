using System;
using System.Collections.Generic;
using Dynastic.Application.Common;
using Dynastic.Architecture.Models;
using NUnit.Framework;

namespace Dynastic.Application.Tests.Common
{
    [TestFixture]
    public class TreeTest
    {
        private Person jod;
        private Person jad;
        private Person sd;
        private Person dd;
        private Person gmd;
        private Person gpd;
        
        [SetUp]
        protected void SetUp()
        {
            gpd = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "Grandpa",
                Lastname = "Doe",
                BirthDate = new DateTime(1956, 6, 23)
            };
            gmd = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "Grandma",
                Lastname = "Doe",
                BirthDate = new DateTime(1957, 3, 11)
            };
            jod = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Doe",
                BirthDate = new DateTime(1970, 4, 4)
            };
            jad = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "Jane",
                Lastname = "Doe",
                BirthDate = new DateTime(1973, 2, 6)
            };
            sd = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "Son",
                Lastname = "Doe",
                BirthDate = new DateTime(1995, 5, 30)
            };
            dd = new Person()
            {
                Id = Guid.NewGuid(),
                Firstname = "Daughter",
                Lastname = "Doe",
                BirthDate = new DateTime(1997, 3, 9)
            };
            jod.Father = gpd;
            jod.FatherId = gpd.Id;
            jod.Mother = gmd;
            jod.MotherId = gmd.Id;
            jod.Relationships = new List<Relationship>()
            {
                new()
                {
                    Partner = jad,
                    PartnerId = jad.Id,
                    Person = jod,
                    PersonId = jod.Id
                }
            };
            jad.Relationships = new List<Relationship>()
            {
                new()
                {
                    Partner = jod,
                    PartnerId = jod.Id,
                    Person = jad,
                    PersonId = jad.Id
                }
            };
            gpd.Relationships = new List<Relationship>()
            {
                new()
                {
                    Partner = gmd,
                    PartnerId = gmd.Id,
                    Person = gpd,
                    PersonId = gpd.Id
                }
            };
            gmd.Relationships = new List<Relationship>()
            {
                new()
                {
                    Partner = gpd,
                    PartnerId = gpd.Id,
                    Person = gmd,
                    PersonId = gmd.Id
                }
            };
            sd.Father = jod;
            sd.FatherId = jod.Id;
            sd.Mother = jad;
            sd.MotherId = jad.Id;
            dd.Father = jod;
            dd.FatherId = jod.Id;
            dd.Mother = jad;
            dd.MotherId = jad.Id;
        }

        [TestCase]
        public void When_Given_Dynasty_Expect_Nested_Tree_Length()
        {
            var tree = new Tree(new Dynasty()
            {
                Description = "Sample",
                Name = "Doe",
                Members = new List<Person>()
                {
                    gpd,
                    gmd,
                    jod,
                    jad,
                    sd,
                    dd
                }
            });
           Assert.AreEqual(3, tree.NestedTree.Count); 
        }

        [TestCase]
        public void When_Given_Dynasty_Expect_Flat_Tree_Length()
        {
            var tree = new Tree(new Dynasty()
            {
                Description = "Sample",
                Name = "Doe",
                Members = new List<Person>()
                {
                    gpd,
                    gmd,
                    jod,
                    jad,
                    sd,
                    dd
                }
            });
           Assert.AreEqual(6, tree.FlatTree.Count); 
        }
    }
}