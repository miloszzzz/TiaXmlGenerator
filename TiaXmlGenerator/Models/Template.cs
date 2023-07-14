using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaXmlGenerator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Template
    {
        public string? _contant { get; set; }
        private EnumTemplates _templateType;
        public string Contant = string.Empty;


        public Template(EnumTemplates enumTemplate)
        { 
            _templateType = enumTemplate; 
            ReadTemplate();
        }


        /// <summary>
        /// Reading file with template text
        /// </summary>
        public void ReadTemplate()
        {
            switch (_templateType)
            {
                case EnumTemplates.Comment:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/EmptySubnetComment.xml");
                    break;

                case EnumTemplates.Header:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsHeader.xml");
                    break;

                case EnumTemplates.Footer:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsFooter.xml");
                    break;

                case EnumTemplates.Movement:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsMovement.xml");
                    break;

                case EnumTemplates.Safety:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsSafety.xml");
                    break;

                case EnumTemplates.Parameters:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsParameters.xml");
                    break;

                case EnumTemplates.Handling:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsHandling.xml");
                    break;

                case EnumTemplates.Outputs:
                    _contant = File.ReadAllText(Environment.CurrentDirectory + "/data/FC_ActuatorsOutputs.xml");
                    break;

                default: 
                    _contant = string.Empty;
                    break;
            }
            Contant = _contant;
        }
    }


    
}
