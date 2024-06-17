using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " carrots";
    }

    public void restartButton() {
        SceneManager.LoadScene(1);
    }

    public void menuButton() {
        SceneManager.LoadScene(0);
    }
}
