using System;
using System.Linq;
using Dynastic.Application.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Dynastic.Application.Tests.Common
{
    [TestFixture]
    public class TreeTest
    {
        private Member jod;
        private Member jad;
        private Member sd;
        private Member dd;
        private Member gmd;
        private Member gpd;
        private Member bw;
        private Member mw;
        
        [SetUp]
        protected void SetUp()
        {
            mw = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Momma",
                Lastname = "Wayne"
            };
            bw = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Bruce",
                Lastname = "Wayne"
            };
            
            gpd = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Grandpa",
                Lastname = "Doe",
                BirthDate = new DateTime(1956, 6, 23)
            };
            gmd = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Grandma",
                Lastname = "Doe",
                BirthDate = new DateTime(1957, 3, 11)
            };
            jod = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Doe",
                BirthDate = new DateTime(1970, 4, 4)
            };
            jad = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Jane",
                Lastname = "Doe",
                BirthDate = new DateTime(1973, 2, 6)
            };
            sd = new Member()
            {
                Id = Guid.NewGuid(),
                Firstname = "Son",
                Lastname = "Doe",
                BirthDate = new DateTime(1995, 5, 30)
            };
            dd = new Member()
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
            sd.Father = jod;
            sd.FatherId = jod.Id;
            sd.Mother = jad;
            sd.MotherId = jad.Id;
            dd.Father = jod;
            dd.FatherId = jod.Id;
            dd.Mother = jad;
            dd.MotherId = jad.Id;
            bw.Mother = mw;
            bw.MotherId = mw.Id;
            
        }

        [TestCase]
        public void When_Given_Dynasty_Expect_Nested_Tree_Length()
        {
            var tree = new Tree(new []
            {
                jod,
                jad,
                gpd,
                gmd,
                sd,
                dd,
                bw,
                mw
            });
           Assert.AreEqual(2, tree.NestedTree.Count); 
        }

        [TestCase]
        public void When_Given_Dynasty_Expect_Depth()
        {
            var tree = new Tree(new []
            {
                jod,
                jad,
                gpd,
                gmd,
                sd,
                dd,
                bw,
                mw
            });
            Assert.AreEqual(4, GetDepth(tree.NestedTree.First())); 
        }

        private int GetDepth(Member m)
        {
            var depth = 1;
            if (m.Relationships.Count <= 0) return depth;
            foreach (var child in m.Relationships.First().Children)
            {
                 depth += GetDepth(child);
            }

            return depth;
        }
    }
}