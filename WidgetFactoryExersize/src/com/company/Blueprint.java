package com.company;

import java.util.HashMap;

public class Blueprint
{
    private String _id;
    private HashMap<String, Integer> requiredParts = new HashMap<>();

    public Blueprint(String id)
    {
        _id = id;
    }

    public void AddRequiredPart(String partId)
    {
        Integer partCount = requiredParts.getOrDefault(partId, 0);
        requiredParts.put(partId, partCount + 1);
    }

    public void SetRequiredPartCount(String partId, Integer count)
    {
        requiredParts.put(partId, count);
    }

    public void ReduceRequiredPart(String partId)
    {
        Integer count = requiredParts.getOrDefault(partId, 0);

        if (count > 0) requiredParts.put(partId, count-1);
    }

    public void DeleteRequiredPart(String partId)
    {
        requiredParts.remove(partId);
    }

    public String ToString()
    {
        StringBuilder toReturn = new StringBuilder();

        toReturn.append("ID: "); toReturn.append(_id);

        // TODO: Print the required parts

        return toReturn.toString();
    }

    // Getters and setters
    public String getId() { return _id; }

    public void setId(String id) { _id = id; }
}
