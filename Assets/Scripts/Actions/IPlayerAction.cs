using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAction
{
    string name {get;}
    bool CanExecute(Player player);
    void Execute(Player player);
    int GetSupplyCost(Player player);
}
