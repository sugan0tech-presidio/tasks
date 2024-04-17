namespace DoctorsAppointmentLibrary.controllers;

public interface IBaseController
{
    public void GetFromConsole();
    public void ListAll();
    public void Get(int id);
    public void Delete(int id);
}