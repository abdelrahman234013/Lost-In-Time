using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private HealthScript playerHealth;
    [SerializeField] private Image HeartsBackGround;
    [SerializeField] private Image RedHearts;
    [SerializeField] private Image BlackBar;
    [SerializeField] private Image RedBar;
    [SerializeField] private Image GreenBar;

    void Start()
    {
        HeartsBackGround.fillAmount = playerHealth.remainingLives / 10f;
        BlackBar.fillAmount = playerHealth.currentHealth / 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        GreenBar.fillAmount = playerHealth.currentHealth / 3f;
        RedHearts.fillAmount = playerHealth.remainingLives / 10f;
    }

}


