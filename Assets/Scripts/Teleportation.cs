using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    public GameObject Portal;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //print("Inside");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        }
    }
}
