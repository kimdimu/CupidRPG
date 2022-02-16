using UnityEngine;
using UnityEngine.UI;

public class AimImageManager : Singleton<AimImageManager>
{

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
