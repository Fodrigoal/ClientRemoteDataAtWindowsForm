//
// Validation class.
//
// Rodrigo Silva
// November 9, 2016
//

using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Business
{
    public class ClientValidation
    {

        private static List<string> errors;

        static ClientValidation()
        {
            errors = new List<string>();
        }

        public static string ErrorMessage => errors.Aggregate((i, j) => i + "\r\n" + j);

        public static ClientCollection GetAllClientsData() => ClientRepository.GetAllClientsData();

        public static int AddClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteClient(Client client) => ClientRepository.DeleteClient(client);

        private static bool validate(Client client)
        {
            bool success = true;
            errors.Clear();

            string regExCdnClientCode = @"^[A-Z][A-Z][A-Z][A-Z][A-Z]$";
            
            // Validate for pattern AAAAA
            if (!Regex.IsMatch(client.ClientCode, regExCdnClientCode))
            {
                errors.Add("Client Code Format is Incorrect");
                success = false;
            }

            if (client.CompanyName.Length < 1)
            {
                errors.Add("Company Name can`t be empty");
                success = false;
            }

            if (client.Address1.Length < 1)
            {
                errors.Add("Address 1 can`t be empty");
                success = false;
            }

            if (client.Province.Length < 1)
            {
                errors.Add("Province can`t be empty");
                success = false;
            }

            string regExCdnProvince = @"^[A-Z][A-Z]$";

            // Validate for pattern AA
            if (!Regex.IsMatch(client.Province, regExCdnProvince))
            {
                errors.Add("Province Format is Incorrect");
                success = false;
            }

            string regExCdnPostalCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";

            // Validate for pattern A9A 9A9
            if (!Regex.IsMatch(client.PostalCode, regExCdnPostalCode))
            {
                errors.Add("Postal Code Format is Incorrect");
                success = false;
            }

            if (client.YTDSales < 0)
            {
                errors.Add("Year To Date Sales cannot be less than zero");
                success = false;
            }

            return success;
        }

    }
}
