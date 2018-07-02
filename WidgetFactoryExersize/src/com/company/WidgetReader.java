package com.company;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;

/**
 * Handles the processing of specification and order
 * files and strings.
 */
public class WidgetReader
{
    /**
     * Read a specification file and use it to populate the factory's blueprints.
     *
     * @param filename The filename of the specification file
     * @param factory The factory to populate with blueprints
     * @throws IOException When the specification file can't be accessed or created
     */
    public static boolean ReadSpecFile(String filename, Factory factory) throws IOException
    {
        Path path = Paths.get(filename);

        if (FileExistsOrCreate(path))
        {
            ReadSpecString(new String(Files.readAllBytes(path)), factory);
            return true;
        }
        else
        {
            System.out.println("An empty file has been created at " + path.getFileName());
            return false;
        }
    }

    /**
     * Read an order file and determine the widgets that are being ordered.
     *
     * @param filename The filename of the order file
     * @return The widgets ordered (read as <WidgetID, WidgetCount>)
     * @throws IOException When the order file can't be accessed or created
     */
    public static HashMap<String, Integer> ReadOrderFile(String filename) throws IOException
    {
        HashMap<String, Integer> orders; // Name, count
        Path path = Paths.get(filename);

        if (FileExistsOrCreate(path))
        {
            orders = ReadOrderString(new String(Files.readAllBytes(path)));
            return orders;
        }
        else
        {
            System.out.println("An empty file has been created at " + path.getFileName());
            return null;
        }
    }

    /**
     * Read a specification string and use it to populate the factory's
     * blueprints.
     *
     * @param specString The specification string to draw the blueprints
     *                   from
     * @param factory The factory to populate with blueprints
     */
    public static void ReadSpecString(String specString, Factory factory)
    {
        String[] components = specString.split("(?<=\\W)\\s+|,\\s+|,");

        Blueprint blue = null;

        for(String s : components)
        {
            if (s != null)
            {
                if (s.charAt(s.length() - 1) == ':')
                {
                    s = s.replace(":", "");
                    blue = new Blueprint(s);
                    factory.AddBlueprint(blue);
                }
                else if (blue != null)
                {
                    s = s.trim();
                    blue.AddRequiredPart(s);
                }
            }
        }
    }

    /**
     * Read an order string and determine the widgets that are being ordered.
     *
     * @param order The order to be processed
     * @return The widgets ordered (read as <WidgetID, WidgetCount>)
     */
    public static HashMap<String, Integer> ReadOrderString(String order)
    {
        HashMap<String, Integer> toReturn = new HashMap();
        String[] items = order.split("\\s+");

        for(String s : items)
        {
            if ((s != null) && !(s.trim().equals("")))
            {
                s = s.trim();
                Integer partCount = toReturn.getOrDefault(s, 0);
                toReturn.put(s, partCount + 1);
            }
        }

        return toReturn;
    }

    /**
     * Check to see if a file exists and create
     * it if it doesn't.
     *
     * @param path The filepath of the file to be checked
     * @return Whether the file existed before this function ran
     * @throws IOException If the file can't be accessed or created
     */
    public static Boolean FileExistsOrCreate(Path path) throws IOException
    {
        if (Files.notExists(path))
        {
            Files.createFile(path);
            return false;
        }
        else
        {
            return true;
        }
    }
}
