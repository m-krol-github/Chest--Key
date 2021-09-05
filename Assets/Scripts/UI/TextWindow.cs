using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.UI
{
    public class TextWindow : BaseView
    {

        public string windowTitle;
        public string windowContext;

        [SerializeField] private RectTransform baseWindow;

        [SerializeField] private Color baseColor;

        [SerializeField] private TextMeshProUGUI title;

        [SerializeField] private TextMeshProUGUI context;

        [SerializeField] private Button yesBtn;

        [SerializeField] private Button noBtn;


        private CoreClasses core;

        private UnityAction answerYes;
        private UnityAction answerNo;

        public void InitWindow(CoreClasses core,string Header,string Description, UnityAction YesCallback, UnityAction NoCallback)
        {
            this.core = core;
            this.title.text = Header;
            this.context.text = Description;
            this.answerYes = YesCallback;
            this.answerNo = NoCallback;

            this.noBtn.gameObject.SetActive(true);
            this.yesBtn.gameObject.SetActive(true);

            this.yesBtn.onClick.AddListener(AnswerYes);
            this.noBtn.onClick.AddListener(AnswerNo);


            ShowView();


        }

        public void InitWindow(CoreClasses core, string Header, string Description, UnityAction YesCallback)
        {
            this.core = core;
            this.title.text = Header;
            this.context.text = Description;
            this.answerYes = YesCallback;

            this.noBtn.onClick.AddListener(AnswerNo);
            this.yesBtn.gameObject.SetActive(true);
            this.noBtn.gameObject.SetActive(false);

            ShowView();
        }

        public void InitWindow(CoreClasses core, string Header, string Description)
        {
            this.core = core;
            this.title.text = Header;
            this.context.text = Description;

            this.noBtn.gameObject.SetActive(false);
            this.yesBtn.gameObject.SetActive(false);

            ShowView();
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        public void AnswerYes()
        {
            answerYes.Invoke();
        }

        public void AnswerNo()
        {
            answerNo.Invoke();
        }
    }
}