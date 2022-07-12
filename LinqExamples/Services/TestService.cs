using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinqExamples.Models;
using LinqExamples.ViewModels;

namespace LinqExamples.Services
{
    internal class TestService
    {
        private static readonly List<Student> students;

        private static readonly List<TestScore> testScores;

        static TestService()
        {
            students = new List<Student>();
            testScores = new List<TestScore>();

            const int NUM_STUDENTS = 100;
            var random = new Random();

            for (int i = 1; i <= NUM_STUDENTS; i++)
            {
                students.Add(new Student { Id = i, Name = $"Student {i}" });

                testScores.Add(new TestScore { StudentId = i, Subject = "Maths", Marks = random.Next(0, 100) });
                testScores.Add(new TestScore { StudentId = i, Subject = "Science", Marks = random.Next(0, 100) });
                testScores.Add(new TestScore { StudentId = i, Subject = "Social Science", Marks = random.Next(0, 100) });
            }
        }

        internal void GenerateMarksCard()
        {
            var marksCardList = students.Join(testScores, s => s.Id, ts => ts.StudentId, (student, score) => new
            {
                StudentId = student.Id,
                student.Name,
                score.Subject,
                score.Marks
            });

            Console.WriteLine(new String('=', 80));
            Console.WriteLine($"Student ID, Student Name, Subject, Marks");
            Console.WriteLine(new String('=', 80));

            foreach (var item in marksCardList)
            {
                Console.WriteLine($"{item.StudentId}, {item.Name}, {item.Subject}, {item.Marks}");
            }

            Console.WriteLine(new string('=', 80));
        }

        public Student HighestScorerIn(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentOutOfRangeException(nameof(subjectName));

            //var highestScore = testScores
            //                        .Where(ts => ts.Subject == subjectName)
            //                        .Max(ts => ts.Marks);

            //var student = testScores
            //                .Where(ts => ts.Subject == subjectName && ts.Marks == highestScore)
            //                .Join(students,
            //                    ts => ts.StudentId,
            //                    s => s.Id,
            //                    (ts, s) => s
            //                ).SingleOrDefault();

            var student = testScores
                            .Where(ts => ts.Subject == subjectName)
                            .OrderByDescending(ts => ts.Marks)
                            .Join(students,
                                ts => ts.StudentId,
                                s => s.Id,
                                (ts, s) => s
                            ).FirstOrDefault();

            return student;
        }

        public IEnumerable<ScoreViewModel> TopFiveScorersIn(string subjectName)
        {
            throw new NotImplementedException();
        }

        public PaginatedDataViewModel<TotalScoreViewModel> GetTotalScores
            (int startRow, int noOfRows)
        {
            var totalScores = students.Join(testScores, s => s.Id, ts => ts.StudentId, (s, ts) => new
            {
                ts.StudentId,
                StudentName = s.Name,
                ts.Marks
            })
            .GroupBy(e => new { e.StudentId, e.StudentName })
            .Select(e =>
            {
                var f = e;

                return new TotalScoreViewModel
                {
                    StudentId = e.Key.StudentId,
                    StudentName = e.Key.StudentName,
                    TotalMarks = e.Sum(a => a.Marks)
                };
            }).Skip(noOfRows * (startRow / noOfRows)).
            Take(15).ToList();

            var totalCount = students.Join(testScores, s => s.Id, ts => ts.StudentId, (s, ts) => new
            {
                ts.StudentId,
                StudentName = s.Name,
                ts.Marks
            })
            .GroupBy(e => new { e.StudentId, e.StudentName })
            .Select(e =>
            {
                var f = e;

                return new TotalScoreViewModel
                {
                    StudentId = e.Key.StudentId,
                    StudentName = e.Key.StudentName,
                    TotalMarks = e.Sum(a => a.Marks)
                };
            }).Count();

            var ret = new PaginatedDataViewModel<TotalScoreViewModel>
            {
                TotalRows = totalCount,
                Rows = totalScores


            };







            return ret;
        }
    }
}
