using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WordDictionary : ScriptableObject {

    private List<WordDictionaryEvents> listeners = new List<WordDictionaryEvents>();

    public Dictionary<int, List<string>> allWords;
    public List<string> backtrackingWords;
    public Dictionary<int, List<string>> wordsByLength;
    [Range(3,8)]
    public int wordLength = 0;
    public string realWord;

    public string currentWord;
    public void Raise(){
        for (int i = listeners.Count-1; i >=0 ; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    internal void UnregisterListener(WordDictionaryEvents dictionaryEvents)
    {
        if (listeners.Contains(dictionaryEvents))
        {
            listeners.Remove(dictionaryEvents);
        }
    }
    internal void RegisterListener(WordDictionaryEvents dictionaryEvents)
    {
        if (!listeners.Contains(dictionaryEvents))
        {
            listeners.Add(dictionaryEvents);
        }
    }


    public IEnumerator LoadWordData() {

		string dictionaryPath = System.IO.Path.Combine (Application.streamingAssetsPath, "wordsByFrequency.txt");

		string result = null;

		if (dictionaryPath.Contains ("://")) {
			WWW www = new WWW (dictionaryPath);
			yield return www;
			result = www.text;
		} else
			result = System.IO.File.ReadAllText (dictionaryPath);

		var words = result.Split ('\n');

		//collect words
		allWords = new Dictionary<int, List<string>> ();
		wordsByLength = new Dictionary<int, List<string>> ();

		var index = 0;

		foreach (var w in words) {

			if (string.IsNullOrEmpty(w) ||  w.Length < 3)
				continue;

			var word = w.TrimEnd ();

			if (word.IndexOf ('#') != -1) {
				index++;
			} else {
                
				if (!allWords.ContainsKey (word.Length)) 
					allWords.Add (word.Length, new List<string> ());
				
				allWords[word.Length].Add (word);

				if (index < 1) {
					if (!wordsByLength.ContainsKey (word.Length))
						wordsByLength.Add (word.Length, new List<string> ());
					wordsByLength [word.Length].Add (word);
				}
			}
		}
        Raise();
	}
    private string ScrambleWord(string word)
    {
        System.Random rnd = new System.Random();
        int rnd_position;
        int scramleWordLenght = word.Length;

        string scrambledWord = "";
        string[] letter = new string[scramleWordLenght];

        for (int i = 0; i <= (scramleWordLenght - 1); i++)
        {
        repeat:
            rnd_position = Convert.ToInt16((scramleWordLenght) * rnd.NextDouble());

            if (rnd_position == scramleWordLenght || letter[rnd_position] != null)
            {
                goto repeat;
            }
            else
            {
                letter[rnd_position] = word.Substring(i, 1);
            }
        }

        for (int j = 0; j <= (scramleWordLenght - 1); j++)
        {
            scrambledWord += letter[j];
        }

        return scrambledWord;
    }

	public bool IsValidWord (string word)	{
		return allWords[word.Length].Contains(word);
	}

    public string ChooseRandomWord (bool all = false) {
		
		if (all) {
            var alllist = allWords [wordLength];
            currentWord = alllist[UnityEngine.Random.Range(0, alllist.Count)];
            realWord = currentWord;
            currentWord = ScrambleWord(realWord);
            return currentWord;
		}
        var list = wordsByLength [wordLength];
        currentWord = list[UnityEngine.Random.Range(0, list.Count)];
        realWord = currentWord;
        backtrackingWords.Clear();
        backtrackingWords.Add(realWord);
        getAng(realWord,"");

        currentWord = ScrambleWord(realWord);
        return currentWord;
	}

    public void getAng(string word, string anagram)
    {
        if (anagram != null && anagram != realWord && anagram.Length > 1)
        {
            Debug.Log("\n" + anagram);
            if (wordsByLength.ContainsKey(anagram.Length) && wordsByLength[anagram.Length].Contains(anagram) && !backtrackingWords.Contains(anagram))
            {
                backtrackingWords.Add(anagram);
            }
        }
        if (word == null || word == "")
        {
            return;
        }
        for (int i = 0; i < word.Length; i++)
        {
            anagram += word[i];
            getAng((Slice(word, 0, i) + word.Substring(i + 1)), anagram);
            anagram = Slice(anagram, 0, anagram.Length - 1);
        }
    }
    public string Slice(string source, int start, int end)
    {
        if (end < 0) // Keep this for negative end support
        {
            end = source.Length + end;
        }
        int len = end - start;               // Calculate length
        return source.Substring(start, len); // Return Substring of length
    }

	public List<string> MatchesAPattern (char[] chars){
		var result = new List<string> ();
		var list = wordsByLength [chars.Length];
		foreach (var word in list) {
			var match = true;
			for (var i = 0; i < word.Length; i++) {
				if (chars [i] != '-' && word [i] != chars [i]) {
					match = false;
					break;
				}
			}
			if (match)
				result.Add (word);
		}

		return result;
	}

}
