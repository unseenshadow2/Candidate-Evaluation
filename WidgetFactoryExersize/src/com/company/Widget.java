package com.company;

import WidgetFactory.Part;

import java.util.HashMap;
import java.util.LinkedList;

public class Widget
{
    private String _id;
    private String _serialNumber;
    private LinkedList<Part> parts = new LinkedList();
    private boolean _isBadWidget = false;

    public Widget(String id, String serialNumber)
    {
        _id = id;
        _serialNumber = serialNumber;
    }

    public Widget(String id, Boolean isBadWidget)
    {
        _id = id;
        _isBadWidget = isBadWidget;
    }

    public void AddPart(Part part)
    {
        parts.add(part);
    }

    public void RemovePart(Part part)
    {
        parts.remove(part);
    }

    public Part[] GetParts()
    {
        return parts.toArray(new Part[0]);
    }

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
    public String getId() { return _id; }

    public void setId(String id) { _id = id; }

    public String getSerialNumber() { return _serialNumber; }

    public void setSerialNumber(String serialNumber) { _serialNumber = serialNumber; }
}
