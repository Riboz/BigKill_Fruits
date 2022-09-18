using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI speaktext;
    public Image speakerimage;
     public string[]dialog;
    public string[]dialogport;
    public string[]dialoglemon;
    public string[]dialogKARPUZ;
    public GameObject[]gameobj;
    
    

    public Sprite[]sprites;
    void Start()
    {
        StartCoroutine(speaker());
    }
    
    // ne? ... ne  annemle nasıl böyle konuşursun... 
    // b... b... be.. bende bende BENDE!!! SİZİN kadar meyveyim N.. n.. ne Cürretle NE cürretle!!! bana böyle davranırsınız doğru ehheheh doğru  eğer 
    //   eğer bütün meyveleri hihihih hepsini  hepinizi öldürürsem belki KİMSE BENLE dalga geçemez!!!
    // ve ve Belki sebzeler beni kabul eder hahahahha evet ... evet!!!! bunu yapmalıyım!!!
    IEnumerator speaker()
    {
         yield return new WaitForSeconds(1f);
      for(int a=0;a<=10;a++)
      {
        gameobj[0].transform.position= Vector2.MoveTowards(gameobj[0].transform.position,new Vector2(-2.5f,-0.6f),1);
        yield return new WaitForSeconds(0.1f);
      }
     yield return new WaitForSeconds(1f);
     //diğer meyveler aşşağılayacak
     gameobj[1].SetActive(true);
     speakerimage.sprite=sprites[1];
      yield return new WaitForSeconds(2f);
     for(int i=0;i<=dialogport.Length-1;i++)
     {
       speaktext.text+=" "+dialogport[i];
        yield return new WaitForSeconds(0.2f);
     }
      yield return new WaitForSeconds(2f);
       speakerimage.sprite=sprites[2];
       speaktext.text="";
       for(int i=0;i<=dialoglemon.Length-1;i++)
     {
       speaktext.text+=" "+dialoglemon[i];
        yield return new WaitForSeconds(0.2f);
     }
      yield return new WaitForSeconds(2f);
       speakerimage.sprite=sprites[3];
       speaktext.text="";
       for(int i=0;i<=dialogKARPUZ.Length-1;i++)
     {
       speaktext.text+=" "+dialogKARPUZ[i];
       if(i==3)
       {
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
        yield return new WaitForSeconds(0.3f);
     }
    yield return new WaitForSeconds(2f);
      speakerimage.sprite=sprites[0];
       speaktext.text="";
       for(int i=0;i<=dialog.Length-1;i++)
     {
       speaktext.text+=" "+dialog[i];
       if(i==7)
       { 
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
       if(i==16)
       { 
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
        if(i==25)
       { 
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
       if(i==33)
       { 
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
       if(i==39)
       { 
         yield return new WaitForSeconds(1.3f);
        speaktext.text="";
       }
        yield return new WaitForSeconds(0.3f);
     }
      yield return new WaitForSeconds(1f);
      gameobj[1].SetActive(false);
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene("Chooseweapon");

    }
    
}
