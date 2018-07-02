package com.company;

import java.util.HashMap;

/**
 * Handles storing the parts required to build a widget.
 */
public class Blueprint
{
    private String _id;
    private HashMap<String, Integer> requiredParts = new HashMap<>();

    /**
     * Constructor.
     *
     * @param id The ID of the blueprint
     */
    public Blueprint(String id)
    {
        _id = id;
    }

    /**
     * Add a single part to the parts required by the blueprint.
     *
     * @param partId The ID of the part to be added to the required parts
     */
    public void AddRequiredPart(String partId)
    {
        Integer partCount = requiredParts.getOrDefault(partId, 0);
        requiredParts.put(partId, partCount + 1);
    }

    /**
     * Set the number of a part required by the blueprint.
     *
     * @param partId The ID of the required part
     * @param count The number of the part needed
     */
    public void SetRequiredPartCount(String partId, Integer count)
    {
        requiredParts.put(partId, count);
    }

    /**
     * Reduce the amount of a type of part that is required
     * to build the blueprint.
     *
     * @param partId The ID of the part being reduced
     */
    public void ReduceRequiredPart(String partId)
    {
        Integer count = requiredParts.getOrDefault(partId, 0);

        if (count > 0) requiredParts.put(partId, count-1);
    }

    /**
     * Remove a part from the required parts of the blueprint.
     *
     * @param partId The ID of the part to be removed from the
     *               required parts
     */
    public void DeleteRequiredPart(String partId)
    {
        requiredParts.remove(partId);
    }

    /**
     * Get the parts required to build the blueprint.
     *
     * @return The required parts for the blueprint (read as <PartID, PartCount>)
     */
    public HashMap<String, Integer> GetRequiredParts() { return requiredParts; }

    /**
     * Create a human readable string
     * representation of the blueprint.
     *
     * @return A string representing the blueprint
     */
    public String toString()
    {
        StringBuilder toReturn = new StringBuilder();

        toReturn.append("ID: " + _id + "\n");

        requiredParts.forEach((k, v) ->
        {
            toReturn.append("\tPart ID: " + k);
            toReturn.append("\n\t\t" + k + "s Required: " + v + "\n");
        });

        return toReturn.toString();
    }

    // Getters and setters
    /**
     * Get the current ID of the blueprint.
     *
     * @return The current ID of the blueprint
     */
    public String getId() { return _id; }

    /**
     * Change the ID of the blueprint.
     *
     * @param id The ID of the blueprint
     */
    public void setId(String id) { _id = id; }
}
