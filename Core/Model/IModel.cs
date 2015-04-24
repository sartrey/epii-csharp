namespace EPII
{
    public interface IModel
    {
        bool Identify();

        IModelSettings Settings { get; }
    }
}
