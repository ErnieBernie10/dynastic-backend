using Dynastic.Domain;
using Dynastic.Models;
using Mapster;

namespace Dynastic.Mapping {
    public class MapsterConfig {
        public MapsterConfig()
        {
            Config = new TypeAdapterConfig();
        }
        public TypeAdapterConfig Config { get; set; }
    }
}