using Assets.Runner.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Runner.Scripts.Barrier
{
    public class BarrierPool : MonoBehaviour
    {
        private void Start()
        {
            OpenRandomBarriers();
        }

        private void OpenRandomBarriers()
        {
            var rnd1 = Random.Range(0, 4);
            var rnd2 = Random.Range(0, 4);
            var rnd3 = Random.Range(0, 4);

            if (rnd1 == 4 && rnd2 == 4)
                rnd3 = Random.Range(0, 3);

            transform.GetChild(0).GetChild(rnd1).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(rnd2).gameObject.SetActive(true);
            transform.GetChild(2).GetChild(rnd3).gameObject.SetActive(true);

        }
        private void CloseBarriers()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                for (int j = 0; j < transform.GetChild(i).childCount; j++)
                {
                    transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        internal void NewPositionBarrier()
        {
            CloseBarriers();
            transform.position = new Vector3(0, 0, MapManager.instance.GetNewBarrierLayerPositionZ());
            OpenRandomBarriers();

            MapManager.instance.SetBarrierLayerCount();
        }

    }
}