using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryBlockController : MonoBehaviour
{

    private Text text;

    void OnEnable()
    {
        text = GetComponentInChildren<Text>();
    }

    public void SetTextValue(string textValue)
    {
        text.text = textValue;
    }

    public void SetSelected(bool selected)
    {
        var renderer = GetComponent<Renderer>();
        var color = selected ? Color.blue : Color.white;
        renderer.material.color = color;
    }
}
