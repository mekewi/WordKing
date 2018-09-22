using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public WordDictionary wordDictionary;
    public int lenght;
    public GameObject playGroundGameObject;
    public GameObject answerdObject;
    public List<string> currentBacktrackingWords;
    public LineRenderer linere;

	void Start () {
        
	}
    private void Awake()
    {
        StartCoroutine(wordDictionary.LoadWordData());
        wordDictionary.ChooseRandomWord();
        currentBacktrackingWords = wordDictionary.backtrackingWords;
        for (int d = 0; d < wordDictionary.backtrackingWords.Count; d++)
        {
            
            AnswerManager answerManager = Instantiate(answerdObject, playGroundGameObject.transform,false).GetComponent<AnswerManager>();
            answerManager.MyWord = wordDictionary.backtrackingWords[d];
        }
    }

    public void Update()
    {
        if ((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown(0))
        {
            wordDictionary.mousDown = true;
        }
        if ((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled))|| Input.GetMouseButtonUp(0))
        {
            wordDictionary.validateWord();
            wordDictionary.mousDown = false;
        }
        linere.positionCount = wordDictionary.buttonsPosition.Count;
        linere.SetPositions(wordDictionary.buttonsPosition.ToArray());
    }
}
