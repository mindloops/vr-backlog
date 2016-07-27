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
            GameObject storyDetails = (GameObject)Instantiate(storyDetailsObject, new Vector3(1.5f, 1.0f, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
            storyDetails.GetComponent<StoryDetailsView>().Display(block.storyModel);
            // z-axis is scaled, compensate
            storyDetails.GetComponent<HingeJoint>().anchor = new Vector3(0.0f, 0.0f, -7.5f);
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
