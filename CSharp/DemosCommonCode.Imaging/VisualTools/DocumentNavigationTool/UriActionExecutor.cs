﻿using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Metadata;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Represents an executor of "URI" actions that opens URL using the default internet browser.
    /// </summary>
    public class UriActionExecutor : IPageContentActionExecutor
    {

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="viewer">Image viewer.</param>
        /// <param name="image">Instance of <see cref="VintasoftImage"/> on wich action will be executed.</param>
        /// <param name="action">The action.</param>
        /// <returns><b>True</b> if action is executed; otherwise, <b>false</b>.</returns>
        public bool ExecuteAction(ImageViewer viewer, VintasoftImage image, PageContentActionMetadata action)
        {
            UriActionMetadata uriAction = action as UriActionMetadata;
            if (uriAction != null)
            {
                if (uriAction.Uri != null)
                {
                    if (MessageBox.Show(string.Format("Open URL '{0}' ?", uriAction.Uri), "Open URL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            DemosTools.OpenBrowser(uriAction.Uri.ToString());
                        }
                        catch (Exception exc)
                        {
                            DemosTools.ShowErrorMessage(exc);
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

    }
}
