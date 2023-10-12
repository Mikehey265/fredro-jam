using UnityEngine;
using UnityEngine.InputSystem;

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
        if (other.CompareTag("Player"))
        {
            if (Keyboard.current.eKey.isPressed)
            {
                Debug.Log("dofjghsoi");
                Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
            }
        }
        //print("Inside");
    }
}
