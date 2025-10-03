using UnityEngine;
using UnityEngine.UI;

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items", order = 1)]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public string Description => _description;
    public Rarity Rarity => _rarity;
    public Sprite Icon => _icon;

}
