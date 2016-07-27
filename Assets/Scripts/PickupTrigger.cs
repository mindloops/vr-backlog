using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObject;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        GetController(other.gameObject).SetSelected(true);
    }

    void OnTriggerExit(Collider other)
    {        
        GetController(other.gameObject).SetSelected(false);
    }

    void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int) trackedObject.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.attachedRigidbody.isKinematic = true;
            other.gameObject.transform.SetParent(gameObject.transform);
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.attachedRigidbody.isKinematic = false;
            other.gameObject.transform.SetParent(null);
        }
    }

    private StoryBlockController GetController(GameObject gameObject)
    {
        return gameObject.GetComponent<StoryBlockController>();
    }
}
