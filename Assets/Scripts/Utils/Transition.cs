using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Utils;

namespace Core.UI
{
    [ExecuteAlways]
    public class Transition : BaseView
    {
        public string sceneNameToLoad;

        public float transitionLevelMax = 1;
        public float transitionLevelMin = -.3f;
        public float step = .1f;
        public float stepTime = .1f;
        private float transitionValue;

        [SerializeField]
        private Button quitBtn;

        [SerializeField]
        private Image transitionObj;

        [SerializeField]
        private bool isVisible;

        private CoreClasses core;

        public void StartTransition(CoreClasses coreClasses,bool goBack)
        {
            this.core = coreClasses;
            transitionObj.gameObject.SetActive(true);
            transitionValue = transitionLevelMin;

            quitBtn.gameObject.SetActive(false);

            if(!goBack)
                StartCoroutine(SetTransition());

            if (goBack)
            {
                transitionValue = 1;
                StartCoroutine(SetTransitionBack());
            }
        }
        
        IEnumerator SetTransition()
        {
            while (transitionValue < 1f)
            {
                yield return new WaitForSeconds(stepTime);
                transitionValue += step;
                transitionObj.material.SetFloat("_Level", transitionValue);
            }


            if(transitionValue == 1)
                transitionObj.gameObject.SetActive(false);
        }

        IEnumerator SetTransitionBack()
        {

            while (transitionValue > -.3f)
            {
                yield return new WaitForSeconds(stepTime);
                transitionValue -= step;
                transitionObj.material.SetFloat("_Level", transitionValue);
            }

            Values.GameValues.isPlaying = false;

            quitBtn.gameObject.SetActive(true);
        }



        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        public void QuitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}