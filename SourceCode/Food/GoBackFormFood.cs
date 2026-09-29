//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBackFormFood : MonoBehaviour

{
    public int eat;
    public Button btf;
    public RawImage im;
    public int HP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eat = PlayerPrefs.GetInt("Eat",0);
        eat = 0;
        PlayerPrefs.SetInt("Eat",eat);
        PlayerPrefs.Save();
        im.enabled = false;
        btf.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        eat = PlayerPrefs.GetInt("Eat",0);
        if(eat >= 3){
            im.enabled = true;
            btf.enabled = true;
        }
        
    }
    public void GoBackFormFoods(){
        HP = PlayerPrefs.GetInt("Hp",10);
        HP += 10;
        Debug.Log("+10 Hp"+" Hp = "+ HP);
        PlayerPrefs.SetInt("Hp",HP);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }
}
