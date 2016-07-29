using UnityEngine;
using System.Collections;
using System;

public class StoryLogic : MonoBehaviour
{
    private StoriesModel storiesModel;

    public GameObject storyDetailsObject;

    public TextAsset issueListText;

    public StoriesModel StoriesModel
    {
        get {
            if (storiesModel == null)
            {
                storiesModel = new StoriesModel(issueListText.text);
            }
            return storiesModel;
        }
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
            var playAreaEdge = PlayArea.GetPlayAreaFrontOrDefault(1.8f) - 0.2f;
            GameObject storyDetails = (GameObject)Instantiate(storyDetailsObject, new Vector3(playAreaEdge, 1.0f, 0.0f), Quaternion.Euler(0.0f, -90.0f, 0.0f));
            storyDetails.GetComponent<StoryDetailsView>().Display(block);
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

    public void ApplyForce(GameObject forcedObject, Vector3 velocity, Vector3 angularVelocity)
    {
        if (velocity.magnitude > 1.0f)
        {
            var forcedRigidbody = forcedObject.GetComponent<Rigidbody>();
            forcedRigidbody.velocity = velocity;
            forcedRigidbody.angularVelocity = angularVelocity;
            Debug.Log("Velocity Applied: " + velocity.magnitude);
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
                details.Remove();
            }
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
