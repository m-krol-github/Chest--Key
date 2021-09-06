using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils
{
    public class Values : MonoBehaviour
    {
        public class GameValues
        {
            public static bool isGameStarted;
            public static bool isSpawnerReady;
            public static bool isPlayerActive;
            public static bool chestSpawned;
            public static bool isDoorActive;

            //

            public static bool hasKey;

            //

            public static bool isPlaying; // time count
        }

        public class UiValues
        {
            public static bool isWindowOpen;
            public static bool isChestOpen;
            public static bool onTimer;
        }
    }
}