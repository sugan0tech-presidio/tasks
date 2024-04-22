namespace PharmacyModels;

using System;

public class Prescription : BaseEntity
{
    // Properties
    public Patient Patient { get; set; }
    public Drug Drug { get; set; }
    public int Quantity { get; set; }
    public string PrescribingDoctor { get; set; }
    public DateTime IssueDate { get; set; }
    public string Notes { get; set; }

    public Prescription()
    {
    }

    // Constructor
    public Prescription(int id, Patient patient, string prescribingDoctor, DateTime issueDate, string notes) : base(id)
    {
        Patient = patient;
        PrescribingDoctor = prescribingDoctor;
        IssueDate = issueDate;
        Notes = notes;
    }

    public override string ToString()
    {
        return $"\nPrescription ID\t: {Id}" +
               $"\n\tPatient\t: {Patient}" +
               $"\n\tPrescribing Doctor\t: {PrescribingDoctor}" +
               $"\n\tIssue Date\t: {IssueDate}" +
               $"\n\tNotes\t: {Notes}" +
               $"\n\tDrug\t: {Drug.Name}" +
               $"\n\tQuantity\t: {Quantity}";
    }
}