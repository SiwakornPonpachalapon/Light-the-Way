using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Loss : MonoBehaviour
{
    public RawImage ri;
    private float fadeSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = ri.color;
        color.a += fadeSpeed* Time.deltaTime;
        ri.color = color;

    }
}
