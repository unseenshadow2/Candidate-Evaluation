package com.company;

import WidgetFactory.Part;

import java.util.HashMap;
import java.util.LinkedList;

public class Widget
{
    private String _id;
    private String _serialNumber;
    private LinkedList<Part> parts = new LinkedList();
    // TODO: Setup input and output for the parts list

    public Widget(String id, String serialNumber)
    {
        _id = id;
        _serialNumber = serialNumber;
    }

    // Getters and setters
    public String getId() { return _id; }

    public void setId(String id) { _id = id; }

    public String getSerialNumber() { return _serialNumber; }

    public void setSerialNumber(String serialNumber) { _serialNumber = serialNumber; }
}
