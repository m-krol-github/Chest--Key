using System.Collections;
using System.Collections.Generic;

using TMPro;
using Utils;
using UnityEngine;

namespace Core.UI
{
    public class Timer : BaseView
    {
        [SerializeField] private TextMeshProUGUI timeText;

        private CoreClasses core;

        public void InitTimer(CoreClasses core)
        {
            this.core = core;

            Values.UiValues.onTimer = true;
        }

        public void UpdateTime()
        {
            timeText.text = core.GameManager.gameTime.ToString("F0");
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }
    }
}