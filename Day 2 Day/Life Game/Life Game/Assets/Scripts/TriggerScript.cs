using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered the trigger: " + other.gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is inside the trigger: " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited the trigger: " + other.gameObject.name);
    }
}