using System;
using System.Collections.Generic;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        AddCollection<string> addCollection = new AddCollection<string>();
        AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
        MyList<string> mylist = new MyList<string>();

        StringBuilder addOpsAddcollection = new StringBuilder();
        StringBuilder addOpsAddRemoveCollection = new StringBuilder();
        StringBuilder addOpsMylist = new StringBuilder();
        StringBuilder removeAddRemoveCollection = new StringBuilder();
        StringBuilder removeOpsMyList = new StringBuilder();

        string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int removeOpsCount = int.Parse(Console.ReadLine());

        foreach (string item in tokens)
        {
            addOpsAddcollection.Append(addCollection.Add(item) + " ");
            addOpsAddRemoveCollection.Append(addRemoveCollection.Add(item) + " ");
            addOpsMylist.Append(mylist.Add(item) + " ");
        }

        for (int i = 0; i < removeOpsCount; i++)
        {
            removeAddRemoveCollection.Append(addRemoveCollection.Remove() + " ");
            removeOpsMyList.Append(mylist.Remove() + " ");
        }

        PrintResult(addOpsAddcollection, addOpsAddRemoveCollection, addOpsMylist, removeAddRemoveCollection,
            removeOpsMyList);
    }

    private static void PrintResult(StringBuilder addOpsAddcollection, StringBuilder addOpsAddRemoveCollection, StringBuilder addOpsMylist, StringBuilder removeAddRemoveCollection, StringBuilder removeOpsMyList)
    {
        Console.WriteLine(addOpsAddcollection.ToString().Trim());
        Console.WriteLine(addOpsAddRemoveCollection.ToString().Trim());
        Console.WriteLine(addOpsMylist.ToString().Trim());
        Console.WriteLine(removeAddRemoveCollection.ToString().Trim());
        Console.WriteLine(removeOpsMyList.ToString().Trim());
    }
}