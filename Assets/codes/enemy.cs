using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemy :MonoBehaviour
{
   public GameObject[] weapons;
   public Transform Weaponpos;
   
   int i=0;
   Rigidbody2D rb;
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

     rb=GetComponent<Rigidbody2D>();

     GameObject weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     weapon.GetComponent<Hweapon>().isplayer=false;
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
}
