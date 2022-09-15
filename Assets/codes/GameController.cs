using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[]enemytypes;
    public GameObject signals;
    public int EnemyCountperWave,nowEnemycounterwave;
    void Start()
    {
        StartCoroutine(Enemyspawner());
    }
    public void enemycount (int negative)
    {
      nowEnemycounterwave+=negative;
      if(nowEnemycounterwave==0)
      {
        StartCoroutine(Enemyspawner());
        
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
           Instantiate(enemytypes[Random.Range(0,4)],randomplace,Quaternion.identity);
           
    
            
        }
        EnemyCountperWave+=1;
        

        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
