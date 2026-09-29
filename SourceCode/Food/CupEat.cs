using UnityEngine;

public class CupEat : MonoBehaviour
{
    public int eat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        eat = PlayerPrefs.GetInt("Eat",0);
        eat += 1;
        Debug.Log(eat);
        PlayerPrefs.SetInt("Eat",eat);
        PlayerPrefs.Save();
        Destroy(gameObject);
    }
}
