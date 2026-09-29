using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private float mousespeed = 5f;
    private float orbitdamping = 10f;
    Vector3 localRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        Vector3 targetPosition = player.position;
        transform.position = targetPosition;
        if(Input.GetMouseButton(1)){
            
        localRot.x += Input.GetAxis("Mouse X") * mousespeed;
        localRot.y -= Input.GetAxis("Mouse Y") * mousespeed;

        localRot.y = Mathf.Clamp(localRot.y,0f,80f);

        Quaternion QT = Quaternion.Euler(localRot.y,localRot.x,0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT,Time.deltaTime * orbitdamping);
        }
    }
}
