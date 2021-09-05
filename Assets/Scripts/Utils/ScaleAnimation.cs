using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.FX
{
    public class ScaleAnimation : BaseAnimation
    {
        public RectTransform targetRect;
        public Vector3 targetOffset;

        private Vector3 startValue;
        private Vector3 targetValue;

        public override void StartAnimation()
        {
            startValue = targetRect.transform.localScale;
            startValue = targetValue + targetOffset;
            base.StartAnimation();
        }

        protected override void UpdateAnimation(float t)
        {
            base.UpdateAnimation(t);
            targetRect.transform.localScale = CurvedValue(startValue, targetValue, t);
        }

        protected override void FinishAnimation()
        {
            targetRect.transform.localScale = targetValue;
            base.FinishAnimation();
        }
    }
}