using System.Globalization;

namespace EffectiveMobile.Validators
{
    internal class InputValidator
    {
        public static bool TryValidate(string[] args, out string? msg)
        {
            try
            {
                msg = null;
                Validate(args);
                
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                
                return false;
            }
        }

        public static void Validate(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("There must be 2 arguments!\nThe first is city district and the second is delivery time!\nExample: 'EffectiveMobile.exe District 2024-01-01 00:00:00'");
            }

            string firstDelivDateTime = args[1] + ' ' + args[2];

            CultureInfo culture = CultureInfo.InvariantCulture;
            if (!DateTime.TryParseExact(firstDelivDateTime, "yyyy-MM-dd HH:mm:ss", culture, DateTimeStyles.None, out _))
            {
                throw new ArgumentException("Invalid delivery time!");
            }
        }
    }
}
