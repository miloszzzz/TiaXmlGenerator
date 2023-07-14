using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TiaXmlGenerator.Models;

namespace TiaXmlGenerator.Helpers
{
    public class XmlHelper
    {

        public static Template Header = new Template(EnumTemplates.Header);
        public static Template Footer = new Template(EnumTemplates.Footer);
        public static Template Comment = new Template(EnumTemplates.Comment);
        public static Template Movement = new Template(EnumTemplates.Movement);
        public static Template Safety = new Template(EnumTemplates.Safety);
        public static Template Parameters = new Template(EnumTemplates.Parameters);
        public static Template Handling = new Template(EnumTemplates.Handling);
        public static Template Outputs = new Template(EnumTemplates.Outputs);

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


        public static string InsertActuator(string xmlContant, Actuator actuator, ref int id)
        {
            xmlContant = xmlContant.Replace("{name}", actuator.Name);
            xmlContant = xmlContant.Replace("{number}", actuator.Number.ToString());
            xmlContant = xmlContant.Replace("{constant}", actuator.Constant.ToString());
            xmlContant = xmlContant.Replace("{station}", actuator.Station.ToString());
            xmlContant = xmlContant.Replace("{station_name}", GetTypeDescription(actuator.Station));
            xmlContant = xmlContant.Replace("{input_retract}", actuator.InputRetract);
            xmlContant = xmlContant.Replace("{input_extend}", actuator.InputExtend);
            xmlContant = xmlContant.Replace("{output_retract}", actuator.OutputRetract);
            xmlContant = xmlContant.Replace("{output_extend}", actuator.OutputExtend);
            xmlContant = InsertIds(xmlContant, ref id);
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



        /// <summary>
        /// Get description of defined program element
        /// </summary>
        /// <param name="defGroup">Group from DefGroup enum</param>
        /// <returns>String with group name</returns>
        private static string GetTypeDescription(EnumStations defGroup)
        {
            Type enumType = typeof(EnumStations);

            var groupInfo = enumType.GetField(defGroup.ToString());
            var attribute = groupInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = (DescriptionAttribute)attribute[0];

            return description.Description;
        }
    }
}
