using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    public GameObject AppleDialogue;
    public string Message = "ERROR: Default message not changed.";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Box entered");
        AppleDialogue.GetComponent<MeshRenderer>().enabled = true;
        AppleDialogue.GetComponent<AppleThunk>().UpdateText(Message);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Box exited");
        AppleDialogue.GetComponent<MeshRenderer>().enabled = false;
    }
}
