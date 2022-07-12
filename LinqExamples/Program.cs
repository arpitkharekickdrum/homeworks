using LinqExamples.Services;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new TestService();

            //service.GenerateMarksCard();

            //var highestScorerInMaths = service.HighestScorerIn("Maths");
            //Console.WriteLine(highestScorerInMaths);

            //var topFiveScorersInMaths = service.HighestScorerIn("maths");
            //Console.WriteLine(topFiveScorersInMaths);

            var totalScores = service.GetTotalScores(35,15);

            
                Console.WriteLine($"{totalScores.TotalRows}");

            foreach(var score in totalScores.Rows)
            {
                Console.WriteLine($"{score.StudentId}, {score.StudentName}, {score.TotalMarks}");
            }
            
        }
    }
}