using System;
using UnityEngine;

namespace EVP
{
    [Serializable]
    public class Wheel
    {
        public WheelCollider wheelCollider;
        public Transform wheelTransform;
        public Transform caliperTransform;
        public bool steer = false;
        public bool drive = false;
        public bool brake = true;
        public bool handbrake = false;
    }
}