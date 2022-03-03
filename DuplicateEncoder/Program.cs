using System.Text;

string input = "Pepa z Depa, huhuhu! :D";
DuplicateEncoder d = new DuplicateEncoder(input);

Console.WriteLine(input);
Console.WriteLine(d.Encode('/','|'));
Console.WriteLine(d.GetStatistics());
class DuplicateEncoder
{
    private readonly string _input;
    private readonly Dictionary<char, int> _charCount = new Dictionary<char, int>();
    public DuplicateEncoder(string input)
    {
        _input = input.ToLower();
        SetStatistics();
    }

    private void SetStatistics()
    {
        foreach (var c in _input)
        {
            if (_charCount.TryGetValue(c, out int count))
            {
                _charCount[c] = count + 1;
            }
            else
            {
                _charCount[c] = 1;
            }
        }
    }
    public string Encode(char appearMult = '_', char appearOnce = '!', int appearThreshold = 1)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var c in _input)
        {
            _charCount.TryGetValue(c, out int count);
            builder.Append(count > ap ? appearMult : appearOnce);
        }

        return builder.ToString();
    }

    public string GetStatistics()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var pair in _charCount)
        {
            builder.AppendLine($"{pair.Key} - {pair.Value}");
        }

        return builder.ToString();
    }
}