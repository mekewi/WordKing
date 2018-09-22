using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordHandler : MonoBehaviour {

    private bool isSuccessful;
    public GameObject successObject;
    public GameObject hiddenObject;
    public Text wordText;
    public bool IsSuccessful
    {
        get
        {
            return isSuccessful;
        }

        set
        {
            if (value == true)
            {
                successObject.SetActive(true);
                hiddenObject.SetActive(false);
            }else{
                successObject.SetActive(false);
                hiddenObject.SetActive(true);
            }
            isSuccessful = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
    void Awake(){
        successObject.SetActive(false);
        hiddenObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
