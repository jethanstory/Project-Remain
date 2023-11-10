using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextPlayerTestScr : MonoBehaviour
{
    public GameObject fpsPlayer;
    public GameObject fpsPlayerRanger;
    public GameObject fpsPlayerObjects;
    public GameObject gameOverCanvas;
    public GameObject rangerIntroCanvas;
    public GameObject wanderEnemy;
    public GameObject longOneEnemy;

    public GameObject wanderEnemyNext;
    public GameObject longOneEnemyNext;
    public float secondsCount;
    // Start is called before the first frame update
    void Start()
    {

        //Destroy(fpsPlayer);

    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer();
    }

    void checkPlayer()
    {
        if (fpsPlayer.GetComponent<PlayerCollision>().hasCollided)
        {
            secondsCount += Time.deltaTime;
            gameOverCanvas.SetActive(true);
            fpsPlayerObjects.SetActive(true);
            fpsPlayerObjects.transform.position = fpsPlayer.transform.position;
            if (secondsCount > 2)
            {
                rangerIntroCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                fpsPlayer.SetActive(false);
                //Destroy(fpsPlayer);
                fpsPlayerRanger.SetActive(true);
                wanderEnemy.SetActive(false);
                wanderEnemyNext.SetActive(true);
                longOneEnemy.SetActive(false);
                longOneEnemyNext.SetActive(true);
                if (secondsCount > 3)
                {

                    rangerIntroCanvas.SetActive(false);
                    //Destroy(wanderEnemy);
                    //Destroy(longOneEnemy);
                }
            }


        }
    }
}
