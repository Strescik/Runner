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

        [SerializeField] int barrierLayerDistance;
        [SerializeField] int floorDistance;

        internal int floorCount;
        internal int barrierLayerCount;

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);
            instance = this;

            for (int i = 0; i < 4; i++)
            {
                Instantiate(planeFloorPrefab, new Vector3(0, 0, floorCount * floorDistance), Quaternion.identity);
                floorCount++;
            }
            for (int i = 0; i < 7; i++)
            {
                Instantiate(barrierLayerPrefab, new Vector3(0, 0, barrierLayerCount * barrierLayerDistance), Quaternion.identity);
                barrierLayerCount++;
            }

        }

        internal void SetFloorCount() => floorCount++;
        internal void SetBarrierLayerCount() => barrierLayerCount++;
        internal float GetNewFloorPositionZ() => floorCount * floorDistance;
        internal float GetNewBarrierLayerPositionZ() => barrierLayerCount * barrierLayerDistance;
    }
}