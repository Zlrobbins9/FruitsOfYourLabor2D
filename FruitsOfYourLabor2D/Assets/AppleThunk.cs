using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleThunk : MonoBehaviour
{
    TextMesh test;
    MeshRenderer wordSpawn;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<TextMesh>();
        wordSpawn = GetComponent<MeshRenderer>();
        wordSpawn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ApplPos = GameObject.Find("Apple").transform.position;
        transform.position = new Vector2(ApplPos.x, ApplPos.y + 2.5f);
    }

    public void UpdateText(string updatedText)
    {
        test.text = updatedText;
    }
}
