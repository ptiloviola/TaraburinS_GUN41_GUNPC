using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.Text;


class Program
{
    static void Main(string[] args)
    {

        // Task #1

        int[] arrayFib = new int[8];
        for (int i = 0; i < arrayFib.Length; i++)
        {
            if (i < 2)
            {
                arrayFib[i] = i;
            }
            else
            {
                arrayFib[i] = arrayFib[i - 1] + arrayFib[i - 2];
            }
        }

        Console.WriteLine("arrayFib = {0}", $"[{string.Join(", ", arrayFib)}]");


        // Task #2

        var en = new CultureInfo("en-US");

        string[] arrayMonts = new string[12];

        for (int i = 0; i < 12; i++)
        {
            arrayMonts[i] = en.DateTimeFormat.GetMonthName(i+1);
        }

        Console.WriteLine("arrayMonts = {0}", $"[{string.Join(", ", arrayMonts)}]");

        // Task #3

        int[,] arrayMatrix = new int[3, 3];

        for (int i = 0; i < arrayMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < arrayMatrix.GetLength(1); j++)
            {
                arrayMatrix[i, j] = (int)Math.Pow(j + 2, i + 1);
            }
        }

        var arrayMatrixString = new StringBuilder();

        arrayMatrixString.Append("[");

        for (int i = 0; i < arrayMatrix.GetLength(0); i++)
        {
            arrayMatrixString.Append("[");
            for (int j = 0; j < arrayMatrix.GetLength(1); j++)
            {
                arrayMatrixString.Append(arrayMatrix[i, j]);
                if (j < arrayMatrix.GetLength(1) - 1)
                {
                    arrayMatrixString.Append(", ");
                } 
                else
                {
                    arrayMatrixString.Append("]");
                }
            }
            if (i < arrayMatrix.GetLength(0) - 1)
            {
                arrayMatrixString.Append(", ");
            }
            else
            {
                arrayMatrixString.Append("]");
            }
        }

        Console.WriteLine("arrayMatrix = {0}", arrayMatrixString);

        // Task # 4

        double[][] arrayJagged = new double[3][];
        arrayJagged[0] = new double[5];
        arrayJagged[1] = new double[2];
        arrayJagged[2] = new double[4];

        for (int i = 0; i < arrayJagged[0].Length; i++)
        {
            arrayJagged[0][i] = i + 1;
        }

        arrayJagged[1][0] = Math.PI;
        arrayJagged[1][1] = Math.E;

        for (int i = 0; i < arrayJagged[2].Length; i++)
        {
            //arrayJagged[2][i] = i;
            arrayJagged[2][i] = Math.Log10(Math.Pow(10, i)); 
        }


        var arrayJaggedString = new StringBuilder();
        arrayJaggedString.Append("[");
        for (int i = 0; i < arrayJagged.Length; i++)
        {
            arrayJaggedString.Append($"[{string.Join(", ", arrayJagged[i])}]");
            if (i < arrayJagged.Length - 1)
            {
                arrayJaggedString.Append(", ");
            }
            else
            {
                arrayJaggedString.Append("]");
            }
        }
      
        Console.WriteLine("arrayJagged = {0}", arrayJaggedString);

        // Task #5

        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

        Array.Copy(array, array2, 3);

        Console.WriteLine("array2 = {0}", $"[{string.Join(", ", array2)}]");

        // Task #6

        Array.Resize(ref array, array.Length * 2);

        Console.WriteLine("array = {0}", $"[{string.Join(", ", array)}]");
















        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}