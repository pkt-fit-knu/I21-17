using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Classifier
{
    class Classifier
    {
        private readonly string path1, path2, TF_IDF_Directory;

        List<List<string>> words;
        string[] stopWords;

        public Classifier(string path1, string path2, string stopWordsPath, string TF_IDF_Directory)
        {
            if(Directory.Exists(path1) && Directory.Exists(path2) && File.Exists(stopWordsPath) && Directory.Exists(TF_IDF_Directory))
            {
                this.path1 = path1;
                this.path2 = path2;
                this.TF_IDF_Directory = TF_IDF_Directory;

                stopWords = File.ReadAllLines(stopWordsPath);
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

            words = new List<List<string>>();

            foreach(string text in texts)
            {
                words.Add(text.Split(new char[] {' ', ',', '.', '(', ')', '\"', '\\', '/', ':', ';', '!', '?', '\r', '\n', '%', '$', '_', '[', ']', '{', '}'}, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            foreach(var list in words)
            {
                double num;

                list.RemoveAll(item => stopWords.Contains(item));
                list.RemoveAll(item => double.TryParse(item, out num));
            }

            int index = 0;

            foreach (var list in words)
            {
                WriteTF_IDF(list, index);

                ++index;
            }
        }

        public void PrepareWords(string path, int index)
        {
            List<string> words = File.ReadAllText(path).ToLower().Split(new char[] { ' ', ',', '.', '(', ')', '\"', '\\', '/', ':', ';', '!', '?', '\r', '\n', '%', '$', '_', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            double num;

            words.RemoveAll(item => stopWords.Contains(item));
            words.RemoveAll(item => double.TryParse(item, out num));

            this.words.Add(words);

            WriteTF_IDF(words, index);
        }

        void WriteTF_IDF(List<string> list, int index)
        {
            using (StreamWriter writer = new StreamWriter(TF_IDF_Directory + $"\\tf - idf{index}.txt"))
            {
                List<string> uniqueWords = new List<string>();

                foreach (string word in list)
                {
                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);

                        double tf = (double)list.Where(w => w == word).Count() / list.Count;
                        double idf = Math.Log10((double)words.Count / words.Where(l => l.Contains(word)).Count());

                        writer.WriteLine(word + "=" + tf * idf);
                    }
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

        double CalculateTanimoto(Document first, Document second)
        {
            List<string> words = first.Terms.Keys.ToList();
            words.AddRange(second.Terms.Keys.ToList());

            double scalarProduct = 0, firstVectorNorm = 0, secondVectorNorm = 0;

            foreach(string word in words)
            {
                double firstMultiplier = 0, secondMultiplier = 0;

                if (!first.Terms.ContainsKey(word) && second.Terms.ContainsKey(word))
                {
                    secondMultiplier = second.Terms[word];
                }
                else if (first.Terms.ContainsKey(word) && !second.Terms.ContainsKey(word))
                {
                    firstMultiplier = first.Terms[word];
                }
                else if (first.Terms.ContainsKey(word) && second.Terms.ContainsKey(word))
                {
                    secondMultiplier = second.Terms[word];
                    firstMultiplier = first.Terms[word];
                }

                scalarProduct += firstMultiplier * secondMultiplier;
                firstVectorNorm += Math.Pow(firstMultiplier, 2);
                secondVectorNorm += Math.Pow(secondMultiplier, 2);
            }

            try
            {
                return scalarProduct / (firstVectorNorm + secondVectorNorm - scalarProduct);
            }
            catch(DivideByZeroException e)
            {
                return 0;
            }
        }

        public string Classify(Document newDoc, int numberOfDocuments, int k)
        {
            SortedList<double, string> nearestNeighbors = new SortedList<double, string>();

            for(int i = 0; i < numberOfDocuments / 2; ++i)
            {
                Document oldDoc = new Document("Programming", TF_IDF_Directory + "\\" + $"tf - idf{i}.txt");
                double distance = CalculateTanimoto(newDoc, oldDoc);

                AddNeighbor(k, ref nearestNeighbors, distance, oldDoc.Class);
            }

            for (int i = numberOfDocuments / 2; i < numberOfDocuments; ++i)
            {
                Document oldDoc = new Document("Health", TF_IDF_Directory + "\\" + $"tf - idf{i}.txt");
                double distance = CalculateTanimoto(newDoc, oldDoc);

                AddNeighbor(k, ref nearestNeighbors, distance, oldDoc.Class);
            }

            int programmingCount = 0, healthCount = 0;
            foreach(string s in nearestNeighbors.Values)
            {
                if(s == "Programming")
                {
                    ++programmingCount; 
                }
                else
                {
                    ++healthCount;
                }
            }

            return programmingCount > healthCount ? "Programming" : "Health";
        }

        void AddNeighbor(int k, ref SortedList<double, string> neighbors, double distance, string @class)
        {
            if(neighbors.Count < k)
            {
                neighbors.Add(distance, @class);
            }
            else if(distance > neighbors.Keys.Last())
            {
                neighbors.RemoveAt(k - 1);
                neighbors.Add(distance, @class);
            }
        }
    }
}
