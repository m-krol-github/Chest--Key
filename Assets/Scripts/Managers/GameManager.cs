using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using PlayerManage;
using Spawners;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private CoreClasses classes;
        public CoreClasses Classes => classes;

        private PlayerManager player;
        private SpawnRandomizer randomizer;

        private void Awake()
        {
            this.player = classes.Player;
            this.randomizer = classes.Randomizer;

            classes.UIRoot.TextWindow.HideView();

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
            if (Values.GameValues.isGameStarted)
                player.UpdatePlayerManage();

            if (Values.GameValues.isSpawnerReady)
                randomizer.UpdateElements();

            if (Values.GameValues.isDoorActive)
                classes.Doors.DoorsUpdate();
        }
    }
}