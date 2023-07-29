using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class GradeBook
    {
        private int[,] grades;

        public string CourseName { get; }

        public GradeBook(string name, int[,] gradesArray)
        {
            CourseName = name;
            grades = gradesArray;
        }

        public void DisplayMessage()
        {
            Console.WriteLine($"Welcome to the grade book for\n{CourseName}!\n");
        }

        public void processGrades()
        {

            OutpuGrades();

            Console.WriteLine($"\nLowest grade in the grade book is{GetMinimum()}" + $"\nHighest grade in the grade book is {GetMaximum()}\n");

            OutputBarChart();
        }

       
        

        public int GetMinimum()
        {

            var lowGrade = grades[0, 0];

            foreach (var grade in grades)
            {

                if (grade < lowGrade)
                {
                    lowGrade = grade;

                }

            }

            return lowGrade;

        }

        public int GetMaximum()
        {

            var highGrade = grades[0, 0];

            foreach (var grade in grades)
            {

                if (grade > highGrade)
                {
                    highGrade = grade;
                }

            }

            return highGrade;

        }

        public double GetAverage(int student)
        {
            var gradeCount = grades.GetLength(1);
            var total = 0.0;

            for (var exam = 0; exam < gradeCount; ++exam)
            {
                total += grades[student, exam];
            }
            return total / gradeCount;
        }

        public void OutputBarChart()
        {
            Console.WriteLine("Overal grade distribution:");

            var frequency = new int[11];


            foreach (var grade in grades)
            {
                ++frequency[grade / 10];

            }

            for (var count = 0; count < frequency.Length; ++count)
            {

                if (count == 10)
                {
                    Console.Write("100:");
                }
                else
                {
                    Console.Write($"{count * 10:D2}-{count * 10 + 9:D2}:");
                }

                for (var stars = 0; stars < frequency[count]; ++stars)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

        }

        public void OutpuGrades()
        {
            Console.WriteLine("The grades are:\n");
            Console.Write("       ");

            for (var test = 0; test < grades.GetLength(1); ++test)
            {
                Console.Write($"Test{test + 1}");
            }


            Console.WriteLine("Average");

            for (var student = 0; student < grades.GetLength(0); ++student)
            {
                Console.Write($"Student{student + 1,2}");

                for (var grade = 0; grade < grades.GetLength(1); ++grade)
                {
                    Console.Write($"{grades[student, grade],8}");
                }

                Console.WriteLine($"{GetAverage(student),9:F}");
            }
            Console.ReadLine();
        }
        }

    }

