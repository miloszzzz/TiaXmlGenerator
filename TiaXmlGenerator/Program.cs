// Read file as Stream and create Xml handling class
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TiaXmlGenerator.Helpers;
using TiaXmlGenerator.Models;
using Siemens.Engineering.SW.Tags;
using static System.Net.Mime.MediaTypeNames;
/*
FileStream xmlHeader = new FileStream("FC_ActuatorsHeader.xml", FileMode.Open);
FileStream xmlFooter = new FileStream("FC_ActuatorsHeader.xml", FileMode.Open);

xmlFooter.CopyTo(xmlMainStream);
*/


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

Template Header = new(EnumTemplates.Header);
Template Footer = new(EnumTemplates.Footer);
Template Comment = new(EnumTemplates.Comment);
Template Movement = new(EnumTemplates.Movement);
Template Safety = new(EnumTemplates.Safety);
Template Parameters = new(EnumTemplates.Parameters);
Template Handling = new(EnumTemplates.Handling);
Template Outputs = new(EnumTemplates.Outputs);


// File to export
string xmlFilePath = "FC_GeneratedXml.Xml";
string xmlContant = Header.Contant;
string tempConatant = string.Empty;

int id = 12;

// ADD NETWORKS
// Adding actuators

foreach (Actuator act in actuatorList)
{
    tempConatant = Movement.Contant;

    tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

    xmlContant += tempConatant;
}

// Adding comment subnet
Comment parametersComment = new("--------------------Parameters--------------------");
tempConatant = Comment.Contant;
tempConatant = XmlHelper.InsertComment(tempConatant, parametersComment);
tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
xmlContant += tempConatant;


// Adding safety network
tempConatant = Safety.Contant;
tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
xmlContant += tempConatant;

// Adding parameters networks
foreach (Actuator act in actuatorList)
{
    tempConatant = Parameters.Contant;

    tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

    xmlContant += tempConatant;
}


// Adding handling network
tempConatant = Handling.Contant;
tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
xmlContant += tempConatant;


// Adding outputs network
foreach (Actuator act in actuatorList)
{
    // Outputs template
    tempConatant = Outputs.Contant;

    tempConatant = XmlHelper.InsertActuator(tempConatant, act, ref id);

    xmlContant += tempConatant;
}


// Adding footer
xmlContant += Footer.Contant;

File.WriteAllText(xmlFilePath, xmlContant);
Console.WriteLine(xmlContant);