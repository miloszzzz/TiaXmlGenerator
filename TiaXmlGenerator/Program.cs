// Read file as Stream and create Xml handling class
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TiaXmlGenerator.Helpers;
using TiaXmlGenerator.Models;
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
actuator1.Constant = 1;
actuatorList.Add(actuator1);

actuator2.Name = "Y21";
actuator2.Constant = 2;
actuatorList.Add(actuator2);
///////////////////////////////////////
///////////////////////////////////////

Template Header = new(EnumTemplates.Header);
Template Footer = new(EnumTemplates.Footer);
Template Comment = new(EnumTemplates.Comment);
Template Movement = new(EnumTemplates.Movement);
Template Safety = new(EnumTemplates.Safety);


// File to export
string xmlFilePath = "FC_GeneratedXml.Xml";
string xmlContant = Header.Contant;
string tempConatant = string.Empty;
Console.WriteLine("Header\t" + xmlContant.Length);

int id = 12;

// ADD NETWORKS
// Adding actuators

foreach (Actuator act in actuatorList)
{
    tempConatant = Movement.Contant;

    tempConatant = XmlHelper.InsertIds(tempConatant, ref id);

    tempConatant = XmlHelper.InsertActuator(tempConatant, act);

    xmlContant += tempConatant;
    Console.WriteLine("Actuator\t" + xmlContant.Length);
}

// Adding comment subnet
Comment parametersComment = new("--------------------Parameters--------------------");
tempConatant = Comment.Contant;
tempConatant = XmlHelper.InsertComment(tempConatant, parametersComment);
tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
xmlContant += tempConatant;
Console.WriteLine("Comment\t" + xmlContant.Length);


// Adding safety network
tempConatant = Safety.Contant;
tempConatant = XmlHelper.InsertIds(tempConatant, ref id);
xmlContant += tempConatant;

// Adding footer
xmlContant += Footer.Contant;
Console.WriteLine("Footer\t" + xmlContant.Length);

File.WriteAllText(xmlFilePath, xmlContant);
Console.WriteLine(xmlContant);