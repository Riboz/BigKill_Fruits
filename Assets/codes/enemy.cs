using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemy :MonoBehaviour
{
   public GameObject[] weapons;
   public Transform Weaponpos;
   bool Follow=false,go;
   Vector3 going;
 public LayerMask player;
   
   int i=0;
   Rigidbody2D rb;
   GameObject Player;
   IEnumerator Dotween()
 {
    
    while( i==0)
    {

    this.transform.DOScale(new Vector3(1f,1f,0),2f);

    yield return new WaitForSeconds(1f);

    this.transform.DOScale(new Vector3(1.25f,1.25f,0),2f);
    
    yield return new WaitForSeconds(1f);
    }
 }
 
    void Start()
    {
        
        StartCoroutine(Dotween());
        int randomint=Random.Range(0,3);
        Player=GameObject.FindGameObjectWithTag("Player");
     rb=GetComponent<Rigidbody2D>();

     GameObject weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     StartCoroutine(weaponplace(weapon));
     weapon.GetComponent<Hweapon>().isplayer=false;
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
    follower();
   
    }
 IEnumerator weaponplace(GameObject weapon)
    {
        for(int i=3;i>=2;i++)
        { 
        yield return new WaitForSeconds(0.02f);
        weapon.transform.position=Weaponpos.position;
        }
    }
    
    public void EnemyMovement()
    {
        if(Follow)
        {
        

        if(Vector2.Distance(Player.transform.position,going)>6f && Vector2.Distance(Player.transform.position,going)<15f&&going.x>-17&&going.x>-17 &&going.y>-11&&going.y<16  )
        {
            
               Follow=false;

             go=true; 
            
            
        }

        else
        {
            going=Player.transform.position+new Vector3((int)Random.Range(-10,10),(int)Random.Range(-10,10),0);
        }
            
        }
        if(go)
        {
            this.transform.position=Vector3.MoveTowards(this.transform.position,going,4*Time.deltaTime);
           if(this.transform.position==going)
           {
           
            Follow=true;
           }
        }
        
    }
    IEnumerator FollowDelay()
    {
    yield return new WaitForSeconds(1.5f);
    Follow=true;
    }
    void follower()
    {
    Collider2D[]range=Physics2D.OverlapCircleAll(this.transform.position,20,player);
    for(int i=0;i<=range.Length-1;i++)
   {
    if(range[0]!=null)
   {
    //playerin yanında bir uzaklık alır oraya gider  biraz bekler sonra tekrardan bir uzaklık seçer sürekli ateş edecek
    Follow=true;
    range[0]=null;
   break;
   }
   }
   EnemyMovement();

    }
}
