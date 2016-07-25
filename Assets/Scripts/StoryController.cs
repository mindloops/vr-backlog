using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryController : MonoBehaviour {

	private Text text;

	void OnEnable() {
		text = GetComponentInChildren<Text> ();
	}

	public void SetTextValue(string textValue) {
		text.text = textValue;
	}
}
