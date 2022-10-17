using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    */
    public Transform bodyTransform;
    private float height = 0.5f;
    
    private float camSens = 300f; //How sensitive it with mouse
    private float xRotation=0f;
    
    private Vector3 lastMouse = new Vector3(255, 255, 255);

    private void Start()
    {
        #if UNITY_STANDALONE
            Cursor.lockState = CursorLockMode.Locked;
        #endif
        #if UNITY_ANDROID
            camSens = 6f;
        #endif
    }

    void Update ()
    {
        #if UNITY_STANDALONE
            PC();
        #endif
        #if UNITY_ANDROID
            Mobile();
        #endif
    }

    private void PC()
    {
        float mouseX = Input.GetAxis("Mouse X") * camSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * camSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        bodyTransform.Rotate(Vector3.up * mouseX);
    }

    private void Mobile()
    {
        if (Input.touchCount == 0) return;

        foreach (Touch touch in Input.touches)
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                continue;
            float mouseX = touch.deltaPosition.x;
            float mouseY = touch.deltaPosition.y;
            mouseX = (mouseX) * camSens * Time.deltaTime;
            mouseY = (mouseY) * camSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            bodyTransform.Rotate(Vector3.up * mouseX);
        }
        
        
    }
     

}
