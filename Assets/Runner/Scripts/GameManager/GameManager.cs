using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Runner.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private int _scorePoint;
        private int _goldPoint;

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);

            instance = this;
        }

        internal void AddScorePoint(int value) => _scorePoint += value;
        internal int GetScorePoint() => _scorePoint;

        internal void AddGoldPoint(int value) => _goldPoint += value;
        internal int GetGoldPoint() => _goldPoint;

    }
}