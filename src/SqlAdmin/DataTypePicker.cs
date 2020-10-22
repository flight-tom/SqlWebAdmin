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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SqlAdmin {
    /// <summary>
    /// </summary>
    [
    ToolboxItem(false)
    ]
    public class DataTypePicker : ListBox {

        private IWindowsFormsEditorService edSvc;

        private bool keyDown = false;
        private bool mouseClicked = false;


        /// <summary>
        /// </summary>
        public DataTypePicker() {
            this.BorderStyle = BorderStyle.None;
        }


        /// <summary>
        /// </summary>
        public void End() {
            Items.Clear();
            edSvc = null;
        }

        /// <summary>
        /// </summary>
        protected void FillData() {
            /*
                        Items.Clear();

                        Items.Add(SR.GetString("ImageIndexPicker_NoImage"));

                        Debug.Assert(treeView != null, "treeView == null");

                        int count = treeView.Images.Count;
                        for (int i = 0; i < count; i++) {
                            Items.Add(i.ToString() + " - " + treeView.Images[i].Url);
                        }
            */            
            Items.Clear();

            Items.Add("bigint");
            Items.Add("binary");
            Items.Add("bit");
            Items.Add("char");
            Items.Add("datetime");
            Items.Add("decimal");
            Items.Add("float");
            Items.Add("image");
            Items.Add("int");
            Items.Add("money");
            Items.Add("nchar");
            Items.Add("ntext");
            Items.Add("numeric");
            Items.Add("nvarchar");
            Items.Add("real");
            Items.Add("smalldatetime");
            Items.Add("smallint");
            Items.Add("smallmoney");
            Items.Add("sql_varient");
            Items.Add("text");
            Items.Add("timestamp");
            Items.Add("tinyint");
            Items.Add("uniqueidentifier");
            Items.Add("varbinary");
            Items.Add("varchar");
        }

        /// <summary>
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnKeyUp(KeyEventArgs e) {
            base.OnKeyUp(e);

            keyDown = true;
            mouseClicked = false;

            if (e.KeyData == Keys.Return) {
                keyDown = false;
                edSvc.CloseDropDown();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            mouseClicked = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            mouseClicked = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnSelectedIndexChanged(EventArgs e) {
            base.OnSelectedIndexChanged(e);

            // selecting an item w/ the keyboard is done via 
            // OnKeyDown. we will select an item w/ the mouse,
            // if this was the last thing that the user did
            if (mouseClicked && !keyDown) {
                mouseClicked = false;
                keyDown = false;
                edSvc.CloseDropDown();
            }

            return;
        }

        /// <summary>
        /// </summary>
        /// <param name="edSvc">
        /// </param>
        /// <param name="selectedDataType">
        /// </param>
        public void Start(IWindowsFormsEditorService edSvc, string selectedDataType) {
            this.edSvc = edSvc;

            // Fill in data and select the item
            FillData();

            this.SelectedIndex = this.Items.IndexOf(selectedDataType);
        }
    }
}
