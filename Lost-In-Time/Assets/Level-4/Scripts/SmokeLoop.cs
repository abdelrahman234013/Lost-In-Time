using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeLoop : MonoBehaviour
{
     private SpriteRenderer spriteRenderer;
    public GameObject targetObject;
    public GameObject targetObject2;
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine when the script starts
        StartCoroutine(ExecuteEveryThreeSeconds());
         spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExecuteEveryThreeSeconds()
    {
        while (true) // Infinite loop, runs forever
        {
            if(FindObjectOfType<PlayerStats>().hasCapsule == true){
              targetObject.SetActive(false); // Deactivate the object
              targetObject2.SetActive(false);
            yield return new WaitForSeconds(70f);
            FindObjectOfType<PlayerStats>().hasCapsule =false;
            }

            yield return new WaitForSeconds(3f); // Wait for 3 seconds
           MakeObjectDisappear(true); // Call the function
        }

          void MakeObjectDisappear(bool value)
    {
            targetObject.SetActive(value); // Deactivate the object
            targetObject2.SetActive(value);
    }

    }
}
