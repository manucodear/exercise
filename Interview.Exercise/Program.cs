using Interview.Exercise.WordProcessor;
using System;
using System.Diagnostics;

/*

Given a list of valid words, find the fewest number of transformations to get from the beginWord to the endWord.

A transformation is defined as a modification of only one letter in the word.
E.g. “him” ==> “hit”, but “him” =/=> “hut”

Example 1:

Input: 
   beginWord = "hit"
   endWord = "cog"
   wordList = ["dog", "lot", "log", "cog", "hot”, "dot"]

Output: ["hit", "hot", "dot", "dog", cog"]

Example 2: 

Input:
    beginWord: “git”
    endWord: “lit”
    wordList: [“sit”, “hit”, “fit”, “bit”, “lit”]

Output: ["git", "lit"]

*/

namespace Interview.Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data1 = new ProcessData
            {
                BeginWord = "hit",
                EndWord = "cog",
                WordList = new string[] { "dog", "lot", "log", "cog", "hot", "dot" }
            };
            
            var processor = new Processor();
            var list = processor.Process(data1);
            Console.WriteLine(string.Join(",", list));
            Console.ReadKey();
        }
    }
}
