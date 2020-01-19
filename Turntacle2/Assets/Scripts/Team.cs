
﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public List<int> playingCharacters;

    public Team()
    {
        playingCharacters = new List<int>();
    }
    public void addCharacter(int indexChar)
    {
        playingCharacters.Add(indexChar);
    }
}
