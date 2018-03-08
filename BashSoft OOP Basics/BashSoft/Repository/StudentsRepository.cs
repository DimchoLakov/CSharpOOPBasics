using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        private bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter repoSorter, RepositoryFilter repoFilter)
        {
            this.filter = repoFilter;
            this.sorter = repoSorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new DataAlreadyInitialisedException();
                //OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
                //return;
            }

            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();

            OutputWriter.WriteMessageOnNewLine($"Reading data...");
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + @"\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex regex = new Regex(pattern);

                string[] allInputLines = File.ReadAllLines(path);


                foreach (string line in allInputLines)
                {
                    if (!string.IsNullOrEmpty(line) && regex.IsMatch(line))
                    {
                        Match currentMatch = regex.Match(line);

                        string courseName = currentMatch.Groups[1].Value;
                        string studentName = currentMatch.Groups[2].Value;

                        string scoresStr = currentMatch.Groups[3].ToString();

                        try
                        {
                            int[] scores = scoresStr
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(studentName))
                            {
                                this.students.Add(studentName, new Student(studentName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (Exception fex)
                        {
                            OutputWriter.DisplayException($"{fex.Message} at line : {line}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine($"Data read!");
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);

            return false;
        }

        public void GetStudentScoreFromCourse(string courseName, string studentName)
        {
            if (this.IsQueryForStudentPossible(courseName, studentName))
            {
                OutputWriter.DisplayStudent(new KeyValuePair<string, double>(studentName, this.courses[courseName].StudentsByName[studentName].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoreFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void OrderAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(k => k.Key, v => v.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(k => k.Key, v => v.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }
    }
}
