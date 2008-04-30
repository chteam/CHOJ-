using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace CSSFriendly
{
    public class Snippet
    {
        private Control _control = null;
        private WebControlAdapter _adapter = null;

        private bool _acquireUnadaptedHtml = true;
        private string _unadaptedHtml = "";
        public string UnadaptedHtml
        {
            get
            {
                if (_acquireUnadaptedHtml)
                {
                    _unadaptedHtml = GenerateHtml(false);
                    _acquireUnadaptedHtml = false;
                }
                return _unadaptedHtml;
            }
        }

        private bool _acquireAdaptedHtml = true;
        private string _adaptedHtml = "";
        public string AdaptedHtml
        {
            get
            {
                if (_acquireAdaptedHtml)
                {
                    _adaptedHtml = GenerateHtml(true);
                    _acquireAdaptedHtml = false;
                }
                return _adaptedHtml;
            }
        }

        private bool _handleExceptions = true;
        public bool HandleExceptions
        {
            get { return _handleExceptions; }
            set { _handleExceptions = value; }
        }

        public Snippet(Control ctrl, WebControlAdapter adapter)
        {
            _control = ctrl;
            _adapter = adapter;
        }

        public string GenerateHtml(bool useAdapter)
        {
            string html = "";
            List<ControlRestorationInfo> stashedControls = new List<ControlRestorationInfo>();

            try
            {
                WebControlAdapter tempAdapter = null;
                FieldInfo fieldInfo = null;
                object[] parameters = new object[2];
                Type cType = _control.GetType();
                MethodInfo methodInfo = cType.GetMethod("RenderControl",
                                                         BindingFlags.ExactBinding | BindingFlags.NonPublic | BindingFlags.Instance,
                                                         null,
                                                         new Type[] { typeof(HtmlTextWriter), typeof(ControlAdapter) },
                                                         null);

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter, "  ");

                WebControlAdapterExtender.RemoveProblemChildren(_control, stashedControls);

                if (useAdapter)
                {
                    if (CSSFriendly.Context.Enabled)
                    {
                        _control.RenderControl(htmlWriter);
                    }
                    else
                    {
                        parameters[0] = htmlWriter;
                        parameters[1] = _adapter;
                        if (_adapter != null)
                        {
                            tempAdapter = parameters[1] as WebControlAdapter;
                            if (tempAdapter != null)
                            {
                                fieldInfo = tempAdapter.GetType().GetField("_control", BindingFlags.NonPublic | BindingFlags.Instance);
                                if (fieldInfo != null)
                                {
                                    fieldInfo.SetValue(tempAdapter, _control);
                                }
                            }
                        }

                        methodInfo.Invoke(_control, parameters);
                    }
                }
                else
                {
                    if (!CSSFriendly.Context.Enabled)
                    {
                        _control.RenderControl(htmlWriter);
                    }
                    else
                    {
                        parameters[0] = htmlWriter;
                        parameters[1] = null;

                        methodInfo.Invoke(_control, parameters);
                    }
                }

                html = stringWriter.ToString();
            }
            catch
            {
                if (!_handleExceptions)
                {
                    throw;
                }
            }
            finally
            {
                WebControlAdapterExtender.RestoreProblemChildren(stashedControls);
            }

            return html;
        }
    }
}
