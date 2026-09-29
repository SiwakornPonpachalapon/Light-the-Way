//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int Agree = 0;
    public Text AgreeText;
    public int Day = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoPlayNew(){
        Agree += 1;
    }
    public void GoPlayContinue(){
        if(Day ==0){
            PlayerPrefs.SetInt("Day",1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Story");

        }
        else if(Day == 1){
            SceneManager.LoadScene("MainScene");
        }
        else if(Day == 2){
            SceneManager.LoadScene("MainScene2");
        }
        
    }
    public void ExitApp(){
        Application.Quit();
    }
    void Start()
    {
        Day = PlayerPrefs.GetInt("Day",1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Agree >= 2){
            PlayerPrefs.SetInt("Hp",10);
            PlayerPrefs.SetInt("Atk",10);
            PlayerPrefs.SetFloat("x", 240);
            PlayerPrefs.SetFloat("y", -78);
            PlayerPrefs.SetFloat("z", -75);
            PlayerPrefs.SetInt("Xp",0);
            PlayerPrefs.SetInt("Day",1);
            PlayerPrefs.SetInt("Story",1);
            PlayerPrefs.SetInt("Story3",1);
            SceneManager.LoadScene("Story");
        }
        if(Agree == 1){
            AgreeText.text = "Sure?";
        }
    }
}
