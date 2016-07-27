using UnityEngine;
using System.Collections;
using System;

public class StoryLogic : MonoBehaviour
{
	private StoriesModel storiesModel = new StoriesModel();

	public GameObject storyDetailsObject;

	public StoriesModel StoriesModel
	{
		get { return storiesModel; } 
	}

    public void HoverIn(GameObject gameObject)
    {
        SetSelected(gameObject, true);
    }

    public void HoverOut(GameObject gameObject)
    {
        SetSelected(gameObject, false);
    }

    public void Select(GameObject gameObject)
    {
        var block = gameObject.GetComponent<StoryBlockView>();
        if (block != null)
        {
            GameObject storyDetails = (GameObject)Instantiate(storyDetailsObject, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
            storyDetails.GetComponent<StoryDetailsView>().Display(block.storyModel);
        }
    }

	public void Remove(GameObject gameObject) {
		var block = gameObject.GetComponent<StoryBlockView>();
		if (block != null) {
			Debug.Log ("We gaan nu het block removen en uit het model halen");
		} else {
			throw new InvalidOperationException();
		}
	}

    private void SetSelected(GameObject gameObject, bool selected)
    {
        var view = GetSelectableView(gameObject);
        if (view != null)
        {
            view.SetSelected(selected);
        }
    }

    private SelectableView GetSelectableView(GameObject gameObject)
    {
        return gameObject.GetComponent<SelectableView>();
    }
}
