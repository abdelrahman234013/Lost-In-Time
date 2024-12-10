using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private Vector3 temp_position;

    public float moveSpeed;
    private PlayerStats Player;
    void Start()
    {
        temp_position = transform.position;
    }

    void FixedUpdate(){
        temp_position.x += HorizontalSpeed;
        temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = temp_position;
    }
    void Update()
    {
        
    }
}