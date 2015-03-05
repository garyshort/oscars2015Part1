/*
Copyright (C) <2015>  <gary@duncodin.it>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as
published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1SourceCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateTimes = ProcessDateTimes();
            //var postingData = GetPostsPerDay(dateTimes);
            var postsPerDayPerHour = GetPostsNorm(dateTimes);
            return;
        }

        private static string GetPostsNorm(List<DateTime> dateTimes)
        {
            var csvString = "Day,NumberOfPostings\n";
            dateTimes.GroupBy(dt => new { dt.Day, dt.Hour })
                .ToList()
                .ForEach(group =>
                {
                    csvString +=
                        group.Key.Day.ToString()
                        + "~"
                        + group.Key.Hour.ToString()
                        + ",";

                    csvString += group.Count().ToString() + "\n";
                });
            return csvString;
        }

        private static string GetPostsPerDay(List<DateTime> dateTimes)
        {
            var csvString = "Day,NumberOfPostings\n";
            dateTimes.GroupBy(dt => dt.Day)
                .ToList()
                .ForEach(group =>
                {
                    csvString += group.Key.ToString() + ",";
                    csvString += group.Count().ToString() + "\n";
                });
            return csvString;
        }

        private static List<DateTime> ProcessDateTimes()
        {
            var dateTimes = new List<DateTime>();
            var path = @"C:\Users\Gary\Documents\Oscars2015\dateTimes.txt";
            var sr = File.OpenText(path);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var dt = DateTime.ParseExact(
                    line,
                    "ddd MMM dd HH:mm:ss zzzz yyyy",
                    CultureInfo.InvariantCulture);
                dateTimes.Add(dt);
            }
            return dateTimes;
        }
    }
}
