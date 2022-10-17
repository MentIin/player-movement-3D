using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    public Transform headTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = new Vector3(0, headTransform.eulerAngles.y, 0);
        transform.eulerAngles = newRotation;
    }
}
