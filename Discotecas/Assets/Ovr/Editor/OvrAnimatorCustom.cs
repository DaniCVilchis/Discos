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
using UnityEditor;

namespace Ovr
{
    [CustomEditor(typeof(OvrAnimator))]
    public class OvrAnimatorCustom : Editor
    {
        public override void OnInspectorGUI()
        {
            var target = base.target as OvrAnimator;

            target.animator = (Animator)EditorGUILayout.ObjectField("Connected Animator:", target.animator, typeof(Animator), true);

            EditorGUILayout.Space();

            target.animatorModType = (AnimatorModType)EditorGUILayout.EnumPopup("AudioMod Animator:", target.animatorModType);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            switch (target.animatorModType)
            {
                case AnimatorModType.CrossFade_int:
                    EditorGUILayout.LabelField("CrossFade (int):-", EditorStyles.largeLabel);
                    target.stateHashName = EditorGUILayout.IntField("State Hash Name:", target.stateHashName);
                    target.transitionDuration = EditorGUILayout.FloatField("Transition Duration:", target.transitionDuration);
                    target.layer = EditorGUILayout.IntField("Layer:", target.layer);
                    target.timeOffset = EditorGUILayout.FloatField("Time Offset:", target.timeOffset);
                    target.transitionTime = EditorGUILayout.FloatField("Transition Time:", target.transitionTime);
                    break;

                case AnimatorModType.CrossFade_string:
                    EditorGUILayout.LabelField("CrossFade (string):-", EditorStyles.largeLabel);
                    target.stateName = EditorGUILayout.TextField("State Name:", target.stateName);
                    target.transitionDuration = EditorGUILayout.FloatField("Transition Duration:", target.transitionDuration);
                    target.layer = EditorGUILayout.IntField("Layer:", target.layer);
                    target.timeOffset = EditorGUILayout.FloatField("Time Offset:", target.timeOffset);
                    target.transitionTime = EditorGUILayout.FloatField("Transition Time:", target.transitionTime);
                    break;

                case AnimatorModType.SetLayerWeight:
                    EditorGUILayout.LabelField("Set Layer Weight:-", EditorStyles.largeLabel);
                    target.layerIndex = EditorGUILayout.IntField("Layer Index:", target.layerIndex);
                    target.weight = EditorGUILayout.FloatField("Weight:", target.weight);
                    break;

                case AnimatorModType.SetLookAtPosition:
                    EditorGUILayout.LabelField("Set Look At Position:-", EditorStyles.largeLabel);
                    target.lookAtPosition = EditorGUILayout.Vector3Field("Look at position:", target.lookAtPosition);
                    break;

                case AnimatorModType.SetTarget:
                    EditorGUILayout.LabelField("Set Target:-", EditorStyles.largeLabel);
                    target.targetIndex = (AvatarTarget)EditorGUILayout.EnumPopup("Weight:", target.targetIndex);
                    target.tNormalizedTime = EditorGUILayout.FloatField("Target Normalized Time:", target.tNormalizedTime);
                    break;

                case AnimatorModType.SetInteger:
                    EditorGUILayout.LabelField("Set Integer:-", EditorStyles.largeLabel);
                    target.parameterName = EditorGUILayout.TextField("Parameter Name:", target.parameterName);
                    target.intValue = EditorGUILayout.IntField("Value:", target.intValue);
                    break;

                case AnimatorModType.SetBool:
                    EditorGUILayout.LabelField("Set Bool:-", EditorStyles.largeLabel);
                    target.parameterName = EditorGUILayout.TextField("Parameter Name:", target.parameterName);
                    target.boolValue = EditorGUILayout.Toggle("Value:", target.boolValue);
                    break;

                case AnimatorModType.SetFloat:
                    EditorGUILayout.LabelField("Set Float:-", EditorStyles.largeLabel);
                    target.parameterName = EditorGUILayout.TextField("Parameter Name:", target.parameterName);
                    target.floatValue = EditorGUILayout.FloatField("Value:", target.floatValue);
                    break;
            }
        }
    }
}