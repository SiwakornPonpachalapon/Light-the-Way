using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Eat");
                SceneManager.LoadScene("FoodCost");
                Destroy(gameObject);
            }
        }
    }
}
