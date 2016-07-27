using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour
{
    public GameObject storyDetailsObject;

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
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            StoriesModel model = new StoriesModel();
            GameObject storyDetails = (GameObject)Instantiate(storyDetailsObject, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
            storyDetails.GetComponent<StoryDetailsOutput>().Display(model.Stories[0]);
           // other.attachedRigidbody.isKinematic = true;
           // other.gameObject.transform.SetParent(gameObject.transform);
        }
        /*if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.attachedRigidbody.isKinematic = false;
            other.gameObject.transform.SetParent(null);
        }*/
    }

    private StoryBlockController GetController(GameObject gameObject)
    {
        return gameObject.GetComponent<StoryBlockController>();
    }
}
