using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Rarerity
{
    o,
    oo,
    ooo
}

[Serializable]
public class PhotoInformation
{
    public int Id;
    public Rarerity rarerity;
    public Sprite picture;
}

[Serializable]
[CreateAssetMenu(fileName = "PictureDate",menuName = "CreateDateBase")]

public class CreateScript_PhotoData : ScriptableObject
{
    public List<PhotoInformation> pictureInfos;
}
