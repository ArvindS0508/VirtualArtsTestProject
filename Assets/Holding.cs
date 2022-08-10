using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour
{
    private bool triggerActive;

    private GameObject holdStuff;


    // Start is called before the first frame update
    void Start()
    {
        holdStuff = GameObject.FindGameObjectsWithTag("holdCheck")[0];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("holdCheck"))
        {
            triggerActive = true;
            holdStuff = other.transform.parent.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("holdCheck"))
        {
            triggerActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("hi");
            gameObject.transform.position = holdStuff.transform.position;
        }
    }
}