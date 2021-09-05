using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class UIRoot : BaseView
    {
        [SerializeField]
        private TextWindow textWindow;
        public TextWindow TextWindow => textWindow;

        [SerializeField]
        private HasKey question;
        public HasKey Question => question;

        [SerializeField]
        private Transition transition;
        public Transition Transition => transition;

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