using UnityEngine;
using System.Collections;

public class StoryStacker : MonoBehaviour {

	public GameObject storyBlockObject;

	void Start () {
		for (var y = 0; y < 10; y++) {
			GameObject storyBlock = (GameObject) Instantiate(storyBlockObject, new Vector3(0, 0.50f + (y * 0.16f), 0), Quaternion.identity);
			storyBlock.GetComponent<StoryController> ().SetTextValue ("Issue " + (y + 1));
		}
	}
}
