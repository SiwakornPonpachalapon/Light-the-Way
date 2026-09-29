using System;
using System.Collections;
using System.Xml.XPath;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private int Hp = 100;
    public int Atk;
    private SphereCollider SC;
    private bool PlayerFound = false;
    public Transform target;
    private float speed = 5f;
    public Rigidbody rb;
    public int Xp;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Arrow")){
            Hp -= Atk;
            rb.AddForce(Vector3.back * 500);
            Debug.Log("Hp - "+Atk+" = "+Hp);
            PlayerFound = true;
        }
        if(collision.gameObject.CompareTag("Sword")){
            rb.AddForce(Vector3.back * 500);
            Hp -= Atk;
            Debug.Log("Hp - "+Atk+" = "+Hp);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            PlayerFound = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            PlayerFound = false;
        }
    }

    void Start()
    {
        Atk = PlayerPrefs.GetInt("Atk",10);
        SC = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Atk = PlayerPrefs.GetInt("Atk",10);
        if(PlayerFound == true){
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.Normalize();
            directionToTarget = new Vector3(directionToTarget.x, 0.0f, directionToTarget.z);
            transform.position += directionToTarget * speed * Time.deltaTime;
            transform.LookAt(target);
            anim.SetBool("See",true);
        }
        if(Hp <= 0){
            Xp = PlayerPrefs.GetInt("Xp",0);
            int Ran = UnityEngine.Random.Range(50,100);
            Xp += Ran;
            PlayerPrefs.SetInt("Xp",Xp);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
