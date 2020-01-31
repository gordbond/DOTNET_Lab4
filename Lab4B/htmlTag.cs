
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4B
{
    /// <summary>
    /// Gord Bond - 000786196
    /// Nov. 12, 2019
    /// I, Gord Bond, 000786196 certify that this material is my original work. No other person's work 
    /// has been used without due acknowledgement.
    /// 
    /// HtmlTag - Class containing the blueprints for a Html tag
    /// Includes tag name and whether it is a opening tag or closing tag. 
    /// Also if it is a non-container tag
    ///
    /// </summary>
    class HtmlTag
    {
        /// <summary>
        /// Boolean property containing whether object is opening/closing tag
        /// </summary>
        public bool OpeningTag { get; private set; } = true;
       

        String tagName;
        /// <summary>
        /// String property containing tag name
        /// </summary>
        public String TagName {
            get {
                return tagName;
            }
            //Custom set - also sets Opening Tag and NonContainerTag
            set {
                tagName = value.ToLower();
                if (value.StartsWith("/"))
                {
                    tagName = value.Substring(1).ToLower();
                    OpeningTag = false;
                }
                if (value.Equals("img") || tagName.Equals("hr") || tagName.Equals("br"))
                    NonContainerTag = true;
                else
                    NonContainerTag = false;
            }
        }


        /// <summary>
        /// Boolean property containing whether object is non-container tag or not
        /// </summary>
        public bool NonContainerTag { get; private set; } = false;

        /// <summary>
        /// Constructor for HtmlTag
        /// Calls custom setter for TagName property which also sets the 
        /// OpeningTag and NonContainerTag properties
        /// </summary>
        /// <param name="tagName">Type of html tag</param>
        public HtmlTag(String tagName)
        {
            TagName = tagName;
        }


        /// <summary>
        /// ToString formatted to create a string representation of the object
        /// Includes type of tag and tag name
        /// </summary>
        /// <returns>a string representation of the object</returns>
        public override string ToString()
        {
            if (OpeningTag)
                if (NonContainerTag)
                    return $"Found non-container tag: <{TagName}>";
                else
                    return $"Found opening tag: <{TagName}>";
            else
                return $"Found closing tag: </{TagName}>";
        }
    }
}
