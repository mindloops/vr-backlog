using UnityEngine;
using System.Collections;

public class StoryStacker : MonoBehaviour {

	public GameObject storyBlockObject;

	void Start () {
		StoriesModel storiesModel = new StoriesModel ();

		for (var i=0; i<storiesModel.Stories.Count; i++) {
			GameObject storyBlock = (GameObject) Instantiate(storyBlockObject, new Vector3(0, 0.50f + (i * 0.16f), 2.0f), Quaternion.identity);
			storyBlock.GetComponent<StoryController> ().SetTextValue (storiesModel.Stories[i].Title);
		}
	}
}
