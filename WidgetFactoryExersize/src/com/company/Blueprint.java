package com.company;

import java.util.HashMap;

public class Blueprint
{
    private String _id;
    private HashMap<String, Integer> requiredParts = new HashMap<>();
    // TODO: Make inputs and outputs for required parts

    public Blueprint(String id)
    {
        _id = id;
    }

    public void AddRequiredPart(String partId)
    {
        Integer partCount = requiredParts.getOrDefault(partId, 0);
        requiredParts.put(partId, partCount + 1);
    }

    // Getters and setters
    public String getId() { return _id; }

    public void setId(String id) { _id = id; }
}
