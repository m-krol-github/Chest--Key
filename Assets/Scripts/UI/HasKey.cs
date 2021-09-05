using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.FX;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Core.UI
{
    public class HasKey : BaseView
    {
        [SerializeField] private RectTransform thisPanel;

        [SerializeField] private Toggle hasKeyToggle;

        private bool hasKey;
        private CoreClasses core;

        public void InitMessage(CoreClasses core, bool hasKey)
        {
            this.core = core;

            this.hasKey = hasKey;

            hasKeyToggle.isOn = true;
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