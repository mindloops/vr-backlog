using UnityEngine;
using Valve.VR;
using UnityEngine.VR;

public class StoryStacker : MonoBehaviour
{
    public GameObject storyBlockObject;
	public StoryLogic storyLogic;

    void Start()
    {		
        var playAreaEdge = PlayArea.GetPlayAreaRightOrDefault(1.8f);        
        var stories = storyLogic.StoriesModel.Stories;
        for (var i = 0; i < stories.Count; i++)
        {
            GameObject storyBlock = (GameObject)Instantiate(storyBlockObject, new Vector3(0, 0.50f + (i * 0.16f), playAreaEdge), Quaternion.identity);
			storyBlock.GetComponent<StoryBlockView>().Display(stories[i]);
        }
    }
}
