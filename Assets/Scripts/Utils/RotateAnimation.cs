using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.FX
{
    public class RotateAnimation : BaseAnimation
    {
        public Vector3 targetOffset;

        private Vector3 startRotation;
        private Vector3 targetRotation;

        public override void StartAnimation()
        {
            startRotation = transform.localEulerAngles;
            targetRotation = startRotation + targetOffset;
            base.StartAnimation();
        }

        protected override void UpdateAnimation(float t)
        {
            base.UpdateAnimation(t);
            transform.localEulerAngles = CurvedValue(startRotation, targetRotation, t);
        }

        protected override void FinishAnimation()
        {
            transform.localEulerAngles = targetRotation;
            base.FinishAnimation();
        }
    }
}