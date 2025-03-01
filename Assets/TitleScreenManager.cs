using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameUI;
    public GameObject bird;
    public GameObject pipesSpawner;
    public GameObject backgroundMusic;
    public GameObject titleText;
    public GameObject startButton;

    void Start()
    {
        gameUI.SetActive(false);
        titleScreen.SetActive(true);
        bird.SetActive(false);
        pipesSpawner.SetActive(false);
        backgroundMusic.SetActive(false);
        titleText.SetActive(true);
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        gameUI.SetActive(true);
        bird.SetActive(true);
        pipesSpawner.SetActive(true);
        backgroundMusic.SetActive(true);

        BirdScript birdScript = bird.GetComponent<BirdScript>(); 
        birdScript.gameHasStarted = true;

        PipeSpawnScript pipeSpawnerScript = pipesSpawner.GetComponent<PipeSpawnScript>();
        pipeSpawnerScript.StartGame();

        pipeSpawnerScript.spawnPipe();
    }

    public void StopMusic()
    {
        backgroundMusic.SetActive(false);
    }
}

