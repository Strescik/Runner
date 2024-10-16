using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Runner.Scripts.Map
{
    public class MapManager : MonoBehaviour
    {
        public static MapManager instance;

        [SerializeField] GameObject planeFloorPrefab;
        [SerializeField] GameObject barrierLayerPrefab;
        [SerializeField] Transform environment;

        [SerializeField] int barrierLayerDistance;
        [SerializeField] int floorDistance;

        internal int floorCount;
        internal int barrierLayerCount;

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);
            instance = this;

            
            ReadyToStartGame();

        }

        internal void ReadyToStartGame()
        {
            var environmentObje = new GameObject("Environment");
            environmentObje.transform.position = Vector3.zero;

            environment = environmentObje.transform;

            for (int i = 0; i < 4; i++)
            {
                var x = Instantiate(planeFloorPrefab, new Vector3(0, 0, floorCount * floorDistance), Quaternion.identity);
                x.transform.parent = environment;
                floorCount++;
            }
            for (int i = 0; i < 7; i++)
            {
                var x = Instantiate(barrierLayerPrefab, new Vector3(0, 0, barrierLayerCount * barrierLayerDistance), Quaternion.identity);
                x.transform.parent = environment;
                barrierLayerCount++;
            }
        }

        internal void SetFloorCount() => floorCount++;
        internal void SetBarrierLayerCount() => barrierLayerCount++;
        internal float GetNewFloorPositionZ() => floorCount * floorDistance;
        internal float GetNewBarrierLayerPositionZ() => barrierLayerCount * barrierLayerDistance;

        public void DestroyFloorAndBarrier()
        {
            floorCount = 0;
            barrierLayerCount = 0;
            Destroy(environment.gameObject);
        }
    }
}