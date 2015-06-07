using System;
using System.Xml;

namespace GenericUtility
{
    public static class XmlUtils
    {
        public static bool GetValue<T>(this XmlNode node, out T value, T defaultValue) where T : IConvertible
        {
            value = defaultValue;
            try
            {
                value = (T)Convert.ChangeType(node.InnerText, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetSubNodeValue<T>(this XmlNode node, string xPath, out T value) where T : IConvertible
        {
            return GetSubNodeValue(node, xPath, out value, default(T));
        }

        public static bool GetSubNodeValue<T>(this XmlNode node, string xPath, out T value, T defaultValue) where T : IConvertible
        {
            value = defaultValue;
            if (string.IsNullOrEmpty(xPath))
            {
                return false;
            }

            var subNode = node.SelectSingleNode(xPath);
            if (subNode == null)
            {
                return false;
            }
            return node.GetValue(out value, defaultValue);
        }

        public static XmlElement CreateSubElement(this XmlNode node, string name, string innerText)
        {
            var element = node.OwnerDocument.CreateElement(name);
            element.InnerText = innerText;
            node.AppendChild(element);
            return element;
        }
    }
}