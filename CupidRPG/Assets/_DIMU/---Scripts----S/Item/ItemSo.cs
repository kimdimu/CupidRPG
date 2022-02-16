using UnityEngine;

public class ItemSo : ScriptableObject
{
    [SerializeField]
    GameObject iconFab;//아이콘

    public void InstantiateFab(Transform transform)
    {
        Instantiate(iconFab, transform);
    }

    public void PlayEffects()
    {

    }
}