using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public RawImage bg;
    public Text Hptext;
    private int Hp = 10;
    public Button Hpbutton;
    public Text HpUIText;
    private bool UI = false;
    public Button ExitUI;
    //public Text ExitUIText;
    public Button AtkButton;
    public Text AtkText;
    public Button ExitMenuButton;
    //public Text ExitMenuButtonText;
    public int Atk = 10;
    private int Menu = 1;
    public Text XpText;
    public int Xp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlusHp(){
        if(Xp >= 100){
            Hp += 1;
            Xp -= 100;
            PlayerPrefs.SetInt("Hp",Hp);
            PlayerPrefs.SetInt("Xp",Xp);
            PlayerPrefs.Save();
        }
    }
    public void PlusAtk(){
        if(Xp >= 100){
            Atk += 1;
            Xp -= 100;
            PlayerPrefs.SetInt("Atk",Atk);
            PlayerPrefs.SetInt("Xp",Xp);
            PlayerPrefs.Save();
        }
    }
    void UIcheck(){
        if(UI == true){
            bg.enabled = true;
            //Hp
            Hpbutton.enabled = true;
            Hpbutton.image.enabled = true;
            HpUIText.enabled = true;
            //Atk
            AtkButton.enabled = true;
            AtkButton.image.enabled = true;
            AtkText.enabled = true;
            //ExitMenu
            ExitMenuButton.enabled = true;
            ExitMenuButton.image.enabled = true;
            //ExitMenuButtonText.enabled = true;
            //Exit
            ExitUI.enabled = true;
            ExitUI.image.enabled = true;
            //ExitUIText.enabled = true;
        }
        else{
            bg.enabled = false;
            //Hp
            Hpbutton.enabled = false;
            Hpbutton.image.enabled = false;
            HpUIText.enabled = false;
            //Atk
            AtkButton.enabled = false;
            AtkButton.image.enabled = false;
            AtkText.enabled = false;
            //ExitMenu
            ExitMenuButton.enabled = false;
            ExitMenuButton.image.enabled = false;
            //ExitMenuButtonText.enabled = false;
            //Exit
            ExitUI.enabled = false;
            ExitUI.image.enabled = false;
            //ExitUIText.enabled = false;
        }
    }
    public void ExitMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitUIw(){
        Menu += 1;
    }
    void Start()
    {
        Hp = PlayerPrefs.GetInt("Hp",10);
        Atk = PlayerPrefs.GetInt("Atk",10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            Xp += 100;
        }
        if((Menu%2) != 0){
            UI = false;
        }
        else{
            UI = true;
        }
        Hp = PlayerPrefs.GetInt("Hp",10);
        Xp = PlayerPrefs.GetInt("Xp",0);
        AtkText.text = ""+Atk;
        XpText.text = ""+Xp;
        Hptext.text = ""+Hp;
        HpUIText.text = ""+Hp; 
        if(Input.GetKeyDown(KeyCode.Escape)){
            Menu += 1;
            Atk = PlayerPrefs.GetInt("Atk",10);
        }
        UIcheck();
    }
}
