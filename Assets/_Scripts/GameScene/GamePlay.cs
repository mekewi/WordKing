using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public WordDictionary wordDictionary;
    // Use this for initialization
    public int lenght;

	void Start () {
	}
    private void Awake()
    {
        wordDictionary.ChooseRandomWord();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
