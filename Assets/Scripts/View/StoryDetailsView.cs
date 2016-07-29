using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StoryDetailsView : MonoBehaviour
{
    private StoryBlockView storyBlock;

    public void Remove()
    {
        gameObject.transform.SetParent(null);
        Destroy(gameObject);
        storyBlock.SetRemoved();
    }

    public void Display(StoryBlockView storyBlock)
    {
        this.storyBlock = storyBlock;
        var story = storyBlock.storyModel;
        foreach (var textField in gameObject.GetComponentsInChildren<Text>())
        {
            if (textField.name.Equals("StoryTitle"))
            {
                textField.text = story.Title;
            }
            else if (textField.name.Equals("StoryDescription"))
            {
                textField.text = story.Description;
            }
            else if (textField.name.Equals("StoryPoints"))
            {
                textField.text = story.Points.ToString();
            }
            else
            {
                throw new InvalidOperationException("Unknown textfield: " + textField.name);
            }
        }
    }
}
