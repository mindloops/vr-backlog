using UnityEngine;
using System.Collections;

public class SelectableView : MonoBehaviour
{
    public void SetSelected(bool selected)
    {
        var renderer = GetComponent<Renderer>();
        var color = selected ? Color.blue : Color.white;
        renderer.material.color = color;
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            Debug.Log("Playing animation");
            anim.Play("Press");
        }
    }
}
