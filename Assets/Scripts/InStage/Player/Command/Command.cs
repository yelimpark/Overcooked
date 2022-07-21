using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.IO;
using System;

public abstract class Command
{
    [PunRPC]
    public abstract void Execute();
}
