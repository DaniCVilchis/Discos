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

namespace Ovr
{
    public enum AnimatorModType
    {
        CrossFade_int,
        CrossFade_string,
        SetLayerWeight,
        SetLookAtPosition,
        SetTarget,
        SetInteger,
        SetBool,
        SetFloat
    };

    [System.Serializable]
    public class OvrAnimator : OvrMod
    {
        public Animator animator;
        public AnimatorModType animatorModType;

        [Header("Cross Fade Int/String")]
        public int stateHashName;
        public string stateName;
        public float transitionDuration;
        public int layer = -1;
        public float timeOffset = float.NegativeInfinity;
        public float transitionTime = 0.0f;

        [Header("Set Layer Weight")]
        public int layerIndex;
        public float weight;

        [Header("Set look at Position")]
        public Vector3 lookAtPosition;

        [Header("Set Target")]
        public AvatarTarget targetIndex;
        public float tNormalizedTime;

        [Header("Set Int / Bool / Float / Vector3")]
        public string parameterName;
        public int intValue;
        public bool boolValue;
        public float floatValue;

        public override void Doit(Collider other)
        {
            if (other.gameObject.Equals(animator.gameObject))
            {
                switch (animatorModType)
                {
                    case AnimatorModType.CrossFade_int:
                        animator.CrossFade(stateHashName, transitionDuration, layer, timeOffset, transitionTime);
                        break;
                    case AnimatorModType.CrossFade_string:
                        animator.CrossFade(stateName, transitionDuration, layer, timeOffset, transitionTime);
                        break;
                    case AnimatorModType.SetLayerWeight:
                        animator.SetLayerWeight(layerIndex, weight);
                        break;
                    case AnimatorModType.SetLookAtPosition:
                        animator.SetLookAtPosition(lookAtPosition);
                        break;
                    case AnimatorModType.SetTarget:
                        animator.SetTarget(targetIndex, tNormalizedTime);
                        break;
                    case AnimatorModType.SetInteger:
                        animator.SetInteger(parameterName, intValue);
                        break;
                    case AnimatorModType.SetBool:
                        animator.SetBool(parameterName, boolValue);
                        break;
                    case AnimatorModType.SetFloat:
                        animator.SetFloat(parameterName, floatValue);
                        break;
                }
            }

        }
    }
}