using UnityEngine;
using UnityEngine.InputSystem;

public class VictoryScreenInterface : MonoBehaviour
{
    [SerializeField] private Gameplay gameplay;

    // This button allows the player to go to the next round when they are ready.
    public void proceed()
    {
        gameplay.nextRound();
    }
}
