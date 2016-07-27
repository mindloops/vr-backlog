using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided with " + collider.name);
        var controller = collider.gameObject.GetComponent<StoryBlockController>();
        controller.SetSelected(true);
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("Collided with " + collider.name);
        var controller = collider.gameObject.GetComponent<StoryBlockController>();
        controller.SetSelected(false);
    }
}
