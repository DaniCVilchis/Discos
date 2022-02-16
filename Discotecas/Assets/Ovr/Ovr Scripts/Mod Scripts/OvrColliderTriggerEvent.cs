﻿/**
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
using UnityEngine.Events;
using System.Collections.Generic;

namespace Ovr
{
    [RequireComponent(typeof(Collider))]
    public class OvrColliderTriggerEvent : MonoBehaviour
    {
        public bool interactWithUserCamera = true;
        public List<string> tags = new List<string>();

        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerStay;
        public UnityEvent onTriggerExit;


        public void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if (other != null && ((interactWithUserCamera && other.tag == "PlayerCam") || tags.Contains(other.tag)))
                onTriggerEnter?.Invoke();

        }
        private void OnTriggerStay(Collider other)
        {
            if (other != null && ((interactWithUserCamera && other.tag == "PlayerCam") || tags.Contains(other.tag)))
                onTriggerStay?.Invoke();
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.name);
            if (other != null && ((interactWithUserCamera && other.tag == "PlayerCam") || tags.Contains(other.tag)))
                onTriggerExit?.Invoke();

        }
    }
}

