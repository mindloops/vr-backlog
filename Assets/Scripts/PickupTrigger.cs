using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {

	void OnTriggerStay(Collider collider)
    {
        Debug.Log("Collided with " + collider.name);
    }
}
