using UnityEngine;
using UnityEngine.UI;

public class Story3 : MonoBehaviour
{
    public AudioSource Audi;
    public AudioClip cli1;
    public AudioClip cli2;
    public AudioClip cli3;
    public AudioClip cli4;
    public RawImage im1;
    public RawImage im2;
    public RawImage im3;
    public RawImage im4;
    public Button bt;
    private int StoryLine = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StoryLine = PlayerPrefs.GetInt("Story3",1);
        bt.enabled = false;
        bt.image.enabled = false;
        im1.enabled = false;
        im2.enabled = false;
        im3.enabled = false;
        im4.enabled = false;
        if(StoryLine == 1){
            bt.enabled = true;
            bt.image.enabled = true;
            im1.enabled = true;
            Audi.clip = cli1;
            Audi.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextToStoryLine(){
        StoryLine += 1;
        if(StoryLine == 1){
            bt.enabled = true;
            bt.image.enabled = true;
            im1.enabled = true;
            Audi.clip = cli1;
            Audi.Play();
        }
        else if(StoryLine == 2){
            im1.enabled = false;
            im2.enabled = true;
            Audi.clip = cli2;
            Audi.Play();
        }
        else if(StoryLine == 3){
            im2.enabled = false;
            im3.enabled = true;
            Audi.clip = cli3;
            Audi.Play();
        }
        else if(StoryLine == 4){
            im3.enabled = false;
            im4.enabled = true;
            Audi.clip = cli4;
            Audi.Play();
        }
        else if(StoryLine == 5){
            im4.enabled = false;
            bt.enabled = false;
            bt.image.enabled = false;
            PlayerPrefs.SetInt("Story3",0);
            PlayerPrefs.Save();
        }
    }
}
