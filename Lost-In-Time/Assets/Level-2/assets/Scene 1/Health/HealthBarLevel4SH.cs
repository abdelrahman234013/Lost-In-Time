using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarLevel4SH : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerStats playerHealth;
    [SerializeField] private Image HeartsBackGround;
    [SerializeField] private Image RedHearts;
    [SerializeField] private Image BlackBar;
    [SerializeField] private Image RedBar;
    [SerializeField] private Image GreenBar;

    void Start()
    {
        HeartsBackGround.fillAmount = playerHealth.lives / 10f;
        BlackBar.fillAmount = playerHealth.health / 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        GreenBar.fillAmount = playerHealth.health / 3f;
        RedHearts.fillAmount = playerHealth.lives / 10f;
    }

}


