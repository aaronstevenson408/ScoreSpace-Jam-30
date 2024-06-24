using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangery : MonoBehaviour
{
    public RectTransform background;
    public changeScenery groundLevel;
    public changeScenery skyLevel;
    public changeScenery SpaceLevel;

    GameManager gameManager;
    public float speed;

    public float distForSceneChange;
     public float dynamicSceneYlevel;
    bool isUsingdynamicSceneChange;

    bool valueChanged;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        
        StageChange();
    }

    public void StageChange()
    {
        if (!isUsingdynamicSceneChange)
        {
            if (gameManager.isInFloorStage)
            {
                background.anchoredPosition = new Vector3(background.anchoredPosition.x, groundLevel.backgroundScenePositionY);
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= groundLevel.increaseEnemySpawns;
                    valueChanged =true;
                }


                if (gameManager.player.transform.position.y > skyLevel.yLevelToNewScene && gameManager.player.transform.position.y < SpaceLevel.yLevelToNewScene)
                {
                    valueChanged = false;
                    CurrentStage(false, true, false);
                }
            }
            if (gameManager.isInSkyStage)
            {
                background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, skyLevel.backgroundScenePositionY), speed / 100);
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= skyLevel.increaseEnemySpawns;
                    valueChanged = true;
                }
                if (gameManager.player.transform.position.y > SpaceLevel.yLevelToNewScene)
                {
                    valueChanged = false;
                    CurrentStage(false, false, true);
                }
            }
            if (gameManager.isInSpaceStage)
            {
                Debug.Log("Is in Space");
                background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, SpaceLevel.backgroundScenePositionY), speed / 100);
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= SpaceLevel.increaseEnemySpawns;
                    valueChanged = true;
                }
                if (gameManager.player.transform.position.y > SpaceLevel.yLevelToNewScene + ((SpaceLevel.yLevelToNewScene + SpaceLevel.yLevelToNewScene) / 2))
                {
                    dynamicSceneYlevel = SpaceLevel.yLevelToNewScene + ((SpaceLevel.yLevelToNewScene + SpaceLevel.yLevelToNewScene) / 2);
                    valueChanged = false;
                    isUsingdynamicSceneChange = true;
                }
            }
        }
        else
        {
            if((transform.position.y - dynamicSceneYlevel) >= distForSceneChange)
            {
                if (gameManager.isInSpaceStage)
                {
                    background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, skyLevel.backgroundScenePositionY), speed / 100);
                    valueChanged = false;
                    gameManager.isInSkyStage = true;
                    gameManager.isInSpaceStage = false;
                   
                } else if (gameManager.isInSkyStage)
                {
                    background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, SpaceLevel.backgroundScenePositionY), speed / 100);

                    gameManager.isInSkyStage = false;
                    gameManager.isInSpaceStage = true;
                    valueChanged = false;
                }
                dynamicSceneYlevel = transform.position.y;
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= .05f;
                    valueChanged = true;
                }
            }
        }
        
    }


    public void CurrentStage(bool ground, bool sky, bool space)
    {
        gameManager.isInFloorStage = ground;
        gameManager.isInSkyStage = sky;
        gameManager.isInSpaceStage = space;
    }
}
[System.Serializable]
public class changeScenery
{
    public float backgroundScenePositionY;
    public float yLevelToNewScene;
    public float increaseEnemySpawns;
    public float increaseItemSpawns;
}