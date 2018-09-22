using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktrackWordHandler : MonoBehaviour {

    public WordDictionary wordDictionary;
    public string myWord;
    public void TouchEnter()
    {
        Debug.Log("Mouse Enterrrr");
        wordDictionary.onSelectedWord(myWord, transform.position);
    }
    public void TouchExit()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
