using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dynastic.Application.Common;
using Newtonsoft.Json;

namespace Dynastic.Architecture.Models
{
    public class Person : Base
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Person Mother { get; set; }
        public Guid? MotherId { get; set; }
        public Person Father { get; set; }
        public Guid? FatherId { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Relationship> Relationships { get; set; }
        [JsonIgnore]
        public virtual List<Person> MothersChildren { get; set; }
        [JsonIgnore]
        public virtual List<Person> FathersChildren { get; set; }
        
        [NotMapped]
        public List<Person> Children => CombineChildren();

        public Member ToMember(bool recurse = false)
        {
            return new()
            {
                Id = Id,
                Firstname = Firstname,
                Middlename = Middlename,
                Lastname = Lastname,
                BirthDate = BirthDate,
                CreatedAt = CreatedAt,
                ModifiedAt = ModifiedAt,
                FatherId = FatherId,
                MotherId = MotherId,
                Father = recurse ? Father?.ToMember() : null,
                Mother = recurse ? Mother?.ToMember() : null
            };
        }
        
        private List<Person> CombineChildren()
        {
            var list = new List<Person>();
            list.AddRange(MothersChildren ?? new List<Person>());
            list.AddRange(FathersChildren ?? new List<Person>());
            return list;
        }
    }
}