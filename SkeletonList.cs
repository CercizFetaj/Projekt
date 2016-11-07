using System;
using System.Collections.Generic;
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{


    public class SkeletonList: List<Skeleton>
        {
        
            /*Default constructor*/
            public SkeletonList() : base()
            {

            }

            /*Computes and returns the mean value of the position for the given joint.
            Format is: [mean x, mean y, mean z]*/
            public float[] meanOfJoint(JointType type)
            {
                float[] sum = new float[3];
            //for (int i = 0; i < Count; i++)
            

            foreach (Skeleton skel in this)
            {
                

                    sum[0] += skel.Joints[type].Position.X;
                    sum[1] += skel.Joints[type].Position.Y;
                    sum[2] += skel.Joints[type].Position.Z;
                }
                for (int i = 0; i < 3; i++)
                    sum[i] /= Count;
                return sum;
            }

            /*Computes and returns the standard deviation of the position for the given joint.
            Format is: [sd x, sd y, sd z]*/
            private float[] standardDeviationOfJoint(JointType type, float[] mean)
            {
                float[] sd = new float[3];
                foreach(Skeleton skel in this)
                {
                    sd[0] += (float)Math.Pow((skel.Joints[type].Position.X - mean[0]), 2);
                    sd[1] += (float)Math.Pow((skel.Joints[type].Position.Y - mean[1]), 2);
                    sd[2] += (float)Math.Pow((skel.Joints[type].Position.Z - mean[2]), 2);
                }
                for (int i = 0; i < 3; i++)
                    sd[i] = (float) Math.Sqrt(sd[i] / Count);
                return sd;
            }

            /*Computes and returns the mean and standard deviation of the position for the given joint.
            Format is: [mean x, sd x, mean y, sd y, mean z, sd z]*/
            private float[] processJoint(JointType joint)
            {
                float[] mean = meanOfJoint(joint);
                float[] sd = standardDeviationOfJoint(joint, mean);
                float[] data = new float[6];
                for (int i = 0, j = 0; i < 6; i += 2, j++)
                {
                    data[i] = mean[j];
                    data[i + 1] = sd[j];
                }
                return data;
            }

            /*Returns a string representation of the given processed joint data.
            Format is: "NAME: X: mean | sd Y: mean | sd Z: mean | sd"*/
            private string formatJointString(JointType joint,float[] data)
            {
                string s = SkeletonConstants.jointNames + ": ";
                s += ("  X: " + data[0] + " | " + data[1] + "  Y : " + data[2] + " | " + data[3] + "  Z: "
                + data[4] + " | " + data[5]);
                return s;
            }

            /*Returns the mean value and standard deviation of the position data for the given joint as a string.
            Format is: "NAME: X: mean | sd Y: mean | sd Z: mean | sd"*/
            public string getProcessedJointData(JointType joint)
            {
                float[] data = processJoint(joint);
                return formatJointString(joint, data);
            }

            /*Computes and returns the mean value and standard deviation of the position for all joints.
            Format is in order of JointType enumeration, [i, 0] = mean x, [i, 1] = sd x ...*/
            private float[,] processSkeleton()
            {
                float[,] skel = new float[20, 2];

            foreach (JointType type in Enum.GetValues(typeof(JointType)))
            
                {
                
                    float[] data = processJoint(type);
                    skel[(int)type, 0] = data[0];
                    skel[(int)type, 1] = data[1];
                    skel[(int)type, 2] = data[2];
                    skel[(int)type, 3] = data[3];
                    skel[(int)type, 4] = data[4];
                    skel[(int)type, 5] = data[5];
                }
                return skel;
            }

            /*Returns the mean value and standard deviation of the position for all joints as a combined string
            Format is: "---PROCESSED SKELETON DATA---
                        NAME: X: mean | sd Y: mean | sd Z: mean | sd
                        ..."*/
            public string getProcessedSkeletonData()
            {
                float[,] skel = processSkeleton();
                string s = "---PROCESSED SKELETON DATA---" + Environment.NewLine;

            int j = 0;
            foreach (JointType type in Enum.GetValues(typeof(JointType)))

            {
                    float[] jointData = new float[6];
                    for (int x = 0, n = j; n < j + 6; x++, n++)
                        jointData[n] = skel[(int)type, n];
                    s += formatJointString(type, jointData) + Environment.NewLine;
                        j += 6;
                }
                return s;
            }
        }
    }

