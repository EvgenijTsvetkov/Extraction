namespace Source
{
    public interface IProvider<T>
    {
        T Value { get; set; }
    }
}