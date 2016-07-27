using UnityEngine;
using System.Collections;

public class StoryLogic : MonoBehaviour
{
    public GameObject storyDetailsObject;

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
