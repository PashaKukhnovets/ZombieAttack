using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHouseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject updateUI;
    [SerializeField] private GameObject newHangar;
    [SerializeField] private GameObject oldHangar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            updateUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            updateUI.SetActive(false);
        }
    }

    public void BuyUpdateHouseSecondLevel() {
        if (SaveProgress.GetMetalPoints() >= 1) {
            SaveProgress.BuyUpgradeHouse(1);
            oldHangar.SetActive(false);
            newHangar.SetActive(true);
            updateUI.SetActive(false);
        }
    }

    public void BuyUpdateHouseThirdLevel()
    {
        if (SaveProgress.GetMetalPoints() >= 2)
        {
            SaveProgress.BuyUpgradeHouse(2);
            oldHangar.SetActive(false);
            newHangar.SetActive(true);
            updateUI.SetActive(false);
        }
    }

}
