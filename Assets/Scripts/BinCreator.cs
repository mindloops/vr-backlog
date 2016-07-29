using UnityEngine;
using System.Collections;
using Valve.VR;
using UnityEngine.VR;

public class BinCreator : MonoBehaviour {

	public GameObject bin;

    public StoryLogic storyLogic;

	// Use this for initialization
	void Start () {
		CVRChaperone chaperone = VRSettings.enabled ? OpenVR.Chaperone : null;
		var rect = new HmdQuad_t();
		bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
		var playAreaEdge = 1.5f;
		if (success)
		{
			playAreaEdge = rect.vCorners2.v2 - 0.7f;
		}

		var gameObject = (GameObject) Instantiate(bin, new Vector3(-0.6f, 0.0f, playAreaEdge), Quaternion.Euler(new Vector3(270, 50, 90)));
        gameObject.GetComponent<BinTrigger>().storyLogic = storyLogic;
    }

}
