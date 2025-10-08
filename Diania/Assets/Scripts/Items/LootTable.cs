using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    [SerializeField] private List<Item> _commonList;
    [SerializeField] private List<Item> _rareList;
    [SerializeField] private List<Item> _epicList;
    [SerializeField] private List<Item> _legendaryList;
    
    [SerializeField] private List<Weapon> _weapons;

    public Rarity _rarityResult;

    private Rarity RarityResult()
    {
        int random = Random.Range(1, 100);
        if (random <= 40)
        {
            _rarityResult = Rarity.Common;
        }
        else if (random <= 70 && random > 40)
        {
            _rarityResult = Rarity.Rare;
        }
        else if (random <= 90 && random > 70)
        {
            _rarityResult = Rarity.Epic;
        }
        else if (random <= 100 && random > 90)
        {
            _rarityResult = Rarity.Legendary;
        }
        return _rarityResult;
    }

    public Item ItemResult()
    {
        RarityResult();
        Item itemLoot = _commonList[RandomItemResult(_commonList)];
        switch (_rarityResult)
        {
            case Rarity.Common:
                itemLoot = _commonList[RandomItemResult(_commonList)];
                break;
            case Rarity.Rare:
                itemLoot = _rareList[RandomItemResult(_rareList)];
                break;
            case Rarity.Epic:
                itemLoot = _epicList[RandomItemResult(_epicList)];
                break;
            case Rarity.Legendary:
                itemLoot = _legendaryList[RandomItemResult(_legendaryList)];
                break;
        }

        return itemLoot;
    }

    private int RandomItemResult(List<Item> currentList)
    {
        return Random.Range(0, currentList.Count);
    }

    private int RandomWeaponResult(List<Weapon> currentList)
    {
        return Random.Range(0, currentList.Count);
    }
}
