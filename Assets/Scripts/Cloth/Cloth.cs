using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cloth", menuName = "Add Cloth")]
public class Cloth: ScriptableObject
{
    public enum Slot { Hair, Hat, Top, Glasses }
    public Slot itemslot = Slot.Hat;
    public int itemID;
    public GameObject mesh;
}
