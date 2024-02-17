using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congrats : MonoBehaviour
{
    public GameObject congratsText;
    public GameObject restartButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        congratsText.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

}
