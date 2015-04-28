namespace EPII.FEA
{
    using System.Collections.Generic;

    public class FEAModel : ISingletonModel
    {
        private WindowPool _WindowPool = null;
        private List<IDirector> _Directors 
            = new List<IDirector>();
        
        public WindowPool WindowPool 
        {
            get { return _WindowPool; }
        }

        public IModelSettings Settings
        {
            get { throw new System.NotImplementedException(); }
        }

        public FEAModel()
        {
            _WindowPool = new WindowPool();
        }

        public IDirector GetDirector<T>()
            where T : IDirector, new()
        {
            var type = typeof(T);
            foreach (var director in _Directors) {
                if (type.IsInstanceOfType(director))
                    return director;
            }
            var new_director = new T();
            _Directors.Add(new_director);
            return new_director;
        }
    }
}
