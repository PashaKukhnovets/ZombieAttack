using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLocationBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject goToLocationWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) 
        {
            goToLocationWindow.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            goToLocationWindow.gameObject.SetActive(false);
        }
    }

    public void GoToFirstLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToSecondLevel()
    {
        SceneManager.LoadScene(3);
    }
}
