using System;
namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _userCreditService;

        private IDUserDbAdder _adapterDbAdder;
        //inject
        public UserService(IClientRepository clientRepository, ICreditLimitService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _adapterDbAdder = new AdapterDbAdder();
        }
        
        [Obsolete]
        public UserService()
        { 
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _adapterDbAdder = new AdapterDbAdder();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (IsFirstNameInvalid(firstName) || IsLastNameInvalid(lastName))
            {
                return false;
            }

            if (IsEmailInvalid(email))
            {
                return false;
            }

            var age = CalculateAgeUsingBirthDate(dateOfBirth);

            if (!IsAgeValid(age)) return false;

            var client = _clientRepository.GetById(clientId);
            
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (IsClientVeryImportant(client))
            {
                user.HasCreditLimit = false;
            }
            else if (IsClientImportant(client))
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (!IsCreditLimitValid(user)) return false;
            
            //problem - czy git?
            _adapterDbAdder.AddUser(user);
            return true;
        }

        private static bool IsClientImportant(Client client)
        {
            return client.Type == "ImportantClient";
        }

        private static bool IsClientVeryImportant(Client client)
        {
            return client.Type == "VeryImportantClient";
        }

        private static bool IsCreditLimitValid(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            return true;
        }

        private static int CalculateAgeUsingBirthDate(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private static bool IsAgeValid(int age)
        {
            if (age < 21)
            {
                return false;
            }

            return true;
        }

        private static bool IsEmailInvalid(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }

        private static bool IsLastNameInvalid(string lastName)
        {
            return string.IsNullOrEmpty(lastName);
        }

        private static bool IsFirstNameInvalid(string firstName)
        {
            return string.IsNullOrEmpty(firstName);
        }
    }
}