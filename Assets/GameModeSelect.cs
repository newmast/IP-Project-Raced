using Assets.GameModes;
using UnityEngine;

public class GameModeSelect : MonoBehaviour
{
	private void Start()
    {
        DontDestroyOnLoad(gameObject);
	}

    public GameMode GameMode { get; set; }
}
