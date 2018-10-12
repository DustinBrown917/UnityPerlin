using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PerlinGenerator : MonoBehaviour {

    private static int[] permutation;
    private static int permutationRepeats = 2;
    private static int permutationLength = 256;


    static PerlinGenerator()
    {
        BuildPermutationTable();
    }

    private static void BuildPermutationTable()
    {
        System.Random rnd = new System.Random();

        permutation = new int[permutationLength * permutationRepeats];
        List<int> orderedNums = new List<int>();

        for (int i = 0; i < permutationLength; i++)
        {
            orderedNums.Add(i);
        }

        List<int> copiedNums;

        int baseIndex;

        for(int repeats = 0; repeats < permutationRepeats; repeats++)
        {
            baseIndex = repeats * permutationLength;
            if(baseIndex >= permutation.Length) { baseIndex = permutation.Length - 1; }

            copiedNums = new List<int>(orderedNums);
            
            int targetIndex;
            for (int i = 0; i < permutationLength; i++)
            {
                targetIndex = rnd.Next(copiedNums.Count);
                permutation[baseIndex + i] = copiedNums[targetIndex];
                copiedNums.RemoveAt(targetIndex);
            }
        }
    }

    private void Start()
    {
        string str = "";

        for(int i = 0; i < permutation.Length; i++)
        {
            str += permutation[i].ToString();
            if(i != permutationLength - 1)
            {
                str += ", ";
            }
        }

        Debug.Log(str);
    }
}
