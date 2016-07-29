using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour
{
    public StoryLogic storyLogic;

    private SteamVR_TrackedObject trackedObject;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        storyLogic.HoverIn(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        storyLogic.HoverOut(other.gameObject);
        storyLogic.Unselect(other.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            storyLogic.Select(other.gameObject, gameObject);
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            storyLogic.Unselect(other.gameObject);
            Transform origin = trackedObject.origin ? trackedObject.origin : trackedObject.transform.parent;
            if (origin != null)
            {
                storyLogic.ApplyForce(other.gameObject, origin.TransformVector(device.velocity), origin.TransformVector(device.angularVelocity));
            }
        }
    }
}
