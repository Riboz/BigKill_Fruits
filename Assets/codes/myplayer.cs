using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class myplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool candamaged=true;
    float speed=4;
    public Image healthimage;
    public Sprite []tomatos;
    public GameObject[] weapons;
    Rigidbody2D rb;
    public  GameObject armor,reloadimage;
    public Transform Weaponpos;
    
    void Start()
    {
   

     int randomint=Random.Range(0,3);

     rb=GetComponent<Rigidbody2D>();

     GameObject weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     weapon.GetComponent<Hweapon>().isplayer=true;
    weapon.GetComponent<Hweapon>().reloadimage=reloadimage;
     weapon.transform.SetParent(this.transform);

      StartCoroutine(weaponplace(weapon));
    }
    IEnumerator weaponplace(GameObject weapon)
    {
        for(int i=3;i>=2;i++)
        { 
        yield return new WaitForSeconds(0.02f);
        weapon.transform.position=Weaponpos.position;
        }
        
    }

    // Update is called once per frame
    bool canjump=true;
    void FixedUpdate()
    {
     Movement();   
     
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&canjump)
     {
        StartCoroutine(jump());
      canjump=false;

     }
    }
    public void Movement()
    {
        float Horizontalx=Input.GetAxis("Horizontal");
        float Verticaly=Input.GetAxis("Vertical");
        rb.velocity=new Vector2(Horizontalx*speed,Verticaly*speed);
        
    }
    public IEnumerator jump()
    {
        speed=6;
        candamaged=false;
     for(int i=0;i<30;i++)
     {
        transform.rotation=Quaternion.Euler(0,0,-12*i);
        yield return new WaitForSeconds(0.025f);

     }        
     transform.rotation=Quaternion.Euler(0,0,0);
     canjump=true;
     candamaged=true;
     speed=4;
     yield break;
    }
    public int Hp_point=10;
    public void hp(int hasar)
    {
        if(candamaged)
        {

        Hp_point+=hasar;
         StartCoroutine(cantdamage());
        }
        if(Hp_point==10)
        {
         healthimage.sprite=tomatos[0];
        }
        if(Hp_point==8)
        {
         healthimage.sprite=tomatos[1];
        }
         if(Hp_point==6)
        {
         healthimage.sprite=tomatos[2];
        }
         if(Hp_point==4)
        {
         healthimage.sprite=tomatos[3];
        }
        if(Hp_point==2)
        {
         healthimage.sprite=tomatos[4];
        }
        
    }
    IEnumerator cantdamage()
    {
        candamaged=false;
        armor.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        candamaged=true;
        armor.SetActive(false);
        yield break;
    }
    
}
