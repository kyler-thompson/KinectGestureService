using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using DiskOfDemiseWPF.Gesture;

namespace DiskOfDemiseWPF.Gesture.Parts
{
    class JoinHandsSegment1 : GestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // hands above waist
            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                // hands below shoulder
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y)
                {
                    // hands joined
                    if ((skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X) && (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X) && (Math.Abs(skeleton.Joints[JointType.HandRight].Position.X-skeleton.Joints[JointType.HandLeft].Position.X) > 0.10))
                    {
                        return GesturePartResult.Succeed;
                    }
                    return GesturePartResult.Pausing;
                }
                return GesturePartResult.Fail;
            }
            return GesturePartResult.Fail;
        }
    }
}