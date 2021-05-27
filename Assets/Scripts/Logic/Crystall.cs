using UnityEngine;

public class Crystall : MonoBehaviour
{
    public int CurrentPlatformId { private set; get; } = 1;
    public int FinalPlatformId;
    
    public void CheckBreak(int platformId)
    {
        if((platformId - CurrentPlatformId) > 1)
        {
            Debug.Log("Проигрыш");
        } else {
            if (platformId == FinalPlatformId)
            {
                Debug.Log("Выигрыш");
            }
            CurrentPlatformId = platformId;
        }
    }
}
