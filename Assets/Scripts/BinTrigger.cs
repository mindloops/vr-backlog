using UnityEngine;
using System.Collections;

public class BinTrigger : MonoBehaviour {

	public StoryLogic storyLogic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
	void OnTriggerStay(Collider other)
	{
        storyLogic.Remove(other.gameObject);
        audioSource.Play();
    }
}
