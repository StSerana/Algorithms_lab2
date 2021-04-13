using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using NUnit.Framework;

namespace Algorithms_lab2
{
    public class Test
    {
        private static readonly Random Random = new Random();
        private static readonly XmlDocument xDoc = new XmlDocument();
        private List<string> orderedWordsCollection;
        private List<string> shuffledWordsCollection;
        
        [Test]
        public void RadixSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./RadixSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            RadixSort.MakeRadixSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }
        
    }
}