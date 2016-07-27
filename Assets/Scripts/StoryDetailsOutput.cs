using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StoryDetailsOutput : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		gameObject.SetActive (false);
	}

	void Display (StoriesModel.StoryModel story)
	{
		var textFields = this.gameObject.GetComponentsInChildren<Text> ();
		foreach (var textField in textFields) {
			if (textField.name.Equals ("StoryTitle")) {
				textField.text = story.Title;
			} else if (textField.name.Equals ("StoryDescription")) {
				textField.text = story.Description;
			} else if (textField.name.Equals ("StoryPoints")) {
				textField.text = story.Points.ToString ();
			} else {
				throw new InvalidOperationException ("Unknown textfield: " + textField.name);
			}
		}
		gameObject.SetActive (true);
	}
}
