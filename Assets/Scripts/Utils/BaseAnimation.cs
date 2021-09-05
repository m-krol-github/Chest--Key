using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.FX
{
    public class BaseAnimation : MonoBehaviour
    {

        public enum AnimationCurveEnum
        {
            Hermite,
            Sinerp,
            Coserp,
            Berp,
            Bounce,
            Lerp,
            Clerp
        }

        [Header("Animation Settings")]
        public float duration = 1f;
        public float delay = 0f;
        public bool isLooping = false;

        public bool autoPlay = false;
        public bool autoDestroy = true;

        public AnimationCurveEnum animationCurve = AnimationCurveEnum.Hermite;

        public UnityAction OnAnimationFinished;

        protected bool isPlaying = false;

        protected float timer = 0f;

        #region [Animation Controls]

        public virtual void StartAnimation()
        {
            isPlaying = true;
        }

        protected virtual void UpdateAnimation()
        {
            UpdateAnimation((timer - delay) / (duration));
        }

        protected virtual void UpdateAnimation(float t)
        {
            // Here goes code for animation with t (0.0 -> 1.0)
        }

        public virtual void PauseAnimation()
        {
            isPlaying = false;
        }

        public virtual void StopAnimation()
        {
            PauseAnimation();
            timer = 0;
        }

        protected virtual void FinishAnimation()
        {
            OnAnimationFinished?.Invoke();
            StopAnimation();

            if (autoDestroy)
            {
                Destroy(this);
            }
        }

        #endregion

        #region [Utils]

        protected float CurvedValue(float start, float end, float t)
        {
            switch (animationCurve)
            {
                case AnimationCurveEnum.Hermite:
                    return Mathfx.Hermite(start, end, t);
                case AnimationCurveEnum.Sinerp:
                    return Mathfx.Sinerp(start, end, t);
                case AnimationCurveEnum.Coserp:
                    return Mathfx.Coserp(start, end, t);
                case AnimationCurveEnum.Berp:
                    return Mathfx.Berp(start, end, t);
                case AnimationCurveEnum.Bounce:
                    return start + ((end - start) * Mathfx.Bounce(t));
                case AnimationCurveEnum.Lerp:
                    return Mathfx.Lerp(start, end, t);
                case AnimationCurveEnum.Clerp:
                    return Mathfx.Clerp(start, end, t);
                default:
                    return 0;
            }
        }

        protected Vector2 CurvedValue(Vector2 start, Vector2 end, float t)
        {
            return new Vector2(CurvedValue(start.x, end.x, t), CurvedValue(start.y, end.y, t));
        }

        protected Vector3 CurvedValue(Vector3 start, Vector3 end, float t)
        {
            return new Vector3(CurvedValue(start.x, end.x, t), CurvedValue(start.y, end.y, t), CurvedValue(start.z, end.z, t));
        }

        #endregion

        #region [Unity]

        private void OnEnable()
        {
            if (autoPlay)
            {
                StartAnimation();
            }
        }

        private void Update()
        {
            // Run only if animation should play.
            if (!isPlaying)
            {
                return;
            }

            // Increase internal timer.
            timer += Time.deltaTime;

            // Wait until delay.
            if (timer > delay)
            {
                UpdateAnimation();
            }

            // When timer hit value above animation duration
            if (timer > duration + delay)
            {
                // Lower timer if animation is looping
                if (isLooping)
                {
                    timer -= duration;
                }
                // Or finish animation.
                else
                {
                    FinishAnimation();
                }
            }
        }

        #endregion
    }
}