using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Models
{
    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get { return enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public Student(string name)
        {
            this.UserName = name;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadEnrolledInGivenCourse, this.userName, course.Name));
                //return;
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
                //OutputWriter.DisplayException(ExceptionMessages.NotEnrolledInCourse);
                //return;
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(nameof(scores), ExceptionMessages.InvalidNumberOfScores);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                //return;
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam =
                scores.Sum() / (double) (Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}
