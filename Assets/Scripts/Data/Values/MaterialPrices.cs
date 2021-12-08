using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPrices : MonoBehaviour
{
    //Prices Per Unit, bar=3m
    private static readonly Dictionary<string, double> pricesPerUnit
        = new Dictionary<string, double>
        {
            { "SquareBar_inch_3/4",                 0.00 },
            { "SquareBar_inch_1",                   0.00 },
            { "SquareBar_mm_9",                     0.00 },
            { "SquareBar_mm_12",                    0.00 },
            { "SquareBar_mm_15",                    0.00 },
            { "SquareBar_mm_10",                    0.00 },

            { "Tees_inch_1/4x11/4x1/8",             0.00 },
            { "Tees_inch_11/2x11/2x1/8",            0.00 },
            { "Tees_inch_11/2x11/2x3/16",           0.00 },
            { "Tees_mm_20x20x3.0",                  0.00 },
            { "Tees_mm_25x25x1.0",                  0.00 },

            { "Agle_inch_2x2x5/16",                 0.00 },
            { "Agle_inch_21/2x21/2x5/16",           0.00 },
            { "Agle_inch_3x3x5/16",                 0.00 },
            { "Agle_inch_5x5x3/8",                  0.00 },
            { "Agle_inch_5x5x1/2",                  0.00 },
            { "Agle_inch_6x6x3/8",                  0.00 },
            { "Agle_inch_6x6x1/2",                  0.00 },
            { "Agle_mm_20x20x2.0",                  0.00 },
            { "Agle_mm_20x20x2.5",                  0.00 },
            { "Agle_mm_20x20x3.0",                  0.00 },
            { "Agle_mm_25x25x2.0",                  0.00 },
            { "Agle_mm_25x25x2.5",                  0.00 },
            { "Agle_mm_25x25x3.0",                  0.00 },
            { "Agle_mm_25x25x4.5",                  0.00 },
            { "Agle_mm_30x30x2.0",                  0.00 },
            { "Agle_mm_30x30x2.5",                  0.00 },
            { "Agle_mm_30x30x3.0",                  0.00 },
            { "Agle_mm_30x30x4.5",                  0.00 },
            { "Agle_mm_38x38x2.0",                  0.00 },
            
            { "TubeSquare_inch_5/8",                0.00 },
            { "TubeSquare_inch_3/4",                0.00 },
            { "TubeSquare_inch_7/8",                0.00 },
            { "TubeSquare_inch_1",                  0.00 },
            { "TubeSquare_inch_11/4",               0.00 },
            { "TubeSquare_inch_11/2",               0.00 },
            { "TubeSquare_inch_2",                  0.00 },
            { "TubeSquare_mm_80",                   0.00 },
            
            { "TubeRound_inch_1/2",                 0.00 },
            { "TubeRound_inch_5/8",                 0.00 },
            { "TubeRound_inch_3/4",                 0.00 },
            { "TubeRound_inch_7/8",                 0.00 },
            { "TubeRound_inch_1",                   0.00 },
            { "TubeRound_inch_11/4",                0.00 },
            { "TubeRound_inch_11/2",                0.00 },
            { "TubeRound_inch_13/4",                0.00 },
            { "TubeRound_inch_2",                   0.00 },
            { "TubeRound_mm_80",                    0.00 },

            { "TubeRetangular_inch_1/2x11/2",       0.00 },
            { "TubeRetangular_inch_1x2",            0.00 },
            { "TubeRetangular_mm_40x60",            0.00 },
            { "TubeRetangular_mm_20x50",            0.00 },

            { "Iron_mm_0.30",                       0.00 },
            { "Iron_mm_0.40",                       0.00 },
            { "Iron_mm_0.55",                       0.00 },
            { "Iron_mm_0.60",                       0.00 },
            { "Iron_mm_0.70",                       0.00 },
            { "Iron_mm_0.75",                       0.00 },
            { "Iron_mm_0.80",                       0.00 },
            { "Iron_mm_0.85",                       0.00 },
            { "Iron_mm_0.90",                       0.00 },
            { "Iron_mm_0.95",                       0.00 },
            { "Iron_mm_1.00",                       0.00 },
            { "Iron_mm_1.15",                       0.00 },
            { "Iron_mm_1.20",                       0.00 }
        };
    public Material  getMaterialReference(){
        return null;
    }
}
