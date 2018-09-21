using UnityEngine;

public class StringPermuter
{
    private string _word;

    public StringPermuter(string word)
    {
        _word = word;
    }

    public void Permute()
    {
        Process(_word.Length);
    }

    private void Process(int c)
    {
        if (c == 1)
        {
            return;
        }

        for (var i = 0; i < c; i++)
        {
            Process(c - 1);
            Rotate(c);
        };
    }


    private void Rotate(int c)
    {
        var target = _word.Length - c;
        Debug.Log("\n" + _word + " >>>> " + _word.Substring(0, target));

        _word = _word.Substring(0, target)
            + _word.Substring(target + 1)
            + _word.Substring(target, 1);

    }
}