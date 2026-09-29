//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story4 : MonoBehaviour
{
    public AudioSource Audi;
    public AudioSource Audi2;
    public AudioClip cli1;
    public AudioClip cli2;
    public AudioClip cli3;
    public AudioClip cli4;
    public AudioClip Music1;
    public RawImage im1;
    public RawImage im2;
    public RawImage im3;
    public RawImage im4;
    //public RawImage imwin;
    public Button bt;
    private int StoryLine = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        im1.enabled = false;
        im2.enabled = false;
        im3.enabled = false;
        im4.enabled = false;
        bt.enabled = false;
        bt.image.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(StoryLine == 1){
            bt.enabled = true;
            bt.image.enabled = true;
            im1.enabled = true;
            Audi.clip = cli1;
            Audi.Play();
        }
        }
        
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
        else if(StoryLine >= 5){
            SceneManager.LoadScene("Win");
        }
        
    }
}
