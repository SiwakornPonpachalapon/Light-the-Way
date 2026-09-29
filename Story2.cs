using System;
using UnityEngine;
using UnityEngine.UI;

public class Story2 : MonoBehaviour
{
    public RawImage im1;
    public RawImage im2;
    public AudioClip cli1;
    public AudioClip cli2;
    public AudioSource audi;
    private int StoryLine = 1;
    public Button bt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StoryLine = PlayerPrefs.GetInt("Story",0);
        im1.enabled = false;
        im2.enabled = false;
        bt.enabled = false;
        bt.image.enabled = false;
        if(StoryLine == 1){
            im1.enabled = true;
            bt.enabled = true;
            bt.image.enabled = true;
            audi.clip = cli1;
            audi.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextToStoryLine(){
        StoryLine += 1;
        if(StoryLine == 1){
            im1.enabled = true;
            audi.clip = cli1;
            audi.Play();
        }
        else if(StoryLine == 2){
            im1.enabled = false;
            im2.enabled = true;
            audi.clip = cli2;
            audi.Play();
        }
        else if(StoryLine >= 3){
            im1.enabled = false;
            im2.enabled = false;
            bt.enabled = false;
            bt.image.enabled = false;
            PlayerPrefs.SetInt("Story",0);
            PlayerPrefs.Save();
        }
    }
}
