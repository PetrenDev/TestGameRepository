using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnWordScripts
{
    public class SpawnPointController : MonoBehaviour
    {
        public List<SpawnPointInfo> ListOfPointPrefabs = new List<SpawnPointInfo>();
        public int ActivePointsCount;
        private int currentActiveCount;

        private int currentPontActive;
        private List<SpawnPointInfo> copyList = new List<SpawnPointInfo>();

        private void Start()
        {
            StartSpawn();
        }

        private void StartSpawn()
        {
            currentActiveCount = ActivePointsCount;
            
            SpawnAllPointOnStart();

            for (int i = 0; i < copyList.Count; i++)
            {
                if (currentActiveCount <= 0)
                {
                    break;
                }
                
                if (copyList[i].IsPointOpen && !copyList[i].InBattleComplete)
                {
                    currentActiveCount--;
                    copyList[i].gameObject.SetActive(true);
                }

                if (copyList[i].IsPointOpen && copyList[i].InBattleComplete)
                {
                    currentActiveCount--;
                    copyList[i].gameObject.SetActive(true);
                    copyList[i].StartTimerPlay();
                }
            }

            if (currentActiveCount >= 1)
            {
                for (int i = 0; i < currentActiveCount; i++)
                {
                    SpawnOnePoint();
                }
            }
        }
        
        public void SetNewPointInMap(SpawnPointInfo spawnPointInfo)
        {
            SpawnOnePoint(spawnPointInfo);
        }
        
        private void SpawnAllPointOnStart()
        {
            copyList = ListOfPointPrefabs;
            for (int i = 0; i < copyList.Count; i++)
            {
               // copyList.Add(Instantiate(ListOfPointPrefabs[i], transform));
               copyList[i].SpawnPointController = this;
               copyList[i].gameObject.SetActive(false);
            }
            
        }
        
        private void SpawnOnePoint()
        {
            int RandomIndex = Random.Range(0, copyList.Count);
            
            while (copyList[RandomIndex].gameObject.activeSelf)
            {
                RandomIndex++;
                if (RandomIndex >= copyList.Count)
                {
                    RandomIndex = 0;
                }
            }

            copyList[RandomIndex].SetActivePoint();
            copyList[RandomIndex].gameObject.SetActive(true);
        }
        
        private void SpawnOnePoint(SpawnPointInfo spawnPointInfo)
        {
            spawnPointInfo.ResetPoint();
            
            int RandomIndex = Random.Range(0, copyList.Count);
            
            while (copyList[RandomIndex].gameObject.activeSelf)
            {
                RandomIndex++;
                if (RandomIndex >= copyList.Count)
                {
                    RandomIndex = 0;
                }
            }

            copyList[RandomIndex].SetActivePoint();
            copyList[RandomIndex].gameObject.SetActive(true);
        }
        
    }

}