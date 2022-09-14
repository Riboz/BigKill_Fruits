using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public interface Ifruits
{
  //dotweenli animasyonik meyveler
}
public abstract class Fruits : MonoBehaviour
{
  
  
/*

verilen colliderin içine girildiğinde saldıran fruitler lazım saldırma işlemi 
ve takip olaylarını araştır ve bul
*/
}

// interface ile duvar etkileşimi yapsın meyveler doscalelensin


public abstract class Weapons : MonoBehaviour
{
  public int FireAmmoCount;
  public int magazinecap,currentmagcap;
  public float cooldowntime;
  public bool isPlayer;
  public GameObject AmmoType,ammotype2;
  public Transform BulletTransform;
  public LayerMask playermask;
  
  Vector3 diffrance;
  public bool incooldown=false ,LookingLeft,canattack=true;
   
  IEnumerator cooldownlook()
  {
    incooldown=true;
    

    yield return new WaitForSeconds(cooldowntime);

    incooldown=false;

    yield break;
  }
  

  public void WeaponRotation()
  {
    if(isPlayer)
    {
    diffrance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float RotZ = Mathf.Atan2(diffrance.y, diffrance.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, RotZ);
    if(diffrance.x<0 && !LookingLeft)
    {
      LookingLeft=true;
      Vector3 scale=transform.localScale;
       scale.y*=-1;
       transform.localScale=scale;
    }
    if(diffrance.x>0 && LookingLeft)
    {
      LookingLeft=false;
      Vector3 scale=transform.localScale;
       scale.y*=-1;
       transform.localScale=scale;
    }
    }
    else
    {
      GameObject player=GameObject.FindGameObjectWithTag("Player");
      diffrance=player.transform.position-this.transform.position;
      float RotZ=Mathf.Atan2(diffrance.y,diffrance.x)*Mathf.Rad2Deg;
      transform.rotation=Quaternion.Euler(0,0,RotZ);
      if(diffrance.x<0 && !LookingLeft)
    {
      LookingLeft=true;
      Vector3 scale=transform.localScale;
       scale.y*=-1;
       transform.localScale=scale;
    }
    if(diffrance.x>0 && LookingLeft)
    {
      LookingLeft=false;
      Vector3 scale=transform.localScale;
       scale.y*=-1;
       transform.localScale=scale;
    }

      // enemylerin bakisi
    }
  }
  float timer;
public void FixedUpdate()
{
  if(isPlayer)
  {
    
   if(canattack)
     {
      WeaponRotation();
     if(Input.GetMouseButton(0) && !incooldown )
       {
        
        WeaponShot();
        StartCoroutine(cooldownlook());
       }
      }
      else
      {
       //mermi doldurma şeysi transfrom rotation a bağla
       
       transform.Rotate(0,0,10);
       Debug.Log("kackere");
       if(reload)
       {
        reloadscene(false);

         reload=false;

         StartCoroutine(Reload());
        
       }
       
      }
  }
  else 
  {
    
   Collider2D[] colliderx=Physics2D.OverlapCircleAll(this.transform.position,10f,playermask);
   
   for(int i=0;i<=colliderx.Length-1;i++)
   {
    if(colliderx[0]!=null)
   {
  
   Playerdetected=true;
   break;
   }
   }
  
   if(Playerdetected)
   {
    timer+=Time.deltaTime; 
    if(magazinecap==10)
    {
      if(timer>=0.75f)
   {
    WeaponShot();
    timer=0;
    }
    }
    if(magazinecap==5)
    {
      if(timer>=1.5f)
   {
    WeaponShot();
    timer=0;
    }
    }
   if(timer>=2.5f)
   {
    WeaponShot();
    timer=0;
   }
   }
   
    WeaponRotation();
    //weaponshot a bir cooldown eklenecek
   
  }
 
  
}

void OnDrawGizmosSelected()
{
Gizmos.color=Color.red;
Gizmos.DrawSphere(this.transform.position,10f);
}
bool reload=true,Playerdetected=false;
//panelde dolum tablosu yap ki gösterilsin
IEnumerator Reload()
{
  //bool kapalı
  Reloadimage.GetComponent<SpriteRenderer>().color=Color.red;

  reloadscene(true);

yield return new WaitForSeconds(1.5f);
//boolu aktif eder
Reloadimage.GetComponent<SpriteRenderer>().color=Color.green;
for(int i=0;i<=10;i++)
{
if(Input.GetKey(KeyCode.C))
{
  currentmagcap=magazinecap;
  Debug.Log("basildi");
  
 

 reloadscene(false);

 reload=true;
 canattack=true;

  yield break; 
  
}
yield return new WaitForSeconds(0.1f);
}

  Reloadimage.GetComponent<SpriteRenderer>().color=Color.red;
// tam zamanında basma olayı olabilir
yield return new WaitForSeconds(1.5f);
//bool kapalı
 

currentmagcap=magazinecap;



reload=true;
canattack=true;


reloadscene(false);

yield break;
}
 public void WeaponShot()
 {
  //silahın ucuna ateş efekti ekle
  if(isPlayer)
  {
   currentmagcap-=1;
  }
  

  for(int i=0;i<=FireAmmoCount-1;i++)
  {
  
   if(isPlayer)
   {
    GameObject ammo=Instantiate(ammotype2,BulletTransform.position+new Vector3(Random.Range(0.2f,0.2f),Random.Range(0.2f,0.2f),0),Quaternion.identity);
     ammo.GetComponent<Rigidbody2D>().AddForce(BulletTransform.right*12+new Vector3(Random.Range(1.5f*i,-1.5f*i),Random.Range(1.5f*i,-1.5f*i),0),ForceMode2D.Impulse);
     Destroy(ammo,4f);
     }
     else
      {GameObject ammo=Instantiate(AmmoType,BulletTransform.position+new Vector3(Random.Range(0.2f,0.2f),Random.Range(0.2f,0.2f),0),Quaternion.identity);
    // hedef aldığın yere göre mermi hızı
    ammo.GetComponent<Rigidbody2D>().AddForce(BulletTransform.right*7+new Vector3(Random.Range(1.5f*i,-1.5f*i),Random.Range(1.5f*i,-1.5f*i),0),ForceMode2D.Impulse);
    Destroy(ammo,4f);}

      
    /*instantiate lazım ve instantiate bullettransform un küçük randomlar eklenerek atılmasına ayarlı
   mermiler izlenilen direksiyonda karakterin hızının eklenilmesiyle atılmalı*/
  }
 }
 GameObject Reloadimage;
 public void reloadvoid(GameObject reloadimage)
 {
 Reloadimage=reloadimage;
 }
public void reloadscene(bool status)
    {
      if(status)
      {
      Reloadimage.SetActive(true);
      }
      else 
      {
      // nesne kapanır
       Reloadimage.SetActive(false);
      }
     
   
      
    }
 //silahların mermisi bitince hepsinde reload olmayacak çünkü enemylerinde var silahları
}
