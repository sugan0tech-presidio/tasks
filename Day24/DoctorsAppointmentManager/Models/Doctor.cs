﻿namespace DoctorsAppointmentManager.Models;

public class Doctor: Person
{

    public int Experience { get; set; }
    public ICollection<Qualification> Qualification { get; set; } = new List<Qualification>();
    public ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();

}