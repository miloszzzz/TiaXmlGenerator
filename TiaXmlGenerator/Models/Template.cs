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
        public string _contant { get; set; }
        private EnumTemplates _templateType;
        public string Contant = "";


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
                    _contant = Properties.Resources.EmptySubnetComment;
                    break;

                case EnumTemplates.Header:
                    _contant = Properties.Resources.FC_ActuatorsHeader;
                    break;

                case EnumTemplates.Footer:
                    _contant = Properties.Resources.FC_ActuatorsFooter;
                    break;

                case EnumTemplates.Movement:
                    _contant = Properties.Resources.FC_ActuatorsMovement;
                    break;

                case EnumTemplates.Safety:
                    _contant = Properties.Resources.FC_ActuatorsSafety;
                    break;

                case EnumTemplates.Parameters:
                    _contant = Properties.Resources.FC_ActuatorsParameters;
                    break;

                case EnumTemplates.Handling:
                    _contant = Properties.Resources.FC_ActuatorsHandling;
                    break;

                case EnumTemplates.Outputs:
                    _contant = Properties.Resources.FC_ActuatorsOutputs;
                    break;

                default: 
                    _contant = string.Empty;
                    break;
            }
            Contant = _contant;
        }
    }


    
}
