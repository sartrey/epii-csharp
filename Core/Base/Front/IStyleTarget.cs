namespace EPII.Front
{
    public interface IStyleTarget<T>
        where T : IStyle
    {
        void Apply(T style);
    }
}
