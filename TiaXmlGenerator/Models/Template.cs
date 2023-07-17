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
<<<<<<< HEAD
                case EnumTemplates.ActuatorComment:
=======
                case EnumTemplates.Comment:
>>>>>>> 228bc4a71bf5ae96ca8c69f8768300cdf639ee86
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
<<<<<<< HEAD
                    break;

                case EnumTemplates.TextListHeader:
                    _contant = Properties.Resources.TextList_Header;
                    break;

                case EnumTemplates.TextListCommentMulti:
                    _contant = Properties.Resources.TextList_HeaderCommentMulti;
                    break;

                case EnumTemplates.TextListEntry:
                    _contant = Properties.Resources.TextList_Text;
                    break;

                case EnumTemplates.TextListEntryMulti:
                    _contant = Properties.Resources.TextList_TextMulti;
                    break;

                case EnumTemplates.TextListFooter:
                    _contant = Properties.Resources.TextList_Footer;
=======
>>>>>>> 228bc4a71bf5ae96ca8c69f8768300cdf639ee86
                    break;

                default: 
                    _contant = string.Empty;
                    break;
            }
            Contant = _contant;
        }
    }


    
}
