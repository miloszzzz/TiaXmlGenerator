using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TiaXmlGenerator.Models;

namespace TiaXmlGenerator.Helpers
{
    public class XmlHelper
    {
        public static string InsertIds(string xmlContant, ref int id)
        {
            int _id = id;
            while (xmlContant.Contains("{id}"))
            {
                xmlContant = Regex.Replace(xmlContant, @"\{id\}", match => _id++.ToString());
            }

            id = _id;

            return xmlContant;
        }


        public static string InsertActuator(string xmlContant, Actuator actuator)
        {
            xmlContant = xmlContant.Replace("{name}", actuator.Name);
            xmlContant = xmlContant.Replace("{constant}", actuator.Constant.ToString());
            return xmlContant;
        }


        public static string InsertComment(string xmlContant, Comment comment)
        {
            while (xmlContant.Contains("{comment}"))
            {
                xmlContant = Regex.Replace(xmlContant, @"\{comment\}", match => comment.CommentText);
            }
            return xmlContant;
        }
    }
}
