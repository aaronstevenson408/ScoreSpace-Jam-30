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
         if (gameManager.isInFloorStage)
        {
            background.anchoredPosition = new Vector3 (background.anchoredPosition.x,groundLevel.yLevelToNewScene);
            if (gameManager.player.transform.position.y > skyLevel.yLevelToNewScene && gameManager.player.transform.position.y < SpaceLevel.yLevelToNewScene)
            {
                CurrentStage(false, true, false);
            }
        }
         if (gameManager.isInSkyStage)
        {
            background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, skyLevel.yLevelToNewScene), speed/100);
            if (gameManager.player.transform.position.y > SpaceLevel.yLevelToNewScene)
            {
                CurrentStage(false, false, true);
            }
        }  if (gameManager.isInSpaceStage)
        {
            Debug.Log("Is in Space");
            background.anchoredPosition = Vector3.Lerp(background.anchoredPosition, new Vector3(background.anchoredPosition.x, SpaceLevel.yLevelToNewScene), speed/100);
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
    public float yPoisitionOfScene;
    public float yLevelToNewScene;
}