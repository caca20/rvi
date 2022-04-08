using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private HPElement playerHealthBar;
    [SerializeField] private RectTransform contentHolder;
    [SerializeField] private Sprite playerImage;
    [SerializeField] private Color playerHealthColor;
    [SerializeField] private Sprite enemyImage;
    [SerializeField] private Color enemyHealthColor;
    [SerializeField] private GameObject barPrefab;

    void OnEnable()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerHealthBar.SetPlayerImage(playerImage);
        playerHealthBar.SetHealthBar(player.Health/100,playerHealthColor);
     
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0;i<enemies.Length;i++){
            GameObject enemyBarObj = Instantiate(barPrefab, GameObject.FindGameObjectWithTag("Content").transform);
            if(enemyBarObj!=null){
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                HPElement enemyBar = enemyBarObj.GetComponent<HPElement>();
                enemyBar.SetId(enemy.ID);
                enemyBar.SetPlayerImage(enemyImage);
                enemyBar.SetHealthBar((float)enemy.Health/(float)(100),enemyHealthColor);
             //   Debug.Log(enemy.Health);
            }
        }   
    }
    private void OnDisable() {
        foreach (Transform child in contentHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
