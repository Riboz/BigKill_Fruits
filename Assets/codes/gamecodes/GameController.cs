using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[]enemytypes;
     public  int wave=0;
     public GameObject pepper,bosspepper;
    public GameObject signals,PepperDialogepanel;
    public TextMeshProUGUI pepperspeak,leftenemy;
    public string[] dialoge;

    public int EnemyCountperWave,nowEnemycounterwave;
     IEnumerator peppertime()
    {
         
        yield return new WaitForSeconds(1f);
        PepperDialogepanel.SetActive(true);
        
        for(int i=0;i<=dialoge.Length-1;i++)
        {
            pepperspeak.text+=" "+dialoge[i];
        if(i==2)
        {
            yield return new WaitForSeconds(1.2f);
            pepperspeak.text="";
        }
        if(i==7)
        {
            yield return new WaitForSeconds(1.2f);
            pepperspeak.text="";
        }
         if(i==9)
        {
            yield return new WaitForSeconds(1.2f);
            pepperspeak.text="";
        }
            yield return new WaitForSeconds(1.2f);
        }
        
       yield return new WaitForSeconds(2f);
        
         bosspepper.SetActive(true);
         PepperDialogepanel.SetActive(false);
         StartCoroutine(Enemyspawner());
         yield break;
    }
    
    void Start()
    {
        StartCoroutine(Enemyspawner());
    }
    public void enemycount (int negative)
    {
      nowEnemycounterwave+=negative;
      leftenemy.text="Kalan düşman: "+nowEnemycounterwave;
      if(nowEnemycounterwave==0 && wave<3)
      {
        StartCoroutine(Enemyspawner());
        
      }
      if(wave==3 && nowEnemycounterwave==0 )
      {
        //geliştirme yapan adam belirecek
        pepper.SetActive(true);
      }
      if(nowEnemycounterwave==0 && wave>3 && wave < 7)
      {
        StartCoroutine(Enemyspawner());
        
      }
       if(wave==7 && nowEnemycounterwave==0 )
      {
         // boss spawnlansın
         //bu alttaki fonksiyonları bir enumeratore bağla belli bir süreden sonra texte hikaye yazaar gibi yazdır ve oyuna başla vb vb
        pepperspeak.text=" ";
        StartCoroutine(peppertime());
         
      }
     
    }
    public IEnumerator Enemyspawner()
    {
        nowEnemycounterwave=EnemyCountperWave;
        
        for(int i=1;i<=EnemyCountperWave;i++)
        {
           Vector3 randomplace=new Vector3((int)Random.Range(-39,3),(int)Random.Range(-11,16),0);
           GameObject Signal=Instantiate(signals,randomplace,Quaternion.identity);
           yield return new WaitForSeconds(0.8f);
           //spawnlanacak yerde gösterge oluşsun
            Destroy(Signal);
            yield return new WaitForSeconds(0.1f);
           Instantiate(enemytypes[Random.Range(0,5)],randomplace,Quaternion.identity);
           
    
            
        }
        
        EnemyCountperWave+=1;
        leftenemy.text="Kalan düşman: "+nowEnemycounterwave;
        wave+=1;

        yield break;
    }
    // Update is called once per frame
    public GameObject winnerpanel;
    void FixedUpdate()
    {
        if(nowEnemycounterwave==-1)
        {
          // tebrikler oyunu kazandınız
          winnerpanel.SetActive(true);
        }
    }
}
