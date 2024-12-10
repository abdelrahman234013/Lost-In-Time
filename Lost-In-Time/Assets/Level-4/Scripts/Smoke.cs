using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public GameObject targetObject;
    public GameObject targetObject2;
    
     void Start()
    {
        // Start the coroutine when the script starts
        StartCoroutine(ExecuteEveryThreeSeconds());
         spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Coroutine that runs every 3 seconds
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
            yield return new WaitForSeconds(6f); // Wait for 6 seconds
           MakeObjectDisappear(false); // Call the function

            yield return new WaitForSeconds(3f); // Wait for 3 seconds
           MakeObjectDisappear(true); // Call the function
        }

    }

    // Function to execute every 3 seconds
    void MakeObjectDisappear(bool value)
    {
            targetObject.SetActive(value); // Deactivate the object
            targetObject2.SetActive(value);
    }
}
