using Assets.Runner.Scripts.GameManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI score;
    [SerializeField] internal TextMeshProUGUI fnishScore;
    [SerializeField] internal GameObject fnishPanel;
    [SerializeField] internal GameObject inGamePanel;

    private void Update()
    {
        SetScoreText();
    }

    internal void SetFnishPanel(bool value)
    {
        inGamePanel.SetActive(!value);
        fnishPanel.SetActive(value);
    }
    internal void SetScoreText()
    {
        score.text = GameManager.instance.GetScorePoint().ToString();
    }
    public void SetFnishSoreText()
    {
        fnishScore.text = GameManager.instance.GetScorePoint().ToString();
    }

}
