using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressionScript : MonoBehaviour
{
    public GameObject Apple;
    public Vector2 warpPoint;
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
        Debug.Log("Next part entered");
        Apple.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Apple.transform.position = warpPoint;
    }
}
