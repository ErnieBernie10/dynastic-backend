using System.Collections.Generic;

namespace Dynastic.Domain {
    public class Couple {
        public Member Partner { get; set; }
        public List<Member> Children { get; set; }
    }
}