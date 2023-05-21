using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBehaviour : MonoBehaviour
{
    public void RestartLevel() {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
