using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdscript : MonoBehaviour
{

    public Camera PlayerCamera;
    public LayerMask RayLayerMask;
    private bool move = false;
    private bool destroy = false;
    private float mouseWheelRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int range = 2;

        RaycastHit hitInfo;

        Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hitInfo, range, RayLayerMask);

        GameObject activeobj = hitInfo.collider.gameObject;

        if(Input.GetButtonDown("Interact") && (activeobj.tag != "Ground"))
        {
            Debug.Log("hi");
            move = !move;
        }
        if(move && Input.GetButtonDown("Destroy") && (activeobj.tag != "Ground"))
        {
            destroy = true;
        }
        if(move)
        {
            mouseWheelRotation = 0;
            activeobj.transform.position = gameObject.transform.position;
            mouseWheelRotation += Input.mouseScrollDelta.y;
            activeobj.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
            if (destroy)
            {
                Destroy(activeobj);
                destroy = false;
                move = false;
            }
        }
    }
}
