using UnityEngine;

public class PlayerTrapStatus : MonoBehaviour
{
    public bool isFallingFromTrap = false;

    public void MarkAsFallingFromTrap()
    {
        isFallingFromTrap = true;
    }

    public void ResetTrapFall()
    {
        isFallingFromTrap = false;
    }
}
