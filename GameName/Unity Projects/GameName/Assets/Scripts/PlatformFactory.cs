using UnityEngine;

public class PlatformFactory : MonoBehaviour {
    
    /// <summary>
    /// Will return which Platform is being used
    /// </summary>
    /// <returns>The Platform that is being used</returns>
    public static Platform GetPlatform() {
        switch (Application.platform) {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                return new Windows();
            case RuntimePlatform.Android:
                return new Android();
            case RuntimePlatform.IPhonePlayer:
                return new Apple();
            default:
                throw new System.Exception(string.Format("Applciation {0} cannot be found. Failing to load", Application.platform));
        }
    }
}
