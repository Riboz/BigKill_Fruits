using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
  public GameObject AmmoType;
  public Transform BulletTransform;
  
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
         StartCoroutine(Reload());
         reload=false;
       }
       
      }
  }
  else
  {
    WeaponRotation();
  }
 
  
}
bool reload=true;
//panelde dolum tablosu yap ki gösterilsin
IEnumerator Reload()
{
  //bool kapalı
yield return new WaitForSeconds(1f);
//boolu aktif eder
for(int i=0;i<=10;i++)
{
if(Input.GetKey(KeyCode.Space))
{
  currentmagcap=magazinecap;
  Debug.Log("basildi");
 reload=true;
  yield break; 
  
}
yield return new WaitForSeconds(0.05f);
}
// tam zamanında basma olayı olabilir
yield return new WaitForSeconds(1f);
//bool kapalı
 reload=true;
currentmagcap=magazinecap;

yield break;
}
 public void WeaponShot()
 {
  if(isPlayer)
  {
   currentmagcap-=1;
  }
  

  for(int i=0;i<=FireAmmoCount-1;i++)
  {
  
    GameObject ammo=Instantiate(AmmoType,BulletTransform.position+new Vector3(Random.Range(0.2f,0.2f),Random.Range(0.2f,0.2f),0),Quaternion.identity);
    // hedef aldığın yere göre mermi hızı
    ammo.GetComponent<Rigidbody2D>().AddForce(BulletTransform.right*10+new Vector3(Random.Range(1.5f*i,-1.5f*i),Random.Range(1.5f*i,-1.5f*i),0),ForceMode2D.Impulse);

      
    /*instantiate lazım ve instantiate bullettransform un küçük randomlar eklenerek atılmasına ayarlı
   mermiler izlenilen direksiyonda karakterin hızının eklenilmesiyle atılmalı*/
  }
 }

 //silahların mermisi bitince hepsinde reload olmayacak çünkü enemylerinde var silahları
}
