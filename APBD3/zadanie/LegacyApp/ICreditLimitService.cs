using System;
using System.Runtime.InteropServices.JavaScript;

namespace LegacyApp;

public interface ICreditLimitService
{
    public int GetCreditLimit(string lastName, DateTime birthday);
}