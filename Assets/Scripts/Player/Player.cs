using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Utils;
using UnityEngine.SceneManagement;
using Spawners;

namespace PlayerManage
{
    public class Player : MonoBehaviour
    {

        [Header("Control Movement")]
        public float panSpeed = 20f;
        public float rotateSpeed = 20f;
        public float panBorder = 10f;
        //
        public float maxX;
        public float maxY;
        public float minX;
        public float minY;

        //
        private CoreClasses classes;
        private PlayerManager manage;
        private SpawnRandomizer spawner;


        public void InitPlayerObj(CoreClasses coreClasses)
        {
            this.classes = coreClasses;
            this.spawner = classes.Randomizer;
            this.manage = classes.Player;            

            Values.GameValues.isPlayerActive = true;
        }

        public void UpdatePlayer()
        {

            if(transform.position.x < minX)
            {
                transform.position = new Vector3(minX,transform.position.y,transform.position.z);
            }else
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }else
            if (transform.position.z < minY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, minY);
            }
            else if (transform.position.z > maxY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxY);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Chest")
            {
                spawner.SpawnChestAtPosition();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Chest")
            {
                spawner.SpawnChestAtPosition();
            }
        }
    }
}