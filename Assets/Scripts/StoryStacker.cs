﻿using UnityEngine;
using Valve.VR;

public class StoryStacker : MonoBehaviour
{
    public GameObject storyBlockObject;

    void Start()
    {
        var chaperone = OpenVR.Chaperone;
        var rect = new HmdQuad_t();
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
        var playAreaEdge = 2.0f;
        if (success)
        {
            playAreaEdge = rect.vCorners2.v2 + 0.2f;
        }
        StoriesModel storiesModel = new StoriesModel();

        for (var i = 0; i < storiesModel.Stories.Count; i++)
        {
            GameObject storyBlock = (GameObject)Instantiate(storyBlockObject, new Vector3(0, 0.50f + (i * 0.16f), playAreaEdge), Quaternion.identity);
            storyBlock.GetComponent<StoryBlockController>().SetTextValue(storiesModel.Stories[i].Title);
        }
    }
}
