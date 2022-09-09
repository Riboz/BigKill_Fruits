using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public GameObject[] weapons;
   public Transform Weaponpos;
   Rigidbody2D rb;
    void Start()
    {
        
         int randomint=Random.Range(0,3);

     rb=GetComponent<Rigidbody2D>();

     GameObject weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     weapon.GetComponent<Hweapon>().isplayer=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
