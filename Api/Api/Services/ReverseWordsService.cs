using System.Linq;
using Castle.Core.Internal;

namespace Api.Services
{
    public class ReverseWordsService : IReverseWordsService
    {
        public string ReverseWordsInSentence(string sentence)
        {
            var words = sentence
                .Split(' ')
                .ToList()
                .Select(s => new string(s.ToCharArray().Reverse().ToArray()));
            
            return string.Join(" ", words);
        }
    }
}