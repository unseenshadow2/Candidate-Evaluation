package com.company;

import WidgetFactory.Part;
import WidgetFactory.PartNotFoundException;
import WidgetFactory.Warehouse;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.UUID;

public class Factory
{
    private LinkedList<Blueprint> blueprints = new LinkedList();
    private Warehouse _warehouse;
    private int reOrders = 0;

    public Factory() {}
    public Factory(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public void OrderAllParts()
    {
        blueprints.forEach(this::OrderParts);
    }

    public void OrderParts(Blueprint blueprint)
    {
        blueprint.GetRequiredParts().forEach((partId, count) -> _warehouse.order(partId));
    }

    private Widget BuildBlueprint(Blueprint blueprint)
    {
        Widget toReturn = new Widget(blueprint.getId(), UUID.randomUUID().toString());

        blueprint.GetRequiredParts().forEach((partId, count) ->
        {
            for (int i = 0; i < count; i++)
            {
                try
                {
                    if (_warehouse.available(partId)) toReturn.AddPart(_warehouse.retrieve(partId));
                    else {
                        _warehouse.order(partId);
                        toReturn.AddPart(_warehouse.retrieve(partId));
                        ++reOrders;
                    }
                }
                catch (PartNotFoundException ex)
                {
                    System.out.println("Part " + partId + " is out of stock. This shouldn't happen.");
                }
            }
        });

        return toReturn;
    }

    public Widget BuildWidget(String widgetId)
    {
        Blueprint blue = null;

        for (Blueprint b : blueprints)
        {
            if (b.getId().equals(widgetId))
            {
                blue = b;
                break;
            }
        }

        if (blue == null)
        {
            Widget toReturn = new Widget(widgetId, true);
            return toReturn;
        }
        else return BuildBlueprint(blue);
    }

    public Widget[] BuildOrder(HashMap<String, Integer> order)
    {
        LinkedList<Widget> widgets = new LinkedList();

        order.forEach((widgetId, count) ->
        {
            for(int i = 0; i < count; i++)
            {
                widgets.add(BuildWidget(widgetId));
            }
        });

        return widgets.toArray(new Widget[0]);
    }

    public void ResetReorders()
    {
        reOrders = 0;
    }

    public void AddBlueprint(Blueprint toAdd)
    {
        blueprints.add(toAdd);
    }

    public void DeleteBlueprint(Blueprint toRemove)
    {
        blueprints.remove(toRemove);
    }

    public Blueprint[] GetBlueprints()
    {
        return blueprints.toArray(new Blueprint[0]);
    }

    public void SetWarehouse(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public Warehouse GetWarehouse()
    {
        return _warehouse;
    }

    public int GetReorders()
    {
        return reOrders;
    }
}
