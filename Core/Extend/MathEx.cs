namespace EPII
{
    public class MathEx
    {
        /// <summary>
        /// x^n
        /// </summary>
        public static long Power(int x, int n)
        {
            long value = 1;
            while (n > 0) {
                value = value * x;
                n--;
            }
            return value;
        }

        /// <summary>
        /// n!
        /// </summary>
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        /// <summary>
        /// log(n!)
        /// </summary>
        public static double LogFactorial(int n, double a)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
                result += System.Math.Log(i, a);
            return result;
        }
    }
}