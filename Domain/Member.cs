using System;
using System.Collections.Generic;
using Dynastic.Models;

namespace Dynastic.Domain {
    public class Member : Base {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Member Mother { get; set; }
        public Guid? MotherId { get; set; }
        public Member Father { get; set; }
        public Guid? FatherId { get; set; }
        public List<Couple> Relationships { get; set; }
    }
}