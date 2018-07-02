package com.company;

import WidgetFactory.Part;

import java.util.HashMap;
import java.util.LinkedList;

/**
 *
 */
public class Widget
{
    private String _id;
    private String _serialNumber;
    private LinkedList<Part> parts = new LinkedList();
    private boolean _isBadWidget = false;

    /**
     * Constructor.
     * Used to define a good widget.
     *
     * @param id The ID of the widget being created
     * @param serialNumber The serial number of the widget being created
     */
    public Widget(String id, String serialNumber)
    {
        _id = id;
        _serialNumber = serialNumber;
    }

    /**
     * Constructor.
     * Used to define a bad widget or a widget with
     * only an ID.
     *
     * @param id The ID of the widget being created
     * @param isBadWidget Whether the widget is a bad widget
     */
    public Widget(String id, Boolean isBadWidget)
    {
        _id = id;
        _isBadWidget = isBadWidget;
    }

    /**
     * Add a part to the widget.
     *
     * @param part The part to be added to the widget
     */
    public void AddPart(Part part)
    {
        parts.add(part);
    }

    /**
     * Remove a part from the widget.
     *
     * @param part The part to be removed
     */
    public void RemovePart(Part part)
    {
        parts.remove(part);
    }

    /**
     * The parts that make up the widget.
     *
     * @return The parts that make up the widget
     */
    public Part[] GetParts()
    {
        return parts.toArray(new Part[0]);
    }

    /**
     * Create a display string for the widget.
     *
     * @return A string that represents the widget
     */
    public String toString()
    {
        StringBuilder toReturn = new StringBuilder();

        toReturn.append("Name: " + _id + '\n');

        if (_isBadWidget)
        {
            toReturn.append("No specification exists for this widget.\nPlease inform your factory if you have a new specification you would like them to begin producing.\n");
        }
        else
        {
            toReturn.append("Serial Number: " + _serialNumber + '\n');

            for (Part p : parts)
            {
                toReturn.append("\tPart Type: " + p.getId() + '\n');
                toReturn.append("\t\tSerial Number: " + p.getSerialNo() + '\n');
            }
        }

        return toReturn.toString();
    }

    // Getters and setters
    /**
     * Get the current ID of the widget.
     *
     * @return The current ID of the widget
     */
    public String getId() { return _id; }

    /**
     * Change the ID of the widget.
     *
     * @param id The new ID of the widget
     */
    public void setId(String id) { _id = id; }

    /**
     * Get the current serial number of the widget.
     *
     * @return The current serial number of the widget
     */
    public String getSerialNumber() { return _serialNumber; }

    /**
     * Change the serial number of the widget.
     *
     * @param serialNumber The new serial number of the widget
     */
    public void setSerialNumber(String serialNumber) { _serialNumber = serialNumber; }
}
