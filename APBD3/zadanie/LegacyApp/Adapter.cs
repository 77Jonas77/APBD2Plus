namespace LegacyApp;

public class AdapterDbAdder: IDUserDbAdder
{
    
    public void AddUser(User user)
    {
        //convert ...
        UserDataAccess.AddUser(user);
    }
}