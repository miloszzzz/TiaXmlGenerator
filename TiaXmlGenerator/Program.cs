// Read file as Stream and create Xml handling class
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
using TiaXmlGenerator.Helpers;
using TiaXmlGenerator.Models;
using Siemens.Engineering.SW.Tags;
using static System.Net.Mime.MediaTypeNames;


internal class Program
{
    private static void Main(string[] args)
    {
        ///////////////////////////////////////
        ///////////////////////////////////////
        // Test actuators
        
        List<Actuator> actuatorList = new List<Actuator>();
        Actuator actuator1 = new Actuator();
        Actuator actuator2 = new Actuator();

        actuator1.Name = "Y19";
        actuator1.Number = 19;
        actuator1.Constant = 1;
        actuator1.Station = EnumStations.st1;
        actuator1.InputRetract = "I10.0";
        actuator1.InputExtend = "I10.1";
        actuator1.OutputRetract = "Q1.1";
        actuator1.OutputExtend = "Q1.2";
        actuatorList.Add(actuator1);

        actuator2.Name = "Y21";
        actuator2.Number = 21;
        actuator2.Constant = 2;
        actuator2.Station = EnumStations.st2;
        actuator2.InputRetract = "I10.2";
        actuator2.InputExtend = "I10.3";
        actuator2.OutputRetract = "Q1.2";
        actuator2.OutputExtend = "Q1.3";
        actuatorList.Add(actuator2);
        ///////////////////////////////////////
        ///////////////////////////////////////

<<<<<<< HEAD
=======
        

>>>>>>> 228bc4a71bf5ae96ca8c69f8768300cdf639ee86

        #region actuators example
        /*
        // File to export
        string xmlFilePath = "FC_GeneratedXml.Xml";
        string xmlContant = XmlHelper.Header.Contant;
        string tempConatant = string.Empty;

        int id = 12;

        // ADD NETWORKS
        // Adding actuators

        foreach (Actuator act in actuatorList)
        {
            tempConatant = XmlHelper.Movement.Contant;

            tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

            xmlContant += tempConatant;
        }

        // Adding comment subnet
        Comment parametersComment = new Comment("--------------------Parameters--------------------");
        tempConatant = XmlHelper.Comment.Contant;
        tempConatant = XmlHelper.InsertComment(tempConatant, parametersComment);
        tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
        xmlContant += tempConatant;


        // Adding safety network
        tempConatant = XmlHelper.Safety.Contant;
        tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
        xmlContant += tempConatant;

        // Adding parameters networks
        foreach (Actuator act in actuatorList)
        {
            tempConatant = XmlHelper.Parameters.Contant;

            tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

            xmlContant += tempConatant;
        }


        // Adding handling network
        tempConatant = XmlHelper.Handling.Contant;
        tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
        xmlContant += tempConatant;


        // Adding outputs network
        foreach (Actuator act in actuatorList)
        {
            // Outputs template
            tempConatant = XmlHelper.Outputs.Contant;

            tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

            xmlContant += tempConatant;
        }


        // Adding footer
        xmlContant += XmlHelper.Footer.Contant;

        File.WriteAllText(xmlFilePath, xmlContant);
        Console.WriteLine(xmlContant);
    }
}