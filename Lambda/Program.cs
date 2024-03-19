namespace Lambda
{
    internal class Program
    {
        public delegate bool IsOdd(int x);
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Print(Filter(arr, Odd));
            Print(Filter(arr, delegate (int x)
            {
                return x % 2 != 0;
            }
            ));
            Print(Filter(arr, x => x % 2 != 0));
        }
        public static bool Odd(int x)
        {
            return x % 2 != 0;
        }
        public static int[] Filter(int[] array, IsOdd isOdd)
        {
            int[] newArr = new int[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (isOdd(array[i]))
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = array[i];
                }
            }
            return newArr;
        }
        public static void Print(int[] array)
        {
            Array.ForEach(array, x => { Console.Write(x + " "); });
            Console.WriteLine();
        }
    }
}
