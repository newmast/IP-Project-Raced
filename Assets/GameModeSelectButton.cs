using Assets.GameModes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelectButton : MonoBehaviour
{
    private GameModeSelect gameModeSelect;

    private void Start()
    {
        gameModeSelect = GameObject.FindGameObjectWithTag("GameModeSelect").GetComponent<GameModeSelect>();
    }
    
    private void ChangeScene()
    {
        SceneManager.LoadScene("Scenes/gameplay");
    }
     
    public void SetToSingleplayer()
    {
        gameModeSelect.GameMode = GameMode.Singleplayer;
        ChangeScene();
    }

    public void SetToChase()
    {
        gameModeSelect.GameMode = GameMode.Chase;
        ChangeScene();
    }

    public void SetToTeamwork()
    {
        gameModeSelect.GameMode = GameMode.Teamwork;
        ChangeScene();
    }

    public void SetToSurvival()
    {
        gameModeSelect.GameMode = GameMode.Survival;
        ChangeScene();
    }
}
