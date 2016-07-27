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
    }

    void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int) trackedObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            storyLogic.Select(other.gameObject);
        }
    }
}
