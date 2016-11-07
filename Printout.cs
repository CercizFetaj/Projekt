using System;
using Microsoft.Kinect;
using System.Windows.Controls;
using System.Windows;
/// <summary>
/// Summary description for Class1
/// </summary>
public static class Printouts
{
	public static void SkeletonPoints(Skeleton skel)
	{
        SkeletonPoint pos = skel.Joints[JointType.Spine].Position;
        SkeletonPoint pos2 = skel.Joints[JointType.ShoulderCenter].Position;

        
    

        Console.WriteLine("Spine " + "X " + pos.X + "Z " + pos.Z);
        Console.WriteLine("ShoulderCenter " + "Y " + pos2.Y + "Z " + pos2.Z);

        
    }
}
