using UnityEngine;
using System.Collections;

public class BinTrigger : MonoBehaviour {

	public StoryLogic storyLogic;
    
	void OnTriggerEnter(Collider other)
	{
        storyLogic.Remove(other.gameObject);
    }
}
