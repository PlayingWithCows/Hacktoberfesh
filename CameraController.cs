using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameStatus status;
    
    void Start(){
        status = FindObjectOfType<GameStatus>();
    }
    // Update is called once per frame
    void Update()
    {
    if(!status.isPaused){
        if(Input.touchCount==2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

            if(Camera.main.orthographic){
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize+(deltaMagnitudediff*Time.deltaTime*.5f), 1f, 10f);
            }
            
        }
        
        if(Input.touchCount==1){
            Touch touchZero = Input.GetTouch(0);
            Vector3 newPos = new Vector3();
            float magnification = .6f;
            if(Camera.main.orthographicSize<2){
                magnification = .1f;
            }
             if(Camera.main.orthographicSize>7){
                magnification = 1.5f;
            }
            newPos.x = Mathf.Clamp(transform.position.x - touchZero.deltaPosition.x * magnification *Time.deltaTime, -10f, 10f);
            newPos.y = Mathf.Clamp(transform.position.y - touchZero.deltaPosition.y * magnification *Time.deltaTime, -10f, 10f);
            newPos.z = transform.position.z;
            
            transform.position = newPos;
        }
            
    }  
    }
}
© 2020 GitHub, Inc.
Terms
Privacy
Security
Status
Help
Contact GitHub
Pricing
API
Training
Blog
About
