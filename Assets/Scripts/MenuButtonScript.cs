using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void playButton() {
        SceneManager.LoadScene(1);
    }

    public void optionButton() {
        SceneManager.LoadScene(2);
    }
}
