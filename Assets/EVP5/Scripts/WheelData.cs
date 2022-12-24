using UnityEngine;

namespace EVP
{
    public class WheelData
    {
        public Wheel wheel;								// Wheel data from the inspector
        public WheelCollider collider;					// WheelCollider component for this wheel
        public Transform transform;						// Transform of the WheelCollider component
        public Vector3 origin;							// Origin point cosidering WheelCollider.center
        public float forceDistance;
        public float steerAngle = 0.0f;

        public bool grounded = false;
        public WheelHit hit;
        public GroundMaterial groundMaterial = null;

        public float suspensionCompression = 0.0f;
        public float downforce = 0.0f;

        public Vector3 velocity = Vector3.zero;
        public Vector2 localVelocity = Vector2.zero;
        public Vector2 localRigForce = Vector2.zero;

        public bool isBraking = false;
        public float finalInput = 0.0f;
        public Vector2 tireSlip = Vector2.zero;
        public Vector2 tireForce = Vector2.zero;
        public Vector2 dragForce = Vector2.zero;
        public Vector2 rawTireForce = Vector2.zero;

        public float angularVelocity = 0.0f;
        public float angularPosition = 0.0f;

        public PhysicMaterial lastPhysicMaterial = new PhysicMaterial();	// A new physic material ensures the first iteration to match the changes.
        public bool visualGrounded = false;                                 // Result of raycast for visual wheels. Used for precise positioning (i.e. tire marks).
        public RaycastHit visualHit;
        public Collider visualHitCollider;									// Sometimes the collider is taken from the ground hit, but RaycastHit.collider is read-only.

        // Utility data

        public float positionRatio = 0.0f;
        public bool isWheelChildOfCaliper = false;

        // Extended tire data.
        // Calculated when extendedTireData is set to True by components.

        public float combinedTireSlip = 0.0f;		// Combined tire slip magnitude, in m/s
        public float downforceRatio = 0.0f;			// A relative measure of the amout of weight supported by each wheel. Will be 1.0 in a balanced car at rest.
    }
}