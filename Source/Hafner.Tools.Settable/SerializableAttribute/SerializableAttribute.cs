// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
/*============================================================
**
** Class: SerializableAttribute
**
**
** Purpose: Used to mark a class as being serializable
**
**
============================================================*/
namespace System {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    internal sealed class SerializableAttribute : Attribute {

        public SerializableAttribute() {
        }

    }

}
