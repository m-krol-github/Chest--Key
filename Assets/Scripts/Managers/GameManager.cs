using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using PlayerManage;
using Spawners;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public float gameTime;

        [SerializeField]
        private CoreClasses classes;
        public CoreClasses Classes => classes;

        private PlayerManager player;
        private SpawnRandomizer randomizer;

        private void Awake()
        {
            this.player = classes.Player;
            this.randomizer = classes.Randomizer;
            gameTime = 0;
            MainMenu();

            //
            classes.CameraController.InitCamera(classes);
            classes.UIRoot.Timer.InitTimer(classes);
            classes.UIRoot.TextWindow.HideView();
            //

            Values.GameValues.isGameStarted = true;
        }

        private void Start()
        {

            player.InitPlayer(classes);
            randomizer.InitSpawner(classes);
            classes.UIRoot.Transition.StartTransition(classes,false);
            //classes.Transition.StartTransition(classes);
        }

        private void Update()
        {
            classes.CameraController.UpdateCamera();
            //
            if (Values.GameValues.isPlaying)
            {
                gameTime += Time.deltaTime;
                PlayerPrefs.SetFloat("LastTime", gameTime);
            }
            //
            if (Values.GameValues.isGameStarted)
                player.UpdatePlayerManage();

            if (Values.GameValues.isSpawnerReady)
                randomizer.UpdateElements();

            if (Values.GameValues.isDoorActive)
                classes.Doors.DoorsUpdate();

            if (Values.UiValues.onTimer)
                classes.UIRoot.Timer.UpdateTime();
        }

        public void MainMenu()
        {
            Values.UiValues.isChestOpen = false;
            Values.UiValues.isWindowOpen = false;
            Time.timeScale = 0;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);            
        }
    }
}