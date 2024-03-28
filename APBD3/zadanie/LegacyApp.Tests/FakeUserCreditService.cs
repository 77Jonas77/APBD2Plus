using System;

namespace LegacyApp;

public class FakeUserCreditService: ICreditLimitService
{
    private int _value;

    public FakeUserCreditService(int value)
    {
        _value = value;
    }

    public FakeUserCreditService()
    {
    }

    public int GetCreditLimit(string lastName, DateTime birthday)
    {
        return _value;
    }
}