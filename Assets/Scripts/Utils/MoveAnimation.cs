using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.FX
{
    public class MoveAnimation : BaseAnimation
    {
        public RectTransform targetRect;
        public Vector3 targetOffset;

        private Vector3 startPos;
        private Vector3 targetPos;

        public override void StartAnimation()
        {
            startPos = targetRect.transform.localPosition;
            targetPos = startPos + targetOffset;
            base.StartAnimation();
        }

        protected override void UpdateAnimation(float t)
        {
            base.UpdateAnimation(t);
            targetRect.transform.localPosition = CurvedValue(startPos, targetPos, t);
        }

        protected override void FinishAnimation()
        {
            targetRect.transform.localPosition = targetPos;
            base.FinishAnimation();
        }
    }
}