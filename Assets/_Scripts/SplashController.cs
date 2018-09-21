using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {
    public WordDictionary wordDictionary;
	// Use this for initialization
	void Start () {
        StartCoroutine(wordDictionary.LoadWordData());
	}
    public void dictionaryInitalized(){
        SceneManager.LoadSceneAsync("GameScene");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
