using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    public class SkeletonTracker
    {
        /// <summary>
        /// Internal list of tracked Skeleton objects. For storage of tracked skeleton data.
        /// </summary>
        private SkeletonList list;
        /// <summary>
        /// The normal y position of the shoulder center. Used to determine risk situation.
        /// </summary>
        private float spineNormal = 2.0f;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SkeletonTracker()
        {
            list = new SkeletonList();
        }

        /// <summary>
        /// Stores the given skeleton data and returns true if a potential risk situation was detected.
        /// </summary>
        /// <param name="skel">The Skeleton object to process.</param>
        /// <returns>true if a risk situation was detected, false otherwise.</returns>
        public bool processSkeleton(Skeleton skel)
        {
            list.Add(skel);
            return RiskDetector.riskDetected(skel, spineNormal);
        }

        /// <summary>
        /// Returns the last processed skeleton.
        /// </summary>
        /// <returns>The Skeleton object at the end of the list.</returns>
        public Skeleton getLastSkeleton()
        {
            return list[list.Count - 1];
        }

        /// <summary>
        /// Returns the last value of the given coordinate type for the given joint.
        /// Use this to simplify output of single coordinates.
        /// </summary>
        /// <param name="joint">The desired joint.</param>
        /// <param name="c">The desired coordinate type.</param>
        /// <returns>The most recent c-coordinate's value of the given joint.</returns>
        public float getLastCoordinate(JointType joint, SkeletonConstants.Coordinate c)
        {
            SkeletonPoint pos = getLastSkeleton().Joints[joint].Position;
            return c == SkeletonConstants.Coordinate.X ? pos.X : c == SkeletonConstants.Coordinate.X ? pos.Y : pos.Z;
        }

        /// <summary>
        /// Returns the mean value and standard deviation of the position data for the given joint as a string.
        ///Format is: "NAME: X: mean | sd Y: mean | sd Z: mean | sd"
        /// </summary>
        /// <param name="joint">The joint to process.</param>
        /// <returns>A string representation of the coordinate values' means and standard deviations for the given joint.</returns>
        public string getMeanAndStandardDeviation(JointType joint)
        {
            return list.getProcessedJointData(joint);
        }

        /// <summary>
        /// Returns the mean value and standard deviation of the position for all joints as a combined string.
        ///Format is: "---PROCESSED SKELETON DATA---
        ///            NAME: X: mean | sd Y: mean | sd Z: mean | sd
        ///            ..."
        /// </summary>
        /// <returns>A string representation of the coordinate values' means and standard deviations for all joints.</returns>
        public string getMeanAndStandardDeviation()
        {
            return list.getProcessedSkeletonData();
        }

        /// <summary>
        /// Removes the currently stored skeleton data.
        /// </summary>
        public void emptyData()
        {
            list.Clear();
        }

        /// <summary>
        /// Calculates the mean of the Shoulder center's y position and uses it as a new spine normal.
        /// </summary>
        /// <returns>Returns 0 if too few skeleton data objects have been aquired, otherwise the new normal is returned.</returns>
        public float calculateSpineNormal()
        {
            if (list.Count > 3)
            {
                float normal = list.meanOfJoint(JointType.ShoulderCenter)[1];
                spineNormal = normal;
                return normal;
            }
            return 0;
        }
    }
}