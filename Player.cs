//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    public int Hp = 10;
    private float jumb = 500f;
    private Rigidbody rb;
    public Transform cam;
    private GameObject CurrentWeapon;
    public Transform CurrentWeaponPoint;
    public GameObject Bow;
    public GameObject Sword;
    public Transform AttackPoint;
    public GameObject Arrow;
    public GameObject SwordHitbox;
    private bool OnGround = true;
    public Animator anim;
    private bool Walk = false;
    private bool dead = false;
    private float tim = 8f;
    public RawImage imagedead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Hp = PlayerPrefs.GetInt("Hp",Hp);
            Hp -= 1;
            Save();
            Debug.Log("GetAtk");
        }
        if(collision.gameObject.CompareTag("Ground")){
            OnGround = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            OnGround = false;
        }
    }
    void Save(){
        PlayerPrefs.SetInt("Hp",Hp);
        PlayerPrefs.Save();
    }

    private void ChangWaepon(GameObject weaponPrefab)
    {
        if(CurrentWeapon != null){
            Destroy(CurrentWeapon);
        }
        if(weaponPrefab == null){
            CurrentWeapon = null;
            return;
        }
        CurrentWeapon = Instantiate(weaponPrefab, CurrentWeaponPoint.transform);
        CurrentWeapon.transform.localPosition = Vector3.zero;
        CurrentWeapon.transform.localRotation = Quaternion.identity;
    }
    void Attack(){
        if(CurrentWeapon != null && CurrentWeapon.name.Contains("Sword")){
            anim.SetTrigger("Atk");
            GameObject Atk = Instantiate(SwordHitbox.gameObject,AttackPoint.position,AttackPoint.rotation);
            Debug.Log("Atk Sword");
        }
        else if(CurrentWeapon != null && CurrentWeapon.name.Contains("Bow")){
            GameObject Atk = Instantiate(Arrow.gameObject,AttackPoint.position,AttackPoint.rotation);
            Debug.Log("Atk Bow");
        }
    }
    void move(){
        float verti = Input.GetAxis("Vertical")*speed;
        float horiz = Input.GetAxis("Horizontal")*speed;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = verti * camForward;
        Vector3 rightRelative = horiz * camRight;

        Vector3 move = forwardRelative + rightRelative;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        
        Vector3 moveDirection = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            anim.SetBool("Walk",true);
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Run",true);
                speed = 15f;
            }
            else{
                speed = 10f;
                anim.SetBool("Run",false);}
        }
        else{anim.SetBool("Walk",false);}
        
    }

    
    
    void Start()
    {
        imagedead.enabled = false;
        Hp = PlayerPrefs.GetInt("Hp",Hp);
        Vector3 oldPos = new Vector3(
            PlayerPrefs.GetFloat("x", 0),
            PlayerPrefs.GetFloat("y", 1),
            PlayerPrefs.GetFloat("z", 0)
        );
        transform.position = oldPos;
        //ChangWaepon(Sword);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            ChangWaepon(Sword);
            Debug.Log("Chang Sword");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            ChangWaepon(Bow);
            Debug.Log("Chang Bow");
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
            Debug.Log("Atk");
        }
        //else{anim.SetBool("Atk",false);};
        move();
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        if(Hp <= 0){
            dead = true;
        }
        if(dead == true){
            tim -= Time.deltaTime;
            if(tim <= 5.5f){
                imagedead.enabled = true;
                Color color = imagedead.color;
                color.a += 1f * Time.deltaTime;
                imagedead.color = color;
            }
            if(tim <= 3f){
                SceneManager.LoadScene("Loss");
            }
        }
        if(Hp <= 0 && tim >= 7.9f){
            anim.SetTrigger("Dead");
        }
    
    }
}
