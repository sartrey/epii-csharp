namespace EPII.Area
{
    public abstract class DataContext : ObjectEx
    {
        protected bool _IsOpen;

        public abstract string Name { get; }

        public bool IsOpen
        {
            get { return _IsOpen; }
        }

        protected abstract void OpenHandler();

        protected abstract void CloseHandler();

        protected abstract void CommitHandler();

        public void Open()
        {
            if (!_IsOpen) {
                OpenHandler();
                _IsOpen = true;
            }
        }

        public void Close()
        {
            if (_IsOpen)
                CloseHandler();
            _IsOpen = false;
        }

        public void Commit()
        {
            if (_IsOpen)
                CommitHandler();
        }

        public abstract void Setup();

        public abstract void Reset();
    }
}
