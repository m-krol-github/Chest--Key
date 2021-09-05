using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Chest;
using PlayerManage;
using Utils;

namespace Spawners
{
    public class SpawnRandomizer : MonoBehaviour
    {

        public Vector2 yPos;

        public ChestElement spawnedChest;
        
        [SerializeField]
        private BoxCollider[] walls;


        [SerializeField]
        private BoxCollider floorCollider;

        [SerializeField]
        private ChestElement chest;

        [SerializeField]
        private GameObject doors;

        [SerializeField]
        private BoxCollider selectedWall;

        private CoreClasses classes;

        public void InitSpawner(CoreClasses classes)
        {
            this.classes = classes;
            classes.Doors.InitDoors(classes);

            SelectWall();
            SpawnChestAtPosition();

            //deb
            Values.GameValues.isSpawnerReady = true;
        }

        public void SpawnChestAtPosition()
        {
            var spawned = Instantiate(chest);
            spawnedChest = spawned;
            spawned.InitChest(classes);
            spawned.transform.localRotation = Quaternion.Euler(transform.rotation.x, yPos.x, transform.rotation.z);
            

            var posXb = Random.Range(floorCollider.bounds.min.x, floorCollider.bounds.max.x);
            var posZb = Random.Range(floorCollider.bounds.min.z, floorCollider.bounds.max.z);
            var moveTo = new Vector3(posXb, 0, posZb);

            spawnedChest.gameObject.transform.localPosition = moveTo;
        }

        public void UpdateElements()
        {
            if(Values.GameValues.chestSpawned)
                 spawnedChest.ChestUpdate();
        }

        public void SelectWall()
        {
            var selected = Random.Range(0, walls.Length);
            selectedWall = walls[selected];
            RandomizeDoors();
        }

        public void RandomizeDoors()
        {
            var wallXmax = selectedWall.bounds.max.x;
            var wallXmin = selectedWall.bounds.min.x;

            var wallZmax = selectedWall.bounds.max.z;
            var wallZmin = selectedWall.bounds.min.z;


            var posX = Random.Range(wallXmin, wallXmax); 
            var posZ = Random.Range(wallZmin, wallZmax);

            doors.transform.localPosition = new Vector3(posX, transform.position.y + yPos.y, posZ);
            doors.transform.rotation = selectedWall.transform.rotation;
        }
    }
}