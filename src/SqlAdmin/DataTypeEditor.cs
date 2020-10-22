//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2003  Microsoft Corporation.  All rights reserved.
//
//=====================================================================
//=====================================================================
//
// THIS CODE AND INFORMATION IS PROVIDED TO YOU FOR YOUR REFERENTIAL
// PURPOSES ONLY, AND IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE,
// AND MAY NOT BE REDISTRIBUTED IN ANY MANNER.
//
// Copyright (C) 2003  Microsoft Corporation.  All rights reserved.
//
//=====================================================================
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace SqlAdmin {
    /// <summary>
    /// </summary>
    public class DataTypeEditor: UITypeEditor {

        private DataTypePicker dataTypePicker;


        /// <summary>
        /// </summary>
        /// <param name="context">
        /// </param>
        /// <param name="provider">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (provider != null) {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null && context.Instance != null) {
                    if (dataTypePicker == null) {
                        dataTypePicker = new DataTypePicker();
                    }

                    // Grab TreeView property from the TreeNode so we have access to the Images property
                    //TreeView treeView = ((TreeNode)context.Instance).TreeView;

                    // Call the editor
                    string previousDataType = (string)value;
                    dataTypePicker.Start(edSvc, (string)value);
                    edSvc.DropDownControl(dataTypePicker);

                    // REVIEW: What the heck do we do here? How do we detect cancelled selections?
                    if (dataTypePicker.SelectedIndex == -1)
                        value = previousDataType;
                    else
                        value = (string)dataTypePicker.SelectedItem;
                    dataTypePicker.End();
                }
            }

            return value;
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        /// </param>
        /// <returns>
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }

    }    
}
