using Dynastic.API.DTO;
using Dynastic.API.Mapping.Converters;
using Dynastic.Application.Common;
using Mapster;

namespace Dynastic.API.Mapping
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            var treeConverter = new TreeConverter();
            TypeAdapterConfig<Tree, FlatTreeDTO>
                .NewConfig()
                .MapWith(tree => treeConverter.Convert(tree));
        }
    }
}