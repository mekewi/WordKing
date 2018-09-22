using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionAreaController : MonoBehaviour {

    private float numPoints;
    public float NumPoints
    {
        get
        {
            return wordDictionary.currentWord.Length;
        }
    }

    public Vector3 centrePos = new Vector3(0, 0, 32);
    public GameObject beadPrefab;
    public float radiusX = 4, radiusY = 2;
    public Vector3 pointPos;
    public WordDictionary wordDictionary;
    // Use this for initialization
    void Start()
    {
        DrowButtons();
    }	
    public void DrowButtons(){

        for (int pointNum = 0; pointNum < NumPoints; pointNum++)
        {
            // "i" now represents the progress around the circle from 0-1
            // we multiply by 1.0 to ensure we get a fraction as a result.
            float i = (pointNum * 1.0f) / NumPoints;
            // get the angle for this step (in radians, not degrees)
            var angle = i * Mathf.PI * 2;
            // the X &amp; Y position for this angle are calculated using Sin &amp; Cos
            float x = Mathf.Sin(angle) * radiusX;
            var y = Mathf.Cos(angle) * radiusY;
            Vector3 pos = new Vector3(x, y, 0) + centrePos;
            // no need to assign the instance to a variable unless you're using it afterwards:
            BacktrackWordHandler ButtonObject = Instantiate(beadPrefab, pos, Quaternion.identity, this.transform).GetComponent<BacktrackWordHandler>();
            Text buttonText = ButtonObject.gameObject.GetComponentInChildren<Text>();
            buttonText.text = wordDictionary.currentWord[pointNum].ToString();
            ButtonObject.myWord = buttonText.text;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
