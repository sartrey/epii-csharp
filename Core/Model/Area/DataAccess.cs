namespace EPII.Area
{
    public abstract class DataAccess : ObjectEx
    {
        protected bool opened_;

        public abstract string Name { get; }

        public bool IsOpened
        {
            get { return opened_; }
        }

        protected abstract void OpenHandler();

        protected abstract void CloseHandler();

        protected abstract void CommitHandler();

        public void Open()
        {
            if (!opened_) {
                OpenHandler();
                opened_ = true;
            }
        }

        public void Close()
        {
            if (opened_)
                CloseHandler();
            opened_ = false;
        }

        public void Commit()
        {
            if (opened_)
                CommitHandler();
        }

        public abstract void Install();

        public abstract void Uninstall();
    }
}