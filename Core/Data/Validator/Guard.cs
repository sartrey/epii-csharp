namespace EPII.Data
{
    public class Guard<T>
    {
        private T data_;

        public T Data 
        {
            get { return data_; }
        }

        public Guard(T data)
        {
            data_ = data;
        }
    }
}