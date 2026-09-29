using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public AudioSource Audi;
    public AudioClip cli1;
    public AudioClip cli2;
    public AudioClip cli3;
    public AudioClip cli4;
    public AudioClip cli5;
    public AudioClip cli6;
    public AudioClip cli7;

    public RawImage im1;
    public RawImage im2;
    public RawImage im3;
    public RawImage im4;
    public RawImage im5;
    public RawImage im6;
    public RawImage im7;
    private int StoryLine = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        im1.enabled = false;
        im2.enabled = false;
        im3.enabled = false;
        im4.enabled = false;
        im5.enabled = false;
        im6.enabled = false;
        im7.enabled = false;
        if(StoryLine == 1){
            im1.enabled = true;
            Audi.clip = cli1;
            Audi.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void ClickForNextStory(){
        StoryLine += 1;
        if(StoryLine == 1){
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
            im5.enabled = true;
            Audi.clip = cli5;
            Audi.Play();
        }
        else if(StoryLine == 6){
            im5.enabled = false;
            im6.enabled = true;
            Audi.clip = cli6;
            Audi.Play();
        }
        else if(StoryLine == 7){
            im6.enabled = false;
            im7.enabled = true;
            Audi.clip = cli7;
            Audi.Play();
        }
        else if(StoryLine >= 8){
            SceneManager.LoadScene("MainScene");
        }
    }
}
