namespace Dynastic.API.Mapping.Converters
{
    public interface ITypeConverter<in T, R>
    {
        public R Convert(T source);
    }
}