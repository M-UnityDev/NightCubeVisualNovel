using UnityEngine;
public class FPSCAPER : MonoBehaviour
{
    [SerializeField] private int FPS;
    private void Awake() 
    {
        Application.targetFrameRate = FPS;
        Screen.SetResolution(800, 600, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 25, denominator = 1 });
    }
}
