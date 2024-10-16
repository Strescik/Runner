using Assets.Runner.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Runner.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private bool startGame = false;

        private int _scorePoint;
        private int _goldPoint;

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);

            instance = this;
        }

        internal void SetScorePoint(int value) => _scorePoint = value + (_goldPoint * 100) + 130;
        internal int GetScorePoint() => _scorePoint;

        internal void AddGoldPoint(int value) => _goldPoint += value;
        internal int GetGoldPoint() => _goldPoint;

        public void SetStartGame(bool value) => startGame = value;
        internal bool GetStartGame() => startGame;

        public void RestartGame()
        {
            _goldPoint = 0;
            startGame = true;
            MapManager.instance.DestroyFloorAndBarrier();
            MapManager.instance.ReadyToStartGame();
        }

    }
}