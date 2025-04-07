using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : IPlayerAction
{
    public abstract string name {get;}
    public abstract bool CanExecute(Player player);
    public abstract void Execute(Player player);
    public virtual int GetSupplyCost(Player player) => 1;
}
