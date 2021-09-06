using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI lastTime;

        private void Awake()
        {
            if (PlayerPrefs.GetFloat("LastTime") != 0)
                lastTime.text = PlayerPrefs.GetFloat("LastTime").ToString("F0");
            else
                lastTime.text = 0.ToString("F0");
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("MainMenu");
        }
    }
}