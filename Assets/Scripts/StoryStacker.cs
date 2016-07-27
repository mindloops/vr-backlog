using UnityEngine;
using Valve.VR;

public class StoryStacker : MonoBehaviour {

	public GameObject storyBlockObject;

	void Start () {
        var chaperone = OpenVR.Chaperone;
        var rect = new HmdQuad_t();
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
        var playAreaEdge = 2.0f;
        if (success)
        {
            playAreaEdge = rect.vCorners2.v2 + 0.2f;
        }

        for (var y = 0; y < 10; y++) {
			GameObject storyBlock = (GameObject) Instantiate(storyBlockObject, new Vector3(0, 0.50f + (y * 0.16f), playAreaEdge), Quaternion.identity);
            var controller = storyBlock.GetComponent<StoryBlockController>();
            controller.SetTextValue("Issue " + (y + 1));
            if (y % 2 == 0)
            {
                controller.SetSelected(true);
            }
		}
	}
}
