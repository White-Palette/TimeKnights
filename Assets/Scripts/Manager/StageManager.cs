using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{
    private int _currentStage;
    private Player[] _players = new Player[2];

    private void Start()
    {
        _players[0] = new Player();
        _players[1] = new Player();
    }

    private void Update()
    {
        foreach (var player in _players)
        {
            player.Money += player.MoneyPerSecond * Time.deltaTime;
        }
        UIManager.Instance.Resource = (int)_players[0].Money;
    }
}