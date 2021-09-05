using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawners;
using Core;
using Utils;

namespace Chest
{
    public class ChestElement : MonoBehaviour
    {
        public string title = "Chest";
        public string context = "Open Chest";

        public string titleKey = "Key";
        public string contextKey = "Take Key ?";

        [Header("Chest Behaviour & Look"), SerializeField] private Animator chestAnimator;

        [SerializeField] private MeshRenderer[] chestRenderers;
        [SerializeField] private Material[] chestAllElementsNormal;
        [SerializeField] private Material[] chestHighlight;
        [SerializeField] private Collider keyCollider;

        [SerializeField, Header("Key")] private KeyObject key;

        private bool isHover;
        private bool isAnimating;
        private bool keySpawned;

        private RaycastHit hit;

        private CoreClasses core;

        public void InitChest(CoreClasses coreClasses)
        {
            this.core = coreClasses;/*
            //
            ///*
            var k = Instantiate(key, keyPosition.transform);
            k.transform.parent = this.transform.parent;
            keyItem = k;
            keyItem.InitKey(core);
            //*/

            keyCollider.enabled = false;

            Values.GameValues.chestSpawned = true;
        }

        public void ChestUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.GetComponent<ChestElement>())
                {
                    //
                    for (int i = 0; i < chestRenderers.Length; i++)
                    {
                        chestRenderers[i].material = chestHighlight[i];
                    }
                    //
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Values.UiValues.isWindowOpen)
                            return;

                        if (Values.UiValues.isChestOpen)
                            return;

                        core.UIRoot.TextWindow.InitWindow(core, title, context, ChestClickOpen, ChestClickCancel);
                        Values.UiValues.isWindowOpen = true;
                    }
                    //
                }

                //
                if (hit.transform.gameObject.GetComponent<KeyObject>())
                {
                    //
                    Debug.Log("Key");
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Values.UiValues.isWindowOpen)
                            return;

                        core.UIRoot.TextWindow.InitWindow(core, titleKey, contextKey, TakeKeyCallback, NotTakeKeyCallback);
                        Values.UiValues.isWindowOpen = true;
                    }
                    //
                }
            }
        }

        private void OnMouseExit()
        {
            isHover = false;
            for (int i = 0; i < chestRenderers.Length; i++)
            {
                chestRenderers[i].material = chestAllElementsNormal[i];
            }
        }

        public void ChestClickCancel()
        {
            StartCoroutine(CloseAnimation());
            //
            core.UIRoot.TextWindow.HideView();
            //
            Values.UiValues.isWindowOpen = false;
        }

        public void ChestClickOpen()
        {
            StartCoroutine(OpenAnimation());
            core.UIRoot.TextWindow.HideView();
        }

        private IEnumerator OpenAnimation()
        {
            //
            Values.UiValues.isChestOpen = true;
            //
            chestAnimator.SetBool("Open",true);
            //
            yield return new WaitForSeconds(2);
            //
            keyCollider.enabled = true;
            //
            Values.UiValues.isWindowOpen = false;
            Debug.Log("Opened");
        }

        private IEnumerator CloseAnimation()
        {
            //
            keyCollider.enabled = false;
            //
            chestAnimator.SetBool("Open", false);
            //
            yield return new WaitForSeconds(1);
            //
            Values.UiValues.isWindowOpen = false;
            //
            Debug.Log("Close");
            Values.UiValues.isChestOpen = false;

        }

        public void TakeKeyCallback()
        {
            Values.GameValues.hasKey = true;
            //
            core.UIRoot.TextWindow.HideView();
            core.UIRoot.Question.InitMessage(core, true);
            //
            Values.UiValues.isWindowOpen = false;
            //
            key.gameObject.SetActive(false);
        }

        public void NotTakeKeyCallback()
        {
            core.UIRoot.TextWindow.HideView();
            StartCoroutine(CloseAnimation());
        }
    }
}