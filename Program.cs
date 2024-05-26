

class Lab2()
{

    public static void Main(string[] args)
    {
        Lab2 lab2 = new Lab2();
        lab2.zad1();
        //lab2.zad2();
        //lab2.zad3();
    }

    void zad1()
    {
        int arrayLen = 0;
        bool lenCanConvert = false;

        while (!lenCanConvert)
        {
            Console.WriteLine("Podaj ile znaków chcesz dodać");
            lenCanConvert = int.TryParse(Console.ReadLine(), out arrayLen);

            if (lenCanConvert)
            {
                int[] nums = new int[arrayLen];

                int i = 0;
                while (i < arrayLen)
                {
                    Console.WriteLine("Podaj liczbę dziesiętną");
                    int num;
                    bool numCanConvert = false;
                    numCanConvert = int.TryParse(Console.ReadLine(), out num);
                    if (numCanConvert)
                    {
                        nums[i] = num;
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Nie podano liczby dziesiętnej");
                        continue;
                    }
                }
                for (i = 0; i < nums.Length - 1; i++)//algorytm sortowania bąbelkowego
                {
                    for (int j = 0; j < nums.Length - i - 1; j++)
                    {
                        if (nums[j] > nums[j + 1])
                        {
                            int temp = nums[j];
                            nums[j] = nums[j + 1];
                            nums[j + 1] = temp;
                        }
                    }
                }
                Console.WriteLine("Posortowane liczby");
                foreach (var item in nums)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.WriteLine("Nieodpowiednia długość tablicy");
            }
        }
    }
    void zad2()
    {
        float[] permValues = { 2.0f, 3.0f, 3.5f, 4.0f, 4.5f, 5.0f };
        Random rd = new Random();
        int arrLen = 0;
        bool lenCanConvert = false;
        float sum = 0;
        float avg;
        float min, max;

        while (!lenCanConvert)
        {
            Console.WriteLine("Podaj długość tablicy");
            lenCanConvert = int.TryParse(Console.ReadLine(), out arrLen);
            if (lenCanConvert)
            {
                float[] nums = new float[arrLen];
                for (int i = 0; i < arrLen; i++)
                {
                    int randomIndex = rd.Next(0, permValues.Length);//losowanie wartości ze zbioru
                    nums[i] = permValues[randomIndex];
                }
                Console.WriteLine("Wygenerowane wartości: ");
                foreach (var item in nums)
                {
                    Console.Write(item + " ");
                    sum += item;
                }
                avg = sum / arrLen;
                Console.WriteLine("\nŚrednia wartość wygenerowanych liczb: " + avg);
                min = nums.Min();
                max = nums.Max();
                Console.WriteLine("Wartość minimalna: " + min + "\nWartość maksymalna: " + max);
                Console.WriteLine("Wartości niższe niż średnia: ");
                foreach (var item in nums)
                {
                    if (item < avg)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine("\nWartości wyższe niż średnia: ");
                foreach (var item in nums)
                {
                    if (item > avg)
                    {
                        Console.Write(item + " ");
                    }
                }
                Dictionary<float, int> freq = new Dictionary<float, int>
                {
                    {2.0f, 0},
                    {3.0f, 0},
                    {3.5f, 0},
                    {4.0f, 0},
                    {4.5f, 0},
                    {5.0f, 0}
                }; //zapisuję tu występowanie poszczególnych wartości
                foreach (var item in nums)
                {
                    if (freq.ContainsKey(item))
                    {
                        freq[item]++;
                    }
                }
                Console.WriteLine("\nCzęstotliwość występowania poszczególnych wartości: ");
                foreach (var item in freq)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
                Console.WriteLine("Odchylenie standardowe wartości w tablicy: ");
                float stdDev = 0.0f;
                foreach (var num in nums)
                {
                    stdDev += (float)Math.Pow((num - avg), 2);
                }
                stdDev /= nums.Length;
                stdDev = (float)Math.Sqrt(stdDev);
                Console.WriteLine(stdDev);
            }
            else
            {
                Console.WriteLine("Niepoprawna długość tablicy");
                continue;
            }
        }
    }
    void zad3()
    {
        int matDimensions;
        Random rand = new Random();
        Console.WriteLine("Podaj wymiar macierzy kwadratowych");
        matDimensions = Convert.ToInt32(Console.ReadLine());

        int[,] matrix1 = new int[matDimensions, matDimensions];
        int[,] matrix2 = new int[matDimensions, matDimensions];

        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                int num = rand.Next(-10, 10 + 1);
                matrix1[i, j] = num;
                num = rand.Next(-10, 10 + 1);
                matrix2[i, j] = num;
            }
        }
        Console.WriteLine("Wygenerowana pierwsza macierz: ");
        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                Console.Write(matrix1[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Wygenerowana druga macierz: ");
        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                Console.Write(matrix2[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Dodawanie macierzy: ");
        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                Console.Write(matrix1[i, j] + matrix2[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Odejmowanie macierzy: ");
        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                Console.Write(matrix1[i, j] - matrix2[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Mnożenie macierzy: ");
        int[,] resultMatrix = new int[matDimensions, matDimensions];
        for (int i = 0; i < matDimensions; i++) // Przechodzenie przez wiersze mat1
        {
            for (int j = 0; j < matDimensions; j++) // Przechodzenie przez kolumny mat2
            {
                int suma = 0;
                for (int k = 0; k < matDimensions; k++) // Przechodzenie przez elementy
                {
                    suma += matrix1[i, k] * matrix2[k, j];
                }
                resultMatrix[i, j] = suma; // Przypisanie wyniku do macierzy wynikowej
            }
        }
        for (int i = 0; i < matDimensions; i++)
        {
            for (int j = 0; j < matDimensions; j++)
            {
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}