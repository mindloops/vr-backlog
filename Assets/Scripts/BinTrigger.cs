using UnityEngine;
using System.Collections;

public class BinTrigger : MonoBehaviour {

	public StoryLogic storyLogic;

	private SteamVR_TrackedObject trackedObject;

	void Awake()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	void OnTriggerStay(Collider other)
	{
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int) trackedObject.index);
		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("You have released Touch while colliding with " + other.name);
			if(other.name.Equals("StoryBlock")) {
				storyLogic.Remove(other.gameObject);	
			}
		}
	}

}
