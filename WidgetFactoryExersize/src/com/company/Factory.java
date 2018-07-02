package com.company;

import WidgetFactory.Part;
import WidgetFactory.PartNotFoundException;
import WidgetFactory.Warehouse;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.UUID;

/**
 *
 */
public class Factory
{
    private LinkedList<Blueprint> blueprints = new LinkedList();
    private Warehouse _warehouse;
    private int reOrders = 0;

    /**
     * Constructor.
     */
    public Factory() {}

    /**
     * Constructor.
     *
     * @param warehouse The warehouse the factory is assigned to
     */
    public Factory(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    /**
     * Orders parts for all blueprints available to the factory.
     */
    public void OrderAllParts()
    {
        blueprints.forEach(this::OrderParts);
    }

    /**
     * Orders parts for a single blueprint. Allows for the ordering of
     * parts for blueprints not available to the factory.
     *
     * @param blueprint The blueprint to order parts for
     */
    public void OrderParts(Blueprint blueprint)
    {
        blueprint.GetRequiredParts().forEach((partId, count) -> _warehouse.order(partId));
    }

    /**
     * Build a widget from the provided blueprint. This can be used to
     * allow the factory to make exclusive or limited production orders.
     *
     * @param blueprint The blueprint of the widget to be produced
     * @return The widget produced
     */
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

    /**
     * Build a single widget from a blueprint referenced by the widget's ID.
     *
     * @param widgetId The ID of the blueprint used to build the widget
     * @return The widget the factory built
     */
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

    /**
     * Build an order.
     *
     * @param order The order to be processed. Should be formatted as
     *              <WidgetID, WidgetCount>
     * @return The widgets produced
     */
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

    /**
     * Reset the reorders value.
     */
    public void ResetReorders()
    {
        reOrders = 0;
    }

    /**
     * Add a blueprint to the factory's available blueprints.
     *
     * @param toAdd The blueprint to be added
     */
    public void AddBlueprint(Blueprint toAdd)
    {
        blueprints.add(toAdd);
    }

    /**
     * Remove a blueprint from the available blueprints.
     *
     * @param toRemove The blueprint to be removed
     */
    public void DeleteBlueprint(Blueprint toRemove)
    {
        blueprints.remove(toRemove);
    }

    /**
     * Get the blueprints available to the factory.
     *
     * @return The blueprints the factory has available
     */
    public Blueprint[] GetBlueprints()
    {
        return blueprints.toArray(new Blueprint[0]);
    }

    /**
     * Change which warehouse the factory is assigned to.
     *
     * @param warehouse The new warehouse
     */
    public void SetWarehouse(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    /**
     * Get the warehouse the factory is assigned to.
     *
     * @return The assigned warehouse
     */
    public Warehouse GetWarehouse()
    {
        return _warehouse;
    }

    /**
     * Get the number of times that the factory has had to order parts
     * after starting to build widgets.
     *
     * @return The number of parts ordered after start
     */
    public int GetReorders()
    {
        return reOrders;
    }
}
