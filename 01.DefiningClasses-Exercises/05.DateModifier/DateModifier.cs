using System;
using System.Globalization;

public class DateModifier
{
    public int CalculateDaysBetweenDates(string firstDate, string secondDate)
    {
        DateTime first = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime second = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        return Math.Abs((int)(first - second).TotalDays);
    }
}
