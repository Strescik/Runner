using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private Transform[] golds;


    private void OnEnable()
    {
        var rnd = Random.RandomRange(0, 6);
        if (rnd > 1)
            OpenGold();
    }

    private void OnDisable()
    {
        CloseGold();
    }

    private void CloseGold()
    {
        foreach (Transform x in golds)
            x.gameObject.SetActive(false);
    }

    private void OpenGold()
    {
        foreach (Transform x in golds)
            x.gameObject.SetActive(true);
    }

}
