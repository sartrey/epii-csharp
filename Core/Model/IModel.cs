namespace EPII
{
    public interface IModel
    {
        IModelSettings Settings { get; }
    }

    public interface ISingletonModel : IModel { }

    public interface ITransientModel : IModel { }
}
