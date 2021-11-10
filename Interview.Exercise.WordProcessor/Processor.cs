using System;
using System.Linq;
using System.Collections.Generic;

namespace Interview.Exercise.WordProcessor
{
    public class Processor : IProcessor
    {
        public string[] Process(ProcessData data)
        {
            var originalList = new List<string>();
            originalList.AddRange(data.WordList);
            var resultList = new List<string>();
            var newList = new List<string>
            {
                data.BeginWord
            };
            if(!data.WordList.Contains(data.EndWord))
            {
                throw new ArgumentException("Invalid parameter", "EndWord");
            }
            var lastProcessedWord = string.Empty;
            while (newList.Count > 0)
            {
                var innerList = new List<string>();

                foreach (var word in newList)
                {
                    if (IsValidWord(data.EndWord, word))
                    {
                        resultList.Remove(lastProcessedWord);
                        resultList.Add(word);
                        resultList.Add(data.EndWord);
                        return resultList.ToArray();
                    }

                    for (var index = originalList.Count; index > 0; index--)
                    {
                        var nextWord = originalList[index - 1];
                        if (!IsValidWord(word, nextWord))
                        {
                            continue;
                        }
                        innerList.Add(originalList[index - 1]);
                        originalList.Remove(nextWord);
                    }
                    resultList.Add(word);
                    lastProcessedWord = word;
                }
                newList = innerList;
            }
            if (resultList.Count < 2) throw new ArgumentException("Invalid parameter", "BeginWord");
            return resultList.ToArray();
        }
        private static bool IsValidWord(string sourceWord, string word)
        {
            var ocurrences = 0;
            for (var index = 0; index < sourceWord.Length; index++)
            {
                if (word[index] != sourceWord[index])
                {
                    ocurrences++;
                    if (ocurrences > 1) return false;
                }
            }
            return ocurrences == 1;
        }
    }
}
