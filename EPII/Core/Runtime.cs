namespace EPII
{
    public class Runtime : ObjectEx
    {
        private static Runtime _Instance = null;

        /// <summary>
        /// get runtime single instance
        /// </summary>
        public static Runtime Instance 
        {
            get 
            {
                if (_Instance == null)
                    _Instance = new Runtime();
                return _Instance;
            }
        }

        protected Table<object> _Data 
            = new Table<object>();

        public Table<object> Data 
        {
            get { return _Data; }
        }

        public Runtime() 
        {
        }

        protected override void DisposeManaged()
        {
            foreach (var key in _Data.Keys) 
            {
                var item = _Data[key] as ObjectEx;
                if(item != null)
                    item.Dispose();
            }
            _Data.Clear();
        }

        protected override void DisposeNative()
        {
        }
    }
}
