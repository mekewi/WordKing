using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour {

    public int AnswerWord;
    public WordDictionary wordDictionary;
    private string myWord;
    public List<WordHandler> wordHandlers;
    public string MyWord{
        get{
            return myWord;
        }
        set{
            
            myWord = value;
            generateWords();
        }
    }
    public void generateWords(){
        for (int i = 0; i < MyWord.Length; i++)
        {
            WordHandler wordHabler = Instantiate(wordDictionary.AnsweredWord, transform, false).GetComponent<WordHandler>();
            wordHabler.wordText.text = MyWord[i].ToString();
            wordHandlers.Add(wordHabler);
        }
    }
	void Start () {
		
	}
	void Update () {
        if (wordDictionary.ValidWords.Contains(MyWord))
        {
            for (int i = 0; i < wordHandlers.Count; i++)
            {
                wordHandlers[i].IsSuccessful = true;
            }
        }
    }
}
