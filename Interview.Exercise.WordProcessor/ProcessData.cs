using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Exercise.WordProcessor
{
    public class ProcessData
    {
        public string BeginWord { get; set; }
        public string EndWord { get; set; }
        public IEnumerable<string> WordList { get; set; }

        public ProcessData() { }
        public ProcessData(string beginWord, string endWord, IEnumerable<string> wordList)
        {
            BeginWord = beginWord;
            EndWord = endWord;
            WordList = wordList;
        }


    }
}
