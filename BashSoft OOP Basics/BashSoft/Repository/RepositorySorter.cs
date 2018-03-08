using System.Collections.Generic;
using System.Linq;
using BashSoft.Exceptions;
using BashSoft.IO;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison.Equals("ascending"))
            {
                PrintStudents(studentsWithMarks.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison.Equals("descending"))
            {
                PrintStudents(studentsWithMarks.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new InvalidComparisonQueryException();
                //OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.DisplayStudent(keyValuePair);
            }
        }
    }
}
