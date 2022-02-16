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

using UnityEditor;
using UnityEngine;

namespace Ovr
{
    [CustomEditor(typeof(OvrRigidBody))]
    public class OvrRigidBodyCustom : Editor
    {
        public override void OnInspectorGUI()
        {
            var rigidBodyModScript = target as OvrRigidBody;

            rigidBodyModScript.rigidBody = (Rigidbody)EditorGUILayout.ObjectField("Connected Rigidbody:", rigidBodyModScript.rigidBody, typeof(Rigidbody), true);

            EditorGUILayout.Space();

            rigidBodyModScript.rbModType = (RigidbodyModType)EditorGUILayout.EnumPopup("Method:", rigidBodyModScript.rbModType);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            switch (rigidBodyModScript.rbModType)
            {
                case RigidbodyModType.MovePosition:
                    EditorGUILayout.LabelField("Move Position:-", EditorStyles.largeLabel);
                    rigidBodyModScript.direction = (Direction)EditorGUILayout.EnumPopup("Direction:", rigidBodyModScript.direction);
                    break;

                case RigidbodyModType.MoveRotation:
                    EditorGUILayout.LabelField("Move Rotation:-", EditorStyles.largeLabel);
                    rigidBodyModScript.quaternion = EditorGUILayout.Vector4Field("Rotation:", rigidBodyModScript.quaternion);
                    break;

                case RigidbodyModType.ExplosiveForce:
                    EditorGUILayout.LabelField("Explosive Force:-", EditorStyles.largeLabel);
                    rigidBodyModScript.explosionRadius = EditorGUILayout.FloatField("Force Explosion radius:", rigidBodyModScript.forceValue);
                    rigidBodyModScript.upwardsModifier = EditorGUILayout.FloatField("Upwards modifier:", rigidBodyModScript.upwardsModifier);
                    goto default;

                case RigidbodyModType.Force:
                    EditorGUILayout.LabelField("Force:-", EditorStyles.largeLabel);
                    goto default;

                case RigidbodyModType.RelativeForce:
                    EditorGUILayout.LabelField("Relative Force:-", EditorStyles.largeLabel);
                    goto default;

                case RigidbodyModType.RelativeTorque:
                    EditorGUILayout.LabelField("Relative Torque:-", EditorStyles.largeLabel);
                    goto default;

                case RigidbodyModType.Torque:
                    EditorGUILayout.LabelField("Torque:-", EditorStyles.largeLabel);
                    goto default;

                default:
                    rigidBodyModScript.forceValue = EditorGUILayout.FloatField("Force Value:", rigidBodyModScript.forceValue);
                    rigidBodyModScript.direction = (Direction)EditorGUILayout.EnumPopup("Direction:", rigidBodyModScript.direction);
                    rigidBodyModScript.forceMode = (ForceMode)EditorGUILayout.EnumPopup("Force mode:", rigidBodyModScript.forceMode);
                    break;
            }
        }
    }
}