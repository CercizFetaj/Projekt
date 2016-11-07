using Microsoft.Kinect;
using System;
public static class RiskDetector{
    /*Limits for the active detection area.
	All limits are measured in meters.*/
    public const float zLimit = 2.0f, xLimit = 0.3f;
	/*Limits used for the detection of risk situations.
	All limits are measured in meters.*/
	public const float handsLimit = 0.2f, shoulderSpineLimit = 0.15f;

	/*Checks if the given skeleton is within the set area of interest.*/
	public static bool skeletonWithinBounds(Skeleton skel){
		SkeletonPoint pos = skel.Joints[JointType.Spine].Position;
		return pos.Z < zLimit && Math.Abs(pos.X) < xLimit;
	}

	/*Checks if the hands of the given skeleton is within the limits of normal behavior.
	This is part of the risk situation detection.*/
	public static bool handsWithinBounds(Skeleton skel){
		SkeletonPoint left = skel.Joints[JointType.HandLeft].Position, right = skel.Joints[JointType.HandRight].Position;
		return Math.Abs(left.X) < handsLimit && Math.Abs(right.X) < handsLimit;
	}

	/*Checks if the shoulder area of the spine is within the desired height range.
	This is part of the risk situation detection.*/
	public static bool spineWithinBounds(Skeleton skel, float normal){
		return Math.Abs(normal - skel.Joints[JointType.ShoulderCenter].Position.Y) < shoulderSpineLimit;
	}

	/*Tests for all signs of a risk situation for the given skeleton data and returns true if such signs are detected.
	This is part of the risk situation detection.*/
	public static bool riskDetected(Skeleton skel, float spineNormal){
		return !handsWithinBounds(skel) || !spineWithinBounds(skel, spineNormal);
	}
}