using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryBlockView : MonoBehaviour
{
    public StoriesModel.StoryModel storyModel;

    public void Display(StoriesModel.StoryModel storyModel)
    {
        this.storyModel = storyModel;
        GetComponentInChildren<Text>().text = storyModel.TitleSummary;
    }

	public void SetRemoved()
	{
		var renderer = GetComponent<Renderer>();
		var color = Color.black;
		renderer.material.color = color;
	}
}
