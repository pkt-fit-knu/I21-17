using static System.Console;

namespace Classifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Classifier classifier = new Classifier(@"D:\Учёба\Лабы\Articles1", @"D:\Учёба\Лабы\Articles2", @"D:\Учёба\Лабы\stopwords.txt", @"D:\Учёба\Лабы");

            classifier.CalculateTF_IDF();

            classifier.PrepareWords(@"D:\Учёба\Лабы\newArticle.txt", 12);

            WriteLine(classifier.Classify(new Document(null, @"D:\Учёба\Лабы\tf - idf12.txt"), 12, 4));

            ReadKey();
        }
    }
}
