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
  public int magazinecap;
  public GameObject AmmoType;
  public Transform BulletTransform;
  Vector3 diffrance;
  public bool incooldown=false ,LookingLeft,canattack=true;
   
  IEnumerator cooldownlook()
  {
    incooldown=true;
    

    yield return new WaitForSeconds(0.4f);

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
 WeaponRotation();
  if(canattack)
  {
  if(Input.GetMouseButton(0) &&!incooldown )
    {
    WeaponShot();
    StartCoroutine(cooldownlook());
    }
  }
}
 public void WeaponShot()
 {
  magazinecap-=1;

  for(int i=0;i<=FireAmmoCount-1;i++)
  {
  
    GameObject ammo=Instantiate(AmmoType,BulletTransform.position+new Vector3(Random.Range(-0.4f,0.4f),Random.Range(-0.4f,0.4f),0),Quaternion.identity);
    // hedef aldığın yere göre mermi hızı
    ammo.GetComponent<Rigidbody2D>().velocity=diffrance+new Vector3((int)Random.Range(-3f,3f),(int)Random.Range(-3f,3f),0);

      
    /*instantiate lazım ve instantiate bullettransform un küçük randomlar eklenerek atılmasına ayarlı
   mermiler izlenilen direksiyonda karakterin hızının eklenilmesiyle atılmalı*/
  }
 }

 //silahların mermisi bitince hepsinde reload olmayacak çünkü enemylerinde var silahları
}
