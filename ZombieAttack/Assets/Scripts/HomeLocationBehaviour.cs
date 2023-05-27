using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeLocationBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zombiePointsText;
    [SerializeField] private TextMeshProUGUI metalPointsText;

    private void Start()
    {
        zombiePointsText.text = SaveProgress.GetZombiePoints().ToString();
        metalPointsText.text = SaveProgress.GetMetalPoints().ToString();
    }

    private void Update()
    {
        zombiePointsText.text = SaveProgress.GetZombiePoints().ToString();
        metalPointsText.text = SaveProgress.GetMetalPoints().ToString();
    }
}
