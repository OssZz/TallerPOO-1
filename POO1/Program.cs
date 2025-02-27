﻿using System;
using System.Collections.Generic;

namespace Taller01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var t1 = new Time();
                var t2 = new Time(2);
                var t3 = new Time(9, 34);
                var t4 = new Time(19, 45, 56);
                var t5 = new Time(11, 3, 45, 678);

                var times = new List<Time> { t1, t2, t3, t4, t5 };

                foreach (Time time in times)
                {
                    Console.WriteLine($"Time: {time}");
                    Console.WriteLine($"\tMilliseconds: {time.ToMilliseconds(),15:N0}");
                    Console.WriteLine($"\tSeconds     : {time.ToSeconds(),15:N0}");
                    Console.WriteLine($"\tMinutes     : {time.ToMinutes(),15:N0}");

                    Time sumTime = time.Add(t3);
                    bool otherDay = time.IsOtherDay(t3);

                    Console.WriteLine($"\tAdd         : {sumTime}");
                    Console.WriteLine($"\tIs Other day: {otherDay}");
                    Console.WriteLine();
                }

                var t6 = new Time(45, -7, 90, -87);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}