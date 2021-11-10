using Interview.Exercise.WordProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Interview.Exercise.Test
{
    [TestClass]
    public class ProcessorTest
    {
        private IDictionary<string, ProcessorTestData> _testData;
        private Processor _processor;
        [TestInitialize]
        public void Init()
        {
            _processor = new Processor();
            _testData = new Dictionary<string, ProcessorTestData>
            {
                {"data1", new ProcessorTestData
                    {
                        Data = new ProcessData("hit", "cog", new string[] { "dog", "lot", "log", "cog", "hot", "dot" }),
                        Result = new string[] { "hit", "hot", "dot", "dog", "cog" }
                    }
                },
                {"data2", new ProcessorTestData
                    {
                        Data = new ProcessData("git", "lit", new string[] { "sit", "hit", "fit", "bit", "lit" }),
                        Result = new string[] { "git", "lit" }
                    }
                },
                {"data3", new ProcessorTestData
                    {
                        Data = new ProcessData("git", "lio", new string[] { "sit", "hit", "fit", "bit", "lit" }),
                        Result = new string[] { "git", "lit" }
                    }
                },
                {"data4", new ProcessorTestData
                    {
                        Data = new ProcessData("ast", "cog", new string[] { "dog", "lot", "log", "cog", "hot", "dot" }),
                        Result = new string[] { "hit", "hot", "dot", "dog", "cog" }
                    }
                },
                {"data5", new ProcessorTestData
                    {
                        Data = new ProcessData("hit", "cog", new string[] { "eeg", "rrt", "lr1", "rqw", "rrr", "qqq" }),
                        Result = new string[] { "hit", "hot", "dot", "dog", "cog" }
                    }
                }
            };
        }

        [TestMethod]
        [DataRow("data1")]
        [DataRow("data2")]
        public void ProcessWithOk(string data)
        {
            var processData = _testData[data].Data;
            var expectedResult = _testData[data].Result;
            var result = _processor.Process(processData);
            Assert.IsTrue(result.Length >= 2);
            Assert.AreEqual(result.Length, expectedResult.Length);
            CollectionAssert.AreEquivalent(result, expectedResult);
        }

        [TestMethod]
        [DataRow("data3")]
        [DataRow("data4")]
        [DataRow("data5")]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessWithParameterError(string data)
        {
            var processData = _testData[data].Data;
            var expectedResult = _testData[data].Result;
            var result = _processor.Process(processData);
        }


        public class ProcessorTestData
        {
            public ProcessData Data { get; set; }
            public string[] Result { get; set; }
        }
    }
}
