using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum choosed 
{
 attack,healthregen   
}

public class choosing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController Gamecont;
    int hp=1;
    public choosed Choosed;
    public GameObject pepper,chooses,pepperspeak;
    

    // Update is called once per frame
    public void damageC(int hasar)
    {
     hp+=hasar;
     if(hp<=0)
     {
        if(Choosed==choosed.attack)
        {
         myplayer.damagepower=2;
         Destroy(chooses);
         Gamecont.wave=5;
        
        Gamecont.enemycount(0);
        }
         if(Choosed==choosed.healthregen)
        {
        GameObject.FindGameObjectWithTag("Player").GetComponent<myplayer>().Hp_point=10;
        GameObject.FindGameObjectWithTag("Player").GetComponent<myplayer>().healthimage.sprite=GameObject.FindGameObjectWithTag("Player").GetComponent<myplayer>().tomatos[0];
        Destroy(chooses);

        Gamecont.wave=5;

        Gamecont.enemycount(0);
        
        }
     Destroy(pepper);
     pepperspeak.SetActive(false);
    }
    }
    
}
