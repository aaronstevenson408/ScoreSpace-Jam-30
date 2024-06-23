using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> floorEnemies;
    public List<GameObject> skyEmemies;
    public List<GameObject> spaceEnemies;

    public List<ItemDropChance> items;
    public int enemySpawnRate;
    public int itemSpawnRate;
    [SerializeField] GameObject player;

    [Header("Flag")]
    public bool isInFloorStage;
    public bool isInSkyStage;
    public bool isInSpaceStage;

    public Vector2 min_maxX;
    public Vector2 min_maxY;
    private void Start()
    {
        SpawnEnemy();
        SpawnItems();
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3();

            spawnPosition.y = player.transform.position.y + 9.5f;

            int spawnDirection = Random.Range(0, 2);
            if(spawnDirection == 0)
            {
                //Spawn Left Side
                spawnPosition.x = player.transform.position.x - 10.5f;
            }
            else
            {
                //Spawn Right Side
                spawnPosition.x = player.transform.position.x + 10.5f;
            }

            if (isInFloorStage)
            {
                var RandomEnemy = Random.Range(0, floorEnemies.Count);
                var enemy = Instantiate(floorEnemies[RandomEnemy], spawnPosition, Quaternion.identity);
                /*    var enemyManager = enemy.GetComponent<Hazards>();
                    if (enemyManager.usingDropPoint)
                    {

                    } else if (enemyManager.goingBetweenTwoPoints)
                    {

                    }
                    else if (enemyManager.usingGlide)
                    {

                    }
                    else if (enemyManager.goingDirection)
                    {

                    }
                } else if (isInSkyStage)
                {

                }
                else if (isInSpaceStage)
                {
                */
        }
        Invoke("SpawnEnemy", enemySpawnRate);
    }
    private void SpawnItems()
    {
        Vector3 spawnPosition = new Vector3();

            spawnPosition.y = player.transform.position.y + min_maxY.y;

                var leftSpawnPositionX = player.transform.position.x - min_maxX.x;
                var rightSpawnPositionX = player.transform.position.x + min_maxX.y;
            spawnPosition.x = Random.Range(leftSpawnPositionX, rightSpawnPositionX);
                var RandomItem = Random.Range(0, items.Count);
       

        foreach (ItemDropChance item in items)
        {
            if (ShouldDropItem(item))
            {
                var spawnedItem = Instantiate(items[RandomItem].item, spawnPosition, Quaternion.identity);
            }
        }
        Invoke("SpawnItems", itemSpawnRate);
    }
    bool ShouldDropItem(ItemDropChance item)
    {
        var ChanceForItemToSpawn = Random.Range(0, 100);
        return ChanceForItemToSpawn <= item.dropChanceOutOf100;
    }

    [System.Serializable]
    public class ItemDropChance
    {
        public GameObject item;
        public int dropChanceOutOf100;
        public ItemDropChance(GameObject _item,int _dropChance)
        {
            item = _item;
            dropChanceOutOf100 = _dropChance;
        }
    }
}
