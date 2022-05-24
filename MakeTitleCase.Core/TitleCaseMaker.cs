using System.Text;
using MakeTitleCase.Core.Configuration;

namespace MakeTitleCase.Core;

public class TitleCaseMaker
{
    private readonly HashSet<string> _excludedWords;

    public TitleCaseMaker(Config config)
    {
        _excludedWords = new(config.ExcludedWords);
    }

    public string MakeTitleCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) { return input; }

        string[] words = input.Split(' ');
        StringBuilder wordBuilder = new();
        for (int i = 0; i < words.Length; ++i)
        {
            if (_excludedWords.Contains(words[i].ToLower()))
            {
                words[i] = words[i].ToLower();
                continue;
            }
            else
            {
                wordBuilder.Clear();
                bool first = true;
                foreach (char c in words[i])
                {
                    if (first)
                    {
                        wordBuilder.Append(char.ToUpper(c));
                    }
                    else
                    {
                        wordBuilder.Append(char.ToLower(c));
                    }
                    first = false;
                }
                words[i] = wordBuilder.ToString();
            }
        }

        return string.Join(" ", words);
    }
}
