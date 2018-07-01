package com.company;

/*
 * Program is to handle translating request orders (files) and
 * outputting the items that need to be produced and their parts.
 */

import WidgetFactory.Warehouse;

import java.io.IOException;
import java.nio.file.Paths;
import java.util.HashMap;
import java.nio.file.Files;

public class Main
{
    private static Warehouse warehouse = new Warehouse();
    private static Factory factory = new Factory(warehouse);

    private static String specFilepath = "specification.txt";
    private static String orderFilepath = "order.txt";
    private static String outputFilepath = "Finished Widgets.txt";

    public static void main(String[] args)
    {
        StringBuilder output = new StringBuilder();
        HashMap<String, Integer> order = null;
        Widget[] producedWidgets;

        // Load files
        try
        {
            boolean specFileExists = WidgetReader.ReadSpecFile(specFilepath, factory);
            order = WidgetReader.ReadOrderFile(orderFilepath);

            if(!specFileExists)
            {
                System.out.println(specFilepath + " now exists. Please fill it.");
                System.exit(-2);
            }

            if(order == null)
            {
                System.out.println(orderFilepath + " now exists. Please fill it.");
                System.exit(-2);
            }
        }
        catch (IOException ex)
        {
            System.out.println("One of the files produced an IOException:");
            System.out.println(ex.getMessage());
            System.exit(-1);
        }

        // Order parts and build the widgets
        factory.OrderAllParts();
        producedWidgets = factory.BuildOrder(order);

        // Setup final output
        output.append("Part orders required during production: "); output.append(factory.GetReorders());
        output.append("\n\n");

        output.append("Widgets produced:\n");

        for(Widget w : producedWidgets)
        {
            output.append(w.toString());
            output.append('\n');
        }

        try
        {
            Files.write(Paths.get(outputFilepath), output.toString().getBytes());
        }
        catch (IOException ex)
        {
            System.out.println("Could not write output file, which produced the following exception:");
            System.out.println(ex.getMessage());
            System.exit(-1);
        }

        System.out.println("Please check " + outputFilepath + " to view your produced widgets.");
    }

    public static Blueprint BlueprintDebug()
    {
        Blueprint blue = new Blueprint("Car");
        blue.AddRequiredPart("Engine");
        blue.AddRequiredPart("Steering Wheel");
        blue.AddRequiredPart("Sunroof");
        blue.AddRequiredPart("Seat");
        blue.SetRequiredPartCount("Wheel", 4);

        blue.AddRequiredPart("Seat");
        blue.AddRequiredPart("Seat");
        blue.AddRequiredPart("Seat");
        blue.AddRequiredPart("Seat");
        blue.ReduceRequiredPart("Seat");

        return blue;
    }

    public static void TestFactory()
    {
        String specString = "motorcycle: wheel, wheel, engine, seat, handlebar, car: wheel, wheel, wheel, wheel, engine, seat, steering wheel, sunroof, truck: wheel, wheel, wheel, wheel, engine, seat, steering wheel, truck-bed";
        String orderString = "car car motorcycle truck car truck motorcycle car car";
        HashMap<String, Integer> order;
        Widget[] widgets;

        WidgetReader.ReadSpecString(specString, factory);
        order = WidgetReader.ReadOrderString(orderString);
        widgets = factory.BuildOrder(order);

        System.out.println("Blueprints test");
        for(Blueprint blue : factory.GetBlueprints())
        {
            System.out.println(blue.toString());
            System.out.println();
        }

        System.out.println("Factory test");
        for(Widget w : widgets)
        {
            System.out.println(w.toString());
            System.out.println();
        }
    }
}
