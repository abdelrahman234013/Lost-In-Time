using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public float CameraSpeed;
    public float MinX, MaxX;
    public float MinY, MaxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate(){
        if(Target != null){
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed);

            float ClampX = Mathf.Clamp(newCamPosition.x, MinX, MaxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, MinY, MaxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
