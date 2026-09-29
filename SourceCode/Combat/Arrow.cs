using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float speed = 10f;
    private float lifetime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Destroy(gameObject,lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
