﻿using System;

namespace E_learn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Newr:
            Console.Write("Введите число: ");
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                string check = num.ToString();
                string[] num1 = new string[6];
                for (int i = 0, k = 0; i < 6; i++, k++)
                {
                    num1[i] = check.Substring(i,k);
                }
                if (((check.Length == 6) & (num > 0)) | ((num < 0) & (check.Length == 7)))
                {
                    if (num < 0)
                    {
                        Console.WriteLine($"Первое число: " + num1[1] + "\nТретье число: " + num1[3] + "\nШестое число: " + num1[6]);
                    }
                    else Console.WriteLine($"Первое число: {num1[0]}\nТретье число: {num1[2]}\nШестое число: {num1[5]}\nСумма: ");
                }
                else
                {
                    Console.WriteLine("В числе должно быть 6 символов!");
                    goto Newr;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введи число!");
                goto Newr;
            }
            Console.ReadKey();
        }
    }
}
