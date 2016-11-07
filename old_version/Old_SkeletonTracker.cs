using Microsoft.Kinect;

using System;

public static class Old_SkeletonTracker{
	public const float zLimit = 2.0f, xLimit = 0.3f, handsLimit = 0.20f;

    public static bool skeletonWithinBounds(Skeleton skel)
    {
        SkeletonPoint pos = skel.Joints[JointType.Spine].Position;
        return pos.Z < zLimit && Math.Abs(pos.X) < xLimit;
    }
        

	public static bool handsWithinBounds(Skeleton skel){
		SkeletonPoint left = skel.Joints[JointType.HandLeft].Position, right = skel.Joints[JointType.HandRight].Position;
		return Math.Abs(left.X) < handsLimit && Math.Abs(right.X) < handsLimit;
	}

    

}