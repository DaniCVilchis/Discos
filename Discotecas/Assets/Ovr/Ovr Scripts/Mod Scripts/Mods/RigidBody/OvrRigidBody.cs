/**
 * OVR Unity SDK License
 *
 * Copyright 2021 OVR
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * 1. The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * 2. All copies of substantial portions of the Software may only be used in connection
 * with services provided by OVR.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.ComponentModel;

namespace Ovr
{
    public enum RigidbodyModType { ExplosiveForce, Force, RelativeForce, RelativeTorque, Torque, MovePosition, MoveRotation };
    public enum Direction { Forward, Back, Up, Down, Left, Right };

    [System.Serializable]
    public class OvrRigidBody : OvrMod
    {
        public Rigidbody rigidBody;
        public RigidbodyModType rbModType;

        [Header("All")]
        public float forceValue;
        public Direction direction;
        [DefaultValue("ForceMode.Force")]
        public ForceMode forceMode;

        [Header("Explosive Force+")]
        public float explosionRadius;
        [DefaultValue("0.0f")]
        public float upwardsModifier = 0.0f;

        [Header("Move Rotation")]
        public Vector4 quaternion;

        Vector3 GetDirection()
        {
            return direction switch
            {
                Direction.Forward => Vector3.forward,
                Direction.Back => Vector3.back,
                Direction.Right => Vector3.right,
                Direction.Left => Vector3.left,
                Direction.Up => Vector3.up,
                Direction.Down => Vector3.down,
                _ => Vector3.forward,
            };
        }

        public override void Doit(Collider other)
        {
            switch (rbModType)
            {
                case RigidbodyModType.ExplosiveForce:
                    rigidBody.AddExplosionForce(forceValue, GetDirection(), explosionRadius, upwardsModifier, forceMode);
                    break;
                case RigidbodyModType.Force:
                    rigidBody.AddForce(GetDirection() * forceValue, forceMode);
                    break;
                case RigidbodyModType.RelativeForce:
                    rigidBody.AddRelativeForce(GetDirection() * forceValue, forceMode);
                    break;
                case RigidbodyModType.RelativeTorque:
                    rigidBody.AddRelativeTorque(GetDirection() * forceValue, forceMode);
                    break;
                case RigidbodyModType.Torque:
                    rigidBody.AddTorque(GetDirection() * forceValue, forceMode);
                    break;
                case RigidbodyModType.MovePosition:
                    rigidBody.MovePosition(GetDirection());
                    break;
                case RigidbodyModType.MoveRotation:
                    rigidBody.MoveRotation(new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w));
                    break;
            }
        }
    }
}