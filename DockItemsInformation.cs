using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace DockItemsInformation
{
    /// <summary> 
    /// The basis data structure for Circle Dock. Every object displayed has a corresponding ObjectData.
    /// <param name="Name">Name to be shown.</param>
    /// <param name="Description">Description to be shown.</param>
    /// <param name="Action">Action taken when object is clicked if allowed by Type. Ex: [link] [objectdir] [physicaldir] [nothing]</param> 
    /// <param name="Args">Args to be used for the action. Ex: Executable path.</param>
    /// <param name="ImagePath">Physical path to the image used for the object drawing. Use ::[defaultimage] if path is unknown.</param>
    /// <param name="Settings">Object specific settings for docklets.</param>
    /// <param name="SubObjectData">A collection of ObjectData that should be shown under the current ObjectData.</param>
    /// </summary> 
    public struct ObjectData
    {
        public String Name;
        public String Description;
        public String Action;
        public String Args;
        public String ImagePath;
        public int Order;
    }
}
