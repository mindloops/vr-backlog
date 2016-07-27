using UnityEngine;
using Valve.VR;
using UnityEngine.VR;

public class StoryStacker : MonoBehaviour
{
    public GameObject storyBlockObject;
	public Component storyLogic;

    void Start()
    {
		CVRChaperone chaperone = VRSettings.enabled ? OpenVR.Chaperone : null; 
        var rect = new HmdQuad_t();
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
        var playAreaEdge = 2.0f;
        if (success)
        {
            playAreaEdge = rect.vCorners2.v2 + 0.2f;
        }

		var stories = ((StoryLogic)storyLogic).StoriesModel.Stories;
        for (var i = 0; i < stories.Count; i++)
        {
            GameObject storyBlock = (GameObject)Instantiate(storyBlockObject, new Vector3(0, 0.50f + (i * 0.16f), playAreaEdge), Quaternion.identity);
			storyBlock.GetComponent<StoryBlockView>().Display(stories[i]);
        }
    }
}
