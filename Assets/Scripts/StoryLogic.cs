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

    public void Select(GameObject selectedObject, GameObject controller)
    {
        var block = selectedObject.GetComponent<StoryBlockView>();
        if (block != null)
        {
            var playAreaEdge = PlayArea.GetPlayAreaFrontOrDefault(1.8f) - 0.1f;
            GameObject storyDetails = (GameObject)Instantiate(storyDetailsObject, new Vector3(playAreaEdge, 1.0f, 0.0f), Quaternion.Euler(0.0f, -90.0f, 0.0f));
            storyDetails.GetComponent<StoryDetailsView>().Display(block.storyModel);
        }

        var details = selectedObject.GetComponent<StoryDetailsView>();
        if (details != null)
        {
            var detailsRigidBody = selectedObject.GetComponent<Rigidbody>();
            detailsRigidBody.isKinematic = true;
            selectedObject.transform.SetParent(controller.transform);
        }
    }

    public void Unselect(GameObject unselectedObject)
    {
        var details = unselectedObject.GetComponent<StoryDetailsView>();
        if (details != null)
        {
            var detailsRigidBody = unselectedObject.GetComponent<Rigidbody>();
            detailsRigidBody.isKinematic = false;
            unselectedObject.transform.SetParent(null);
        }
    }

    public void Remove(GameObject removeObject)
    {
        var details = removeObject.GetComponent<StoryDetailsView>();
        if (details != null)
        {
            var detailsRigidBody = removeObject.GetComponent<Rigidbody>();
            if (!detailsRigidBody.isKinematic)
            {
                Destroy(removeObject);
            }
        }
        else
        {
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
