using System.Collections.Generic;

namespace Dynastic.Application.Common {
    public class Couple {
        public Member Partner { get; set; }
        public HashSet<Member> Children { get; set; }
    }
}