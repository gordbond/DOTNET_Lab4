/// <summary>
/// Gord Bond - 000786196
/// Nov. 12, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. No other person's work 
/// has been used without due acknowledgement.
/// 
/// BalanceTags - recieves a List of HtmlTags and 
/// compares the number of opening and closing tags 
/// to determine if the file has balanced tags.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4B
{
    class BalanceTags
    {

        /// <summary>
        /// Uses a Stack of strings to check for balanced number of 
        /// opening and closing tags. If an opening tag is found it is 
        /// placed on the stack if a corresponding closing tag is found
        /// the opening tag is popped off the stack. 
        /// 
        /// If balanced - stack count will equal zero/ no tags left in the stack
        /// Not balanced - stack count will be greater than zero/ tags still in stack
        /// 
        /// </summary>
        /// <param name="Tags">List of html tags</param>
        /// <returns>true if balanced and false if unbalanced</returns>
        public static bool CheckForBalance(List<HtmlTag> Tags) {
            
            Stack<String> tags = new Stack<String>();

            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].NonContainerTag == false)
                {
                    if (Tags[i].OpeningTag)
                        tags.Push(Tags[i].TagName);
                    else {
                        if (Tags[i].TagName.Equals(tags.Peek()))
                            tags.Pop();
                        }    
                }
            }
            if (tags.Count == 0)
                return true;
            else
                return false;

        }


    }
}
