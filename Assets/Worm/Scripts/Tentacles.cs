using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles : MonoBehaviour
{
    public int Length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    public Transform targetDir;
    public float targetDist;
    public float SmoothSpeed;
    public float trailSpeed;
    private Vector3[] segmentV;

    // Update is called once per frame
    private void Start()
    {
        lineRend.positionCount = Length;
        segmentPoses = new Vector3[Length];
        segmentV = new Vector3[Length];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], SmoothSpeed + i / trailSpeed);
        }
        lineRend.SetPositions(segmentPoses);
     }
}
