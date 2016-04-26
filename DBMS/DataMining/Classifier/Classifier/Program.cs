using System.Collections.Generic;

namespace Classifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Classifier classifier = new Classifier(@"D:\Учёба\Лабы\Articles1", @"D:\Учёба\Лабы\Articles2", @"D:\Учёба\Лабы\stopwords.txt", @"D:\Учёба\Лабы");

            classifier.CalculateTF_IDF();

            classifier.PrepareWords(@"D:\Учёба\Лабы\newArticle.txt", 12);

            List<Document> documents;
        }
    }
}
