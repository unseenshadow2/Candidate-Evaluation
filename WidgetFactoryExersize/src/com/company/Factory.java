package com.company;

import java.util.LinkedList;

public class Factory
{
    private LinkedList<Blueprint> blueprints = new LinkedList();

    public Factory() {}

    public void AddBlueprint(Blueprint toAdd)
    {
        blueprints.add(toAdd);
    }

    public void DeleteBlueprint(Blueprint toRemove)
    {
        blueprints.remove(toRemove);
    }

    // TODO: Create Build(Blueprint) function
}
