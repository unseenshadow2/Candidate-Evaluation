package com.company;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;

public class WidgetReader
{
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
