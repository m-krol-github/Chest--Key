using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerManage;
using Core.UI;
using Chest;
using Spawners;
using DoorsElement;
using CameraControll;

namespace Core
{
    public class CoreClasses : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;

        [SerializeField]
        private PlayerManager player;
        public PlayerManager Player => player;

        [SerializeField]
        private Transition transition;
        public Transition Transition => transition;

        [SerializeField]
        private Doors doors;
        public Doors Doors => doors;

        [SerializeField]
        private SpawnRandomizer randomizer;
        public SpawnRandomizer Randomizer => randomizer;

        [SerializeField]
        private UIRoot uiRoot;
        public UIRoot UIRoot => uiRoot;

        [SerializeField]
        private CameraController cameraController;
        public CameraController CameraController => cameraController;
    }
}