using UnityEngine;
using UnityEngine.UI;

public class AimImageManager : MonoBehaviour
{
    private static AimImageManager _instance = null;
    public static AimImageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(AimImageManager)) as AimImageManager;
                if (_instance == null)
                {
                    _instance = new GameObject("Singleton of " + typeof(AimImageManager).ToString(), typeof(AimImageManager)).GetComponent<AimImageManager>();
                }

            }
            return _instance;
        }
    }

    [SerializeField]
    Image aimImage;
    [SerializeField]
    Color[] colors;

    public void ChangeChargeColor(int zeroto)
    {
        print(zeroto);
        aimImage.color = colors[zeroto];
    }
    public void AimUIOnOff(bool bl)
    {
        aimImage.gameObject.SetActive(bl);
    }
}
