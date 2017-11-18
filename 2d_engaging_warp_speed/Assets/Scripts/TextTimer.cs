using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour {

    TextMesh txtRef;
    [TextArea(3,10)]
    public string newText;
    public float time = 4;  //Seconds to read the text (by default is equal to 4)

    // Initialization
    void Start() {

        txtRef = GetComponent<TextMesh>();
        StartCoroutine(LateCall());

    }

    private IEnumerator LateCall() {

        yield return new WaitForSeconds(time);

        txtRef.text = newText;
    }
}
