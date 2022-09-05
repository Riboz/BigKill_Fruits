using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Hweapon : Weapons
{
    public bool isplayer=false;
     // startda olduğu objenin ismine göre belirlenicek
    // Update is called once per frame
    
    void Update()
    {
        if(isplayer)
        {

     
        if(magazinecap>0)
        {
            canattack=true;
        }
        else
        {
            canattack=false;
        }
        if(!canattack)
        {
            // bir slider oluşsun sliderin ortasında herhangi bir
        }
        }
        
    }
}
