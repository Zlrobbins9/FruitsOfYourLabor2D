using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleThunkBackup : MonoBehaviour
{
    TextMeshProUGUI test;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText(string updatedText)
    {
        test.text = updatedText;
    }
}
