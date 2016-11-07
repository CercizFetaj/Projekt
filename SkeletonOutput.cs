using System;
using Microsoft.Kinect;


namespace Microsoft.Samples.Kinect.SkeletonBasics
{

    public static class SkeletonOutput 
        {

            /*Prints the joint position data of the given skeleton to a file.*/
            public static void skeletonToFile(Skeleton skel)
            {
                //JointCollection joints = skel.Joints;
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"skeleton data.txt", true))
                {
                    file.WriteLine("---SKELETON DATA---");
                foreach(Joint joint in skel.Joints)
                    
                        file.WriteLine(jointToString(joint,(int)joint.JointType ));
                }
            }

            /*Forms and returns a string representation of the given skeleton. Newline is used as separator.*/
            public static string skeletonToString(Skeleton skel)
            {
                string s = "SKELETON DATA" + Environment.NewLine;
                //JointCollection joints = skel.Joints;

            foreach (Joint joint in skel.Joints)
                
                    s += (jointToString(joint,(int)joint.JointType) + Environment.NewLine);
                return s;
            }

            /*Forms and returns a string representation of the given joint.*/
            public static string jointToString(Joint joint, int jointIndex)
            {
                return SkeletonConstants.jointNames[jointIndex] + ":\t" + positionToString(joint.Position);
            }

            /*Forms and returns a string representation of the given SkeletonPoint object.*/
            private static string positionToString(SkeletonPoint pos)
            {
                string xDirection = pos.X < 0 ? " to the left" : " to the right";
                return "x = " + Math.Abs(pos.X) + xDirection + " y =  " + pos.Y + " z = " + pos.Z;
            }
        }
    }

