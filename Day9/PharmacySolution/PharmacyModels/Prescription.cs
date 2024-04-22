namespace PharmacyModels;

using System;
using System.Collections.Generic;

public class Prescription: BaseEntity
{
    // Properties
    public Patient Patient { get; set; }
    public Dictionary<Drug, int> Medications { get; set; }
    public string PrescribingDoctor { get; set; }
    public DateTime IssueDate { get; set; }
    public string Notes { get; set; }

    public Prescription()
    {
    }

    // Constructor
    public Prescription(int id, Patient patient, string prescribingDoctor, DateTime issueDate, string notes = ""): base(id)
    {
        Patient = patient;
        Medications = new Dictionary<Drug, int>();
        PrescribingDoctor = prescribingDoctor;
        IssueDate = issueDate;
        Notes = notes;
    }

    /// <summary>
    /// To add prescribed medication to the prescription 
    /// </summary>
    /// <param name="medication">Provieded Drug object</param>
    public void AddPrescribedMedication(Drug medication, int quantity)
    {
        Medications.Add(medication, quantity);
    }

    public override string ToString()
    {
        string medicationsString = string.Join("\n", Medications.Keys);
        return $"\nPrescription ID\t: {Id}" +
               $"\n\tPatient\t: {Patient}" +
               $"\n\tPrescribing Doctor\t: {PrescribingDoctor}" +
               $"\n\tIssue Date\t: {IssueDate}" +
               $"\n\tNotes\t: {Notes}" +
               $"\n\tMedications\t:\n{medicationsString}";
    }
}
