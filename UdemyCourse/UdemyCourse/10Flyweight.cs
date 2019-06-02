using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding.Exercise
{
    public class Sentence
    {
        private string plainText;
        private Dictionary<int, WordToken> tokenDict = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            this.plainText = plainText;
        }

        public WordToken this[int index]
        {
            get
            {                
                if (tokenDict.ContainsKey(index)) return tokenDict[index];
                var token = new WordToken();
                tokenDict.Add(index, token);
                return token;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int index = 0;
            foreach (var word in plainText.Split(' '))
            {
                if (tokenDict.ContainsKey(index))
                {
                    if (tokenDict[index].Capitalize)
                    {
                        sb.Append(word.ToUpper());
                    }
                    else
                    {
                        sb.Append(word);
                    }
                }
                else
                {
                    sb.Append(word);
                }
                sb.Append(' ');
                index++;
            }
            sb.Remove(sb.Length - 2, 1);
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }


    public class Demo
    {
        public static void Main()
        {
            Sentence sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
        }
    }
}
