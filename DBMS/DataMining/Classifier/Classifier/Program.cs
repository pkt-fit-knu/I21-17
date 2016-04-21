namespace Classifier
{
    class Program
    {
        static void Main(string[] args)
        {
            new Classifier(@"D:\Учёба\Лабы\Articles1", @"D:\Учёба\Лабы\Articles2", @"D:\Учёба\Лабы\stopwords.txt", @"D:\Учёба\Лабы").CalculateTF_IDF();
        }
    }
}
