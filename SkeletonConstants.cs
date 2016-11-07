using System;
using Microsoft.Kinect;
using Microsoft.Samples.Kinect.SkeletonBasics;


public static class SkeletonConstants{
    /// <summary>
    /// Limits for the active detection area.
    ///All limits are measured in meters.
    /// </summary>
    public const float zLimit = 2.0f, xLimit = 0.3f;
    public static SkeletonTracker tracker = new SkeletonTracker();
    /// <summary>
    /// Enumeration for easy reference of SkeletonPoint coordinate types.
    /// </summary>
    public enum Coordinate { X, Y, Z };

    /*Names of joints arranged in order of JointType enumeration.*/
    public static readonly string [] jointNames  = {"Hip Center", "Spine", "Neck", "Left shoulder", "Left elbow", "Left wrist", "Left hand", "Right shoulder", "Right elbow"
	, "Right wrist", "Right hand", "Left hip", "Left knee", "Left ankle", "Left foot", "Right hip", "Right knee", "Right ankle", "Right foot", "Spine shoulders"};
}


