using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemy :MonoBehaviour
{
   public GameObject[] weapons;
   public int hp;
   public Transform Weaponpos;
   bool Follow=false,go;
  public  Sprite idle,hurts;
   public Vector3 going;
 public LayerMask player;
 GameObject weapon;
 GameController gamcont;
 public ParticleSystem deatheffect;
   
   int i=0;
   Rigidbody2D rb;
   GameObject Player;
   IEnumerator hurt()
   {
    this.gameObject.GetComponent<SpriteRenderer>().sprite=hurts;
    yield return new WaitForSeconds(0.15f);
    this.gameObject.GetComponent<SpriteRenderer>().sprite=idle;
    yield break;
   }
   public void enemyhp(int hasar)
    {
     hp+=hasar;
    StartCoroutine(hurt());
     if(hp==0)
     {
        //particle effect  bıraksın ve destroy olsun
         gamcont.enemycount(-1);
         Instantiate(deatheffect,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        
        Destroy(weapon);
       
       
     }
     
    }
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
      
        gamcont=GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(Dotween());
        int randomint=Random.Range(0,3);
        Player=GameObject.FindGameObjectWithTag("Player");
     rb=GetComponent<Rigidbody2D>();
      going=new Vector3((int)Random.Range(-10,10),(int)Random.Range(-8,8),0);
    weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     
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
        

        if(Vector2.Distance(Player.transform.position,going)>8f && Vector2.Distance(Player.transform.position,going)<16f&&going.x>-38.5f&&going.x<3 &&going.y>-11&&going.y<16  )
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
            this.transform.position=Vector3.MoveTowards(this.transform.position,going,4f*Time.deltaTime);
           if(this.transform.position==going)
           {
           
            Follow=true;
           }
        }
        
    }
    IEnumerator FollowDelay()
    {
    yield return new WaitForSeconds(Random.Range(1,3));
    Follow=true;
    }
    void follower()
    {
    Collider2D[]range=Physics2D.OverlapCircleAll(this.transform.position,14,player);
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
