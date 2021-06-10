using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> registered = new Dictionary<string, List<string>>();
            string courseAndStudent;
            string points = "";


            while ((courseAndStudent = Console.ReadLine()) != "no more time")
            {
                string[] courseSplitted = courseAndStudent.Split(" -> ").ToArray();
                string studentName = courseSplitted[0];
                string courseName = courseSplitted[1];
                points = courseSplitted[2];


                if (!registered.ContainsKey(courseName))
                {
                    registered.Add(courseName, new List<string>() { studentName });
                }


                else
                {
                    registered[courseName].Add(studentName);
                }
            }


            foreach (var course in registered.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count()} participants");

                foreach (var name in course.Value.OrderBy(x => x))
                {
                    int count = 0;

                    Console.WriteLine();
                    Console.WriteLine($"{count++}. {name} <::> {points}");
                }
            }
        }
    }
}