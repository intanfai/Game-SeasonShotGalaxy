using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/Level Config")]
public class LevelConfig : ScriptableObject
{
    public int totalItems = 2;
    public float timeLimit = 60f;
    public int scorePerItem = 50;
    public string nextLevelName = "Level2";
}
