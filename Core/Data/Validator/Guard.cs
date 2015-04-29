namespace EPII.Data
{
    public class Guard<T>
    {
        private T _Data;

        public T Data 
        {
            get { return _Data; }
        }

        public Guard(T data)
        {
            _Data = data;
        }
    }
}