using System;
using System.Collections.Generic;

namespace PharmacyModels;

    public class Dangerouscombinations
    {
        // Dictionary to store dangerous combinations of drugs
        private static Dictionary<string, string> DangerousCombinations { get; } = new Dictionary<string, string>
        {
            { "Clopidogrel+PPIs", "Increased risk of thrombosis"},
            { "Ramipril+Spironolactone", "Hyperkalemia"},
            { "Furosemide+Ramipril", "Postural hypotension"},
            { "Spironolactone+Digoxin", "Digoxin toxicity"},
            { "Alprazolam+Digoxin", "Digoxin toxicity (nausea, vomiting, arrhythmia)"},
            { "Diltiazem+Atorvastatin", "Increased risk of rhabdomyolysis"},
            { "Heparin+Aspirin", "Increased risk of bleeding"},
            { "Theophylline+Ciprofloxacin", "Increased Theophylline toxicity"},
            { "Metronidazole+Warfarin", "Increased risk of bleeding"},
            { "Warfarin+Pantoprazole", "Increased INR and prothrombin time"},
            { "Insulin+Ciprofloxacin","Increased risk of hypoglycemia or hyperglycemia"},
            { "Diltiazem+Carvedilol", "Increased risk of hypotension, bradycardia, AV conduction disturbance"},
            { "Hydrochlorthiazide+Ramipril", "Postural hypotension"},
            { "Rifampicin+Isoniazid", "Hepatotoxicity"},
            { "Diltiazem+metoprolol", "Increased risk of hypotension, bradycardia, AV conduction disturbance"},
            { "Amoxicillin+warfarin", "Increased risk of bleeding"}
        };

        // Method to check if a combination is dangerous
        public static bool IsCombinationDangerous(string drugA, string drugB)
        {
            return DangerousCombinations.ContainsKey(drugA + "+" + drugB) || DangerousCombinations.ContainsKey(drugB + "+" + drugA);
        }

        // Method to get the risk associated with a dangerous combination
        public static string GetRisk(string drugA, string drugB)
        {
            if (DangerousCombinations.TryGetValue(drugA + "+" drugB, out var value))
            {
                return value;
            }
            else
            {
                return "Unknown";
            }
        }
    }