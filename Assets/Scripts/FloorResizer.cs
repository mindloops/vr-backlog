using UnityEngine;
using Valve.VR;

public class FloorResizer : MonoBehaviour {
    
	void Start () {
        var chaperone = OpenVR.Chaperone;
        var rect = new HmdQuad_t();
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref rect);
        if (success)
        {
            var xScale = Difference(rect.vCorners1.v0, rect.vCorners3.v0);
            var zScale = Difference(rect.vCorners0.v2, rect.vCorners2.v2);
            transform.localScale = new Vector3(xScale * 0.1f, 1.0f, zScale * 0.1f);
        }
    }
    
    float Difference(float pointA, float pointB)
    {
        if (pointA > pointB)
        {
            return pointA - pointB;
        }
        return pointB - pointA;
    }
}
