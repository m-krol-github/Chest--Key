using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;

namespace DoorsElement
{
    public class Doors : MonoBehaviour
    {
        [Header("Strings"),Space]
        public string title = "Doors";
        public string contextNot = "Get the KEY to open!";
        public string context = "Doors open!";


        [Header("Materials"), Space,SerializeField] private Material doorsMaterial;
        [SerializeField] private Material doorsHighlight;
        [SerializeField] private MeshRenderer doorRenderer;

        [SerializeField] private bool canOpen;

        private RaycastHit hit;
        private CoreClasses core;

        public void InitDoors(CoreClasses core)
        {
            this.core = core;
            //
            canOpen = false;
            //
            Values.GameValues.isDoorActive = true;
            //
            StartCoroutine(WaitForKey());
        }

        public void DoorsUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.GetComponent<Doors>())
                {
                    doorRenderer.material = doorsHighlight;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Values.UiValues.isWindowOpen)
                            return;

                        if (canOpen)
                        {
                            CanOpen();
                        }
                        else if(!canOpen)
                        {
                            StartCoroutine(NotCanOpen());
                        }
                    }
                }
            }
        }

        private void OnMouseExit()
        {
            doorRenderer.material = doorsMaterial;
        }

        public void CanOpen()
        {
            core.UIRoot.TextWindow.InitWindow(core, title, context, EndGame);
            Values.UiValues.isWindowOpen = true;
        }

        private IEnumerator NotCanOpen()
        {
            core.UIRoot.TextWindow.InitWindow(core, title, contextNot);
            yield return new WaitForSeconds(2);
            core.UIRoot.TextWindow.HideView();
        }

        private IEnumerator WaitForKey()
        {
            yield return new WaitUntil(()=> Values.GameValues.hasKey == true);
            canOpen = true;
        }

        public void EndGame()
        {
            core.UIRoot.TextWindow.HideView();
            Debug.Log("GameEnd");
            core.UIRoot.Transition.StartTransition(core, true);
        }

    }
}