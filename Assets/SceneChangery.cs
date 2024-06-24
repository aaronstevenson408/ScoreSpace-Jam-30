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


    [Header("Options")]
    public float changeBackgroundSpeed;
    public float dynamicSceneYlevel;

    float distForSceneChange;
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
                    CurrentStage(false, true, false);
                }
            }
            if (gameManager.isInSkyStage)
            {
                
                background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, skyLevel.backgroundScenePositionY), changeBackgroundSpeed / 100);
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= skyLevel.increaseEnemySpawns;
                    valueChanged = true;
                }
                if (gameManager.player.transform.position.y > SpaceLevel.yLevelToNewScene)
                {
                    CurrentStage(false, false, true);
                }
            }
            if (gameManager.isInSpaceStage)
            {
                Debug.Log("Is in Space");
                background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, SpaceLevel.backgroundScenePositionY), changeBackgroundSpeed / 100);
                if (!valueChanged)
                {
                    gameManager.enemySpawnRate -= SpaceLevel.increaseEnemySpawns;
                    valueChanged = true;
                }
                if (gameManager.player.transform.position.y > SpaceLevel.yLevelToNewScene + ((SpaceLevel.yLevelToNewScene + SpaceLevel.yLevelToNewScene) / 2))
                {
                    
                    isUsingdynamicSceneChange = true;
                }
            }
        }
        else
        {
            if (gameManager.player.transform.position.y - dynamicSceneYlevel >= distForSceneChange)
            {
                valueChanged = false;
                if (gameManager.isInSpaceStage)
                {
                    background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, skyLevel.backgroundScenePositionY), changeBackgroundSpeed / 100);
                    valueChanged = false;
                    gameManager.isInSkyStage = true;
                    gameManager.isInSpaceStage = false;
                   
                } 
                else if (gameManager.isInSkyStage)
                {
                    background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, SpaceLevel.backgroundScenePositionY), changeBackgroundSpeed / 100);

                    gameManager.isInSkyStage = false;
                    gameManager.isInSpaceStage = true;
                    valueChanged = false;
                }
                
                dynamicSceneYlevel = gameManager.player.transform.position.y + (gameManager.player.transform.position.y*.5f);
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
        valueChanged = false;
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
}