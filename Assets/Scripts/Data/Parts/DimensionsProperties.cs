using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionsProperties : MonoBehaviour
{
    public static Dictionary<string, string[]> partsInformation
        = new Dictionary<string, string[]>
        {
            { "simpleDoor_body_tp1", new string[]
                {
                    "TubeRetangular_mm_40x60"
                }
            },
            { "simpleDoor_header_tp1", new string[]
                {
                    "Agle_mm_38x38x2.0",
                    "TubeRetangular_mm_40x60"
                }
            },
            { "simpleDoor_midle_security_tp1", new string[]
                {
                    "Agle_mm_38x38x2.0",
                    "TubeRetangular_mm_40x60",
                    "Iron_mm_1.20",
                    "SquareBar_mm_12"
                }
            },
            { "simpleDoor_partdown_security_tp1", new string[]
                {
                    "SquareBar_mm_12"
                }
            },
            { "simpleDoor_partup_security_tp1", new string[]
                {
                    "SquareBar_mm_12"
                }
            },
            { "simpleDoor_partdown_tp1", new string[]
                {
                    "Iron_mm_0.90"
                }
            },
            { "simpleDoor_partdown_tp2", new string[]
                {
                    "SquareBar_mm_12"
                }
            },
            { "simpleDoor_partup_tp1", new string[]
                {
                    "Iron_mm_0.90"
                }
            },
            { "simpleDoor_partup_tp2", new string[]
                {
                    "SquareBar_mm_12"
                }
            }
        };
}
