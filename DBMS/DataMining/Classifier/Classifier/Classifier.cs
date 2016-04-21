using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Classifier
{
    class Classifier
    {
        private readonly string path1, path2, stopWordsPath, TF_IDF_Directory;

        public Classifier(string path1, string path2, string stopWordsPath, string TF_IDF_Directory)
        {
            if(Directory.Exists(path1) && Directory.Exists(path2) && File.Exists(stopWordsPath) && Directory.Exists(TF_IDF_Directory))
            {
                this.path1 = path1;
                this.path2 = path2;
                this.stopWordsPath = stopWordsPath;
                this.TF_IDF_Directory = TF_IDF_Directory;
            }
            else
            {
                throw new ArgumentException("Some path doesn't exist");
            }
        }

        public void CalculateTF_IDF()
        {
            List<string> texts = new List<string>();

            GetTexts(path1, ref texts);
            GetTexts(path2, ref texts);

            List<List<string>> words = new List<List<string>>();

            foreach(string text in texts)
            {
                words.Add(text.Split(new char[] {' ', ',', '.', '(', ')', '\"', '\\', '/', ':', ';', '!', '?', '\r', '\n', '%', '$', '_', '[', ']', '{', '}'}, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            string[] stopWords = File.ReadAllLines(stopWordsPath);

            foreach(var list in words)
            {
                double num;

                list.RemoveAll(item => stopWords.Contains(item));
                list.RemoveAll(item => double.TryParse(item, out num));
            }

            using (StreamWriter writer = new StreamWriter(TF_IDF_Directory + "\\tf - idf.txt"))
            {
                foreach(var list in words)
                {
                    List<string> uniqueWords = new List<string>();

                    foreach(string word in list)
                    {
                        if(!uniqueWords.Contains(word))
                        {
                            uniqueWords.Add(word);

                            double tf = (double)list.Where(w => w == word).Count() / list.Count;
                            double idf = Math.Log10((double)words.Count / words.Where(l => l.Contains(word)).Count());

                            writer.WriteLine(word + "=" + tf * idf);
                        }
                    }

                    writer.WriteLine();
                }
            }
        }

        void GetTexts(string path, ref List<string> list)
        {
            foreach (string fileName in Directory.GetFiles(path))
            {
                list.Add(File.ReadAllText(fileName).ToLower());
            }
        }
    }
}
