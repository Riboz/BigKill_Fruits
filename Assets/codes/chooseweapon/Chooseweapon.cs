using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chooseweapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Image tomatoweapon;
    public Sprite[] weaponimage;
    public GameObject[] panels;
    public void Entershotgun()
    {
    tomatoweapon.sprite=weaponimage[0];
    panels[0].GetComponent<Image>().color=Color.green;
     panels[1].GetComponent<Image>().color=Color.white;
      panels[2].GetComponent<Image>().color=Color.white;
    }
    public void Enterdoublegun()
    {
     tomatoweapon.sprite=weaponimage[1];
     panels[1].GetComponent<Image>().color=Color.green;
     
      panels[2].GetComponent<Image>().color=Color.white;
      panels[0].GetComponent<Image>().color=Color.white;
    }
    public void Entermachinegun()
    {
     tomatoweapon.sprite=weaponimage[2];
     panels[2].GetComponent<Image>().color=Color.green;
      panels[1].GetComponent<Image>().color=Color.white;
      panels[0].GetComponent<Image>().color=Color.white;
    }
     public void clickshotgun()
    {
     myplayer.randomint=2;
     myplayer.damagepower=1;
      SceneManager.LoadScene("Abyss");
    }
    public void clickdoublegun()
    {
     myplayer.randomint=0;
     myplayer.damagepower=1;
     SceneManager.LoadScene("Abyss");
    }
    public void clickmachinegun()
    {
      myplayer.randomint=1;
      myplayer.damagepower=1;
      SceneManager.LoadScene("Abyss");
    }
    public Text deat;
    public void FixedUpdate()
    {
      if(myplayer.dead)
      {
        // active et
        deat.gameObject.SetActive(true);
      }
      
    }

}
