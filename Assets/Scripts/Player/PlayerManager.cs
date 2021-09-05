using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;
using Spawners;

namespace PlayerManage
{
    public class PlayerManager : MonoBehaviour
    {

        [SerializeField]
        private Vector3 playerStartPos;

        [SerializeField]
        private Player playerObj;

        //
        private CoreClasses core;
        //

        public void InitPlayer(CoreClasses coreClasses)
        {
            this.core = coreClasses;
            
            Debug.Log("mgPLayer");


            //
            playerObj.transform.position = playerStartPos;

            playerObj.InitPlayerObj(coreClasses);
        }

        public void UpdatePlayerManage()
        {
            if (Values.GameValues.isPlayerActive)
                playerObj.UpdatePlayer();
        }

        public void SpawnPlayer()
        {
            var player = Instantiate(playerObj);
            player.transform.localPosition = playerStartPos;
            player.InitPlayerObj(core);
        }
    }
}