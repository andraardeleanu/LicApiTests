using TechTalk.SpecFlow;

namespace LicUiTests.Helpers
{
    [Binding]
    public static class Transforms
    {
        private static readonly Random Random = new Random();

        [StepArgumentTransformation("random no")]
        public static string RandomNumber(int min, int max)
        {
            Random random = new Random();
            return "1" + random.Next(min, max);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "1234567890ABCDEFGHIJ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
