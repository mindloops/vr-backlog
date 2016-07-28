using System;
using UnityEngine;
using Valve.VR;
using UnityEngine.VR;

public class PlayArea {

    public static float GetPlayAreaFrontOrDefault(float defaultFront)
    {
        if (!VRSettings.enabled)
        {
            return defaultFront;
        }

        return GetPlayAreaRect().vCorners0.v2;
    }

    public static float GetPlayAreaRightOrDefault(float defaultRight)
    {
        if (!VRSettings.enabled)
        {
            return defaultRight;
        }

        return GetPlayAreaRect().vCorners2.v2;        
    }

	static HmdQuad_t GetPlayAreaRect()
    {        
        var chaperone = OpenVR.Chaperone;
        var rect = new HmdQuad_t();
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
        if (success)
        {
            return rect;
        }
        throw new InvalidOperationException();
    }
}
