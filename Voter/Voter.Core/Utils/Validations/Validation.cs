using System;
using System.Collections.Generic;
using System.Xml;

namespace Voter.Core.Utils.Validations
{
    /// <summary>
    /// Helper pro zpracování validací
    /// </summary>
    public static class Validation
    {
        public static System.Resources.ResourceManager ResourceManager;

        /// <summary>
        /// Zjistí zda vyjímka obsahuje validační chyby
        /// </summary>
        public static bool IsValidatationResult(Exception exception)
        {
            return exception != null && exception.Message.StartsWith("<validation>");
        }

        /// <summary>
        /// Zjistí zda vyjímka obsahuje systémové chyby
        /// </summary>
        public static bool IsErrorResult(Exception exception)
        {
            return exception != null && exception.Message.StartsWith("<error>");
        }

        /// <summary>
        /// Zjistí zda vyjímka obsahuje validační hlášky, pokud ano, tak vrátí jejich seznam.
        /// </summary>
        public static List<ValidateMessage> GetMessages(Exception exception)
        {
            if (IsValidatationResult(exception))
            {
                var output = new List<ValidateMessage>();

                var xml = new XmlDocument();
                var xmlSource = exception.Message;

                // taskid#5524 - pri naruseni XML
                if (xmlSource.StartsWith("<validation>") && !xmlSource.EndsWith("</validation>"))
                {
                    int startIndex = xmlSource.IndexOf("<validation>");
                    int endIndex = xmlSource.IndexOf("</validation>");
                    xmlSource = xmlSource.Substring(startIndex, endIndex - startIndex + "</validation>".Length);
                }

                xml.LoadXml(xmlSource);
                foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                {
                    var validationMessage = new ValidateMessage();

                    // Vlastnost, ktere se validace tyka
                    validationMessage.Property = validationMessage.DisplayName = node["Property"].InnerText;

                    // Resources (pouziva se pro webove  sluzby)
                    if (node["ResourceName"] != null)
                    {
                        validationMessage.ResourceName = node["ResourceName"].InnerText;
                    }
                    if (node["Args"] != null)
                    {
                        validationMessage.Args = node["Args"].InnerText.Split('|');
                    }

                    // DisplayName se bere jako prvni v pripade, ze neni nastaven ResourceManager a nebo neni zadan ResourceName
                    if ((ResourceManager == null || node["ResourceName"] == null) && node["DisplayName"] != null)
                    {
                        // Nelokalizovana validacni hlaska
                        validationMessage.DisplayName = node["DisplayName"].InnerText;
                    }
                    // Pokud jsou zadane argumenty, pak formatuji zpravu
                    else if (node["ResourceName"] != null && node["Args"] != null)
                    {
                        // lokalizovana validacni hlaska s parametrama
                        validationMessage.DisplayName = GetFormatValidationMessage(node["ResourceName"].InnerText, validationMessage.Args);
                    }
                    else if (node["ResourceName"] != null)
                    {
                        // lokalizovana validacna hlaska bez parametru
                        validationMessage.DisplayName = GetValidationMessage(node["ResourceName"].InnerText);
                    }

                    output.Add(validationMessage);
                }

                return output;
            }
            else
            {
                // jedná se o jinou vyjímku než validační hlášky => zobrazím standardní chybovou hlášku
                throw new Exception(exception.Message, exception);
            }
        }

        /// <summary>
        /// Zjistí zda vyjímka obsahuje validační hlášky, pokud ano, tak vrátí jejich seznam.
        /// </summary>
        public static List<ValidateMessage> GetErrorMessages(Exception exception)
        {
            if (IsErrorResult(exception))
            {
                var output = new List<ValidateMessage>();

                var xml = new XmlDocument();
                var xmlSource = exception.Message;

                // taskid#5524 - pri naruseni XML
                if (xmlSource.StartsWith("<error>") && !xmlSource.EndsWith("</error>"))
                {
                    int startIndex = xmlSource.IndexOf("<error>");
                    int endIndex = xmlSource.IndexOf("</error>");
                    xmlSource = xmlSource.Substring(startIndex, endIndex - startIndex + "</error>".Length);
                }

                xml.LoadXml(xmlSource);
                foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                {
                    var validationMessage = new ValidateMessage();

                    // Vlastnost, ktere se validace tyka
                    validationMessage.Property = validationMessage.DisplayName = node["Property"].InnerText;

                    // Resources (pouziva se pro webove  sluzby)
                    if (node["ResourceName"] != null)
                    {
                        validationMessage.ResourceName = node["ResourceName"].InnerText;
                    }
                    if (node["Args"] != null)
                    {
                        validationMessage.Args = node["Args"].InnerText.Split('|');
                    }

                    // DisplayName se bere jako prvni v pripade, ze neni nastaven ResourceManager a nebo neni zadan ResourceName
                    if ((ResourceManager == null || node["ResourceName"] == null) && node["DisplayName"] != null)
                    {
                        // Nelokalizovana validacni hlaska
                        validationMessage.DisplayName = node["DisplayName"].InnerText;
                    }
                    // Pokud jsou zadane argumenty, pak formatuji zpravu
                    else if (node["ResourceName"] != null && node["Args"] != null)
                    {
                        // lokalizovana validacni hlaska s parametrama
                        validationMessage.DisplayName = GetFormatValidationMessage(node["ResourceName"].InnerText, validationMessage.Args);
                    }
                    else if (node["ResourceName"] != null)
                    {
                        // lokalizovana validacna hlaska bez parametru
                        validationMessage.DisplayName = GetValidationMessage(node["ResourceName"].InnerText);
                    }

                    output.Add(validationMessage);
                }

                return output;
            }
            else
            {
                // jedná se o jinou vyjímku než validační hlášky => zobrazím standardní chybovou hlášku
                throw new Exception(exception.Message, exception);
            }
        }

        /// <summary>
        /// Vrátí validační hlášku podle zadaného klíče
        /// </summary>
        /// <param name="key">Klíč hlášky</param>
        /// <returns></returns>
        public static string GetValidationMessage(string key)
        {
            string message = ResourceManager.GetString(key);
            if (message == null)
            {
                throw new Exception(string.Format("Neznámá validační hláška '{0}'!", key));
            }
            return message;
        }

        /// <summary>
        /// Vrátí validační hlášku, kde jsou doplněné zadané údaje
        /// </summary>
        /// <param name="key">Klíč hlášky</param>
        /// <param name="args">Parametry pro doplnění</param>
        /// <returns></returns>
        public static string GetFormatValidationMessage(string key, params object[] args)
        {
            string message = ResourceManager.GetString(key);
            if (message == null)
            {
                throw new Exception(string.Format("Neznámá validační hláška '{0}'!", key));
            }
            return String.Format(message, args);
        }
    }
}
